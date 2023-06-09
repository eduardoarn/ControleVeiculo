import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'motorista', loadChildren: () => import('./motorista/motorista.module').then(m => m.MotoristaModule) },
  { path: 'veiculo', loadChildren: () => import('./veiculo/veiculo.module').then(m => m.VeiculoModule) },
  { path: 'lancamento', loadChildren: () => import('./lancamento/lancamento.module').then(m => m.LancamentoModule) },
  { path: 'abastecimento', loadChildren: () => import('./abastecimento/abastecimento.module').then(m => m.AbastecimentoModule) },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
