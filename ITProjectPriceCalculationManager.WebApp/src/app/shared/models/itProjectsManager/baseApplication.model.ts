import { BaseModel } from "../base.model";
import { ProgramLanguage } from "./programLanguage.model";
import {Evaluator} from "./evaluator.model";

export class BaseApplication extends BaseModel {

  constructor(id: string | null = null) {
    super(id);
  }

  userCreatorId: string;
  name: string;
  description: string;
  statusId: string;
  statusName: string;
  price: number | null;
  profit: number;
  confidenceArea: number | null;
  overhead: number;
  socialInsurance: number;
  averageCostLabor: number;
  averageMonthlyRateWorkingHours: number;
  programLanguages: ProgramLanguage[];
  evaluationGroup: Evaluator[] | null
}
