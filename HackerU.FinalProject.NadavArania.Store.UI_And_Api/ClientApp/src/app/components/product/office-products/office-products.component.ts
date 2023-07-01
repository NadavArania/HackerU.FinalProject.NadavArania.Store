import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../services/product.service';
import { UserService } from '../../../services/user.service';
import { ValidationService } from '../../../services/validation.service';

@Component({
  selector: 'app-office-products',
  templateUrl: './office-products.component.html',
  styleUrls: ['./office-products.component.css']
})
export class OfficeProductsComponent implements OnInit {

  orangeValue: any;
  oMinValue: any;
  oMaxValue: any;
  Cat: any[] = ["Chair", "Desk","None"];
  DCat: any[] = [];
  oCat: any[] = [];
  selectedValue: string = "None";
  highTrue: boolean = false;
  lowTrue: boolean = false;
  aToZ: boolean = false;
  zToA: boolean = false;

  constructor(public service: ProductService, public user: UserService, public vali: ValidationService, private router: Router) { }

  ngOnInit(): void {
    this.vali.addFailed = false;
    this.vali.alert = false;
    this.DCat = this.service.chooseCatOfficeToService(6);
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
    this.orangeValue = Math.max(...this.DCat.map((x: any) => x.price));
    this.oMaxValue = Math.max(...this.DCat.map((x: any) => x.price));
    this.oMinValue = Math.min(...this.DCat.map((x: any) => x.price));
  }

  //Handle Choosing Category 

  chooseCatToService(id: number) {
    this.DCat = this.service.chooseCatOfficeToService(id);
    this.DCat.sort((a: any, b: any) => a.price - b.price);
    if (id == 6) {
      this.orangeValue = Math.max(...this.DCat.map((x: any) => x.price));
    }
    else {
      this.orangeValue = Math.max(...this.DCat.map((x: any) => x.price));
      this.oMaxValue = Math.max(...this.DCat.map((x: any) => x.price));
      this.oMinValue = Math.min(...this.DCat.map((x: any) => x.price));
    }
  }

  //Handle If User Want To Go To Cart Or Keep Shopping
  stayOrGo() {
    this.router.navigate(['cart']);
  }

}
