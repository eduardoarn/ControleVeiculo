import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LancamentoRoutingModule } from './lancamento-routing.module';
import { ListaComponent } from './lista/lista.component';
import { FormComponent } from './form/form.component';
import { BaseAdminModule } from '../base-admin.module';


@NgModule({
  declarations: [
    ListaComponent,
    FormComponent
  ],
  imports: [
    CommonModule,
    LancamentoRoutingModule,
    BaseAdminModule
  ]
})
export class LancamentoModule { }
