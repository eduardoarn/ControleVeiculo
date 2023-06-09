import { Component, Inject } from '@angular/core';
import { Veiculo, VeiculoService } from '../shared/sdkcore';
import { ComunicacaoService } from '../services/comunicacao.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  lista: Veiculo[] | null | undefined = [];

  constructor(@Inject(VeiculoService) public api: VeiculoService, @Inject(ComunicacaoService) public comunic: ComunicacaoService) {
    this.comunic.isCarregando(false);
    this.api.veiculoGet("", 1).subscribe({
      next: (x) => {
        this.lista = x.lista;
        console.log(this.lista);
      },
      error: (err) => console.log(err)
    });
  }
}
