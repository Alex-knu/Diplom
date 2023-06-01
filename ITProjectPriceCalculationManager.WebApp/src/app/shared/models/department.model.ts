import { BaseModel } from "./base.model";

export class Department extends BaseModel {

  constructor(id: number | null = null) {
    super(id);
  }

  name: string;
  parentId: number | null;
  parent: Department | null;
  subDepartments: Department[] | null = null;
}
