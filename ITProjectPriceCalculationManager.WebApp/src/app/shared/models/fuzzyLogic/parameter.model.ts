import { BaseModel } from "../base.model";
import {EvaluateParameter} from "./evaluateParameter.model";

export class Parameter extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  name: string;
  applicationId: string;
  value: number;
  evaluationParameters: EvaluateParameter[];
}
