import { BaseModel } from "./base.model";

export class Evaluator extends BaseModel {

  constructor(id: number | null = null) {
    super(id);
  }
  departmentId: number;
  userId: string;
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
}
