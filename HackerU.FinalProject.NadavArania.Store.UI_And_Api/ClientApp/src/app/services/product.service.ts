import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { UserService } from './user.service';
import { ValidationService } from './validation.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  url: string = "";
  data: any;
  gaming: any;
  office: any;
  casual: any;
  mouse: any;
  keyboard: any;
  headset: any;
  monitor: any;
  chair: any;
  desk: any;
  other: any;
  productCart: any[] = [];
  totalprice: number = 0;
  bestGaming: any;
  bestOffice: any;
  bestCasual: any;
  quantity: number = 1;
  highTrue: boolean = false;
  lowTrue: boolean = false;
  aToZ: boolean = false;
  zToA: boolean = false;

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string, private user: UserService, public vali: ValidationService) {
    this.url = baseUrl;
    this.fetchProductsFromDb();
  }

  //Fetching Products From DB And Splitting Them To Categories And Sub Categories

  fetchProductsFromDb() {
    this.http.get(this.url + `products`).subscribe(x => {
      this.data = x;
      this.gaming = this.data.filter((x: any) => x.type == 0);
      this.office = this.data.filter((x: any) => x.type == 1);
      this.casual = this.data.filter((x: any) => x.type == 2);
      this.mouse = this.gaming.filter((x: any) => x.category == 0);
      this.keyboard = this.gaming.filter((x: any) => x.category == 1);
      this.headset = this.gaming.filter((x: any) => x.category == 2);
      this.monitor = this.gaming.filter((x: any) => x.category == 3);
      this.chair = this.office.filter((x: any) => x.category == 4);
      this.desk = this.office.filter((x: any) => x.category == 5);
      this.other = this.casual.filter((x: any) => x.category == 6);
      this.gaming.forEach((x: any) => {
        if (x.added) {
          this.productCart.push(x);
        }
      })
      this.office.forEach((x: any) => {
        if (x.added) {
          this.productCart.push(x);
        }
      })
      this.casual.forEach((x: any) => {
        if (x.added) {
          this.productCart.push(x);
        }
      });
      this.updateTotal();
      this.bestGaming = this.gaming.filter((x: any) => x.id == 2);
      this.bestOffice = this.office.filter((x: any) => x.id == 13);
      this.bestCasual = this.casual.filter((x: any) => x.id == 19);

      this.vali.alert = false;
      this.vali.addFailed = false;
    })
  }

  //Handle Adding, Deleting Products From Cart And Also Updating Total Price

  addToCart(item: {
    id: number,
    type:number,
    name: string,
    price: number,
    description: string,
    image: string,
    category: number,
    quantity:number,
    added: boolean
  }) {
    if (!this.productCart.includes(item)) {
      this.http.post(this.url + `products?id=${item.id}`, null).subscribe(x => {
        x;
        this.productCart.push(item);
        this.updateTotal();
        item.added = true;
        this.vali.alert = true;
        this.vali.addFailed = false;
      })
    }
    else if (this.productCart.includes(item) && this.vali.alert) {
      this.vali.alert = false;
      this.vali.addFailed = true;
    }
    else {
        this.productCart.splice(0, this.productCart.length);
      this.updateTotal();
      this.vali.alert = false;
      this.vali.addFailed = false;
    }
  }

  deleteFromCart(item: {
    id: number,
    type: number,
    name: string,
    price: number,
    description: string,
    image: string,
    category: number,
    quantity: number,
    added: boolean
  }) {
    if (this.productCart.includes(item)) {
      this.http.delete(this.url + `products?id=${item.id}`).subscribe(x => {
        x;
        item.added = false;
        let index = this.productCart.indexOf(item);
        this.productCart.splice(index, 1);
        this.totalprice -= item.price * item.quantity;
      });
    }
  }

  updateTotal() {
    if (this.productCart.length == 0) {
      this.totalprice = 0;
    }
    else {
      this.totalprice = 0;
      for (let i = 0; i < this.productCart.length; i++) {
        this.totalprice += this.productCart[i].price * this.productCart[i].quantity;
      }
    }
  }

  //Handle Choosing Category

  chooseCatCasualToService(): any  {
    return this.casual;
  }

  chooseCatGamingToService(id: number) {
    switch (id) {
      case 0:
        return this.mouse;
      case 1:
        return this.keyboard;
      case 2:
        return this.headset;
      case 3:
        return this.monitor;
      default:
        return this.gaming;
    }
  }

  chooseCatOfficeToService(id: number) {
    switch (id) {
      case 4:
        return this.chair;
      case 5:
        return this.desk;
      default:
        return this.office;
    }
  }

  //Handle Finish Order Details

  finishOrder() {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      body: {}
    }

    this.http.post(this.url + `orders?id=${this.user.loggedUser.id}&products=${JSON.stringify(this.productCart)}&total=${this.totalprice}`, options).subscribe(x => {
      x;
      this.productCart.splice(0, this.productCart.length);
      this.updateTotal();
      this.user.fetchUsersFromDb();
    })
  }

  //Handle Deleting Order Or Product From DB By Admin

  deleteOrder(number: string) {
    this.http.delete(this.url + `orders?number=${number}`).subscribe(x => {
      x;
      this.fetchProductsFromDb();
      this.user.fetchAllUsers();
    })
  }

  deleteProductFromDb(id: any) {
    this.http.delete(this.url + `products/deleteProduct?id=${id}`).subscribe(x => {
      x;
      this.fetchProductsFromDb();
    })
  }

  //Handle Editing And Adding Product To DB By Admin

  editProductDetails(id:number,type:number,name:string,price:number,description:string,image:string,category:number) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      body: {}
    }
    this.http.put(this.url + `products?id=${id}&type=${type}&name=${name}&price=${price}&description=${description}&image=${image}&category=${category}`, options).subscribe(x => {
      x;
      this.fetchProductsFromDb();
    })
  }

  addProductToDB(type: number, name: string, price: number, description: string, image: string, category: number) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      body: {}
    }
    this.http.post(this.url + `products/addProduct?type=${type}&name=${name}&price=${price}&description=${description}&image=${image}&category=${category}`, options).subscribe(x => {
      x;
      this.fetchProductsFromDb();
    });
  }

  sortByLowest(list:any) {
    if (!this.lowTrue) {
      this.lowTrue = true;
    }
    else {
      this.lowTrue = false;
    }
    list.sort((a: any, b: any) => a.price - b.price)
  }

  sortByHighest(list:any) {
    if (!this.highTrue) {
      this.highTrue = true;
    }
    else {
      this.highTrue = false;
    }
    list.sort((a: any, b: any) => b.price - a.price)
  }

  //Handle Sorting By Name

  sortByNameAsce(list:any) {
    if (!this.aToZ) {
      this.aToZ = true;
    }
    else {
      this.aToZ = false;
    }
    list.sort((a: any, b: any) => a.name.toLowerCase() > b.name.toLowerCase() ? 1 : -1);
  }

  sortByNameDesc(list:any) {
    if (!this.zToA) {
      this.zToA = true;
    }
    else {
      this.zToA = false;
    }
    list.sort((a: any, b: any) => a.name.toLowerCase() > b.name.toLowerCase() ? 1 : -1).reverse();
  }

}
