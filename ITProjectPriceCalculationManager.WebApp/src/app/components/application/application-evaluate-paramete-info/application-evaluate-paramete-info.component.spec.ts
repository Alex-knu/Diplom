import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ApplicationEvaluationParameterInfoComponent } from './application-evaluate-paramete-info.component';
describe('ApplicationEvaluationParameterInfoComponent', () => {
  let component: ApplicationEvaluationParameterInfoComponent;
  let fixture: ComponentFixture<ApplicationEvaluationParameterInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApplicationEvaluationParameterInfoComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(ApplicationEvaluationParameterInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
