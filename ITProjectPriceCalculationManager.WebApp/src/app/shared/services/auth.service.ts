import { Injectable } from '@angular/core';
import { UserManager, User, UserManagerSettings, WebStorageStateStore } from 'oidc-client';
import { Observable, Subject, catchError, throwError } from 'rxjs';
import { CookieStorage } from 'cookie-storage';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './api/config.service';
import { BaseService } from './core/base.service';
import { ServiceType } from './core/serviceType';
import { UserModel } from '../models/user.model';
import { ClientConfigurationService } from './core/client-configuration.service';
import { HttpService } from './core/http.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService<any>  {
  private _userManager: UserManager;
  // @ts-ignore
  private _user: User;
  private _loginChangedSubject = new Subject<boolean>();
  public loginChanged = this._loginChangedSubject.asObservable();

  private get idpSettings() : UserManagerSettings {
    return {
      authority: "https://localhost:5007",
      client_id: "angular",
      redirect_uri: `${location.origin}/SignInCallback`,
      scope: "openid profile unitsAPI IdentityServerApi attachmentsAPI",
      response_type: "code",
      post_logout_redirect_uri: `${location.origin}/SignOutCallback`,
      stateStore: new WebStorageStateStore({ store: new CookieStorage() }),
      userStore: new WebStorageStateStore({ store: new CookieStorage() })
    }
  }
  constructor(httpService: HttpService, configService: ClientConfigurationService) {
    super(httpService, 'commander', configService, UserModel, ServiceType.identity)
    this._userManager = new UserManager(this.idpSettings);
  }

  public login = () => {
    return this._userManager.signinRedirect();
  }

  register(userRegistration: any) {
    return new Observable<Object>; //this.httpService.post(ServiceType.units + '/account', userRegistration).pipe(catchError(this.handleError));
  }

  public finishLogin = (): Promise<User> => {
    return this._userManager.signinRedirectCallback()
    .then(user => {
      this._user = user;
      this._loginChangedSubject.next(this.checkUser(user));
      return user;
    })
  }

  public logout = () => {
    return this._userManager.signoutRedirect({ 'id_token_hint': this._user.id_token });
  }

  public finishLogout = () => {
    // @ts-ignore
    this._user = null;
    return this._userManager.signoutRedirectCallback();
  }

  public getAccessToken = (): Promise<string> => {
    // @ts-ignore
    return this._userManager.getUser()
      .then(user => {
         return !!user && !user.expired ? user.access_token : null;
    })
  }
  public getUserId = (): Promise<string> => {
    // @ts-ignore
    return this._userManager.getUser()
      .then(user => {
        return user?.profile.sub;
      })
  }

  public isAuthenticated = (): Promise<boolean> => {
    return this._userManager.getUser()
    .then(user => {
      if(user)
      {
        if(this._user !== user){
          this._loginChangedSubject.next(this.checkUser(user));
        }
        this._user = user;
        return this.checkUser(user);
      }
      return false;
    })
  }

  public getCurrentUser() {
    return this._user;
  }

  private checkUser = (user : User): boolean => {
    return !!user && !user.expired;
  }

  protected handleError(error: any) {

    var applicationError = error.headers.get('Application-Error');

    // either application-error in header or model error in body
    if (applicationError) {
      return throwError(applicationError);
    }

    var modelStateErrors: string = '';

      // for now just concatenate the error descriptions, alternative we could simply pass the entire error response upstream
      for (var key in error.error) {
        if (error.error[key]) modelStateErrors += error.error[key].description + '\n';
      }

    // modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
    return throwError(modelStateErrors || 'Server error');
  }
}
