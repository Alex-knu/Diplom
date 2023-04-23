import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators'
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
  userRegistration: UserRegistration = { username: '', email: '', password: ''};
  submitted: boolean = false;

  constructor(private authService: AuthService, private spinner: NgxSpinnerService) {

  }

  ngOnInit() {
  }

  onSubmit() {
    this.authService.register(this.userRegistration).subscribe(() => {
      this.userRegistration.username = "new UserRegistration()";
    });
  }
}
