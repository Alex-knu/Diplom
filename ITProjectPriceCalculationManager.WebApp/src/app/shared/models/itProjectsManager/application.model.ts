import { BaseApplication } from "./baseApplication.model";
import { InfluenceFactor } from "./influenceFactor.model";
import { ProgramsParametr } from "./programsParametr.model";
import { ScaleFactor } from "./scaleFactor.model";

export class Application extends BaseApplication {
  scaleFactors: ScaleFactor[];
  influenceFactors: InfluenceFactor[];
  programsParametrs: ProgramsParametr[];
}
