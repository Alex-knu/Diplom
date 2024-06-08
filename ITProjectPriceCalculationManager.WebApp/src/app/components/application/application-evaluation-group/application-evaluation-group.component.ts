import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ApplicationToEstimators } from 'src/app/shared/models/applicationToEstimators.model';
import { Evaluator } from 'src/app/shared/models/evaluator.model';
import { ApplicationToEstimatorsService } from 'src/app/shared/services/api/applicationToEstimators.service';
import { EvaluatorService } from 'src/app/shared/services/api/estimator.service';

@Component({
  selector: 'app-application-evaluation-group',
  templateUrl: './application-evaluation-group.component.html',
  styleUrls: ['./application-evaluation-group.component.scss']
})
export class ApplicationEvaluationGroupComponent implements OnInit, OnDestroy {
  applicationToEstimators: ApplicationToEstimators = new ApplicationToEstimators();
  evaluators: Evaluator[] = [];
  selectedEvaluators: Evaluator[] = [];

  constructor(
    private messageService: MessageService,
    private applicationToEstimatorsService: ApplicationToEstimatorsService,
    private evaluatorService: EvaluatorService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig
  ) { }

  ngOnInit(): void {
    this.loadEvaluators();
    this.applicationToEstimators.applicationId = this.config.data.id;
  }

  ngOnDestroy(): void {
    if (this.ref) {
      this.ref.close();
    }
  }

  private loadEvaluators(): void {
    setTimeout(() => {
      this.evaluatorService.collection.getAll().subscribe(
        evaluators => {
          this.evaluators = evaluators.map(evaluator => ({
            ...evaluator,
            name: `${evaluator.firstName} ${evaluator.lastName}`
          }));
        },
        error => this.handleError(error)
      );
    });
  }

  addEstimatorGroup(applicationId: string): void {
    this.applicationToEstimators = new ApplicationToEstimators();
    this.applicationToEstimators.applicationId = applicationId;
  }

  saveEstimatorGroup(): void {
    this.applicationToEstimators.evaluators = this.selectedEvaluators;

    this.applicationToEstimatorsService.single.create(this.applicationToEstimators).subscribe(
      () => {
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Групу назначено' });
        this.ref.close();
      },
      error => this.handleError(error)
    );
  }

  private handleError(error: HttpErrorResponse): void {
    this.messageService.add({ severity: 'error', summary: 'Error', detail: String(error.error).split('\n')[0] });
  }
}
