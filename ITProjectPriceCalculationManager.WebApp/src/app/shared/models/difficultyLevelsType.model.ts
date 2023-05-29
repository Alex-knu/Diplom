import { BaseModel } from "./base.model";

export class DifficultyLevelsType extends BaseModel {

  constructor(id: number | null = null) {
    super(id);
  }

  name: string;
}
