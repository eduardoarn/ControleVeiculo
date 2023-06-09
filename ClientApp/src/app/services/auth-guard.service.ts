import { Inject, Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateChildFn, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { AuthService } from './auth.service';
import { ComunicacaoService } from './comunicacao.service';

// @Injectable({
//   providedIn: 'root'
// })
// export class AuthGuardService implements CanActivateChild {

//   constructor() { }
//   canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
//     return true;
//   }
// }


export const canActivate: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  const comunic = inject(ComunicacaoService);
  comunic.isCarregando(true, 'Verificando permissão...');

  return true;

  // authService.checkLogin().pipe(
  //   map(() => true),
  //   catchError(() => {
  //     router.navigate(['route-to-fallback-page']);
  //     return of(false);
  //   })
  // );
};

export const canActivateChild: CanActivateChildFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => canActivate(route, state);