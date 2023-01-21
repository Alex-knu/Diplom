import { BaseModel } from "./base.model";
import { SubjectAreaElement } from "./subjectAreaElement.model";

export class ProgramsParametr extends BaseModel{
    sloc: number;
    programLanguageName: string;
    subjectAreaElements: SubjectAreaElement[];
}