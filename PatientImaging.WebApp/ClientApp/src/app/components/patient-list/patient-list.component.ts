import { Component, OnInit } from '@angular/core';
import { Patient } from '../../models/patient';
import { MessageService } from '../../services/message.service';
import { PatientService } from '../../services/patient-service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {
  public patientList: Patient[];
  constructor(private patientService: PatientService, private messageService: MessageService) { }

  ngOnInit() {
    this.messageService.patientReceived.subscribe((patient) => {
      if (this.patientList)
        this.patientList.push(patient);
    });

    this.patientService.getAllPatients().subscribe((data) => {
      this.patientList = data;
    }, error => {
        console.log(error);
    });


  }

}
