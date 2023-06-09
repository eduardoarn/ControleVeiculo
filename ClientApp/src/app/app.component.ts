import { Component, Inject } from '@angular/core';
import { ComunicacaoService } from './services/comunicacao.service';
import { NavigationStart, Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  constructor(@Inject(ComunicacaoService) public comunic: ComunicacaoService, private router: Router) {

  }

  ngOnInit() {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        this.comunic.isCarregando(true);
      }
      // if (!environment.production) console.log(event);
    });
  }

}
