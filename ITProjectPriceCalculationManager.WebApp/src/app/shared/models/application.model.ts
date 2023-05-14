import { BaseApplication } from "./baseApplication.model";
import { InfluenceFactor } from "./influenceFactor.model";
import { ProgramsParametr } from "./programsParametr.model";
import { ScaleFactor } from "./scaleFactor.model";

export class Application extends BaseApplication {
  overhead: number;
  socialInsurance: number;
  averageCostLabor: number;
  averageMonthlyRateWorkingHours: number;
  scaleFactors: ScaleFactor[];
  influenceFactors: InfluenceFactor[];
  programsParametrs: ProgramsParametr[];
}
