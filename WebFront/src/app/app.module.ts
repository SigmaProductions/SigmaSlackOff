import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DxTextBoxModule } from  'devextreme-angular';
import { DxButtonModule } from 'devextreme-angular';
import { DxDataGridModule } from 'devextreme-angular';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LobbiesComponent } from './lobbies/lobbies.component';
import { DataService } from './lobbies/data.service';

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
  }
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LobbiesComponent
  ],
  imports: [
     RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
    DxButtonModule,
    DxTextBoxModule,
    DxDataGridModule,
    BrowserModule
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
