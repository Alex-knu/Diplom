import { BaseModel } from "./base.model";

export class ApplicationToFactors extends BaseModel {

  constructor(id: number | null = null) {
    super(id);
  }

  applicationId: number;
  difficultyLevelsTypeToFactorTypeId: number;
  value: number;
}
