import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { BaseApplication } from 'src/app/shared/models/itProjectsManager/baseApplication.model';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import {ParameterService} from "../../../shared/services/api/parameter.service";
import {Parameter} from "../../../shared/models/fuzzyLogic/parameter.model";
import {
  EvaluatorFuzzyCalculatorManagerService
} from "../../../shared/services/api/evaluatorFuzzyCalculatorManager.service";
import {CalculateConfidenceArea} from "../../../shared/models/itProjectsManager/calculateConfidenceArea.model";
import {EvaluationCompetentValue} from "../../../shared/models/itProjectsManager/evaluationCompetentValueDTO.model";

@Component({
  selector: 'app-estimator-parameters',
  templateUrl: './estimator-parameters.component.html',
  styleUrls: ['./estimator-parameters.component.scss']
})

export class EstimatorParametersComponent implements OnInit {
  application: BaseApplication;
  parameters: Parameter[];
  loading = false;

  constructor(
    private messageService: MessageService,
    private evaluatorFuzzyCalculatorManagerService: EvaluatorFuzzyCalculatorManagerService,
    private parameterService: ParameterService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig) { }

  ngOnInit(): void {
    this.parameterService.collection.getListById(this.config.data.applicationId).subscribe(
      parameters => {
        this.parameters = parameters;
        this.loading = false;
      },
      error => this.loading = false
    );
  }

  calculateConfidenceArea() {
    let evaluationCompetentValues: EvaluationCompetentValue[] = [];
    let calculateConfidenceArea = new CalculateConfidenceArea();

    calculateConfidenceArea.applicationId = this.config.data.applicationId;
    calculateConfidenceArea.evaluatorId = this.config.data.evaluatorId;

    for(let i = 0; i < this.parameters.length; i++){
      let evaluationCompetentValue = new EvaluationCompetentValue();

      evaluationCompetentValue.evaluationParameterId = this.parameters[i].id;
      evaluationCompetentValue.value = this.parameters[i].value;

      evaluationCompetentValues.push(evaluationCompetentValue);
    }

    calculateConfidenceArea.evaluationCompetentValues = evaluationCompetentValues;

    this.evaluatorFuzzyCalculatorManagerService.single.create(calculateConfidenceArea).subscribe(
      application => {
        this.messageService.add({ severity: 'info', summary: 'Successful', detail: 'Заявку оновлено' });
        this.ref.close(application);
      },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
      });
  }
}
