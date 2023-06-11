import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
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

export class ApplicationEvaluationGroupComponent implements OnInit {
  applicationToEstimators: ApplicationToEstimators;
  evaluators: Evaluator[];
  selectedEvaluators: Evaluator[];

  constructor(
    private messageService: MessageService,
    private applicationToEstimatorsService: ApplicationToEstimatorsService,
    private estimatorService: EvaluatorService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig) { }

  ngOnInit() {
    setTimeout(() => {
    this.estimatorService.collection.getAll()
    .subscribe(
      (evaluators) => {
        evaluators.forEach((evaluator) => {
          evaluator.name = evaluator.firstName + ' ' + evaluator.lastName;
        });

        this.evaluators = evaluators;
      });

      this.applicationToEstimators = new ApplicationToEstimators();
      this.applicationToEstimators.applicationId = this.config.data.id;
    });
  }

  ngOnDestroy() {
    if (this.ref) {
      this.ref.close();
    }
  }

  addEstimatorGroup(applicationId: string) {
    this.applicationToEstimators = new ApplicationToEstimators();

    this.applicationToEstimators.applicationId = applicationId;
  }

  saveEstimatorGroup() {
    this.applicationToEstimators.evaluators = this.selectedEvaluators;

    this.applicationToEstimatorsService.single.create(this.applicationToEstimators).subscribe(
      () => {
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Групу назначено' });
        this.ref.close();
      },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
      })
  }
}
