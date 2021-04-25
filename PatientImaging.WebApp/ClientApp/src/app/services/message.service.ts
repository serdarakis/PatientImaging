import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';  
import { Patient } from '../models/patient';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  patientReceived = new EventEmitter<Patient>();  
  connectionEstablished = new EventEmitter<Boolean>();  
  
    
  private connectionIsEstablished = false;  
  private _hubConnection: HubConnection;  

  constructor() {
    this.createConnection();  
    this.registerOnServerEvents();  
    this.startConnection();  
   }

   private createConnection() {  
     console.log("Create Conncetions")
    this._hubConnection = new HubConnectionBuilder()  
      .withUrl("http://localhost:13391/patientHub")
      .build();  
  }  
  
  private startConnection(): void {  
    this._hubConnection  
      .start()  
      .then(() => {  
        this.connectionIsEstablished = true;  
        console.log('Hub connection started');  
        this.connectionEstablished.emit(true);  
      })  
      .catch(err => {  
        console.log('Error while establishing connection, retrying...');  
        setTimeout(function () { this.startConnection(); }, 5000);  
      });  
  }  
  
  private registerOnServerEvents(): void {
    this._hubConnection.on('PatientAdded', (data: Patient) => {  
      this.patientReceived.emit(data);  
    });  
  } 

  sendMessage(message: string) {  
    this._hubConnection.invoke('NewMessage', message);  
  }  
}
