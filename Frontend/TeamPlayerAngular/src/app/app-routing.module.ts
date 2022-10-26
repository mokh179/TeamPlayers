import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreatePlayerComponent } from './Home/create-player/create-player.component';
import { EditPlayerComponent } from './Home/edit-player/edit-player.component';
import { GetPlayerComponent } from './Home/get-player/get-player.component';
import { IndexComponent } from './Home/index/index.component';
import { DeletePlayerComponent } from './Home/delete-player/delete-player.component';


const routes: Routes = [
  {path:"Players",component:IndexComponent},
  {path:"",redirectTo:"Players",pathMatch:'full'},
  {path:"Add",component:CreatePlayerComponent },
  {path:"Player/details/:id",component:GetPlayerComponent},
  {path:"Player/edit/:id",component:EditPlayerComponent},
  {path:"Player/Delete/:id",component:DeletePlayerComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
exports: [RouterModule]
})
export class AppRoutingModule { }
