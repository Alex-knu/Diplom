import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { BaseApplicationService } from 'src/app/shared/services/api/baseApplication.service';
import { ApplicationInfoComponent } from '../application-info/application-info.component';
import { ApplicationEvaluationGroupComponent } from '../application-evaluation-group/application-evaluation-group.component';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ROLE_ADMIN, ROLE_EVALUATOR, ROLE_USER } from 'src/app/shared/constants';
import { CalculateApplicationService } from 'src/app/shared/services/api/calculateApplication.service';
import { ApplicationToEstimatorsService } from 'src/app/shared/services/api/applicationToEstimators.service';
import {EstimatorParametersComponent} from "../estimator-parameters/estimator-parameters.component";

@Component({
  selector: 'app-application-table',
  templateUrl: './application-table.component.html',
  styleUrls: ['./application-table.component.scss']
})
export class ApplicationTableComponent implements OnInit, OnDestroy {
  readonly admin = ROLE_ADMIN;
  readonly evaluator = ROLE_EVALUATOR;
  readonly user = ROLE_USER;

  loading = false;
  applications: BaseApplication[];
  application: BaseApplication;
  selectedApplications: BaseApplication[];
  ref: DynamicDialogRef;

  constructor(
    private applicationToEstimatorsService: ApplicationToEstimatorsService,
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private calculateApplicationService: CalculateApplicationService,
    private baseApplicationService: BaseApplicationService,
    private dialogService: DialogService,
    private authService: AuthService) { }

  ngOnInit() {
    this.loadApplications();
  }

  ngOnDestroy() {
    if (this.ref) {
      this.ref.close();
    }
  }

  private loadApplications() {
    this.loading = true;
    this.baseApplicationService.collection.getAll().subscribe(
      applications => {
        this.applications = applications;
        this.loading = false;
      },
      () => this.loading = false
    );
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

    this.ref.onClose.subscribe((updatedApplication: BaseApplication) => {
      if (updatedApplication?.id) {
        this.loadApplications();
        this.messageService.add({ severity: 'info', summary: 'Список оновлено', detail: updatedApplication.name });
      }
    });
  }

  deleteApplication(application: BaseApplication) {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete ${application.name}?`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        if (application.id) {
          this.baseApplicationService.single.deleteById(application.id).subscribe(
            () => {
              this.applications = this.applications.filter(val => val.id !== application.id);
              this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку видалено' });
            },
            (error: HttpErrorResponse) => {
              this.messageService.add({ severity: 'error', summary: 'Error', detail: error.error.split('\n')[0] });
            }
          );
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

    this.ref.onClose.subscribe((newApplication: BaseApplication) => {
      if (newApplication?.id) {
        this.loadApplications();
        this.messageService.add({ severity: 'info', summary: 'Список оновлено', detail: newApplication.name });
      }
    });
  }

  addEstimatorGroup(applicationId: string) {
    this.ref = this.dialogService.open(ApplicationEvaluationGroupComponent, {
      header: 'Група експертів',
      data: { id: applicationId },
      width: '20%',
      height: '35%',
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true
    });
  }

  redirectToEvaluationForm(applicationId: string) {
    this.router.navigate(['/application/application-evaluation'], { queryParams: { applicationId } });
  }

  redirectToEvaluationParameterForm(applicationId: string) {
    this.router.navigate(['/application/application-evaluate-paramete-table'], { queryParams: { applicationId } });
  }

  isVisible(role: string): boolean {
    return this.authService.checkRole(role);
  }

  calculate(applicationId: string) {
    this.calculateApplicationService.single.create({ applicationId }).subscribe(
      () => {
        this.loadApplications();
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку обраховано' });
      },
      (error: HttpErrorResponse) => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: error.error.split('\n')[0] });
      }
    );
  }

  getEvaluationGroup(application: BaseApplication) {
    if (application.id) {
      this.loading = true;
      this.applicationToEstimatorsService.collection.getListById(application.id).subscribe(
        evaluationGroup => {
          application.evaluationGroup = evaluationGroup;
          this.loading = false;
        },
        () => this.loading = false
      );
    }
  }

  setEvaluatorParameters(applicationId: string, evaluatorId: string) {
      this.ref = this.dialogService.open(EstimatorParametersComponent, {
        header: 'Деталі заявки',
        data: {
          applicationId: applicationId,
          evaluatorId: evaluatorId
        },
        contentStyle: { overflow: 'auto' },
        baseZIndex: 10000,
        maximizable: true
      });
    }
}
