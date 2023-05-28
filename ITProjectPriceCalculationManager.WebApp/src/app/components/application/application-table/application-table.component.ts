import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Application } from 'src/app/shared/models/application.model';
import { ApplicationToEstimators } from 'src/app/shared/models/applicationToEstimators.model';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { Evaluator } from 'src/app/shared/models/evaluator.model';
import { ProgramLanguage } from 'src/app/shared/models/programLanguage.model';
import { ApplicationToEstimatorsService } from 'src/app/shared/services/api/applicationToEstimators.service';
import { BaseApplicationService } from 'src/app/shared/services/api/baseApplication.service';
import { EstimatorService } from 'src/app/shared/services/api/estimator.service';
import { ProgramLanguageService } from 'src/app/shared/services/api/programLanguage.service';
import { TokenService } from 'src/app/shared/services/core/token.service';

@Component({
  selector: 'app-application-table',
  templateUrl: './application-table.component.html',
  styleUrls: ['./application-table.component.scss']
})
export class ApplicationTableComponent {

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
  selectedEvaluators: Evaluator[];

  constructor(
    private router: Router,
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private applicationToEstimatorsService: ApplicationToEstimatorsService,
    private baseApplicationService: BaseApplicationService,
    private estimatorService: EstimatorService,
    private programLanguageService: ProgramLanguageService,
    private tokenService: TokenService) { }

  ngOnInit() {
    this.loading = true;
    setTimeout(() => {
      this.baseApplicationService.collection.getAll()
        .subscribe(
          (applications) => {
            this.applications = applications;
          });

      this.programLanguageService.collection.getAll()
        .subscribe(
          (programLanguages) => {
            this.programLanguages = programLanguages;
          });

      this.loading = false;
    });
  }

  saveApplication() {
    this.submitted = true;

    if (this.application.id) {
      this.baseApplicationService.single.update(this.application).subscribe(
        application => {
          this.applications[this.findIndexById(application.id)] = application;
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application updated' });
          this.applicationDialog = false;
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
          this.applications.push(application);
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application created' })
          this.applicationDialog = false;
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
  }

  editApplication(application: BaseApplication) {
    this.application = application;
    this.applicationDialog = true;
  }

  deleteApplication(application: Application) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + application.name + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        if (application.id) {
          this.baseApplicationService.single.deleteById(application.id).subscribe(
            application => {
              this.applications = this.applications.filter(val => val.id !== application.id);
              this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application Deleted' });
            },
            error => {
              this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
            })
        }
      }
    });
  }

  openNew() {
    this.application = new BaseApplication();
    this.submitted = false;
    this.applicationDialog = true;
  }

  addEstimatorGroup(applicationId: number) {
    this.estimatorService.collection.getAll()
      .subscribe(
        (evaluators) => {
          evaluators.forEach((evaluator) => {
            evaluator.name = evaluator.firstName + ' ' + evaluator.lastName;
          });

          this.evaluators = evaluators;
        });

    this.applicationToEstimators = new ApplicationToEstimators();
    this.submitted = false;
    this.applicationToEstimatorsDialog = true;

    this.applicationToEstimators.applicationId = applicationId;
  }

  saveEstimatorGroup() {
    this.submitted = true;
    this.applicationToEstimators.evaluators = this.selectedEvaluators;

    this.applicationToEstimatorsService.single.create(this.applicationToEstimators).subscribe(
      () => {
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application created' })
        this.applicationToEstimatorsDialog = false;
      },
      error => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
      })
  }

  hideEstimatorGroupDialog() {
    this.applicationToEstimatorsDialog = false;
    this.submitted = false;
  }

  hideDialog() {
    this.applicationDialog = false;
    this.submitted = false;
  }

  redirectToEvaluationForm(applicationId: number){
    this.router.navigate(['/application/application-evaluation'], { queryParams: { applicationId } });
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
