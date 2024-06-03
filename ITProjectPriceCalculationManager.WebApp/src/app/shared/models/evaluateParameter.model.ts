import { BaseModel } from "./base.model";
import { BelongingFunction } from "./belongingFunction.model";
import { Parameter } from "./parameter.model";

export class EvaluateParameter extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  name: string;
  applicationId: string;
  belongingFunctionId: string;
  parameterId: string;

  belongingFunction: BelongingFunction | null;
  parameter: Parameter | null;
}
