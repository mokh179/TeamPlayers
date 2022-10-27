import { Component, OnInit } from '@angular/core';
import { PlayerDTO } from 'src/app/DTOs/player-dto';
import { PlayerServiceService } from 'src/app/Services/player-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TeamServiceService } from 'src/app/Services/team-service.service';
import { CountryServiceService } from './../../Services/country-service.service';
import { TeamDTO } from 'src/app/DTOs/team-dto';
import { CountyryDTO } from './../../DTOs/countyry-dto';
@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css'],
})
export class EditPlayerComponent implements OnInit {
  constructor(
    private countryservice: CountryServiceService,
    private teamservice: TeamServiceService,
    private playerService: PlayerServiceService,
    private ac: ActivatedRoute,
    private router: Router
  ) {}
  player: PlayerDTO = new PlayerDTO();
  Teams: TeamDTO[] = [];
  Countries: CountyryDTO[] = [];
  ngOnInit(): void {
    this.ac.params.subscribe((i) => {
      this.playerService.getbyID(i.id).subscribe((a) => {
        this.player = a;
      });
    });
    this.teamservice.GetAll().subscribe((a) => {
      this.Teams = a;
      console.log(this.Teams);
    });
    this.countryservice.GetAll().subscribe((a) => {
      this.Countries = a;
    });
  }

  Save() {
    this.playerService.edit(this.player).subscribe((a) => {
      this.router.navigateByUrl('/Players');
    });
  }
}
