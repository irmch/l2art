import { Routes } from '@angular/router';
import {AdminComponent} from './admin.component';
import {PrivateShopComponent} from './pages/privateShop/private-shop/private-shop.component';
import {AuctionComponent} from './pages/auction/auction.component';

export const adminRoutes: Routes = [
  {
    path: "admin",
    component: AdminComponent,
    children: [
      {
        path: "private-shop",
        component: PrivateShopComponent
      },
      {
        path: "auction",
        component: AuctionComponent
      }
    ],
  }
];
