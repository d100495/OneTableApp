import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/Observable';
import { IWorker } from '../Models/IWorker';
import { Worker } from '../Models/Worker';

@Injectable()
export class WorkersFromMsSqlDatabaseService {
    private _urlApi = `http://localhost:63271/api/Workers`;
    
    constructor(private httpClient: HttpClient) { }

    public set urlAPi(type: string) {
        this._urlApi = `http://localhost:63271/api/${type}`;
    }
    public getAll(): Observable<IWorker[]> {
        return this.httpClient.get<IWorker[]>(this._urlApi);
    }

    public Delete(id: number): Observable<IWorker> {
        const url = `${this._urlApi}/${id}`;
        return this.httpClient.delete<IWorker>(url);
    }

    public Add(model: Worker) {
        return this.httpClient.post(this._urlApi, model);
    }

    public Update(model: Worker, id: number) {
        const url = `${this._urlApi}/${id}`;
        return this.httpClient.put(url, model);
    }
}