import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AvanderRoutingModule } from './avander-routing.module';
import { TaskComponent } from './task/task.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { UploadComponent } from './upload/upload.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    TaskComponent,
    UploadComponent
  ],
  imports: [
    SharedModule,
    AvanderRoutingModule
  ]
})
export class AvanderModule { }
