import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserRegistration } from '../models/user.registration';
import { TokenService } from './core/token.service';
import { LoginInfo } from '../models/loginInfo.model';
import { UserLoginModel } from '../models/userLogin.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
    private tokenService: TokenService) { }

  public register(userRegistration: UserRegistration): Observable<any> {
    return this.http.post<any>(`${environment.serveces.AuthServerUrl}api/authenticate/register`, userRegistration, { headers: this.setHeaders() })
      .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
  }

  public login(user: UserLoginModel): Observable<LoginInfo> {
    return this.http.post<any>(`${environment.serveces.AuthServerUrl}api/authenticate/login`, JSON.stringify(user), { headers: this.setHeaders() })
      .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
  }

  public getMe(): Observable<string> {
    return this.http.get(`${environment.serveces.AuthServerUrl}api/Auth`, { responseType: 'text' })
      .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
  }

  private setHeaders(): HttpHeaders {
    const headersConfig = {
      'Content-Type': 'application/json',
      Accept: 'application/json',

    };
    return new HttpHeaders(headersConfig);
  }

  private formatErrors(error: HttpErrorResponse): Observable<never> {
    // TODO: handle api service level errors
    return throwError(() => error);
  }
}
