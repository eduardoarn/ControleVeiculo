

# Comandos  úteis 

## Dotnet Core

    #Banco de dados
    dotnet tool install --global dotnet-ef    
    dotnet ef migrations add InitialCreate
    dotnet ef database update


## Angular

```
ng g m cliente/abastecimento --routing
ng g c cliente/abastecimento/lista
ng g c cliente/abastecimento/form 

ng g c admin/home
ng g c cliente/home

ng g m admin --routing
ng g m admin/baseAdmin --routing
ng g m cliente --routing

ng g c restrito/perfil


ng g s services/AuthGuard
ng g s services/AuthGuardChild
```

Dentro do routing gerado colocar o código

```
import { ListaComponent } from './lista/lista.component';
import { FormComponent } from './form/form.component';


const routes: Routes = [
  { path: '', component: ListaComponent },
  { path: 'novo', component: FormComponent },
  { path: 'editar/:id', component: FormComponent },
];
```

e incluir essa linha no app-routing pra lazyloading

```
const routes: Routes = [ 
    ....
    { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule), canActivate: [AuthGuardService], canActivateChild: [AuthGuardChildService] },
....
}
```



Adicionar Rotas

ng g m admin/cidadeRegioes --route cidaderegioes --module admin/admin.module
ng g c admin/cidadeRegioes/lista
ng g c admin/cidadeRegioes/form 

ng g c admin/cidadeRegioes/lista --route novo --module admin/cidadeRegioes/cidadeRegioes.module
ng g c admin/cidadeRegioes/form --route editar/:id --module admin/cidadeRegioes/cidadeRegioes.module
