import {Injectable, signal, effect, Inject} from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: HubConnection;
  messages = signal<any[]>([]);
  hubUrl = "http://backend/api/items-hub";

  constructor() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl(this.hubUrl)
      .build();

    this.startConnection();
  }

  private startConnection() {
    this.hubConnection
      .start()
      .then(() => console.log('SignalR Connection Established'))
      .catch(err => console.error('Error while establishing connection:', err));
  }

  listen(eventName: string, callback: (data: any) => void) {
    this.hubConnection.on(eventName, callback);
  }

  send(method: string, data: any) {
    this.hubConnection
      .invoke(method, data)
      .catch(err => console.error(err));
  }

  private addMessage(data: any) {
    this.messages.set([...this.messages(), data]);
  }
}
