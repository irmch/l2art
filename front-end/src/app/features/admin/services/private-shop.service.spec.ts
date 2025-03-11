import { TestBed } from '@angular/core/testing';

import { PrivateShopService } from './private-shop.service';

describe('PrivateShopServiceService', () => {
  let service: PrivateShopService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PrivateShopService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
