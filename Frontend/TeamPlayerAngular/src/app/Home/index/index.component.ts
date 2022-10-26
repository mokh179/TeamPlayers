import { Component, OnInit } from '@angular/core';
import { PlayerServiceService } from 'src/app/Services/player-service.service';
import { PlayerDTO } from 'src/app/DTOs/player-dto';
@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  constructor(private playerService:PlayerServiceService) { }
  Players:PlayerDTO[]=[]
  ngOnInit(): void {
    this.playerService.GetAll().subscribe(a=>
      {
        this.Players=a
        console.log(this.Players)
      }
      )
  }

}
