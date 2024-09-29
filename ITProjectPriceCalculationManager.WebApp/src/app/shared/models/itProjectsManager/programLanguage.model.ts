import { BaseModel } from "../base.model";
import { ProgramsParametr } from "./programsParametr.model";

export class ProgramLanguage extends BaseModel {
  sloc: number;
  name: string;
  programsParametrs: ProgramsParametr[];
}
