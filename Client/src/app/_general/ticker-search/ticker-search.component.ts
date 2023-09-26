import { Component, EventEmitter, Output } from '@angular/core';
import { SymbolService } from '../../_services/symbol.service';

@Component({
  selector: 'app-ticker-search',
  templateUrl: './ticker-search.component.html',
  styleUrls: ['./ticker-search.component.css']
})
export class TickerSearchComponent {

  @Output()
  addTickerSymbol = new EventEmitter();

  searchTerm: string = "";
  filteredData: string[] = [];

  constructor(private symbolService: SymbolService) { }

  sendTicker() {
    if (this.searchTerm != "") {
      this.addTickerSymbol.emit(this.searchTerm);
    }
  }

  tickerClick(clickedTicker: string) {
    this.searchTerm = clickedTicker;
    this.filteredData = [];
  }

  filterResults() {
    if (this.searchTerm.length > 0) {
      this.symbolService.searchTickers(this.searchTerm).subscribe({
        next: (data: string[]) => {
          this.filteredData = data;
        },
        error: (error) => console.log("There was an error in searching the symbol vy ticker:" + error.message)
      });
    }
    else {
      this.filteredData = [];
    }

  }

}
