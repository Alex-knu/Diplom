import { BaseModel } from "../base.model";
import { Department } from "./department.model";

export class Evaluator extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }
  departmentId: string | null;
  userId: string;
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
  competencyLevel: number;

  department: Department | null;
}
