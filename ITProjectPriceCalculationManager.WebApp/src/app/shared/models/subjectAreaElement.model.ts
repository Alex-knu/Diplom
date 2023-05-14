import { ConditionalUnitsOfFunctionality } from "../enums/conditionalUnitsOfFunctionality.enum";
import { SubjectAreaType } from "../enums/subjectAreaType.enum";
import { BaseModel } from "./base.model";

export interface SubjectAreaElement extends BaseModel {
  count: number;
  difficultyLevel: number;
  subjectAreaType: SubjectAreaType;
  conditionalUnitsOfFunctionality: ConditionalUnitsOfFunctionality;
}
