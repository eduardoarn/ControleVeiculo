import { Inject, Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ComunicacaoService {

  constructor(@Inject(ActivatedRoute) public route: ActivatedRoute, @Inject(Router) private router: Router) { }

  private _isCarregando: boolean = true;
  private _mensagemCarregandoPadrao: string = 'Carregando...';
  private _mensagemCarregando: string = this._mensagemCarregandoPadrao;
  public get mostarCarregando(): boolean {
    return this._isCarregando;
  }

  public get mensagemCarregando(): string {
    return this._mensagemCarregando;
  }
  isCarregando(mostrar: boolean = true, mensagem: string = '') {
    this._isCarregando = mostrar;
    this._mensagemCarregando = mensagem || this._mensagemCarregandoPadrao;
  }

  error(err: any) {
    console.error(err);
  }

  navegar(url: string[] = [], queryParams: any = {}) {
    this.router.navigate(url, queryParams);
  }

}
