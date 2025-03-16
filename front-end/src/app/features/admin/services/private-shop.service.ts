import {computed, effect, inject, Injectable, OnInit, signal} from '@angular/core';
import { SignalRService } from '../../../shared/services/signalr.service';
import { IPrivateShop } from '../models/iprivate-shop-item';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs';

interface PrivateShopServiceState {
  privateShops: IPrivateShop[];
  isLoading: boolean;
  privateShopsById: IPrivateShop[];
}

@Injectable({
  providedIn: 'root',
})
export class PrivateShopService {
  baseUrl: string = 'http://0.0.0.0/api';
  signalrService = inject(SignalRService);
  http = inject(HttpClient);

  state = signal<PrivateShopServiceState>({
    privateShops: [],
    isLoading: true,
    privateShopsById: []
  });

  privateShops = computed(() => this.state().privateShops);
  isLoading = computed(() => this.state().isLoading);
  privateShopsById = computed(() => this.state().privateShopsById);

  constructor() {
    this.signalrService.listen('BestDealPrivateShops_init', (data) => {
      const res: IPrivateShop[] = JSON.parse(data);
      this.state.update(prev => ({
        ...prev,
        privateShops: res,
        isLoading: false
      }));
      console.log(this.state().privateShops);
    });

    this.signalrService.listen('BestDealPrivateShops_addNew', (data) => {
      const res: IPrivateShop = JSON.parse(data);
      this.state.update(prev => ({
        ...prev,
        privateShops: [...prev.privateShops, res]
      }));
    });

    this.signalrService.listen('BestDealPrivateShops_delete', (data) => {
      const res: IPrivateShop = JSON.parse(data);
      this.state.update(prev => ({
        ...prev,
        privateShops: prev.privateShops.filter(item => item.id !== res.id)
      }));
    });
  }

  getPrivateShopByItemId(itemId: number) {
    const url = `${this.baseUrl}/private-shop/${itemId}`;
    return this.http.get<IPrivateShop[]>(url).pipe(
      tap(() => {
        this.state.update(prev => ({
          ...prev,
          isLoading: true
        }));
      })
    ).subscribe(privateShops => {
      this.state.update(prev => ({
        ...prev,
        privateShopsById: privateShops,
        isLoading: false
      }));
    });
  }
}
