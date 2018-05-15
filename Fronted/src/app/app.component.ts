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
  constructor(private msSqlHttpClient: WorkersFromMsSqlDatabaseService) { }

  ngOnInit(): void {
    this.GetAll();
  }

  GetAll() {
    this.msSqlHttpClient.getAll().subscribe(response => this.workers = response);
  }

  Delete(id: number){
    this.msSqlHttpClient.Delete(id).subscribe();
    this.GetAll();
  }
}
