import { DifficultyLevelsType } from "../../enums/difficultyLevelsType.enum";
import { BaseModel } from "../base.model";

export class InfluenceFactor extends BaseModel {
  name: string;
  count: number;
  difficultyLevelsType: DifficultyLevelsType;
}
