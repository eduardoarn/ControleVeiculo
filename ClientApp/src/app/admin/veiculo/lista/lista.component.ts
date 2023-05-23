import { Component, Inject } from '@angular/core';
import { Veiculo, VeiculoListaRetorno, VeiculoService } from 'src/app/shared/sdkcore';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaComponent {

  public iniciado: boolean = false;
  public retorno: VeiculoListaRetorno = { lista: null, paginaAtual: 0, totalRegistros: 0, tamanhoPagina: 0 };
  public textoFiltro: string = '';

  constructor(@Inject(VeiculoService) public apiVeiculo: VeiculoService) {
    this.buscar();
  }

  buscar() {
    this.iniciado = false;
    this.apiVeiculo.veiculoGet(this.textoFiltro).subscribe({
      next: (x) => { this.retorno = x; },
      error: (err) => console.error(err),
      complete: () => { this.iniciado = true; }
    });
  }
}
