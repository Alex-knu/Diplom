import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DifficultyLevelsType } from 'src/app/shared/models/difficultyLevelsType.model';
import { DifficultyLevelsType as DifficultyLevelsTypeEnum } from 'src/app/shared/enums/difficultyLevelsType.enum';
import { DifficultyLevelsTypeService } from 'src/app/shared/services/api/difficultyLevelsType.service';
import { FactorType } from 'src/app/shared/enums/factorType.enum';

@Component({
  selector: 'app-application-evaluation',
  templateUrl: './application-evaluation.component.html',
  styleUrls: ['./application-evaluation.component.scss']
})

export class ApplicationEvaluationComponent {
  applicationId: number;
  selectedCity: any;
  influenceFactors: DifficultyLevelsType[];
  scaleFactors: DifficultyLevelsType[];
  informationObject: DifficultyLevelsType[];
  function: DifficultyLevelsType[];

  constructor(
    private route: ActivatedRoute,
    private difficultyLevelsTypeService: DifficultyLevelsTypeService) { }

  ngOnInit() {
    this.route.queryParams
      .subscribe(params => {
        this.applicationId = params['applicationId'];
      });

    this.difficultyLevelsTypeService.collection.getListById(FactorType.InfluenceFactors)
      .subscribe(factors => {
        this.influenceFactors = factors;
      });

    this.difficultyLevelsTypeService.collection.getListById(FactorType.ScaleFactors)
      .subscribe(factors => {
        this.scaleFactors = factors;
      });

    this.difficultyLevelsTypeService.collection.getListById(FactorType.InformationObject)
      .subscribe(factors => {
        this.informationObject = factors;
      });

    this.difficultyLevelsTypeService.collection.getListById(FactorType.Function)
      .subscribe(factors => {
        this.function = factors;
      });
  }

  save() { }
}
