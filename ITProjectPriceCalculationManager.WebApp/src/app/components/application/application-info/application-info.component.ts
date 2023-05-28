import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ApplicationToEstimators } from 'src/app/shared/models/applicationToEstimators.model';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { Evaluator } from 'src/app/shared/models/evaluator.model';
import { ProgramLanguage } from 'src/app/shared/models/programLanguage.model';
import { BaseApplicationService } from 'src/app/shared/services/api/baseApplication.service';
import { ProgramLanguageService } from 'src/app/shared/services/api/programLanguage.service';
import { TokenService } from 'src/app/shared/services/core/token.service';

@Component({
  selector: 'app-application-info',
  templateUrl: './application-info.component.html',
  styleUrls: ['./application-info.component.scss']
})

export class ApplicationInfoComponent implements OnInit {
  loading: boolean = false;
  applicationDialog: boolean;
  applications: BaseApplication[];
  application: BaseApplication;
  applicationToEstimators: ApplicationToEstimators;
  evaluators: Evaluator[];
  applicationToEstimatorsDialog: boolean;
  selectedApplications: BaseApplication[];
  submitted: boolean;
  programLanguages: ProgramLanguage[];
  selectedProgramLanguages: ProgramLanguage[];

  constructor(
    private messageService: MessageService,
    private baseApplicationService: BaseApplicationService,
    private programLanguageService: ProgramLanguageService,
    private tokenService: TokenService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig) { }

  ngOnInit(): void {
    this.programLanguageService.collection.getAll()
      .subscribe(
        (programLanguages) => {
          this.programLanguages = programLanguages;
        });

    if (this.config.data != null) {
      this.application = this.config.data;
    }
    else {
      this.application = new BaseApplication();
    }
  }

  saveApplication() {
    this.submitted = true;

    if (this.application.id) {
      this.baseApplicationService.single.update(this.application).subscribe(
        application => {
          this.applications[this.findIndexById(application.id)] = application;
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application updated' });
          this.ref.close(application);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
    else {
      this.application.id = 0;
      this.application.price = 0;
      this.application.status = "New";
      this.application.userCreatorId = this.tokenService.getUserIdentifier();
      this.application.programLanguages = this.selectedProgramLanguages;
      this.baseApplicationService.single.create(this.application).subscribe(
        application => {
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application created' });
          this.ref.close(application);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
  }

  findIndexById(id: number): number {
    let index = -1;
    for (let i = 0; i < this.applications.length; i++) {
      if (this.applications[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  }
}
