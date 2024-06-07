import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { MessageService, ConfirmationService } from 'primeng/api';
import {DialogService, DynamicDialogConfig, DynamicDialogRef} from 'primeng/dynamicdialog';
import {UUID} from "angular2-uuid";
import {ParameterValue} from "../../../shared/models/parameterValue.model";
import {EvaluateParameter} from "../../../shared/models/evaluateParameter.model";
import {EvaluateParameterService} from "../../../shared/services/api/evaluateParameter.service";
import {belongingFunctions} from "../../../shared/constants";

@Component({
  selector: 'application-evaluation-parameter-info',
  templateUrl: './application-evaluation-parameter-info.component.html',
  styleUrls: ['./application-evaluation-parameter-info.component.scss']
})
export class ApplicationEvaluationParameterDetalesComponent {
  protected readonly belongingFunctions = belongingFunctions;

  submitted: boolean;
  evaluateParameter: EvaluateParameter;

  constructor(
    private messageService: MessageService,
    private evaluateParameterService: EvaluateParameterService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig) { }

  ngOnInit(): void {
    this.submitted = false;

    if (this.config.data.evaluateParameter) {
      this.evaluateParameter = this.config.data.evaluateParameter;
    }
    else {
      this.evaluateParameter = new EvaluateParameter();
    }

    if(!this.evaluateParameter.parameterValue)
    {
      this.evaluateParameter.parameterValue = new ParameterValue();
    }
  }

  saveEvaluateParameter() {
    this.submitted = true;

    if (this.evaluateParameter.id) {
      this.evaluateParameterService.single.update(this.evaluateParameter).subscribe(
        parameter => {
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Параметер оновлено' });
          this.ref.close(parameter);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
    else {
      this.evaluateParameter.id = UUID.UUID();
      this.evaluateParameter.parameterId = this.config.data.parameterId;
      this.evaluateParameter.parameterValue.id = this.evaluateParameter.id;
      this.evaluateParameterService.single.create(this.evaluateParameter).subscribe(
        parameter => {
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку створено' });
          this.ref.close(parameter);
        },
        error => {
          this.evaluateParameter.id = null;
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
  }
}
