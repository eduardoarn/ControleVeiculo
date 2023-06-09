import { Component, Inject } from '@angular/core';
import { ComunicacaoService } from './services/comunicacao.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(@Inject(ComunicacaoService) public comunic: ComunicacaoService) {
    
  }
}
