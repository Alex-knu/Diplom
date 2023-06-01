import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { DifficultyLevelsType } from "../../models/difficultyLevelsType.model";

@Injectable()
export class DifficultyLevelsTypeService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'DifficultyLevelsTypeManager', configService, DifficultyLevelsType, ServiceType.route);
  }
}
