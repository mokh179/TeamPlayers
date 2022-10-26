import { Component, OnInit } from '@angular/core';
import { PlayerDTO } from 'src/app/DTOs/player-dto';
import { PlayerServiceService } from 'src/app/Services/player-service.service';
import { ActivatedRoute,Router } from '@angular/router';

@Component({
  selector: 'app-delete-player',
  templateUrl: './delete-player.component.html',
  styleUrls: ['./delete-player.component.css']
})
export class DeletePlayerComponent implements OnInit {

  player:PlayerDTO=new PlayerDTO();
  constructor(private playerService:PlayerServiceService,private ac:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.ac.params.subscribe(i=>{
      this.playerService.getbyID(i.id).subscribe(a=>{
        this.player=a;
      })
    })
  }
 
  delete(){
    this.playerService.deletePlayer(this.player).subscribe(
      a=>{this.router.navigateByUrl('/Players')}
    );
  }
}
