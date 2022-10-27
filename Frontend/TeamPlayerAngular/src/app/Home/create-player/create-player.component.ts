import { Component, OnInit } from '@angular/core';
import { PlayerDTO } from 'src/app/DTOs/player-dto';
import { PlayerServiceService } from 'src/app/Services/player-service.service';
import { Router } from '@angular/router';
import { TeamDTO } from 'src/app/DTOs/team-dto';
import { TeamServiceService } from './../../Services/team-service.service';
import { CountyryDTO } from './../../DTOs/countyry-dto';
import { CountryServiceService } from './../../Services/country-service.service';

@Component({
  selector: 'app-create-player',
  templateUrl: './create-player.component.html',
  styleUrls: ['./create-player.component.css']
})
export class CreatePlayerComponent implements OnInit {

  constructor(private countryservice:CountryServiceService,private teamservice:TeamServiceService ,private playerService:PlayerServiceService,private router:Router) { }
  player:PlayerDTO=new PlayerDTO();
  Teams:TeamDTO[]=[]
  Countries:CountyryDTO[]=[]
  ngOnInit(): void {
    this.teamservice.GetAll().subscribe(a=>{

      this.Teams=a;
      console.log(this.Teams)
   })
   this.countryservice.GetAll().subscribe(a=>{
    this.Countries=a;
 })
  }
  Save(){
    console.log(this.player);
    this.playerService.addPlayer(this.player).subscribe(a=>{this.router.navigateByUrl('/Players')});
    console.log(this.player);
  }
}
