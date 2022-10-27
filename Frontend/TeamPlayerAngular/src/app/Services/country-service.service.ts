import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PlayerDTO } from './../DTOs/player-dto';
import { CountyryDTO } from './../DTOs/countyry-dto';

@Injectable({
  providedIn: 'root'
})
export class CountryServiceService {

  constructor(private http:HttpClient) { }
  GetAll(){
    return this.http.get<CountyryDTO[]>('https://localhost:7086/api/Country');
  }
}
