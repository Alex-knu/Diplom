import { Component } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { Department } from 'src/app/shared/models/department.model';
import { DepartmentService } from 'src/app/shared/services/api/department.service';

@Component({
  selector: 'app-department-tree',
  templateUrl: './department-tree.component.html',
  styleUrls: ['./department-tree.component.scss'],
})

export class DepartmentTreeComponent {
  departments: TreeNode<Department>[] = [];

  constructor(private departmentService: DepartmentService) { }

  ngOnInit() {
    setTimeout(() => {
      this.departmentService.collection.getAll().subscribe((departments) => {
        departments.forEach((department) => {
          this.recursiveTree(department);
        });
        this.departments = departments;
      });
    });
  }

  recursiveTree(department: any) {
    department.label = department.name;
    department.expandedIcon = 'pi pi-user-minus';
    department.collapsedIcon = 'pi pi-user-plus';

    if(department.subDepartments != null)
    {
      department.subDepartments.forEach((subDepartment: any) => {
        this.recursiveTree(subDepartment);
      });
    }

    department.children = department.subDepartments;
  }
}
