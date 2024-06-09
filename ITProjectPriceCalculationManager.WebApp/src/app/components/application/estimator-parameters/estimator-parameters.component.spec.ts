import { ComponentFixture, TestBed } from '@angular/core/testing';
import {EstimatorParametersComponent} from "./estimator-parameters.component";

describe('EstimatorParametersComponent', () => {
  let component: EstimatorParametersComponent;
  let fixture: ComponentFixture<EstimatorParametersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EstimatorParametersComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(EstimatorParametersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
