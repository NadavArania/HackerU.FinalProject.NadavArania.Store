import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  url: string = "";
  data: any;
  loggedUser: any;
  x: any;
  ordersNumberHistory: any;
  fullHistory: any;
  isLogged: boolean = false;
  allUsers: any;
 

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.url = baseUrl;
    this.fetchUsersFromDb();
    this.fetchAllUsers();
  }

  //Fetching Logged User Details

  fetchUsersFromDb():any {
    this.http.get(this.url + `users`).subscribe(x => {
      this.data = x;
      this.data.forEach((y: any) => {
        if (y.logged == true) {
          this.loggedUser = y;
          this.isLogged = this.loggedUser.logged;
          this.fetchNumberOfOrderPerUser();
          this.fetchFullHistoryPerUser(this.loggedUser.id);
        }
      })
    })
  }

  //Fetching Order Details Per User

  fetchNumberOfOrderPerUser() {
    this.http.get(this.url + `users/numberOfOrderByUserId?id=${this.loggedUser.id}`).subscribe(x => {
      this.ordersNumberHistory = x;
    })
  }

  fetchFullHistoryPerUser(id: number) {
    this.http.get(this.url + `users/getUserFullOrderHistory?id=${id}`).subscribe(x => {
      this.fullHistory = x;
      this.fetchAllUsers();
    })
  }

  //Fetching All Users Details

  fetchAllUsers() {
    this.http.get(this.url + `users/allUsers`).subscribe(x => {
      this.allUsers = x;
    })
  }

  //Handle Editing Profile Details

  editProfileDetails(id:number,email: string, password: string, phone: string, city: string, address: string) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      body: {}
    } 
    this.http.put(this.url + `users?id=${id}&email=${email}&password=${password}&phone=${phone}&city=${city}&address=${address}`, options).subscribe(x => {
      x;
      this.fetchUsersFromDb();
      this.fetchAllUsers();
    })
  }

  //Handle Registration Of New User

  registerUser(email: string, password: string, phone: string, city: string, address: string) {
    if (email && password && phone && city && address) {
      this.http.post(this.url + `users?email=${email}&password=${password}&phone=${phone}&city=${city}&address=${address}`, null).subscribe(x => {
        x;
        this.fetchUsersFromDb();
      })
    }
  }

  //Handle Login And Logout Of Register User

  loginUser(email: string, password: string) {
    if (email && password) {
      this.http.post(this.url + `users/login?email=${email}&password=${password}`, null).subscribe(x => {
        x;
        this.fetchUsersFromDb();
      })
    }
  }

  loggedOutUser() {
    this.http.post(this.url + `users/logout`, null).subscribe(x => {
      x;
      this.isLogged = false;
      this.fetchUsersFromDb();
    })
  }

  //Handle Deleting User From DB By Admin

  deleteUserFromDb(id: any) {
    this.http.delete(this.url + `users?id=${id}`).subscribe(x => {
      x;
      this.fetchAllUsers();
    })
  }
}
