import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { AvanderRoutingModule } from './avander-routing.module';
import { DisplayMeasurementsComponent } from './displayMeasurements/displayMeasurements.component';
import { UploadComponent } from './upload/upload.component';
import { MeasurementDetailsDialog } from './displayMeasurements/measurement-details-dialog/measurement-details-dialog.component';



@NgModule({
  declarations: [
    DisplayMeasurementsComponent,
    UploadComponent,
    MeasurementDetailsDialog
  ],
  imports: [
    SharedModule,
    AvanderRoutingModule
  ],
  entryComponents: [
    MeasurementDetailsDialog
  ]
})
export class AvanderModule { }
