import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogRef, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { Department } from 'src/app/shared/models/department.model';
import { Evaluator } from 'src/app/shared/models/evaluator.model';
import { DepartmentService } from 'src/app/shared/services/api/department.service';
import { EvaluatorService } from 'src/app/shared/services/api/estimator.service';

@Component({
  selector: 'app-evaluator-info',
  templateUrl: './evaluator-info.component.html',
  styleUrls: ['./evaluator-info.component.scss']
})
export class EvaluatorInfoComponent {
  loading: boolean = false;
  departments: Department[];
  evaluator: Evaluator;

  constructor(
    private departmentService: DepartmentService,
    private evaluatorService: EvaluatorService,
    private messageService: MessageService,
    public dialogService: DialogService,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig) { }

  ngOnInit() {
    this.loading = true;
    this.evaluator = this.config.data;

    setTimeout(() => {
      this.departmentService.collection.getAll().subscribe((departments) => {
        this.departments = departments;
      });

      this.loading = false;
    })
  }

  saveEvaluator() {
    if (this.evaluator.department) {
      this.evaluator.departmentId = this.evaluator.department.id;
    }

    if (this.evaluator.id) {
      this.evaluatorService.single.update(this.evaluator).subscribe(
        evaluator => {
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Підрозділ оновлено' });
          this.ref.close(evaluator);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        })
    }
  }
}
