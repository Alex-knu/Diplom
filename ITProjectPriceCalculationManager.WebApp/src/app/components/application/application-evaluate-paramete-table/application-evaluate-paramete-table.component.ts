import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Application } from 'src/app/shared/models/application.model';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { BaseApplicationService } from 'src/app/shared/services/api/baseApplication.service';
import { AuthService } from 'src/app/shared/services/auth.service';
import { CalculateApplicationService } from 'src/app/shared/services/api/calculateApplication.service';
import { ApplicationEvaluationParameterInfoComponent } from '../application-evaluate-paramete-info/application-evaluate-paramete-info.component';
import { ParameterService } from 'src/app/shared/services/api/parameter.service';
import { Parameter } from 'src/app/shared/models/parameter.model';

@Component({
  selector: 'application-evaluate-paramete-table',
  templateUrl: './application-evaluate-paramete-table.component.html',
  styleUrls: ['./application-evaluate-paramete-table.component.scss']
})
export class ApplicationEvaluationParameterTableComponent {
  loading: boolean = false;
  applicationId: string;
  parameters: Parameter[];
  applications: BaseApplication[];
  application: BaseApplication;
  selectedApplications: BaseApplication[];
  ref: DynamicDialogRef;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private calculateApplicationService: CalculateApplicationService,
    private parameterService: ParameterService,
    private baseApplicationService: BaseApplicationService,
    private dialogService: DialogService,
    private authService: AuthService) { }

  ngOnInit() {
    this.loading = true;
    this.activatedRoute.queryParams
      .subscribe(params => {
        this.applicationId = params['applicationId'];
      });

    setTimeout(() => {
      this.parameterService.collection.getListById(this.applicationId)
        .subscribe(
          (parameters) => {
            this.parameters= parameters;
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

    this.ref = this.dialogService.open(ApplicationEvaluationParameterInfoComponent, {
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
    this.ref = this.dialogService.open(ApplicationEvaluationParameterInfoComponent, {
      header: 'Деталі заявки',
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
}
