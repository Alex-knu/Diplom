import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Application } from 'src/app/shared/models/application.model';
import { ApplicationToEstimators } from 'src/app/shared/models/applicationToEstimators.model';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { Evaluator } from 'src/app/shared/models/evaluator.model';
import { ProgramLanguage } from 'src/app/shared/models/programLanguage.model';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ApplicationToEstimatorsService } from 'src/app/shared/services/api/applicationToEstimators.service';
import { BaseApplicationService } from 'src/app/shared/services/api/baseApplication.service';
import { EstimatorService } from 'src/app/shared/services/api/estimator.service';
import { ApplicationInfoComponent } from '../application-info/application-info.component';

@Component({
  selector: 'app-application-table',
  templateUrl: './application-table.component.html',
  styleUrls: ['./application-table.component.scss']
})
export class ApplicationTableComponent {

  loading: boolean = false;
  applicationDialog: boolean;
  applications: BaseApplication[];
  application: BaseApplication;
  applicationToEstimators: ApplicationToEstimators;
  evaluators: Evaluator[];
  applicationToEstimatorsDialog: boolean;
  selectedApplications: BaseApplication[];
  submitted: boolean;
  programLanguages: ProgramLanguage[];
  selectedProgramLanguages: ProgramLanguage[];
  selectedEvaluators: Evaluator[];
  ref: DynamicDialogRef;

  constructor(
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private applicationToEstimatorsService: ApplicationToEstimatorsService,
    private baseApplicationService: BaseApplicationService,
    private estimatorService: EstimatorService,
    public dialogService: DialogService) { }

  ngOnInit() {
    this.loading = true;
    setTimeout(() => {
      this.baseApplicationService.collection.getAll()
        .subscribe(
          (applications) => {
            this.applications = applications;
          });

      this.loading = false;
    });
  }

  ngOnDestroy() {
    if (this.ref) {
      this.ref.close();
    }
  }

  editApplication(application: BaseApplication) {
    this.application = application;

    this.ref = this.dialogService.open(ApplicationInfoComponent, {
      header: 'Деталі заявки',
      data: application,
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true
    });

    this.ref.onClose.subscribe((application: BaseApplication) => {
      if (application && application.id) {
        this.applications[this.findIndexById(application.id)] = application;
        this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: application.name });
      }
    });
  }

  deleteApplication(application: Application) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + application.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        if (application.id) {
          this.baseApplicationService.single.deleteById(application.id).subscribe(
            application => {
              this.applications = this.applications.filter(val => val.id !== application.id);
              this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application Deleted' });
            },
            error => {
              this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
            })
        }
      }
    });
  }

  openNew() {
    this.ref = this.dialogService.open(ApplicationInfoComponent, {
      header: 'Деталі заявки',
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true
    });

    this.ref.onClose.subscribe((application: BaseApplication) => {
      if (application) {
        this.applications.push(application);
        this.messageService.add({ severity: 'info', summary: 'Product Selected', detail: application.name });
      }
    });
  }

  addEstimatorGroup(applicationId: number) {
    this.estimatorService.collection.getAll()
      .subscribe(
        (evaluators) => {
          evaluators.forEach((evaluator) => {
            evaluator.name = evaluator.firstName + ' ' + evaluator.lastName;
          });

          this.evaluators = evaluators;
        });

    this.applicationToEstimators = new ApplicationToEstimators();
    this.submitted = false;
    this.applicationToEstimatorsDialog = true;

    this.applicationToEstimators.applicationId = applicationId;
  }

  saveEstimatorGroup() {
    this.submitted = true;
    this.applicationToEstimators.evaluators = this.selectedEvaluators;

    this.applicationToEstimatorsService.single.create(this.applicationToEstimators).subscribe(
      () => {
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application created' })
        this.applicationToEstimatorsDialog = false;
      },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
      })
  }

  hideEstimatorGroupDialog() {
    this.applicationToEstimatorsDialog = false;
    this.submitted = false;
  }

  hideDialog() {
    this.applicationDialog = false;
    this.submitted = false;
  }

  redirectToEvaluationForm(applicationId: number) {
    this.router.navigate(['/application/application-evaluation'], { queryParams: { applicationId } });
  }

  findIndexById(id: number): number {
    let index = -1;
    for (let i = 0; i < this.applications.length; i++) {
      if (this.applications[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  }
}
