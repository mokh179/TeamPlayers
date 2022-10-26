import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PlayerDTO } from './../DTOs/player-dto';
@Injectable({
  providedIn: 'root'
})
export class PlayerServiceService {

  constructor(private http:HttpClient) { }

  GetAll(){
    return this.http.get<PlayerDTO[]>('https://localhost:7086/api/Player');
  }

  addPlayer(player:PlayerDTO){
    return this.http.post("https://localhost:7086/api/Departments/AddDepartment",player)
  }
getbyID(id:number){
  return this.http.get<PlayerDTO>("https://localhost:7086/api/Departments/Department/"+id)
}
edit(player:PlayerDTO){
return this.http.put("https://localhost:7086/api/Departments/EditDepartment/",player)
}
deletePlayer(player:PlayerDTO){
  return this.http.post("https://localhost:7086/api/Departments/Remove",player)

}
 
}
