import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { BaseApplicationService } from 'src/app/shared/services/api/baseApplication.service';
import { ProgramLanguage } from "../../../shared/models/programLanguage.model";
import { ProgramLanguageService } from "../../../shared/services/api/programLanguage.service";
import { UUID } from "angular2-uuid";
import {ParameterService} from "../../../shared/services/api/parameter.service";
import {Parameter} from "../../../shared/models/parameter.model";

@Component({
  selector: 'app-estimator-parameters',
  templateUrl: './estimator-parameters.component.html',
  styleUrls: ['./estimator-parameters.component.scss']
})

export class EstimatorParametersComponent implements OnInit {
  application: BaseApplication;
  programLanguages: ProgramLanguage[];
  parameters: Parameter[];
  loading = false;

  constructor(
    private messageService: MessageService,
    private baseApplicationService: BaseApplicationService,
    private programLanguageService: ProgramLanguageService,
    private parameterService: ParameterService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig) { }

  ngOnInit(): void {
    this.parameterService.collection.getListById(this.config.data.id).subscribe(
      parameters => {
        this.parameters = parameters;
        this.loading = false;
      },
      error => this.loading = false
    );
  }

  calculateConfidenceArea() {
    // this.submitted = true;
    //
    // if (this.application.id) {
    //   this.baseApplicationService.single.update(this.application).subscribe(
    //     application => {
    //       this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку оновлено' });
    //       this.ref.close(application);
    //     },
    //     error => {
    //       this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
    //     })
    // }
    // else {
    //   this.application.id = UUID.UUID();
    //   this.application.price = 0;
    //   this.application.statusId = "4706D234-E64D-4AB2-BED0-6086E10C3325";
    //   this.baseApplicationService.single.create(this.application).subscribe(
    //     application => {
    //       this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку створено' });
    //       this.ref.close(application);
    //     },
    //     error => {
    //       this.application.id = null;
    //       this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
    //     })
    // }
  }
}
