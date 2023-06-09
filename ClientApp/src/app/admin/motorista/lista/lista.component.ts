import { Component, Inject } from '@angular/core';
import { ComunicacaoService } from 'src/app/services/comunicacao.service';
import { MotoristaListaRetorno, MotoristaService } from 'src/app/shared/sdkcore';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss']
})
export class ListaComponent {
  constructor(@Inject(MotoristaService) public apiMotorista: MotoristaService, @Inject(ComunicacaoService) public comunic: ComunicacaoService) {
    this.buscar();
  }

  public iniciado: boolean = false;
  public retorno: MotoristaListaRetorno = { lista: null, paginaAtual: 1, totalRegistros: 0, tamanhoPagina: 0 };
  public textoFiltro: string = '';
  public get totalDePaginas(): number {
    if (this.retorno.totalRegistros && this.retorno.tamanhoPagina)
      return Math.ceil(this.retorno.totalRegistros / this.retorno.tamanhoPagina);
    else return 0;
  }

  buscar(pagina: number = 1) {
    this.iniciado = false;
    this.comunic.isCarregando(true, "Buscando os motoristas...");
    this.apiMotorista.motoristaGet(this.textoFiltro, pagina).subscribe({
      next: (x) => { this.retorno = x; },
      error: (err) => this.comunic.error(err),
      complete: () => { this.iniciado = true; this.comunic.isCarregando(false); }
    });
  }
}
