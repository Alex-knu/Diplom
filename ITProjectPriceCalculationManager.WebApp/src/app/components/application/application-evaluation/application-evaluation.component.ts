import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FactorType } from 'src/app/shared/enums/factorType.enum';
import { EvaluationParametrsInfoService } from 'src/app/shared/services/api/evaluationParametrsInfo.service';
import { EvaluationParametrsInfo } from 'src/app/shared/models/itProjectsManager/evaluationParametrsInfo.model';
import { ApplicationToFactorsService } from 'src/app/shared/services/api/applicationToFactors.service';
import { ApplicationToFactors } from 'src/app/shared/models/itProjectsManager/applicationToFactors.model';
import { MessageService } from 'primeng/api';
import { HttpErrorResponse } from '@angular/common/http';
import { EvaluationApplication } from 'src/app/shared/models/itProjectsManager/evaluationApplication.model';
import { UUID } from 'angular2-uuid';
import { ProgramLanguageService } from 'src/app/shared/services/api/programLanguage.service';
import { ProgramsParametr } from 'src/app/shared/models/itProjectsManager/programsParametr.model';
import { ProgramsEvaluationInfo } from 'src/app/shared/models/itProjectsManager/programsEvaluationInfo.model';

@Component({
  selector: 'app-application-evaluation',
  templateUrl: './application-evaluation.component.html',
  styleUrls: ['./application-evaluation.component.scss']
})

export class ApplicationEvaluationComponent {
  applicationId: string;
  evaluationApplication: EvaluationApplication;

  influenceEvaluationParametrsInfo: EvaluationParametrsInfo[];
  scaleEvaluationParametrsInfo: EvaluationParametrsInfo[];
  informationObjectEvaluationParametrsInfo: EvaluationParametrsInfo[];
  functionEvaluationParametrsInfo: EvaluationParametrsInfo[];
  programsParametrs: ProgramsParametr[];

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private messageService: MessageService,
    private evaluationParametrsInfoService: EvaluationParametrsInfoService,
    private applicationToFactorsService: ApplicationToFactorsService,
    private programLanguageService: ProgramLanguageService) { }

  ngOnInit() {
    this.evaluationParametrsInfoService.collection.getAll()
      .subscribe(evaluationParametrsInfo => {
        this.influenceEvaluationParametrsInfo = evaluationParametrsInfo.filter(info => info.factorTypeId == FactorType.InfluenceFactors);
        this.scaleEvaluationParametrsInfo = evaluationParametrsInfo.filter(info => info.factorTypeId == FactorType.ScaleFactors);
        this.informationObjectEvaluationParametrsInfo = evaluationParametrsInfo.filter(info => info.factorTypeId == FactorType.InformationObject);
        this.functionEvaluationParametrsInfo = evaluationParametrsInfo.filter(info => info.factorTypeId == FactorType.Function);

        this.activatedRoute.queryParams
          .subscribe(params => {
            this.applicationId = params['applicationId'];
            this.programLanguageService.collection.getListById(this.applicationId)
              .subscribe(programsParametrs => {
                this.programsParametrs = programsParametrs;
                this.programsParametrs.forEach(programsParametr => {
                  programsParametr.functionEvaluationParametrsInfo = this.functionEvaluationParametrsInfo;
                  programsParametr.informationObjectEvaluationParametrsInfo = this.informationObjectEvaluationParametrsInfo;
                });
              });
          });
      });

    this.evaluationApplication = new EvaluationApplication();
    this.evaluationApplication.applicationToFactors = [];
    this.evaluationApplication.programInfo = [];
  }

  save() {
    this.influenceEvaluationParametrsInfo.forEach(factor => {
      var selectFactor = new ApplicationToFactors(this.applicationId, factor.selectDifficultyLevel.relationId);
      selectFactor.id = UUID.UUID();

      this.evaluationApplication.applicationToFactors.push(selectFactor);
    });

    this.scaleEvaluationParametrsInfo.forEach(factor => {
      var selectFactor = new ApplicationToFactors(this.applicationId, factor.selectDifficultyLevel.relationId);
      selectFactor.id = UUID.UUID();

      this.evaluationApplication.applicationToFactors.push(selectFactor);
    });

    this.programsParametrs.forEach(programsParametr => {
      var programsEvaluationInfo = new ProgramsEvaluationInfo();

      programsEvaluationInfo.id = programsParametr.id;
      programsEvaluationInfo.applicationToFactors = [];

      programsParametr.informationObjectEvaluationParametrsInfo
        .map(parametr => parametr.difficultyLevels
          .map(difficultyLevel => new ApplicationToFactors(this.applicationId, difficultyLevel.relationId, difficultyLevel.value, UUID.UUID())))
        .forEach(param => {
          programsEvaluationInfo.applicationToFactors = [...programsEvaluationInfo.applicationToFactors, ...param];
        });

      programsParametr.functionEvaluationParametrsInfo
        .map(parametr => parametr.difficultyLevels
          .map(difficultyLevel => new ApplicationToFactors(this.applicationId, difficultyLevel.relationId, difficultyLevel.value, UUID.UUID())))
        .forEach(param => {
          programsEvaluationInfo.applicationToFactors = [...programsEvaluationInfo.applicationToFactors, ...param];
        });

      this.evaluationApplication.programInfo.push(programsEvaluationInfo);
    });

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
