import { IWorker } from './IWorker';

export class Worker implements IWorker {
    IdWorker: number;
    Name: string;
    Surname: String;
    Age: number;
    Payment: number;
    Office: string;
    Pesel: number;
    constructor(Name: string, Surname: String, Age: number, Payment: number, Office: string, Pesel: number) {
        this.Name = Name;
        this.Surname = Surname;
        this.Age = Age;
        this.Payment = Payment;
        this.Office = Office;
        this.Pesel = Pesel;
    }
}
