import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { WorkersFromMsSqlDatabaseService } from '../Services/WorkersFromMsSqlDatabaseService';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { WorkerFormComponent } from './worker-form/worker-form.component';


@NgModule({
  declarations: [
    AppComponent,
    WorkerFormComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [WorkersFromMsSqlDatabaseService],
  bootstrap: [AppComponent]
})
export class AppModule { }
