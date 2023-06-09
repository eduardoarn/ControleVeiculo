import { Component, Inject } from '@angular/core';
import { ComunicacaoService } from 'src/app/services/comunicacao.service';
import { Veiculo, VeiculoListaRetorno, VeiculoService } from 'src/app/shared/sdkcore';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaComponent {

  public iniciado: boolean = false;
  public retorno: VeiculoListaRetorno = { lista: null, paginaAtual: 1, totalRegistros: 0, tamanhoPagina: 0 };
  public textoFiltro: string = '';
  public get totalDePaginas(): number {
    if (this.retorno.totalRegistros && this.retorno.tamanhoPagina)
      return Math.ceil(this.retorno.totalRegistros / this.retorno.tamanhoPagina);
    else return 0;
  }

  constructor(@Inject(VeiculoService) public apiVeiculo: VeiculoService, @Inject(ComunicacaoService) public comunic: ComunicacaoService) {
    this.buscar();
  }

  buscar(pagina: number = 1) {
    this.iniciado = false;
    this.comunic.isCarregando(true,"Buscando os veículos...");
    this.apiVeiculo.veiculoGet(this.textoFiltro, pagina).subscribe({
      next: (x) => { this.retorno = x; },
      error: (err) => console.error(err),
      complete: () => { this.iniciado = true; this.comunic.isCarregando(false); }
    });
  }
}
