import { BaseModel } from "./base.model";

export class ParameterValue extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  a: string;
  b: string;
  c: string;
  d: string;
}
