import { DifficultyLevelsType } from "./difficultyLevelsType.model";

export class EvaluationParametrsInfo {
  name: string;
  factorTypeId: string
  selectDifficultyLevel: DifficultyLevelsType;
  difficultyLevels: DifficultyLevelsType[];
}
