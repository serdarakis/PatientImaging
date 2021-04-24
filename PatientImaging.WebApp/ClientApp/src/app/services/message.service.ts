import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';  

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  messageReceived = new EventEmitter<any>();  
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
    this._hubConnection.on('ReceiveMessage', (data: any) => {  
      console.log(data);
      this.messageReceived.emit(data);  
    });  
  } 

  sendMessage(message: string) {  
    this._hubConnection.invoke('NewMessage', message);  
  }  
}
