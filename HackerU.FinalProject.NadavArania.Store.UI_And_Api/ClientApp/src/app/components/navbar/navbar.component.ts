import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  enteredValue: string = '';
  productsOptions: any[] = [];
  selectCategory: boolean = false;

  constructor(public service: ProductService, public user: UserService, private router: Router) { }

  ngOnInit(): void {
  }

  //Handle loggout button

  logout() {
    this.user.loggedOutUser();
    this.router.navigate(['home']);
  }

  //Handle Search Item In Navbar

  dataFilter(value: string) {
    this.productsOptions = this.service.data.filter((x: any) => x.name.toLowerCase().startsWith(value.toLowerCase()));
  }

  goToSelectedProduct(id: number) {
    if (id > 0) {
      setTimeout(() => { this.router.navigate([`single-product/${id}`]); }, 1000);
      this.enteredValue = '';
    }
  }

  productSelected() {
    if (!this.selectCategory) {
      this.selectCategory = true;
    }
    else {
      this.selectCategory = false;
    }
  }

}
