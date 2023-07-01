import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IDiscardChangesInterface } from '../../guards/discard-changes-guard.service';
import { UserService } from '../../services/user.service';
import { ValidationService } from '../../services/validation.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, IDiscardChangesInterface {

  signupForm: any;

  constructor(public service: UserService, private router: Router, public vali: ValidationService) { }

  get email() { return this.signupForm.get('email'); }
  get password() { return this.signupForm.get('password'); }
  get phone() { return this.signupForm.get('phone'); }
  get city() { return this.signupForm.get('city'); }
  get address() { return this.signupForm.get('address'); }

  //Handle The Discard Guard Navigation

  canExit(): boolean {
    if (this.email.value || this.password.value || this.phone.value || this.city.value || this.address.value) {
      return confirm("Are you sure you want to exit before complete the registration?");
    }
    else {
      return true;
    }
  }

  ngOnInit(): void {
    this.signupForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.pattern(this.vali.emailRegex)]),
      password: new FormControl('', [Validators.required, Validators.pattern(this.vali.passwordRegex)]),
      phone: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
      city: new FormControl('', [Validators.required, Validators.minLength(3)]),
      address: new FormControl('', [Validators.required, Validators.minLength(3)])
    });
    this.vali.alert = false;
    this.vali.regFailed = false;
  }

  //Handle The Submit Of Registration

  onSubmit() {
    if (this.signupForm.valid) {
      this.service.registerUser(this.email?.value, this.password?.value, this.phone?.value, this.city?.value, this.address?.value);
      this.signupForm.setValue({
        email: '',
        password: '',
        phone: '',
        city: '',
        address: ''
      });
      this.vali.regFailed = false;
      this.vali.alert = true;
      setTimeout(() => { this.router.navigate(['login']) }, 5000);
    }
    else {
      this.vali.alert = false;
      this.vali.regFailed = true;
    }
  }
}
