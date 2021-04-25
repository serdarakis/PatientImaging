import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Patient } from '../models/patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  private readonly _baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public getAllPatients(): Observable<Patient[]>{
    return this.http.get<Patient[]>(this._baseUrl + "patient/list");
  }

  public insertPatient(patient: Patient): Observable<Object> {
    return this.http.post(this._baseUrl + "patient", patient);
  }
}


