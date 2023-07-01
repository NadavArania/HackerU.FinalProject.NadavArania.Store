import { TestBed } from '@angular/core/testing';

import { NavigateGuardService } from './navigate-guard.service';

describe('NavigateGuardService', () => {
  let service: NavigateGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NavigateGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
