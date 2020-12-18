import { TestBed } from '@angular/core/testing';

import { ViewFirmServiceService } from './view-firm-service.service';

describe('ViewFirmServiceService', () => {
  let service: ViewFirmServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ViewFirmServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
