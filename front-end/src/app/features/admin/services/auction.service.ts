import {computed, inject, Injectable, OnInit, signal} from '@angular/core';
import {SignalRService} from '../../../shared/services/signalr.service';
import {HttpClient} from '@angular/common/http';
import {Auction} from '../models/auction';
import {BehaviorSubject, Subject, tap} from 'rxjs';


interface AuctionServiceState {
  auctions: Auction[];
  isLoading: boolean;
  auctionsById: Auction[];
}

@Injectable({
  providedIn: 'root'
})
export class AuctionService {
  baseUrl: string = '/api';
  signalrService = inject(SignalRService);
  http = inject(HttpClient);

  state = signal<AuctionServiceState>({
    auctions: [],
    isLoading: true,
    auctionsById: []
  });

  auctions = computed(() => this.state().auctions);
  isLoading = computed(() => this.state().isLoading);
  auctionsById = computed(() => this.state().auctionsById);

  playNotifySound(){
    const notifySound = new Audio();
    notifySound.src = 'assets/sounds/notify/private_shop.mp3';
    notifySound.load();

    notifySound.play().catch(err => {
      console.warn(`Cant play sound:`, err);
    });
  }

  constructor() {
    this.signalrService.listen('BestDealAuction_init', (data: string) => {
      const res:Auction[] = JSON.parse(data);
      this.state.update((prev) => ({
        ...prev,
        auctions: structuredClone([...prev.auctions, ...res]),
        isLoading: false
      }));
    });
  }

  getAuctionItemByItemId(commissionId: number) {
    const url = `${this.baseUrl}/auction/${commissionId}`;
    return this.http.get<Auction[]>(url).pipe(
      tap(data => {
        this.state.update(prev => ({
          ...prev,
          isLoading: true
        }));
      })
    ).subscribe(auction => {
      this.state.update(prev => ({
        ...prev,
        auctionsById: [...auction],
        isLoading: false
      }))
    });
  }
}
