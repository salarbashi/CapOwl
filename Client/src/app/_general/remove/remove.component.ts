import { Component, EventEmitter, Input, Output } from '@angular/core';
import { WatchListService } from '../../_services/watchListService';

@Component({
  selector: 'app-remove',
  templateUrl: './remove.component.html',
  styleUrls: ['./remove.component.css']
})
export class RemoveComponent {
  @Input()
  ticker: string = '';

  @Output()
  updateWatchList = new EventEmitter();

  constructor(private watchListService: WatchListService) { }

  removeFromWatchList() {
    this.watchListService.removeFromWatchList(this.ticker).subscribe({
      next: data => {
        this.updateWatchList.emit();
        console.log('removed from watchlist!');
      },
      error: error => console.log('there was an error in removing from watchlist:' + error.message)
    });
  }
}
