import { Component, OnInit } from '@angular/core';
import { tick } from '@angular/core/testing';
import { FormControl } from '@angular/forms';
import { Patient } from '../../models/patient';
import { PatientService } from '../../services/patient-service';

@Component({
  selector: 'app-patient-add',
  templateUrl: './patient-add.component.html',
  styleUrls: ['./patient-add.component.css']
})
export class PatientAddComponent implements OnInit {

  public identityNumber: string;
  constructor(private patientService: PatientService) { }

  ngOnInit() {

  }

  public addPatient() {
    this.patientService.insertPatient(
      {
        identityNumber: this.identityNumber
      }
    ).subscribe(data => {

    }, error => {
    });
    
  }

}
