import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UUID } from 'angular2-uuid';
import { MessageService } from 'primeng/api';
import { UserRegistration } from 'src/app/shared/models/user.registration';
import { EvaluatorService } from 'src/app/shared/services/api/estimator.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  success: boolean;
  error: string;
  userRegistration: UserRegistration;
  submitted: boolean = false;

  constructor(
    private authService: AuthService,
    private estimatorService: EvaluatorService,
    private messageService: MessageService,
    private router: Router) { }

  ngOnInit() {
    this.userRegistration = new UserRegistration();
  }

  onSubmit() {
    this.authService.register(
      {
        username: this.userRegistration.username,
        email: this.userRegistration.email,
        password: this.userRegistration.password
      }).subscribe(
        (result) => {
          this.estimatorService.single.create(
            {

              id: UUID.UUID(),
              userId: result,
              firstName: this.userRegistration.firstName,
              lastName: this.userRegistration.lastName,
              phone: this.userRegistration.phoneNumber,
              email: this.userRegistration.email
            }).subscribe(
              () => {
                this.router.navigate(['/auth/login']);
              },
              error => {
                this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
              });
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        });
  }
}
