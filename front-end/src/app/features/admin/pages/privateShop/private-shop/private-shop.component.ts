import { Component } from '@angular/core';
import {AuctionComponent} from '../../auction/auction.component';
import {PrivateShopSellsComponent} from '../tabs/private-shop-sells/private-shop-sells.component';
import {Tab, TabList, TabPanel, TabPanels, Tabs} from 'primeng/tabs';

@Component({
  selector: 'app-private-shop',
  imports: [
    PrivateShopSellsComponent,
    Tab,
    TabList,
    TabPanel,
    TabPanels,
    Tabs
  ],
  templateUrl: './private-shop.component.html',
  styleUrl: './private-shop.component.scss'
})
export class PrivateShopComponent {

}
