import { Component } from '@angular/core';
import { MessageService, ConfirmationService } from 'primeng/api';
import { DynamicDialogRef, DialogService } from 'primeng/dynamicdialog';
import { Evaluator } from 'src/app/shared/models/evaluator.model';
import { EvaluatorService } from 'src/app/shared/services/api/estimator.service';
import { EvaluatorInfoComponent } from '../evaluator-info/evaluator-info.component';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-evaluator-table',
  templateUrl: './evaluator-table.component.html',
  styleUrls: ['./evaluator-table.component.scss']
})
export class EvaluatorTableComponent {
  loading: boolean = false;
  evaluators: Evaluator[];
  evaluator: Evaluator;
  selectedEvaluators: Evaluator[];
  ref: DynamicDialogRef;

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private evaluatorService: EvaluatorService,
    private dialogService: DialogService) { }

  ngOnInit() {
    this.loading = true;
    setTimeout(() => {
      this.evaluatorService.collection.getAll()
        .subscribe(
          (evaluators) => {
            this.evaluators = evaluators;
          });

      this.loading = false;
    });
  }

  ngOnDestroy() {
    if (this.ref) {
      this.ref.close();
    }
  }

  editEvaluator(evaluator: Evaluator){
    this.ref = this.dialogService.open(EvaluatorInfoComponent, {
    header: 'Деталі заявки',
    data: evaluator,
    contentStyle: { overflow: 'auto' },
    baseZIndex: 10000,
    maximizable: true
  });

  this.ref.onClose.subscribe((evaluator: Evaluator) => {
    if (evaluator && evaluator.id) {
      this.evaluatorService.collection.getAll()
        .subscribe(
          (evaluators) => {
            this.evaluators = evaluators;
          });

      this.messageService.add({ severity: 'info', summary: 'Список оновлено', detail: evaluator.firstName + ' ' + evaluator.lastName });
    }
  });}

  deleteEvaluator(evaluator: Evaluator){
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + evaluator.firstName + ' ' + evaluator.lastName + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        if (evaluator.id) {
          this.evaluatorService.single.deleteById(evaluator.id).subscribe(
            evaluator => {
              this.evaluators = this.evaluators.filter(val => val.id !== evaluator.id);
              this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Заявку видалено' });
            },
            error => {
              this.messageService.add({ severity: 'error', summary: 'Error', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
            })
        }
      }
    });}
}
