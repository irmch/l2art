import {Component, computed, effect, inject, OnInit, signal} from '@angular/core';
import {ButtonModule} from 'primeng/button';
import {TableModule} from 'primeng/table';
import {ChartModule} from 'primeng/chart';
import {TabsModule} from 'primeng/tabs';
import {MenubarModule} from 'primeng/menubar';
import {PrivateShopComponent} from './pages/privateShop/private-shop/private-shop.component';
import {RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-admin',
  imports: [ButtonModule, TableModule, ChartModule, TabsModule, MenubarModule, RouterOutlet],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.scss',
})
export class AdminComponent {
  items = [
    {
      label: 'Main',
      icon: 'pi pi-fw pi-home',
      routerLink: ['/admin'],
      items: [],
    },
    {
      label: 'Private Shops',
      icon: 'pi pi-fw pi-dollar',
      items: [],
      routerLink: ['/admin/private-shop'],
    },
    {
      label: 'Auction',
      icon: 'pi pi-fw pi-money-bill',
      items: [],
      routerLink: ['/admin/auction']
    }
  ];




}
