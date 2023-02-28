import { Component, OnInit } from '@angular/core';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Application } from 'src/app/shared/models/application.model';

@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.scss']
})
export class ApplicationComponent implements OnInit {

  applicationDialog: boolean;
  applications: Application[];
  application: Application;
  selectedApplications: Application[];
  submitted: boolean;

  constructor(private messageService: MessageService, private confirmationService: ConfirmationService) { }

  ngOnInit() {
    // this.applicationService.getApplications().then(data => this.applications = data);
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
        this.selectedApplications = null;
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
      if (this.application.id) {
        this.applications[this.findIndexById(this.application.id)] = this.application;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application Updated', life: 3000 });
      }
      else {
        this.application.id = 0;
        this.applications.push(this.application);
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Application Created', life: 3000 });
      }

      this.applications = [...this.applications];
      this.applicationDialog = false;
      this.application = new Application();
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
