import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
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
  parameter: Parameter;
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

  editParameter(parameter: Parameter) {
    this.ref = this.dialogService.open(ApplicationEvaluationParameterInfoComponent, {
      header: 'Деталі параметра',
      data: {
        parameter: parameter, 
        applicationId: this.applicationId
      },
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true
    });

    this.ref.onClose.subscribe((parameter: Parameter) => {
      if (parameter && parameter.id) {
        this.parameterService.collection.getListById(this.applicationId)
        .subscribe(
          (parameters) => {
            this.parameters= parameters;
          });

        this.messageService.add({ severity: 'info', summary: 'Список оновлено', detail: parameter.name });
      }
    });
  }

  deleteParameter(parameter: Parameter) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + parameter.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        if (parameter.id) {
          this.parameterService.single.deleteById(parameter.id).subscribe(
            parameter => {
              this.parameters = this.parameters.filter(val => val.id !== parameter.id);
              this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Параметер видалено' });
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
      header: 'Деталі параметру',
      data: {
        applicationId: this.applicationId
      },
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true
    });

    this.ref.onClose.subscribe((parameter: Parameter) => {
      if (parameter && parameter.id) {
        this.parameterService.collection.getListById(this.applicationId)
        .subscribe(
          (parameters) => {
            this.parameters= parameters;
          });

        this.messageService.add({ severity: 'info', summary: 'Список оновлено', detail: parameter.name });
      }
    });
  }
}
