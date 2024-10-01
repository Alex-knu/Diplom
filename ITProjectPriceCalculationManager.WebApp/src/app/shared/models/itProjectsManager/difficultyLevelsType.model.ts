import { BaseModel } from "../base.model";

export class DifficultyLevelsType extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  relationId: string
  name: string;
  value: number;
}
