export class EndPoints
{
  //API endpoints
  static apiBaseUrl = 'http://localhost:5246/';
  static apiGetWatchlistDataEP = 'Watchlist/GetWatchlistData';
  static apiAddToWatchListEP = 'Watchlist/AddToWatchList';
  static apiRemoveFromWatchListEP = 'Watchlist/RemoveFromWatchList';
  static apiSearchTickersEP = 'Symbol/SearchTickers';

  //Angular routing
  static routingWatchList = 'watchlist';
  static routingHome = '';
  static routingPortfolio = 'portfolio';
}
