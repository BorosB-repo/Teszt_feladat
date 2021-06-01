import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DisplayMeasurementsComponent } from './displayMeasurements/displayMeasurements.component';
import { UploadComponent } from './upload/upload.component';

const routes: Routes = [
  {
    path: 'displayMeasurements',
    component: DisplayMeasurementsComponent
  },
  {
    path: 'upload',
    component: UploadComponent
  },
  {
    path: '**',
    redirectTo: 'task'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AvanderRoutingModule { }
