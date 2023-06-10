import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EvaluatorTableComponent } from './evaluator-table.component';

describe('EvaluatorTableComponent', () => {
  let component: EvaluatorTableComponent;
  let fixture: ComponentFixture<EvaluatorTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EvaluatorTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EvaluatorTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
