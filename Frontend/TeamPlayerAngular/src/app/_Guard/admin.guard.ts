import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate,Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const token = sessionStorage.getItem("jwt") as string;
      const Role = sessionStorage.getItem("Role") as string;
      if(token==null){
        this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
        return false;
      }
      if(Role!="User"){

        return true;
      }
        else{
          //this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
          this.router.navigateByUrl('/login');
          alert("UnAuthorized");
          return false;
        }
  }
  constructor(private router: Router){}
}
