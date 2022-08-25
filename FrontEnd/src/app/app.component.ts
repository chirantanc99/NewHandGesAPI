import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';

import { WebcamImage, WebcamInitError, WebcamUtil } from 'ngx-webcam';
import { environment } from '../environments/environment.prod';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
}) 
export class AppComponent implements OnInit {
  private trigger = new Subject();
  public webcamImage!: WebcamImage;
  private nextWebcam = new Subject();
  captureImage = '';
  public forecasts?: WeatherForecast[]; 

  constructor(http: HttpClient) {
    http.get<WeatherForecast[]>('/weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

ngOnInit() { }
      /*------------------------------------------
    --------------------------------------------
    triggerSnapshot()
    ---------------------------------------------
    --------------------------------------------*/
    public triggerSnapshot(): void {
      this.trigger.next({});
  }
  
  public Predict() {
  //const xhttp = new XMLHttpRequest();
  //xhttp.onload = function () {
    //  alert(this.responseText);
    
  //};
  //xhttp.open('GET', 'https://localhost:7122', true);
    //xhttp.send();
  }
  

      /*------------------------------------------
    --------------------------------------------
    handleImage()
    --------------------------------------------
    --------------------------------------------*/
    public handleImage(webcamImage: WebcamImage): void {
      this.webcamImage = webcamImage;

      this.captureImage = webcamImage.imageAsDataUrl;
      //localStorage.getItem(this.captureImage);




      
      
  console.info('received webcam image', this.captureImage);
}
      /*------------------------------------------
    --------------------------------------------
    triggerObservable()
    --------------------------------------------
    --------------------------------------------*/
  public get triggerObservable(): Observable<any> {

  return this.trigger.asObservable();
}
      /*------------------------------------------
    --------------------------------------------
    nextWebcamObservable()
    --------------------------------------------
    --------------------------------------------*/
  public get nextWebcamObservable(): Observable<any> {

  return this.nextWebcam.asObservable();
  }



 
}
interface WeatherForecast {
  predict: string;
 
}
