import { Component } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Department } from 'src/app/shared/models/department.model';
import { DepartmentTreeService } from 'src/app/shared/services/api/departmentTree.service';
import { DepartmentInfoComponent } from '../department-info/department-info.component';

@Component({
  selector: 'app-department-tree',
  templateUrl: './department-tree.component.html',
  styleUrls: ['./department-tree.component.scss'],
})

export class DepartmentTreeComponent {
  ref: DynamicDialogRef;
  departments: TreeNode<Department>[] = [];

  constructor(
    private departmentTreeService: DepartmentTreeService,
    public dialogService: DialogService) { }

  ngOnInit() {
    setTimeout(() => {
      this.getDepartmentTree();
    });
  }

  recursiveTree(department: any) {
    department.label = department.name;
    department.expandedIcon = 'pi pi-user-minus';
    department.collapsedIcon = 'pi pi-user-plus';

    if (department.subDepartments != null) {
      department.subDepartments.forEach((subDepartment: any) => {
        this.recursiveTree(subDepartment);
      });
    }

    department.children = department.subDepartments;
  }

  createNewDepartment() {
    this.ref = this.dialogService.open(DepartmentInfoComponent, {
      header: 'Деталі підрозділу',
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true
    });

    this.ref.onClose.subscribe(
      () => {
        this.getDepartmentTree();
      }
    )
  }

  getDepartmentTree() {
    this.departmentTreeService.collection.getAll().subscribe((departments) => {
      departments.forEach((department) => {
        this.recursiveTree(department);
      });
      this.departments = departments;
    });
  }

  nodeSelect(event: any) {
    if (event.node) {
      this.ref = this.dialogService.open(DepartmentInfoComponent, {
        header: 'Деталі підрозділу',
        data: { id: event.node.id },
        contentStyle: { overflow: 'auto' },
        baseZIndex: 10000,
        maximizable: true
      });

      this.ref.onClose.subscribe(
        () => {
          this.getDepartmentTree();
        }
      )
    }
  }
}
