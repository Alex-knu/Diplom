import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Application } from 'src/app/shared/models/application.model';
import { BaseApplication } from 'src/app/shared/models/baseApplication.model';
import { BaseApplicationService } from 'src/app/shared/services/api/baseApplication.service';

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
  selectedApplications: BaseApplication[];
  submitted: boolean;

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private baseApplicationService: BaseApplicationService) { }

  ngOnInit() {
    this.loading = true;
    setTimeout(() => {
      this.baseApplicationService.collection.getAll()
        .subscribe(
          (applications) => {
            this.applications = applications;
          });
      this.loading = false;
    });
  }

  openNew() {
    this.application = new Application();
    this.submitted = false;
    this.applicationDialog = true;
  }

  deleteSelectedApplications() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected applications?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.applications = this.applications.filter(val => !this.selectedApplications.includes(val));
        //this.selectedApplications = null;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Applications Deleted', life: 3000 });
      }
    });
  }

  editApplication(application: Application) {
    // this.application = { ...application };
    this.applicationDialog = true;
  }

  deleteApplication(application: Application) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + application.id + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.applications = this.applications.filter(val => val.id !== application.id);
        this.application = new Application();
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application Deleted', life: 3000 });
      }
    });
  }

  hideDialog() {
    this.applicationDialog = false;
    this.submitted = false;
  }

  saveApplication() {
    this.submitted = true;

    if (this.application.id) {
      this.applications[this.findIndexById(this.application.id)] = this.application;
      this.baseApplicationService.single.update(this.application).subscribe(
        () => {
          this.messageService.add({ severity: 'success', summary: 'Командира створено', detail: 'user created' })
          this.applicationDialog = false;
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Командира не створено!', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
    else {
      this.application.id = 0;
      this.application.price = 0;
      this.application.status = "New";
      this.baseApplicationService.single.create(this.application).subscribe(
        () => {
          this.messageService.add({ severity: 'success', summary: 'Командира створено', detail: 'user created' })
          this.applicationDialog = false;
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Командира не створено!', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
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

  createId(): string {
    let id = '';
    var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (var i = 0; i < 5; i++) {
      id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return id;
  }
}
