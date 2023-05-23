import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeComponent } from './home/home.component';
import { AdminRoutingModule } from './admin-routing.module';
import { BaseAdminModule } from './base-admin.module';


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    BaseAdminModule
  ]
})
export class AdminModule { }
