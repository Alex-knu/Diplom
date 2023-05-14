import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ApplicationTableComponent } from './application-table.component';

describe('ApplicationTableComponent', () => {
  let component: ApplicationTableComponent;
  let fixture: ComponentFixture<ApplicationTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApplicationTableComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(ApplicationTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
