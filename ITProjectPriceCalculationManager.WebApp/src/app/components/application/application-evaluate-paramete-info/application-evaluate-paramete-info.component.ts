import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { UUID } from 'angular2-uuid';
import { Parameter } from 'src/app/shared/models/parameter.model';
import { ParameterService } from 'src/app/shared/services/api/parameter.service';
import { belongingFunctions } from "../../../shared/constants";

@Component({
  selector: 'application-evaluate-paramete-info',
  templateUrl: './application-evaluate-paramete-info.component.html',
  styleUrls: ['./application-evaluate-paramete-info.component.scss']
})
export class ApplicationEvaluationParameterInfoComponent implements OnInit {
  submitted = false;
  applicationId: string;
  parameter: Parameter;

  protected readonly belongingFunctions = belongingFunctions;

  constructor(
    private messageService: MessageService,
    private parameterService: ParameterService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig
  ) {}

  ngOnInit(): void {
    this.applicationId = this.config.data.applicationId;
    this.parameter = this.config.data.parameter ?? new Parameter();
  }

  saveParameter(): void {
    this.submitted = true;

    if (this.parameter.id) {
      this.updateParameter();
    } else {
      this.createParameter();
    }
  }

  private updateParameter(): void {
    this.parameterService.single.update(this.parameter).subscribe(
      parameter => {
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Параметер оновлено' });
        this.ref.close(parameter);
      },
      error => this.handleError(error)
    );
  }

  private createParameter(): void {
    this.parameter.id = UUID.UUID();
    this.parameter.applicationId = this.config.data.applicationId;

    this.parameterService.single.create(this.parameter).subscribe(
      parameter => {
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку створено' });
        this.ref.close(parameter);
      },
      error => {
        this.parameter.id = null;
        this.handleError(error);
      }
    );
  }

  private handleError(error: HttpErrorResponse): void {
    this.messageService.add({ severity: 'error', summary: 'Error', detail: String(error.error).split('\n')[0] });
  }
}
