import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TeamDTO } from './../DTOs/team-dto';
@Injectable({
  providedIn: 'root'
})
export class TeamServiceService {

  constructor(private http:HttpClient) { }
  GetAll(){
    return this.http.get<TeamDTO[]>('https://localhost:7086/api/Team');
  }

  addPlayer(team:TeamDTO){
    return this.http.post("https://localhost:7086/api/Team/AddTeam",team)
  }
getbyID(id:number){
  return this.http.get<TeamDTO>("https://localhost:7086/api/Team/getteam"+id)
}
edit(team:TeamDTO){
return this.http.put("https://localhost:7086/api/Team/EditPlayer",team)
}
deletePlayer(team:TeamDTO){
  return this.http.post("https://localhost:7086/api/api/Team/Deleteteam",team)
}
}
