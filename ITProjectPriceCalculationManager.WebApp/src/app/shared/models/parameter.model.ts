import { BaseModel } from "./base.model";
import { ParameterValue } from "./parameterValue.model";

export class Parameter extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  name: string;
  parameterValue: ParameterValue | null;
}
