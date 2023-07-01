import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeCollabComponent } from './home-collab.component';

describe('HomeCollabComponent', () => {
  let component: HomeCollabComponent;
  let fixture: ComponentFixture<HomeCollabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeCollabComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeCollabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
