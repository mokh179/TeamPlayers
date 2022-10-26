import { Component, OnInit } from '@angular/core';
import { PlayerDTO } from 'src/app/DTOs/player-dto';
import { PlayerServiceService } from 'src/app/Services/player-service.service';
import { ActivatedRoute,Router } from '@angular/router';
@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css']
})
export class EditPlayerComponent implements OnInit {

  constructor(private playerService:PlayerServiceService,private ac:ActivatedRoute,private router:Router) { }
   player:PlayerDTO=new PlayerDTO();
  ngOnInit(): void {
    this.ac.params.subscribe(i=>{
      this.playerService.getbyID(i.id).subscribe(a=>{
        this.player=a;
      })
    })
  }
  
  Save(){
    this.playerService.edit(this.player).subscribe(a=>{this.router.navigateByUrl('/Players')});
  }
}
