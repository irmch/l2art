import { Component, computed, inject, signal } from '@angular/core';
import { PrivateShopService } from '../../../../services/private-shop.service';
import { IPrivateShop } from '../../../../models/iprivate-shop-item';
import { PrimeTemplate } from 'primeng/api';
import { TableModule } from 'primeng/table';
import { UIChart } from 'primeng/chart';
import { Dialog } from 'primeng/dialog';

@Component({
  selector: 'app-private-shop-sells',
  imports: [
    PrimeTemplate,
    TableModule,
    Dialog,
    UIChart
  ],
  templateUrl: './private-shop-sells.component.html',
  styleUrls: ['./private-shop-sells.component.scss']
})
export class PrivateShopSellsComponent {
  privateShopService = inject(PrivateShopService);

  privateShops = this.privateShopService.privateShops;
  isLoading = this.privateShopService.isLoading;

  privateShopsById = this.privateShopService.privateShopsById;

  selectedPrivateShop!: IPrivateShop;
  displayChart = false;

  chartData = computed(() => {
    return {
      labels: this.privateShopsById().map(item => item.price),
      datasets: [
        {
          label: 'Price',
          data: this.privateShopsById().map(item => item.price),
          fill: false,
          borderColor: '#42A5F5',
          tension: 0.4,
        },
      ],
    };
  });

  onRowSelect($event: any) {
    const itemId = this.selectedPrivateShop.itemId;
    this.privateShopService.getPrivateShopByItemId(itemId);
    this.displayChart = true;
  }
}
