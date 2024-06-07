import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ApplicationEvaluationParameterDetalesComponent } from './application-evaluation-parameter-info.component';

describe('ApplicationEvaluationParameterDetalesComponent', () => {
  let component: ApplicationEvaluationParameterDetalesComponent;
  let fixture: ComponentFixture<ApplicationEvaluationParameterDetalesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApplicationEvaluationParameterDetalesComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(ApplicationEvaluationParameterDetalesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
