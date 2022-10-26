import { Component, OnInit } from '@angular/core';
import { PlayerServiceService } from 'src/app/Services/player-service.service';
import { PlayerDTO } from 'src/app/DTOs/player-dto';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-get-player',
  templateUrl: './get-player.component.html',
  styleUrls: ['./get-player.component.css']
})
export class GetPlayerComponent implements OnInit {
   player:PlayerDTO=new PlayerDTO();
  constructor(private playerService:PlayerServiceService,private ac:ActivatedRoute) { }

  ngOnInit(): void {

    this.ac.params.subscribe(i=>{
      this.playerService.getbyID(i.id).subscribe(a=>{
        this.player=a;
      })
    })
  }

}
