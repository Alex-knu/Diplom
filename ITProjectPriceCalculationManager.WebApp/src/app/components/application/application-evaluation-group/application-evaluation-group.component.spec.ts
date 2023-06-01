import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ApplicationEvaluationGroupComponent } from './application-evaluation-group.component';

describe('ApplicationEvaluationGroupComponent', () => {
  let component: ApplicationEvaluationGroupComponent;
  let fixture: ComponentFixture<ApplicationEvaluationGroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApplicationEvaluationGroupComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(ApplicationEvaluationGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
