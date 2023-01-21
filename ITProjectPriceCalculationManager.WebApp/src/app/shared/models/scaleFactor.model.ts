import { DifficultyLevelsType } from "../enums/difficultyLevelsType.enum";
import { BaseModel } from "./base.model";

export interface ScaleFactor extends BaseModel{
    name: string;
    count: number;
    difficultyLevelsType: DifficultyLevelsType;
}