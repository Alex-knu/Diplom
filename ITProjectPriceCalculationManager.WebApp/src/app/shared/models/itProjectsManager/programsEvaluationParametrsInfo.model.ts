import { DifficultyLevelsType } from "./difficultyLevelsType.model";

export class ProgramsEvaluationInfo {
  name: string;
  factorTypeId: string
  selectDifficultyLevel: DifficultyLevelsType;
  difficultyLevels: DifficultyLevelsType[];
}
