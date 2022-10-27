import { Component, OnInit } from '@angular/core';
import { PlayerDTO } from 'src/app/DTOs/player-dto';
import { PlayerServiceService } from 'src/app/Services/player-service.service';
import { Router } from '@angular/router';
import { TeamDTO } from 'src/app/DTOs/team-dto';
import { TeamServiceService } from './../../Services/team-service.service';

@Component({
  selector: 'app-create-player',
  templateUrl: './create-player.component.html',
  styleUrls: ['./create-player.component.css']
})
export class CreatePlayerComponent implements OnInit {

  constructor(private teamservice:TeamServiceService ,private playerService:PlayerServiceService,private router:Router) { }
  player:PlayerDTO=new PlayerDTO();
  Teams:TeamDTO[]=[]
  ngOnInit(): void {
    this.teamservice.GetAll().subscribe(a=>{
      this.Teams=a;
   })
  }
  Save(){
    this.playerService.addPlayer(this.player).subscribe(a=>{this.router.navigateByUrl('/Players')});
    console.log(this.player);
  }
}
