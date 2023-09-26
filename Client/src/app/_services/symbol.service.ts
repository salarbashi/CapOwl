import { Injectable } from '@angular/core';
import { EndPoints } from '../_Helpers/end-points';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SymbolService {

  constructor(private httpClient: HttpClient) { }

  searchTickers(searchTerm: string) {
    let params = new HttpParams().set('searchChars', searchTerm);
    return this.httpClient.get<string[]>(EndPoints.apiBaseUrl + EndPoints.apiSearchTickersEP, { params: params });
  }
}
