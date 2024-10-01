import { ApplicationToFactors } from "./applicationToFactors.model";
import { ProgramsEvaluationInfo } from "./programsEvaluationInfo.model";

export class EvaluationApplication {
  userCreatorId: string;
  applicationToFactors: ApplicationToFactors[];
  programInfo: ProgramsEvaluationInfo[];
}
