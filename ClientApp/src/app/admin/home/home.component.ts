import { Component, Inject } from '@angular/core';
import { ComunicacaoService } from 'src/app/services/comunicacao.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  constructor(@Inject(ComunicacaoService) public comunic: ComunicacaoService) {
    comunic.isCarregando(false);
  }
}
