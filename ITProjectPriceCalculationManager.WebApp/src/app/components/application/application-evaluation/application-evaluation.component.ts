import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FactorType } from 'src/app/shared/enums/factorType.enum';
import { EvaluationParametrsInfoService } from 'src/app/shared/services/api/evaluationParametrsInfo.service';
import { EvaluationParametrsInfo } from 'src/app/shared/models/evaluationParametrsInfo.model';

@Component({
  selector: 'app-application-evaluation',
  templateUrl: './application-evaluation.component.html',
  styleUrls: ['./application-evaluation.component.scss']
})

export class ApplicationEvaluationComponent {
  applicationId: number;

  influenceEvaluationParametrsInfo: EvaluationParametrsInfo[];
  scaleEvaluationParametrsInfo: EvaluationParametrsInfo[];
  informationObjectEvaluationParametrsInfo: EvaluationParametrsInfo[];
  functionEvaluationParametrsInfo: EvaluationParametrsInfo[];

  constructor(
    private route: ActivatedRoute,
    private evaluationParametrsInfoService: EvaluationParametrsInfoService) { }

  ngOnInit() {
    this.route.queryParams
      .subscribe(params => {
        this.applicationId = params['applicationId'];
      });

    this.evaluationParametrsInfoService.collection.getAll()
      .subscribe(evaluationParametrsInfo => {
        this.influenceEvaluationParametrsInfo = evaluationParametrsInfo.filter(info => info.factorTypeId == FactorType.InfluenceFactors);
        this.scaleEvaluationParametrsInfo = evaluationParametrsInfo.filter(info => info.factorTypeId == FactorType.ScaleFactors);
        this.informationObjectEvaluationParametrsInfo = evaluationParametrsInfo.filter(info => info.factorTypeId == FactorType.InformationObject);
        this.functionEvaluationParametrsInfo = evaluationParametrsInfo.filter(info => info.factorTypeId == FactorType.Function);
      });
  }

  save() { }
}
