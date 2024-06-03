import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ApplicationEvaluationParameterTableComponent } from './application-evaluate-paramete-table.component';

describe('ApplicationEvaluationParameterTableComponent', () => {
  let component: ApplicationEvaluationParameterTableComponent;
  let fixture: ComponentFixture<ApplicationEvaluationParameterTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApplicationEvaluationParameterTableComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(ApplicationEvaluationParameterTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
