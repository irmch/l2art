import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateShopBuyComponent } from './private-shop-buy.component';

describe('PrivateShopBuyComponent', () => {
  let component: PrivateShopBuyComponent;
  let fixture: ComponentFixture<PrivateShopBuyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrivateShopBuyComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrivateShopBuyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
