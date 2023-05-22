import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'abastecimento', loadChildren: () => import('./abastecimento/abastecimento.module').then(m => m.AbastecimentoModule) },
  { path: 'lancamento', loadChildren: () => import('./lancamento/lancamento.module').then(m => m.LancamentoModule) }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteRoutingModule { }
