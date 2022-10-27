import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './Home/index/index.component';
import { CreatePlayerComponent } from './Home/create-player/create-player.component';
import { EditPlayerComponent } from './Home/edit-player/edit-player.component';
import { GetPlayerComponent } from './Home/get-player/get-player.component';
import { DeletePlayerComponent } from './Home/delete-player/delete-player.component';
import { LoginComponent } from './Account/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    CreatePlayerComponent,
    EditPlayerComponent,
    GetPlayerComponent,
    DeletePlayerComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
