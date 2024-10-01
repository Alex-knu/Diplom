import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UUID } from 'angular2-uuid';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { BaseApplication } from 'src/app/shared/models/itProjectsManager/baseApplication.model';
import { ProgramLanguage } from 'src/app/shared/models/itProjectsManager/programLanguage.model';
import { BaseApplicationService } from 'src/app/shared/services/api/baseApplication.service';
import { ProgramLanguageService } from 'src/app/shared/services/api/programLanguage.service';

@Component({
  selector: 'app-application-info',
  templateUrl: './application-info.component.html',
  styleUrls: ['./application-info.component.scss']
})
export class ApplicationInfoComponent implements OnInit {
  submitted = false;
  application: BaseApplication;
  programLanguages: ProgramLanguage[] = [];

  constructor(
    private messageService: MessageService,
    private baseApplicationService: BaseApplicationService,
    private programLanguageService: ProgramLanguageService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig
  ) {
  }

  ngOnInit(): void {
    this.initializeProgramLanguages();
    this.initializeApplication();
  }

  private initializeProgramLanguages(): void {
    this.programLanguageService.collection.getAll().subscribe(
      (programLanguages: ProgramLanguage[]) => this.programLanguages = programLanguages,
      (error: HttpErrorResponse) => this.handleError(error)
    );
  }

  private initializeApplication(): void {
    this.application = this.config.data ? this.config.data : new BaseApplication();
  }

  saveApplication(): void {
    this.submitted = true;

    if (this.application.id) {
      this.updateApplication();
    } else {
      this.createApplication();
    }
  }

  private updateApplication(): void {
    this.baseApplicationService.single.update(this.application).subscribe(
      (application: BaseApplication) => this.showMessage('success', 'Successful', 'Заявку оновлено'),
      (error: HttpErrorResponse) => this.handleError(error)
    );
  }

  private createApplication(): void {
    this.application.id = UUID.UUID();
    this.application.price = 0;
    this.application.statusId = "4706D234-E64D-4AB2-BED0-6086E10C3325";

    this.baseApplicationService.single.create(this.application).subscribe(
      (application: BaseApplication) => this.showMessage('success', 'Successful', 'Заявку створено'),
      (error: HttpErrorResponse) => {
        this.application.id = null;
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
