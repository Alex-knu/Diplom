import { BaseModel } from "./base.model";

export class ApplicationToFactors extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  applicationId: string
  difficultyLevelsTypeToFactorTypeId: string
  value: number;
}
