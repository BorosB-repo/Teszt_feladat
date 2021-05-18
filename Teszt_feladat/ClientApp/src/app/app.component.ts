import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';
  constructor(private readonly http: HttpClient) {
    this.http.get<any>('Test/GetAllVechiles').subscribe(console.log);
  }
}
