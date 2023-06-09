import { Component, Inject } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ComunicacaoService } from 'src/app/services/comunicacao.service';
import { Veiculo, VeiculoService } from 'src/app/shared/sdkcore';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent {

  dadosDoForm: Veiculo = {};
  submitted: boolean = false;


  constructor(@Inject(VeiculoService) private api: VeiculoService, @Inject(ActivatedRoute) private route: ActivatedRoute, @Inject(Router) private router: Router, @Inject(ComunicacaoService) public comunic: ComunicacaoService) {
    this.route.paramMap.subscribe(parans => {
      let id = parans.get('id');
      if (id) { //Editando
        this.comunic.isCarregando(true, 'Buscando dados do veículo...');
        this.api.veiculoIdGet(id).subscribe({
          next: (result: Veiculo) => { this.dadosDoForm = result; },
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
      let dados: Veiculo = Object.assign({}, formulario.value);
      this.comunic.isCarregando(true, 'Salvando dados do veículo...');
      if (!this.dadosDoForm.id) { //Novo Cadastro
        this.api.veiculoPost(dados).subscribe({
          next: (x) => {
            this.comunic.isCarregando(false);
            this.comunic.navegar(['..'], { relativeTo: this.route });
          }, error: (err) => this.comunic.error(err)
        })
      } else { //Alterando o cadastro
        dados.id = this.dadosDoForm.id;
        this.api.veiculoPut(dados).subscribe({
          next: (x) => {
            this.comunic.isCarregando(false);
            this.comunic.navegar(['../..'], { relativeTo: this.route });
          }, error: (err) => this.comunic.error(err)
        })
      }
    }
  }



}
