import { BaseModel } from "../base.model";
import { EvaluationParametrsInfo } from "./evaluationParametrsInfo.model";

export class ProgramsParametr extends BaseModel {
  constructor(id: string | null = null) {
    super(id);
  }

  name: string;
  informationObjectEvaluationParametrsInfo: EvaluationParametrsInfo[];
  functionEvaluationParametrsInfo: EvaluationParametrsInfo[];
}
