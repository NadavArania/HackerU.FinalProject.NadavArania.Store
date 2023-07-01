import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OfficeProductsComponent } from './office-products.component';

describe('OfficeProductsComponent', () => {
  let component: OfficeProductsComponent;
  let fixture: ComponentFixture<OfficeProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OfficeProductsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OfficeProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
