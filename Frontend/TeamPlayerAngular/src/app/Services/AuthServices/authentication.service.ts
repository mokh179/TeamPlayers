import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginDTO } from './../../DTOs/AuthenticateDTOs/login-dto';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http:HttpClient) { }
  LogIN(credentials:LoginDTO){
      return this.http.post('https://localhost:7086/api/Account/Login',credentials);
  }
}
