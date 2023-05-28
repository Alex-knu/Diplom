import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { UserRegistration } from 'src/app/shared/models/user.registration';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  success: boolean;
  error: string;
  userRegistration: UserRegistration = { username: '', email: '', password: '' };
  submitted: boolean = false;

  constructor(
    private authService: AuthService,
    private messageService: MessageService,
    private router: Router) { }

  ngOnInit() { }

  onSubmit() {
    this.authService.register(this.userRegistration).subscribe(
      () => {
        this.router.navigate(['/auth/login']);
      },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
      });
  }
}
