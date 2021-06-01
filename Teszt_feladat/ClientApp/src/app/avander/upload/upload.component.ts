import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { switchMap, map, filter } from 'rxjs/operators';
import { HttpService } from '../../shared/services/http.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UploadComponent implements OnInit {
  selectedFiles: Observable<Array<File>> = new Observable<Array<File>>();
  splicerSubject: BehaviorSubject<string> = new BehaviorSubject<string>('');
  disableUploadButton: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);

  constructor(private readonly httpClient: HttpService,
    private readonly snackbar: MatSnackBar) {
  }

  ngOnInit(): void {
    this.init();
  }
  init(): void {
    this.splicerSubject.subscribe(name => {
      this.selectedFiles = this.selectedFiles.pipe(map(files => {
        if (name !== '') {
          let filteredFiles = files.filter(file => file.name !== name);
          if (filteredFiles.length === 0)
            this.disableUploadButton.next(true);
          return filteredFiles;
        }
        else
          return files
      }));
    });
  }

  onChange(event: any): void {
    let list: FileList = event.target.files;
    let array: Array<File> = [];
    for (let i = 0; i < list.length; i++) {
      let file = list.item(i);
      if (file) {
        if (file.name.slice(file.name.length - 4) === '.csv')
          array.push(file);
      }
    }
    if (array.length > 0)
      this.disableUploadButton.next(false);
    this.selectedFiles = of(array);
  }

  readAndUploadFiles(): void {
    this.selectedFiles.pipe(switchMap(files => {
      return this.httpClient.uploadCsvFiles(files);
    })).subscribe(apires => {
      this.snackbar.open(apires.message, 'OK', { duration: 4000 });
      if (apires.isSuccess) {
        this.selectedFiles = new Observable<Array<File>>();
      }
    });
  }
}
