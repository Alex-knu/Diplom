import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ApplicationEvaluationComponent } from './application-evaluation.component';

describe('ApplicationEvaluationComponent', () => {
  let component: ApplicationEvaluationComponent;
  let fixture: ComponentFixture<ApplicationEvaluationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApplicationEvaluationComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(ApplicationEvaluationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
