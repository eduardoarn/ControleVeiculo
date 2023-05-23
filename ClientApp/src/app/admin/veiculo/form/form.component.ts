import { Component, Inject } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Veiculo, VeiculoService } from 'src/app/shared/sdkcore';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent {

  dadosDoForm: Veiculo = {};
  submitted: boolean = false;


  constructor(@Inject(VeiculoService) private api: VeiculoService, @Inject(ActivatedRoute) private route: ActivatedRoute, @Inject(Router) private router: Router,) {
    this.route.paramMap.subscribe(parans => {
      let id = parans.get('id');
      if (id) { //Editando
        this.api.veiculoIdGet(id).subscribe((result: Veiculo) => {
          this.dadosDoForm = result;
        })
      }
      else { //Novo
        this.dadosDoForm = {};
      }
    })
  }

  async onSubmit(formulario: NgForm) {
    this.submitted = true;
    if (formulario.valid) {
      let dados: Veiculo = Object.assign({}, formulario.value);
      if (!this.dadosDoForm.id) { //Novo Cadastro
        this.api.veiculoPost(dados).subscribe({
          next: (x) => {
            this.router.navigate(['..'], { relativeTo: this.route });//Voltar pra lista
          }, error: (err) => console.error(err)
        })
      } else { //Alterando o cadastro
        dados.id = this.dadosDoForm.id;
        this.api.veiculoPut(dados).subscribe({
          next: (x) => {
            this.router.navigate(['../..'], { relativeTo: this.route });//Voltar pra lista
          }, error: (err) => console.error(err)
        })
      }
    }
  }



}
