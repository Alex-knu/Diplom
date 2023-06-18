import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Application } from 'src/app/shared/models/application.model';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { BaseApplicationService } from 'src/app/shared/services/api/baseApplication.service';
import { ApplicationInfoComponent } from '../application-info/application-info.component';
import { ApplicationEvaluationGroupComponent } from '../application-evaluation-group/application-evaluation-group.component';
import { AuthService } from 'src/app/shared/services/auth.service';
import { ROLE_ADMIN, ROLE_EVALUATOR, ROLE_USER } from 'src/app/shared/constants';
import { CalculateApplicationService } from 'src/app/shared/services/api/calculateApplication.service';

@Component({
  selector: 'app-application-table',
  templateUrl: './application-table.component.html',
  styleUrls: ['./application-table.component.scss']
})
export class ApplicationTableComponent {
  admin = ROLE_ADMIN;
  evaluator = ROLE_EVALUATOR;
  user = ROLE_USER;

  loading: boolean = false;
  applications: BaseApplication[];
  application: BaseApplication;
  selectedApplications: BaseApplication[];
  ref: DynamicDialogRef;

  constructor(
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private calculateApplicationService: CalculateApplicationService,
    private baseApplicationService: BaseApplicationService,
    private dialogService: DialogService,
    private authService: AuthService) { }

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
        this.baseApplicationService.collection.getAll()
          .subscribe(
            (applications) => {
              this.applications = applications;
            });

        this.messageService.add({ severity: 'info', summary: 'Список оновлено', detail: application.name });
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
              this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку видалено' });
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
        this.messageService.add({ severity: 'info', summary: 'Список оновлено', detail: application.name });
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

  isVisible(role: string): boolean {
    return this.authService.checkRole(role);
  }

  calculate(applicationId: string) {
    this.calculateApplicationService.single.create({applicationId: applicationId}).subscribe(
    application => {

      this.baseApplicationService.collection.getAll()
          .subscribe(
            (applications) => {
              this.applications = applications;
            });

      this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку обраховано' });
    },
    error => {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
    })
  }
}
