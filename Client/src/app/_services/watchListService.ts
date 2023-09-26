import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FundamentalSummary } from './Models/fundamentalSummary';
import { EndPoints } from '../_Helpers/end-points';

@Injectable({
  providedIn: 'root'
})
export class WatchListService {

  constructor(private httpClient: HttpClient) { }

  getWatchlistData() {
    return this.httpClient.get<FundamentalSummary[]>(EndPoints.apiBaseUrl + EndPoints.apiGetWatchlistDataEP);
  }

  addToWatchList(ticker: string) {
    return this.httpClient.post(EndPoints.apiBaseUrl + EndPoints.apiAddToWatchListEP + '?ticker=' + ticker, null, { responseType: 'text' });
  }

  removeFromWatchList(ticker: string) {
    return this.httpClient.delete(EndPoints.apiBaseUrl + EndPoints.apiRemoveFromWatchListEP + '?ticker=' + ticker, { responseType: 'text' });
  }
}
