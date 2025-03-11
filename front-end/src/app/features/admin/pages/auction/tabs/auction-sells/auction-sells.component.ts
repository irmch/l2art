import {Component, computed, inject, signal} from '@angular/core';
import {Dialog} from "primeng/dialog";
import {UIChart} from "primeng/chart";
import {PrimeTemplate} from 'primeng/api';
import {TableModule} from 'primeng/table';
import {AuctionService} from '../../../../services/auction.service';
import {Auction} from '../../../../models/auction';
import {DecimalPipe} from '@angular/common';

@Component({
  selector: 'app-auction-sells',
  imports: [
    Dialog,
    UIChart,
    PrimeTemplate,
    TableModule,
    DecimalPipe
  ],
  templateUrl: './auction-sells.component.html',
  styleUrl: './auction-sells.component.scss'
})
export class AuctionSellsComponent {
  displayChart = false;

  auctionService = inject(AuctionService);
  auctionItems = this.auctionService.auctions;
  isLoading = this.auctionService.isLoading;
  auctionsById = this.auctionService.auctionsById;

  selectedAuction!: Auction;

  chartData = computed(() => {
    return {
      labels: this.auctionsById().map(item => item.pricePerUnit),
      datasets: [
        {
          label: 'Price',
          data: this.auctionsById().map(item => item.pricePerUnit),
          fill: false,
          borderColor: '#42A5F5',
          tension: 0.4,
        },
      ],
    };
  });

  trackByAuction(index: number, auction: Auction) {
    return auction.commissionId;
  }

  onRowSelect($event: any) {
    console.log(this.selectedAuction);
    const itemId = this.selectedAuction.itemId;
    this.auctionService.getAuctionItemByItemId(itemId);
    this.displayChart = true;
  }
}
