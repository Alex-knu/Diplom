import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { UserModel } from '../../models/user.model';

@Injectable({
  providedIn: 'root'
})

export class TokenService {

  constructor(private cookieService: CookieService) { }

  setUserInfo(info: UserModel) {
    this.cookieService.set('userName', info.UserName)
    this.cookieService.set('userIdentifier', info.UserIdentifier)
    this.cookieService.set('role', info.Role)
  }

  setToken(token: string) {
    this.cookieService.set('token', token);
  }

  getUserName(): string {
    return this.cookieService.get('userName')
  }

  getUserIdentifier(): string {
    return this.cookieService.get('userIdentifier')
  }

  getUserRole(): string {
    return this.cookieService.get('role')
  }

  getToken(): string {
    return this.cookieService.get('token');
  }
}
