import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { Worker } from '../../Models/Worker';
import { WorkersFromMsSqlDatabaseService } from '../../Services/WorkersFromMsSqlDatabaseService';
import { IWorker } from '../../Models/IWorker';
@Component({
  selector: 'app-worker-form',
  templateUrl: './worker-form.component.html',
  styleUrls: ['./worker-form.component.css']
})
export class WorkerFormComponent implements OnInit {
  workerForm: FormGroup;
  @Input() worker: Worker;
  @Output() submit = new EventEmitter<boolean>();

  constructor(private formBuilder: FormBuilder, private msSqlHttpClient: WorkersFromMsSqlDatabaseService) {
  }

  ngOnInit() {
    console.log(this.worker);
    this.createForm();

  }

  createForm() {
    if (this.worker != null) {
      this.workerForm = this.formBuilder.group({
        name: this.worker.Name,
        surname: this.worker.Surname,
        age: this.worker.Age,
        payment: this.worker.Payment,
        office: this.worker.Office,
        pesel: this.worker.Pesel
      });
    } else {
      this.workerForm = this.formBuilder.group({
        name: '',
        surname: '',
        age: '',
        payment: '',
        office: '',
        pesel: ''
      });
    }

  }

  Submit() {
    if (this.worker != null) {
      let model = new Worker(this.workerForm.value.name, this.workerForm.value.surname, this.workerForm.value.age,
        this.workerForm.value.payment, this.workerForm.value.office, this.workerForm.value.pesel);
        model.IdWorker = this.worker.IdWorker;
      this.msSqlHttpClient.Update(model, model.IdWorker).subscribe();
    } else {
      let model = new Worker(this.workerForm.value.name, this.workerForm.value.surname, this.workerForm.value.age,
        this.workerForm.value.payment, this.workerForm.value.office, this.workerForm.value.pesel);
      console.log(model);
      this.msSqlHttpClient.Add(model).subscribe();
      this.submit.emit(false);
      this.RebuildForm();
    }

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
