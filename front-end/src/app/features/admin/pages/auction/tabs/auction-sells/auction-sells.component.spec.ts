import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionSellsComponent } from './auction-sells.component';

describe('AuctionSellsComponent', () => {
  let component: AuctionSellsComponent;
  let fixture: ComponentFixture<AuctionSellsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AuctionSellsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuctionSellsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
