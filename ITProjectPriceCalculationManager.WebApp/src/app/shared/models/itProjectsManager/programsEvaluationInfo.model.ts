import { ApplicationToFactors } from "./applicationToFactors.model";
import { BaseModel } from "../base.model";

export class ProgramsEvaluationInfo extends BaseModel {
  constructor(id: string | null = null) {
    super(id);
  }

  applicationToFactors: ApplicationToFactors[];
}
