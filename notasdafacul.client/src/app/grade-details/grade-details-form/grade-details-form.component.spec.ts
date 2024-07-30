import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradeDetailsFormComponent } from './grade-details-form.component';

describe('GradeDetailsFormComponent', () => {
  let component: GradeDetailsFormComponent;
  let fixture: ComponentFixture<GradeDetailsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GradeDetailsFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GradeDetailsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
