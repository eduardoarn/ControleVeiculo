import { Injectable } from '@angular/core';
import { Configuration } from '../shared/sdkcore';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public accessToken: string = '';
  getAccessToken(): string {
    return this.accessToken;
  };

  // private apiConfiguration: Configuration

  constructor() { }

  // definirToken(accessToken: string) {
  //   this.accessToken = accessToken;
  //   this.apiConfiguration.withCredentials = true;
  //   this.apiConfiguration.credentials = { 'Authorization': 'Bearer ' + accessToken };


  // }
}
