import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResult, MeasurementModel } from '../models';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private readonly http: HttpClient) {

  }

  public getAllMeasurements(): Observable<Array<MeasurementModel>> {
    return this.http.get<Array<MeasurementModel>>('Measurement/GetAllMeasurements');
  }

  public uploadCsvFiles(files: Array<File>): Observable<ApiResult> {
    if (!files)
      throw new Error('There is no files here...');
    let csvFiles: FormData = new FormData();
    files.forEach(file => {
      csvFiles.append('uploadModel', file);
    });
    csvFiles.forEach(console.log);
    return this.http.post<ApiResult>('Measurement/UploadCsvFiles', csvFiles);
  }
}
