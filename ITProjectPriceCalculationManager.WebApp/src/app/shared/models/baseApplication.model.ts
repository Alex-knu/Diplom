import { BaseModel } from "./base.model";
import { ProgramLanguage } from "./programLanguage.model";

export class BaseApplication extends BaseModel {

  constructor(id: number | null = null) {
    super(id);
  }

  userCreatorId: string;
  name: string;
  description: string;
  status: string;
  price: number | null;
  profit: number;
  confidenceArea: number | null;
  overhead: number;
  socialInsurance: number;
  averageCostLabor: number;
  averageMonthlyRateWorkingHours: number;
  programLanguages: ProgramLanguage[];
}
