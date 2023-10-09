import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WatchlistComponent } from './watchlist/watchlist.component';
import { EndPoints } from './_Helpers/end-points';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PortfolioComponent } from './portfolio/portfolio.component';

const routes: Routes = [
  { path: EndPoints.routingWatchList, component: WatchlistComponent },
  { path: EndPoints.routingHome, component: HomeComponent },
  { path: EndPoints.routingPortfolio, component: PortfolioComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
