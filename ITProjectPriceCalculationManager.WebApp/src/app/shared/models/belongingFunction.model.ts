import { BaseModel } from "./base.model";

export class BelongingFunction extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  name: string;
}
