import {
  ApplicationConfig,
  inject,
  InjectionToken,
  provideAppInitializer,
  provideZoneChangeDetection
} from '@angular/core';
import {provideRouter} from '@angular/router';

import {routes} from './app.routes';
import {SignalRService} from './shared/services/signalr.service';
import {provideAnimationsAsync} from '@angular/platform-browser/animations/async';
import {providePrimeNG} from 'primeng/config';
import {provideHttpClient} from '@angular/common/http';

import Aura from '@primeng/themes/aura';
import {AuctionService} from './features/admin/services/auction.service';
import {PrivateShopService} from './features/admin/services/private-shop.service';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({eventCoalescing: true}),
    provideRouter(routes),
    provideHttpClient(),
    provideAnimationsAsync(),
    providePrimeNG({
      theme: {
        preset: Aura
      },
      ripple: true
    }),
    provideAppInitializer(async () => {
      const auctionService = inject(AuctionService);
      const privateShopService = inject(PrivateShopService);

      return true;
    })
    ]
};
