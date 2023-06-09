import { Component, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ComunicacaoService } from 'src/app/services/comunicacao.service';
import { Motorista, MotoristaService } from 'src/app/shared/sdkcore';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent {
  dadosDoForm: Motorista = {};
  submitted: boolean = false;


  constructor(@Inject(MotoristaService) private api: MotoristaService, @Inject(ActivatedRoute) private route: ActivatedRoute, @Inject(ComunicacaoService) public comunic: ComunicacaoService) {
    this.route.paramMap.subscribe(parans => {
      let id = parans.get('id');
      if (id) { //Editando
        this.comunic.isCarregando(true, 'Buscando dados do motorista...');
        this.api.motoristaIdGet(id).subscribe({
          next: (result: Motorista) => { this.dadosDoForm = result; },
          error: (err) => this.comunic.error(err),
          complete: () => this.comunic.isCarregando(false)
        });
      }
      else { //Novo
        this.dadosDoForm = {};
        this.comunic.isCarregando(false);
      }
    })
  }

  async onSubmit(formulario: NgForm) {
    this.submitted = true;
    if (formulario.valid) {
      let dados: Motorista = Object.assign({}, formulario.value);
      this.comunic.isCarregando(true, 'Salvando dados do motorista...');
      if (!this.dadosDoForm.id) { //Novo Cadastro
        this.api.motoristaPost(dados).subscribe({
          next: (x) => {
            this.comunic.isCarregando(false);
            this.comunic.navegar(['..'], { relativeTo: this.route });
          }, error: (err) => this.comunic.error(err)
        })
      } else { //Alterando o cadastro
        dados.id = this.dadosDoForm.id;
        this.api.motoristaPut(dados).subscribe({
          next: (x) => {
            this.comunic.isCarregando(false);
            this.comunic.navegar(['../..'], { relativeTo: this.route });
          }, error: (err) => this.comunic.error(err)
        })
      }
    }
  }
}
