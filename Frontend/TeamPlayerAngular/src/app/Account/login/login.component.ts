import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/AuthServices/authentication.service';
import { LoginDTO } from './../../DTOs/AuthenticateDTOs/login-dto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginDTO:LoginDTO=new LoginDTO();
  returnUrl: string="";
  invalidLogin :boolean =false ;
  ExpiredLogin:boolean= false;

  constructor(private authenticate:AuthenticationService,private route: ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  Save(){
    debugger;
    this.authenticate.LogIN(this.loginDTO) .subscribe(response => {
       const token = (<any>response).token;
       const Role = (<any>response).roles;

       sessionStorage.setItem("jwt" , token);
       sessionStorage.setItem("Role" , Role);
       this.invalidLogin=false;
       this.router.navigateByUrl('/Players')
       

       } , err => {
        this.invalidLogin=true;

    })

  }

}
