import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { UUID } from 'angular2-uuid';
import { ParameterValue } from '../../../shared/models/parameterValue.model';
import { EvaluateParameter } from '../../../shared/models/evaluateParameter.model';
import { EvaluateParameterService } from '../../../shared/services/api/evaluateParameter.service';
import { belongingFunctions } from '../../../shared/constants';

@Component({
  selector: 'application-evaluation-parameter-info',
  templateUrl: './application-evaluation-parameter-info.component.html',
  styleUrls: ['./application-evaluation-parameter-info.component.scss']
})
export class ApplicationEvaluationParameterDetailsComponent implements OnInit {
  protected readonly belongingFunctions = belongingFunctions;
  submitted = false;
  evaluateParameter: EvaluateParameter;

  constructor(
    private messageService: MessageService,
    private evaluateParameterService: EvaluateParameterService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig
  ) {}

  ngOnInit(): void {
    this.initializeEvaluateParameter();
  }

  private initializeEvaluateParameter(): void {
    this.evaluateParameter = this.config.data.evaluateParameter || new EvaluateParameter();
    if (!this.evaluateParameter.evaluateParameterValue) {
      this.evaluateParameter.evaluateParameterValue = new ParameterValue();
    }
  }

  saveEvaluateParameter(): void {
    this.submitted = true;

    if (this.evaluateParameter.id) {
      this.updateEvaluateParameter();
    } else {
      this.createEvaluateParameter();
    }
  }

  private updateEvaluateParameter(): void {
    this.evaluateParameterService.single.update(this.evaluateParameter).subscribe(
      parameter => {
        this.showMessage('success', 'Successful', 'Параметер оновлено');
        this.ref.close(parameter);
      },
      error => this.handleError(error)
    );
  }

  private createEvaluateParameter(): void {
    this.evaluateParameter.id = UUID.UUID();
    this.evaluateParameter.parameterId = this.config.data.parameterId;
    this.evaluateParameter.evaluateParameterValue.id = this.evaluateParameter.id;

    this.evaluateParameterService.single.create(this.evaluateParameter).subscribe(
      parameter => {
        this.showMessage('success', 'Successful', 'Заявку створено');
        this.ref.close(parameter);
      },
      error => {
        this.evaluateParameter.id = null;
        this.handleError(error);
      }
    );
  }

  private showMessage(severity: string, summary: string, detail: string): void {
    this.messageService.add({ severity, summary, detail });
  }

  private handleError(error: HttpErrorResponse): void {
    this.showMessage('error', 'Error', String(error.error).split('\n')[0]);
  }
}
