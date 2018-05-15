import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { WorkersFromMsSqlDatabaseService } from '../Services/WorkersFromMsSqlDatabaseService';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule
  ],
  providers: [WorkersFromMsSqlDatabaseService],
  bootstrap: [AppComponent]
})
export class AppModule { }
