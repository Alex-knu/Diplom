import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { ProgramLanguage } from "../../models/programLanguage.model";

@Injectable()
export class ProgramLanguageService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'ProgramLanguageManager', configService, ProgramLanguage, ServiceType.route, ServiceType.itprojectsmanagerapi);
  }
}
