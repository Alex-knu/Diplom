import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ApplicationEvaluationParameterInfoComponent } from '../application-evaluate-paramete-info/application-evaluate-paramete-info.component';
import { ParameterService } from 'src/app/shared/services/api/parameter.service';
import { Parameter } from 'src/app/shared/models/parameter.model';
import { EvaluateParameterService } from "../../../shared/services/api/evaluateParameter.service";
import { belongingFunctions } from "../../../shared/constants";
import { EvaluateParameter } from "../../../shared/models/evaluateParameter.model";
import {
  ApplicationEvaluationParameterDetailsComponent
} from "../application-evaluation-paramete-info/application-evaluation-parameter-info.component";

@Component({
  selector: 'application-evaluate-paramete-table',
  templateUrl: './application-evaluate-paramete-table.component.html',
  styleUrls: ['./application-evaluate-paramete-table.component.scss']
})
export class ApplicationEvaluationParameterTableComponent implements OnInit, OnDestroy {
  loading = false;
  applicationId: string;
  parameters: Parameter[] = [];
  parameter: Parameter;
  selectedApplications: BaseApplication[] = [];
  ref: DynamicDialogRef;

  constructor(
    private activatedRoute: ActivatedRoute,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private parameterService: ParameterService,
    private evaluateParameterService: EvaluateParameterService,
    private dialogService: DialogService
  ) {}

  ngOnInit() {
    this.loading = true;
    this.activatedRoute.queryParams.subscribe(params => {
      this.applicationId = params['applicationId'];
      this.loadParameters();
    });
  }

  ngOnDestroy() {
    if (this.ref) {
      this.ref.close();
    }
  }

  private loadParameters() {
    this.parameterService.collection.getListById(this.applicationId).subscribe(
      parameters => {
        this.parameters = parameters;
        this.loading = false;
      },
      error => this.loading = false
    );
  }

  editParameter(parameter: Parameter) {
    this.ref = this.dialogService.open(ApplicationEvaluationParameterInfoComponent, {
      header: 'Деталі параметра',
      data: { parameter, applicationId: this.applicationId },
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true
    });

    this.ref.onClose.subscribe((updatedParameter: Parameter) => {
      if (updatedParameter && updatedParameter.id) {
        this.loadParameters();
        this.messageService.add({ severity: 'info', summary: 'Список оновлено', detail: updatedParameter.name });
      }
    });
  }

  deleteParameter(parameter: Parameter) {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete ${parameter.name}?`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        if (parameter.id) {
          this.parameterService.single.deleteById(parameter.id).subscribe(
            () => {
              this.parameters = this.parameters.filter(val => val.id !== parameter.id);
              this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Параметер видалено' });
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
    this.ref = this.dialogService.open(ApplicationEvaluationParameterInfoComponent, {
      header: 'Деталі параметру',
      data: { applicationId: this.applicationId },
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true
    });

    this.ref.onClose.subscribe((newParameter: Parameter) => {
      if (newParameter && newParameter.id) {
        this.loadParameters();
        this.messageService.add({ severity: 'info', summary: 'Список оновлено', detail: newParameter.name });
      }
    });
  }

  getEvaluationParameters(parameter: Parameter) {
    if (parameter.id) {
      this.loading = true;
      this.evaluateParameterService.collection.getListById(parameter.id).subscribe(
        evaluationParameters => {
          parameter.evaluationParameters = evaluationParameters;
          this.loading = false;
        },
        () => this.loading = false
      );
    }
  }

  addParameterInfo(parameterId: string) {
    this.ref = this.dialogService.open(ApplicationEvaluationParameterDetailsComponent, {
      header: 'Деталі параметру',
      data: { parameterId },
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true
    });

    if (parameterId) {
      this.evaluateParameterService.collection.getListById(parameterId).subscribe(
        evaluationParameters => {
          this.parameter.evaluationParameters = evaluationParameters;
        }
      );
    }
  }

  editParameterInfo(evaluateParameter: EvaluateParameter) {
    this.ref = this.dialogService.open(ApplicationEvaluationParameterDetailsComponent, {
      header: 'Деталі параметра',
      data: { evaluateParameter },
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true
    });

    this.ref.onClose.subscribe((updatedEvaluateParameter: EvaluateParameter) => {
      if (updatedEvaluateParameter && updatedEvaluateParameter.id) {
        this.evaluateParameterService.collection.getListById(this.applicationId).subscribe(
          parameters => {
            this.parameters = parameters;
            this.messageService.add({ severity: 'info', summary: 'Список оновлено', detail: updatedEvaluateParameter.name });
          }
        );
      }
    });
  }

  deleteParameterInfo(parameter: Parameter, evaluateParameter: EvaluateParameter) {
    this.confirmationService.confirm({
      message: `Are you sure you want to delete ${evaluateParameter.name}?`,
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        if (evaluateParameter.id) {
          this.evaluateParameterService.single.deleteById(evaluateParameter.id).subscribe(
            () => {
              parameter.evaluationParameters = parameter.evaluationParameters.filter(val => val.id !== evaluateParameter.id);
              this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Параметер видалено' });
            },
            (error: HttpErrorResponse) => {
              this.messageService.add({ severity: 'error', summary: 'Error', detail: error.error.split('\n')[0] });
            }
          );
        }
      }
    });
  }

  getBelongingFunctionsNameById(belongingFunctionId: string) {
    return belongingFunctions.find(bf => bf.id === belongingFunctionId)?.name;
  }
}
