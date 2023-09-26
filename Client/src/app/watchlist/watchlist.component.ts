import { Component, OnInit } from '@angular/core';
import { FundamentalSummary } from '../_services/Models/fundamentalSummary';
import { WatchListService } from '../_services/watchListService';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-watchlist',
  templateUrl: './watchlist.component.html',
  styleUrls: ['./watchlist.component.css']
})
export class WatchlistComponent {

  watchListdata: FundamentalSummary[] = [];
  model: any = {};

  constructor(private watchListService: WatchListService, private toast: ToastrService) { }

  ngOnInit(): void {
    //fill the wathclist
    this.getWatchlistData();
  }


  addToWatchList(ticker: string) {
    this.watchListService.addToWatchList(ticker).subscribe({
      next: (data) => {
        this.getWatchlistData();
        this.toast.success('Symbol added to the watchlist');
      },
      error: (error: HttpErrorResponse) => {
        if (error.status == 404) {
          this.toast.warning("Ticker is not correct!");
        }
        else { console.log("There was an error in adding the symbol:" + error.message); }
        
      }
    });
  }

  removeFromWatchList() {
    this.getWatchlistData();
    this.toast.success('Symbol removed from watchlist');
  }

  getWatchlistData() {
    this.watchListService.getWatchlistData().subscribe({
      next: (data) => {
        this.watchListdata = data;
      },
      error: (error) => console.log("There was an error in receiving the data:" + error.message)
    });
  }

  //average function
  average(data: FundamentalSummary[], variable: keyof FundamentalSummary): number {
    if (data.length === 0) {
      /*throw new Error("Data array is empty");*/
      return 0;
    }

    const sum = data.reduce((total, item) => total + (+item[variable]), 0);
    const average = sum / data.length;

    return average;
  }
}
