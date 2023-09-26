import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavComponent } from './_general/nav/nav.component';
import { WatchlistComponent } from './watchlist/watchlist.component';
import { RemoveComponent } from './_general/remove/remove.component';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TickerSearchComponent } from './_general/ticker-search/ticker-search.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    WatchlistComponent,
    RemoveComponent,
    HomeComponent,
    TickerSearchComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({positionClass: 'toast-bottom-right'})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
