import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { ApplicationToEstimators } from "../../models/itProjectsManager/applicationToEstimators.model";

@Injectable()
export class ApplicationToEstimatorsService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'ApplicationToEstimatorsManager', configService, ApplicationToEstimators, ServiceType.route, ServiceType.itprojectsmanagerapi);
  }
}
