import { DifficultyLevelsType } from "./difficultyLevelsType.model";

export class EvaluationParametrsInfo {
  name: string;
  factorTypeId: number;
  selectDifficultyLevel: DifficultyLevelsType;
  difficultyLevels: DifficultyLevelsType[];
}
