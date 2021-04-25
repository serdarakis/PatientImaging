import { Component, OnInit } from '@angular/core';
import { tick } from '@angular/core/testing';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { from } from 'rxjs';
import { Patient } from '../../models/patient';
import { PatientService } from '../../services/patient-service';

@Component({
  selector: 'app-patient-add',
  templateUrl: './patient-add.component.html',
  styleUrls: ['./patient-add.component.css']
})
export class PatientAddComponent implements OnInit {
  registerPatientForm: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder, private patientService: PatientService, private router: Router) { }


  ngOnInit() {
    this.registerPatientForm = this.formBuilder.group({
      polyclinicCode: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(4)]],
      docRegistrationNumber: ['', [Validators.required, Validators.pattern("[0-9]{8}")]],
      docName: ['', Validators.required],
      docSurname: ['', Validators.required],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      dateOfBirth: [null, Validators.required],
      gender: [3, Validators.required],
      identityNumber: ['', [Validators.required, Validators.pattern("[0-9]{11}")]],
      phoneNumber: ['', [Validators.required, Validators.pattern("[0-9]{10}")]],
      visitDate: [null, Validators.required],
      nextVisitDate: [null],
      doctorsNote: ['', Validators.maxLength(1000)],
    });
  }

  get f() { return this.registerPatientForm.controls; }



  onSubmit() {
    this.submitted = true;

    if (this.registerPatientForm.invalid) {
      return;
    }
    const form = this.registerPatientForm.value;
    var patient: Patient = {
      identityNumber: form.identityNumber,
      dateOfBirth: form.dateOfBirth,
      doctorNote: form.doctorsNote,
      gender: form.gender,
      nextVisitDate: form.nextVisitDate,
      phoneNumber: form.phoneNumber,
      polyclinicCode: form.polyclinicCode,
      visitDate: form.visitDate,
      doctor: {
        name: form.docName,
        registrationNumber: form.docRegistrationNumber,
        surname: form.docSurname
      }

    }
    this.patientService.insertPatient(patient).subscribe(data => {
      this.router.navigate(["patient"]);
    }, error => {
    });
  }

  onCancel() {
    this.router.navigate(["patient"]);
  }

}


