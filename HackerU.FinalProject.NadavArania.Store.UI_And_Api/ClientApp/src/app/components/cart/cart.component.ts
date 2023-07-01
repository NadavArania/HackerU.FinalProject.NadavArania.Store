import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { UserService } from '../../services/user.service';
import { ValidationService } from '../../services/validation.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(public service: ProductService, private user: UserService, private router: Router, public vali: ValidationService) { }

  ngOnInit(): void {
    this.vali.alert = false;
  }

  //Handle Purchased Button

  finishOrder() {
    if (confirm("Are you sure you want to proceed?")) {
      this.vali.alert = true;
      this.service.finishOrder();
      setTimeout(() => { this.router.navigate(['home']); }, 3000);
    }
    else {
      this.vali.alert = false;
    }
  }

}
