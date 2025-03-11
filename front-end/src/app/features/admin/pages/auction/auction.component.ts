import {Component, computed, inject, signal} from '@angular/core';
import {TableModule} from "primeng/table";
import {AuctionSellsComponent} from './tabs/auction-sells/auction-sells.component';
import {AuctionService} from '../../services/auction.service';
import {PrivateShopSellsComponent} from "../privateShop/tabs/private-shop-sells/private-shop-sells.component";
import {Tab, TabList, TabPanel, TabPanels, Tabs} from "primeng/tabs";

@Component({
  selector: 'app-auction',
    imports: [
        TableModule,
        AuctionSellsComponent,
        Tab,
        TabList,
        TabPanel,
        TabPanels,
        Tabs
    ],
  templateUrl: './auction.component.html',
  styleUrl: './auction.component.scss'
})
export class AuctionComponent {

}
