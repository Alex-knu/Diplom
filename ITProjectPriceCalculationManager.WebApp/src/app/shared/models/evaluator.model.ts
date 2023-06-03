import { BaseModel } from "./base.model";

export class Evaluator extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }
  departmentId: string
  userId: string;
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
}
