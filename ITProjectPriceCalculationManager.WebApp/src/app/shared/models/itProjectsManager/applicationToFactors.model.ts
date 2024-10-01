import { BaseModel } from "../base.model";

export class ApplicationToFactors extends BaseModel {

  constructor(
    public applicationId: string,
    public difficultyLevelsTypeToFactorTypeId: string,
    public value: number | null = null,
    id: string | null = null) {
    super(id);
  }
}
