import { BaseModel } from "./base.model";

export class Parameter extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  name: string;
}
