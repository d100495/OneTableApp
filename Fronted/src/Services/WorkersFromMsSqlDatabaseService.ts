import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs/Observable';
import { IWorker } from '../Models/IWorker';

@Injectable()
export class WorkersFromMsSqlDatabaseService {
    private urlApi = `http://localhost:63271/api/Workers`;
    constructor(private httpClient: HttpClient) { }
    

    public getAll(): Observable<IWorker[]> {
        return this.httpClient.get<IWorker[]>(this.urlApi);
    }

    public Delete(id: number): Observable<IWorker>{
        const url = `${this.urlApi}/${id}`;
        return this.httpClient.delete<IWorker>(url);
    }
}