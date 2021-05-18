import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MeasurementModel } from '../models';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private readonly http: HttpClient) {

  }

  public getAllMeasurements(): Observable<Array<MeasurementModel>> {
    return this.http.get<Array<MeasurementModel>>('Measurement/GetAllMeasurement');
  }

}
