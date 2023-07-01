import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CasualProductsComponent } from './casual-products.component';

describe('CasualProductsComponent', () => {
  let component: CasualProductsComponent;
  let fixture: ComponentFixture<CasualProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CasualProductsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CasualProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
