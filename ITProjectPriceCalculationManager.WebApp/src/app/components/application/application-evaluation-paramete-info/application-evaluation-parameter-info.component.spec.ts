import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ApplicationEvaluationParameterDetailsComponent } from './application-evaluation-parameter-info.component';

describe('ApplicationEvaluationParameterDetailsComponent', () => {
  let component: ApplicationEvaluationParameterDetailsComponent;
  let fixture: ComponentFixture<ApplicationEvaluationParameterDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApplicationEvaluationParameterDetailsComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(ApplicationEvaluationParameterDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
