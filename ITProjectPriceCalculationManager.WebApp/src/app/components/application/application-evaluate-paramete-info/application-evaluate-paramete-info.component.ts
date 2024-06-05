import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { UUID } from 'angular2-uuid';
import { ProgramLanguage } from 'src/app/shared/models/programLanguage.model';
import { Parameter } from 'src/app/shared/models/parameter.model';
import { ParameterService } from 'src/app/shared/services/api/parameter.service';

@Component({
  selector: 'application-evaluate-paramete-info',
  templateUrl: './application-evaluate-paramete-info.component.html',
  styleUrls: ['./application-evaluate-paramete-info.component.scss']
})
export class ApplicationEvaluationParameterInfoComponent implements OnInit {
  submitted: boolean;
  applicationId: string;
  parameter: Parameter;

  constructor(
    private messageService: MessageService,
    private parameterService: ParameterService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig) { }

  ngOnInit(): void {
    this.submitted = false;

    this.applicationId = this.config.data.applicationId;

    if (this.config.data.parameter != null) {
      this.parameter = this.config.data.parameter;
    }
    else {
      this.parameter = new Parameter();
    }
  }

  saveParameter() {
    this.submitted = true;

    if (this.parameter.id) {
      this.parameterService.single.update(this.parameter).subscribe(
        parameter => {
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Параметер оновлено' });
          this.ref.close(parameter);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
    else {
      this.parameter.id = UUID.UUID();
      this.parameter.applicationId = this.config.data.applicationId;
      this.parameterService.single.create(this.parameter).subscribe(
        parameter => {
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку створено' });
          this.ref.close(parameter);
        },
        error => {
          this.parameter.id = null;
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
  }
}