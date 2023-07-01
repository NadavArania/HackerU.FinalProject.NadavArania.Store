import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { ValidationService } from '../../services/validation.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: any;

  constructor(public service: UserService, private router: Router, public vali: ValidationService) { }

  //Shortcut for form values

  get email() { return this.loginForm.get('email'); }
  get password() { return this.loginForm.get('password'); }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.pattern(this.vali.emailRegex)]),
      password: new FormControl('', [Validators.required, Validators.pattern(this.vali.passwordRegex)])
    });
    this.vali.alert = false;
    this.vali.logFailed = false;
  }

  //Handle submit button in form

  onSubmit() {
    if (this.loginForm.valid) {
      this.service.loginUser(this.email?.value, this.password?.value);
        this.vali.logFailed = false;
        this.vali.alert = true;
        this.loginForm.setValue({
          email: '',
          password: ''
        });
      setTimeout(() => {
        if (this.service.isLogged) { this.router.navigate(['home']) } else {
          this.vali.alert = false;
          this.vali.logFailed = true; } }, 5000);
    }
    else {
      this.vali.alert = false;
      this.vali.logFailed = true;
    }
  }
}
