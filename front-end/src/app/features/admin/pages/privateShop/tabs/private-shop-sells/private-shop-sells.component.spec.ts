import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateShopSellsComponent } from './private-shop-sells.component';

describe('PrivateShopSellsComponent', () => {
  let component: PrivateShopSellsComponent;
  let fixture: ComponentFixture<PrivateShopSellsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrivateShopSellsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrivateShopSellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
