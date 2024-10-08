import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { UUID } from 'angular2-uuid';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogRef, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { Department } from 'src/app/shared/models/itProjectsManager/department.model';
import { DepartmentService } from 'src/app/shared/services/api/department.service';

@Component({
  selector: 'app-department-info',
  templateUrl: './department-info.component.html',
  styleUrls: ['./department-info.component.scss'],
})

export class DepartmentInfoComponent {
  loading: boolean = false;
  department: Department;
  departments: Department[];

  constructor(private departmentService: DepartmentService,
    private messageService: MessageService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig) { }

  ngOnInit() {
    this.loading = true;

    setTimeout(() => {
      this.departmentService.collection.getAll().subscribe((departments) => {
        this.departments = departments;
      });

      if (this.config.data != null) {
        this.departmentService.single.getById(this.config.data.id).subscribe((department: Department) => {
          this.department = department;
        });
      }
      else {
        this.department = new Department();
      }

      this.loading = false;
    })
  }

  saveDepartment() {
    if (this.department.parent) {
      this.department.parentId = this.department.parent.id;
    }

    if (this.department.id) {
      this.departmentService.single.update(this.department).subscribe(
        department => {
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Підрозділ оновлено' });
          this.ref.close(department);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
    else {
      this.department.id = UUID.UUID();

      this.departmentService.single.create(this.department).subscribe(
        department => {
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Підрозділ створено' });
          this.ref.close(department);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
  }
}
