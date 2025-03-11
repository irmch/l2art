import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateShopComponent } from './private-shop.component';

describe('PrivateShopComponent', () => {
  let component: PrivateShopComponent;
  let fixture: ComponentFixture<PrivateShopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrivateShopComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrivateShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
