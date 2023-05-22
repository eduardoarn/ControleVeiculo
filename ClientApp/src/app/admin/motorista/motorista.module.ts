import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MotoristaRoutingModule } from './motorista-routing.module';
import { ListaComponent } from './lista/lista.component';
import { FormComponent } from './form/form.component';


@NgModule({
  declarations: [
    ListaComponent,
    FormComponent
  ],
  imports: [
    CommonModule,
    MotoristaRoutingModule
  ]
})
export class MotoristaModule { }
