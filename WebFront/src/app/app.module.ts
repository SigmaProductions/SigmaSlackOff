import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DxTextBoxModule } from  'devextreme-angular';
import { DxButtonModule } from 'devextreme-angular';
import { DxDataGridModule } from 'devextreme-angular';
import { DxListModule} from 'devextreme-angular';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LobbiesComponent } from './lobbies/lobbies.component';
import { DataService } from './lobbies/data.service';
import { CoolthanksComponent } from './coolthanks/coolthanks.component';
import { HttpClient, HttpHandler, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule} from '@angular/material/table';

const appRoutes: Routes = [
  {
    path: '',
    component: LoginComponent,
    data: { title: 'login component' }
  },
  {
    path: 'test',
    component: LobbiesComponent,
    data: { title: 'lobbies component' }
  },
  {
    path: "cool",
    component: CoolthanksComponent,
    data: {title: 'cool thaanks'}
  }
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LobbiesComponent,
    CoolthanksComponent

  ],
  imports: [
     RouterModule.forRoot(
      appRoutes,
      {  } // <-- debugging purposes only
    ),
    DxButtonModule,
    DxTextBoxModule,
    HttpClientModule,
    DxListModule,
    DxDataGridModule,
    MatTableModule,
    BrowserModule,
    BrowserAnimationsModule
  ],
  providers: [DataService, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
