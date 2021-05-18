import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatCardModule,
    MatTableModule
  ],
  exports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatCardModule,
    MatTableModule
  ]
})
export class SharedModule { }
