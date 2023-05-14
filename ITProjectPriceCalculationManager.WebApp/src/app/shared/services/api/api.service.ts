import { Injectable } from "@angular/core";
import { AuthService } from "../auth.service";
import { ApplicationService } from "./application.service";
import { BaseApplicationService } from "./baseApplication.service";

@Injectable()
export class ApiService {
  constructor(
    public auth: AuthService,
    public applicationService: ApplicationService,
    public baseApplicationService: BaseApplicationService) { }
}
