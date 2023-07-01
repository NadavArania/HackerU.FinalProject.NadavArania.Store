import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../services/product.service';
import { UserService } from '../../../services/user.service';
import { ValidationService } from '../../../services/validation.service';

@Component({
  selector: 'app-casual-products',
  templateUrl: './casual-products.component.html',
  styleUrls: ['./casual-products.component.css']
})
export class CasualProductsComponent implements OnInit {

  crangeValue: any;
  cMaxValue: any;
  cMinValue: any;
  Cat: any = ["Other"];
  DCat: any[] = [];
  highTrue: boolean = false;
  lowTrue: boolean = false;
  aToZ: boolean = false;
  zToA: boolean = false;

  constructor(public service: ProductService, public user: UserService, public vali: ValidationService, private router: Router) { }

  ngOnInit(): void {
    this.vali.addFailed = false;
    this.vali.alert = false;
    this.DCat = this.service.chooseCatCasualToService();
    this.priceRangeBar();
  }


  //Handle Sorting By Price

  sortByLowestFromService() {
    this.service.sortByLowest(this.DCat);
  }

  sortByHighestFromService() {
    this.service.sortByHighest(this.DCat);
  }

  //Handle Sorting By Name

  sortByNameAsceFromService() {
    this.service.sortByNameAsce(this.DCat);
  }

  sortByNameDescFromService() {
    this.service.sortByNameDesc(this.DCat);
  }

  //Handle Price Rangebar

  priceRangeBar() {
    this.DCat.sort((a: any, b: any) => a.price - b.price);
    this.crangeValue = Math.max(...this.DCat.map((x: any) => x.price));
    this.cMaxValue = Math.max(...this.DCat.map((x: any) => x.price));
    this.cMinValue = Math.min(...this.DCat.map((x: any) => x.price));
  }

  //Handle If User Want To Go To Cart Or Keep Shopping
  stayOrGo() {
    this.router.navigate(['cart']);
  }

}
