import { BaseModel } from "./base.model";
import { BelongingFunction } from "./belongingFunction.model";
import {ParameterValue} from "./parameterValue.model";

export class EvaluateParameter extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  name: string;
  belongingFunctionId: string;
  parameterId: string;

  parameterValue: ParameterValue | null;
  belongingFunction: BelongingFunction | null;
}
