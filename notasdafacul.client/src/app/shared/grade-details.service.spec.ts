import { TestBed } from '@angular/core/testing';

import { GradeDetailsService } from './grade-details.service';

describe('GradeDetailsService', () => {
  let service: GradeDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GradeDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
