import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FactorType } from 'src/app/shared/enums/factorType.enum';
import { EvaluationParametrsInfoService } from 'src/app/shared/services/api/evaluationParametrsInfo.service';
import { EvaluationParametrsInfo } from 'src/app/shared/models/evaluationParametrsInfo.model';
import { ApplicationToFactorsService } from 'src/app/shared/services/api/applicationToFactors.service';
import { ApplicationToFactors } from 'src/app/shared/models/applicationToFactors.model';
import { MessageService } from 'primeng/api';
import { HttpErrorResponse } from '@angular/common/http';
import { EvaluationApplication } from 'src/app/shared/models/evaluationApplication.model';
import { TokenService } from 'src/app/shared/services/core/token.service';

@Component({
  selector: 'app-application-evaluation',
  templateUrl: './application-evaluation.component.html',
  styleUrls: ['./application-evaluation.component.scss']
})

export class ApplicationEvaluationComponent {
  applicationId: number;
  evaluationApplication: EvaluationApplication;

  influenceEvaluationParametrsInfo: EvaluationParametrsInfo[];
  scaleEvaluationParametrsInfo: EvaluationParametrsInfo[];
  informationObjectEvaluationParametrsInfo: EvaluationParametrsInfo[];
  functionEvaluationParametrsInfo: EvaluationParametrsInfo[];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private messageService: MessageService,
    private evaluationParametrsInfoService: EvaluationParametrsInfoService,
    private applicationToFactorsService: ApplicationToFactorsService,
    private tokenService: TokenService) { }

  ngOnInit() {
    this.activatedRoute.queryParams
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

      this.evaluationApplication = new EvaluationApplication();
  }

  save() {
    var factors: ApplicationToFactors[] = [];
    this.influenceEvaluationParametrsInfo.forEach(factor => {
      var selectFactor = new ApplicationToFactors();
      selectFactor.id = 0;
      selectFactor.applicationId = this.applicationId;
      selectFactor.difficultyLevelsTypeToFactorTypeId = factor.selectDifficultyLevel.relationId;

      factors.push(selectFactor);
    });

    this.scaleEvaluationParametrsInfo.forEach(factor => {
      var selectFactor = new ApplicationToFactors();
      selectFactor.id = 0;
      selectFactor.applicationId = this.applicationId;
      selectFactor.difficultyLevelsTypeToFactorTypeId = factor.selectDifficultyLevel.relationId;

      factors.push(selectFactor);
    });

    this.evaluationApplication.userCreatorId = this.tokenService.getUserIdentifier();
    this.evaluationApplication.applicationToFactors = factors;

    this.applicationToFactorsService.single.create(this.evaluationApplication).subscribe(
      () => {
        this.router.navigate(['/application/application-table']);
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Оцінку збережено' });
      },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
      });
  }
}
