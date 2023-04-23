import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'oidc-client';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { UserModel } from 'src/app/shared/models/user.model';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styles: [`
        :host ::ng-deep .pi-eye,
        :host ::ng-deep .pi-eye-slash {
            transform:scale(1.6);
            margin-right: 1rem;
            color: var(--primary-color) !important;
        }
    `]
})
export class LoginComponent {

    user: UserModel;

    valCheck: string[] = ['remember'];

    username: string;

    password!: string;

    isUserAuthenticated = false;

    constructor(
        public layoutService: LayoutService,
        public authService: AuthService) {
        }

    ngOnInit(): void { }

    public login(){
        this.authService.login(new UserModel(this.username, this.password)).subscribe(() => {
          this.user = new UserModel();
        });
    }
}
