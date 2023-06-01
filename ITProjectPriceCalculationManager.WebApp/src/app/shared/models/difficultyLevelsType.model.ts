import { BaseModel } from "./base.model";

export class DifficultyLevelsType extends BaseModel {

  constructor(id: number | null = null) {
    super(id);
  }

  relationId: number;
  name: string;
}
