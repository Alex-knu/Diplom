import { BaseModel } from "../base.model";

export class Department extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  name: string;
  parentId: string | null;
  parent: Department | null;
  subDepartments: Department[] | null = null;
}
