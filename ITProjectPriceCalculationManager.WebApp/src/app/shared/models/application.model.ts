import { BaseModel } from "./base.model";
import { InfluenceFactor } from "./influenceFactor.model";
import { ProgramsParametr } from "./programsParametr.model";
import { ScaleFactor } from "./scaleFactor.model";

export class Application extends BaseModel {
    price: number;
    profit: number;
    overhead: number;
    socialInsurance: number;
    averageCostLabor: number;
    averageMonthlyRateWorkingHours: number;
    scaleFactors: ScaleFactor[];
    influenceFactors: InfluenceFactor[];
    programsParametrs: ProgramsParametr[];
}