import { BaseModel } from "./base.model";

export class Department extends BaseModel {

  constructor(id: number | null = null) {
    super(id);
  }

  name: string;
  departmentId: number | null;
  subDepartments: Department[] | null = null;
}
