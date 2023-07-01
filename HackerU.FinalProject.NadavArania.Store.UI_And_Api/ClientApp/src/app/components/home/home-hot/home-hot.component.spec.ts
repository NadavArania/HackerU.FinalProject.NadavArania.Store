import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeHotComponent } from './home-hot.component';

describe('HomeHotComponent', () => {
  let component: HomeHotComponent;
  let fixture: ComponentFixture<HomeHotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeHotComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeHotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
