import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { BaseApplicationService } from 'src/app/shared/services/api/baseApplication.service';
import { UUID } from 'angular2-uuid';
import { ProgramLanguage } from 'src/app/shared/models/programLanguage.model';
import { ProgramLanguageService } from 'src/app/shared/services/api/programLanguage.service';

@Component({
  selector: 'application-evaluate-paramete-info',
  templateUrl: './application-evaluate-paramete-info.component.html',
  styleUrls: ['./application-evaluate-paramete-info.component.scss']
})
export class ApplicationEvaluationParameterInfoComponent implements OnInit {
  submitted: boolean;
  application: BaseApplication;
  programLanguages: ProgramLanguage[];

  constructor(
    private messageService: MessageService,
    private baseApplicationService: BaseApplicationService,
    private programLanguageService: ProgramLanguageService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig) { }

  ngOnInit(): void {
    this.submitted = false;

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
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку оновлено' });
          this.ref.close(application);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
    else {
      this.application.id = UUID.UUID();
      this.application.price = 0;
      this.application.statusId = "4706D234-E64D-4AB2-BED0-6086E10C3325";
      this.baseApplicationService.single.create(this.application).subscribe(
        application => {
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку створено' });
          this.ref.close(application);
        },
        error => {
          this.application.id = null;
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
  }
}