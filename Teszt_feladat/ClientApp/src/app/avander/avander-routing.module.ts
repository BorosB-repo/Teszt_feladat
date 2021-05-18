import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskComponent } from './task/task.component';
import { UploadComponent } from './upload/upload.component';

const routes: Routes = [
  {
    path: 'task',
    component: TaskComponent
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
