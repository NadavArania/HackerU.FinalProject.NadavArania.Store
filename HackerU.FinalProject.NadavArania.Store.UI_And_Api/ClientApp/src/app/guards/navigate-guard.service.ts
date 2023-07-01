import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root'
})
export class NavigateGuardService implements CanActivate {


  constructor(private service: UserService, private router: Router, private http: HttpClient) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    return this.haveAuth();
  }

  //Handle Check If User Is Authorize For Navigation

  haveAuth() {
    return this.http.get(this.service.url + `users`).pipe(map(
      ((result: any) => {
        var user = result.find((x: any) => x.logged == true);
        if (user != undefined && user.logged) {
          return true;
        }
        else {
          this.router.navigate(['home']);
          return false;
        }
      }
    )));
  }
}
