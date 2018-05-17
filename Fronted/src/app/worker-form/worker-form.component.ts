import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { Worker } from '../../Models/Worker';
import { WorkersFromMsSqlDatabaseService } from '../../Services/WorkersFromMsSqlDatabaseService';
@Component({
  selector: 'app-worker-form',
  templateUrl: './worker-form.component.html',
  styleUrls: ['./worker-form.component.css']
})
export class WorkerFormComponent implements OnInit {
  workerForm: FormGroup;
  

  constructor(private formBuilder: FormBuilder, private msSqlHttpClient: WorkersFromMsSqlDatabaseService) {
    this.createForm();
  }

  ngOnInit() {
  }

  createForm() {
    this.workerForm = this.formBuilder.group({
      name: '',
      surname: '',
      age: '',
      payment: '',
      office: '',
      pesel: ''
    });
  }

  AddWorker() {
    let worker = new Worker(this.workerForm.value.name, this.workerForm.value.surname, this.workerForm.value.age,
      this.workerForm.value.payment, this.workerForm.value.office, this.workerForm.value.pesel);
    console.log(worker);
    this.msSqlHttpClient.Add(worker).subscribe();
    this.RebuildForm();
  }

  RebuildForm() {
    this.workerForm.reset({
      name: '',
      surname: '',
      age: '',
      payment: '',
      office: '',
      pesel: ''
    });
  }
}
