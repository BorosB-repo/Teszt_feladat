import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MeasurementModel } from '../../../shared/models';

@Component({
  selector: 'app-measurement-details-dialog',
  templateUrl: './measurement-details-dialog.component.html'
})
export class MeasurementDetailsDialog {

  constructor(private readonly dialogRef: MatDialogRef<MeasurementDetailsDialog>,
    @Inject(MAT_DIALOG_DATA) public measurement: MeasurementModel) {
  }
  onCloseClick(): void {
    this.dialogRef.close();
  }
}
