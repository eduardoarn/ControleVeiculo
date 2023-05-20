import { Component, Inject } from '@angular/core';
import { Veiculo, VeiculoService } from '../shared/sdkcore';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  lista: Veiculo[] | null | undefined = [];

  constructor(@Inject(VeiculoService) public api: VeiculoService) {
    this.api.veiculoGet("", 1).subscribe({
      next: (x) => {
        this.lista = x.lista;
        console.log(this.lista);
      },
      error: (err) => console.log(err)
    });
  }
}
