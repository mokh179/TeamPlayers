import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreatePlayerComponent } from './Home/create-player/create-player.component';
import { EditPlayerComponent } from './Home/edit-player/edit-player.component';
import { GetPlayerComponent } from './Home/get-player/get-player.component';
import { IndexComponent } from './Home/index/index.component';
import { DeletePlayerComponent } from './Home/delete-player/delete-player.component';
import { LoginComponent } from './Account/login/login.component';
import { LoginGuardGuard } from './_Guard/login-guard.guard';
import { AdminGuard } from './_Guard/admin.guard';
const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"Players",component:IndexComponent,canActivate:[LoginGuardGuard]},
   {path:"",redirectTo:"Players",pathMatch:'full',canActivate:[LoginGuardGuard]},
  {path:"Add",component:CreatePlayerComponent ,canActivate:[LoginGuardGuard]},
  {path:"Player/details/:id",component:GetPlayerComponent,canActivate:[AdminGuard]},
  {path:"Player/edit/:id",component:EditPlayerComponent,canActivate:[LoginGuardGuard]},
  {path:"Player/Delete/:id",component:DeletePlayerComponent,canActivate:[LoginGuardGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
exports: [RouterModule]
})
export class AppRoutingModule { }
