import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../services/product.service';
import { UserService } from '../../../services/user.service';
import { ValidationService } from '../../../services/validation.service';

@Component({
  selector: 'app-single-product',
  templateUrl: './single-product.component.html',
  styleUrls: ['./single-product.component.css']
})
export class SingleProductComponent implements OnInit {

  product: any;
  productId: any;

  constructor(private activatedRoute: ActivatedRoute, public service: ProductService, public vali: ValidationService, private router: Router, public user: UserService) { }

  ngOnInit(): void {
    this.productId = this.activatedRoute.snapshot.paramMap.get('id');
    this.product = this.service.data.find((x: any) => x.id == this.productId);
    this.vali.addFailed = false;
    this.vali.alert = false;
  }

  //Handle If User Want To Go To Cart Or Keep Shopping
  stayOrGo() {
    this.router.navigate(['cart']);
  }
}
