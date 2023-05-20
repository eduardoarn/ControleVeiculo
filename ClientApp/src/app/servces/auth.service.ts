import { Injectable } from '@angular/core';
import { Configuration } from '../shared/sdkcore';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private apiConfiguration: Configuration) { }

  definirToken(accessToken: string) {
    this.apiConfiguration.withCredentials = true;
    this.apiConfiguration.credentials = { 'Authorization': 'Bearer ' + accessToken };


  }
}
