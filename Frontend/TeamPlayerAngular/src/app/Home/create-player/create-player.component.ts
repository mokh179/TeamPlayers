import { Component, OnInit } from '@angular/core';
import { PlayerDTO } from 'src/app/DTOs/player-dto';
import { PlayerServiceService } from 'src/app/Services/player-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-player',
  templateUrl: './create-player.component.html',
  styleUrls: ['./create-player.component.css']
})
export class CreatePlayerComponent implements OnInit {

  constructor(private playerService:PlayerServiceService,private router:Router) { }
  player:PlayerDTO=new PlayerDTO();
  ngOnInit(): void {

  }
  Save(){
    this.playerService.addPlayer(this.player).subscribe(a=>{this.router.navigateByUrl('/Players')});
    console.log(this.player);
  }
}
