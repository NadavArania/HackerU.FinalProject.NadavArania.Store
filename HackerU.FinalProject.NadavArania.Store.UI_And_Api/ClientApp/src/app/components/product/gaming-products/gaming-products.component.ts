import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../services/product.service';
import { UserService } from '../../../services/user.service';
import { ValidationService } from '../../../services/validation.service';

@Component({
  selector: 'app-gaming-products',
  templateUrl: './gaming-products.component.html',
  styleUrls: ['./gaming-products.component.css']
})
export class GamingProductsComponent implements OnInit {

  grangeValue: any;
  gMaxValue: any;
  gMinValue: any;
  Cat: any[] = ["Mouse", "Keyboard", "Headset", "Monitor","None"];
  DCat: any[] = [];
  gCat: any[] = [];
  selectedValue: string = "None";

  constructor(public service: ProductService, public user: UserService, public vali: ValidationService, private router: Router) { }

  ngOnInit(): void {
    this.vali.addFailed = false;
    this.vali.alert = false;
    this.DCat = this.service.chooseCatGamingToService(4);
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
    this.grangeValue = Math.max(...this.DCat.map((x: any) => x.price));
    this.gMaxValue = Math.max(...this.DCat.map((x: any) => x.price));
    this.gMinValue = Math.min(...this.DCat.map((x: any) => x.price));
  }

  //Handle Choosing Category

  chooseCatToService(id: number) {
    this.DCat = this.service.chooseCatGamingToService(id);
    this.DCat.sort((a: any, b: any) => a.price - b.price);
    if (id == 4) {
      this.grangeValue = Math.max(...this.DCat.map((x: any) => x.price));
    }
    else {
      this.grangeValue = Math.max(...this.DCat.map((x: any) => x.price));
      this.gMaxValue = Math.max(...this.DCat.map((x: any) => x.price));
      this.gMinValue = Math.min(...this.DCat.map((x: any) => x.price));
    }
  }

  //Handle If User Want To Go To Cart Or Keep Shopping
  stayOrGo() {
    this.router.navigate(['cart']);
  }

}
