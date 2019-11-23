import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { DxTextBoxModule } from  'devextreme-angular';
import { DxButtonModule } from 'devextreme-angular';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    DxButtonModule,
    DxTextBoxModule,
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
