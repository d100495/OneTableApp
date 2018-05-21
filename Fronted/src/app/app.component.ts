import { Component, OnInit } from '@angular/core';
import { WorkersFromMsSqlDatabaseService } from '../Services/WorkersFromMsSqlDatabaseService';
import { IWorker } from '../Models/IWorker';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  workers: IWorker[];
  model: IWorker;
  add = false;
  clickedId: number;
  constructor(private msSqlHttpClient: WorkersFromMsSqlDatabaseService) { }

  ngOnInit(): void {
    this.GetAll();
  }

  OnSubmit(value: boolean) {
    this.add = value;
    this.GetAll();
  }
  OnClick(id: number) {
    this.clickedId = id;
    this.model = this.workers.find(x => x.IdWorker === id);
  }

  Toggle() {
    this.add = !this.add;
  }
  GetAll() {
    this.msSqlHttpClient.getAll().subscribe(response => this.workers = response);
  }

  Delete() {
    this.msSqlHttpClient.Delete(this.clickedId).subscribe();
    this.GetAll();
  }


  ChangeDatabaseToBrighstar() {
    this.msSqlHttpClient.urlAPi = 'BrightstarWorkers';
    this.GetAll();
    console.log(this.workers);
  }

  ChangeDatabaseToSql() {
    this.msSqlHttpClient.urlAPi = 'Workers';
    this.GetAll();
  }
}
