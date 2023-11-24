import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private http: HttpClient) {
  
  }
   callBackend() {
  this.http.get<any>('localhost:44481/ForexController/Forex/ConvertCurr')
    .subscribe(
      (response) => {
        console.log('Backend Response:', response);
      },
      (error) => {
        //  errors
        console.error('Error:', error);
      }
    );

  }
}
