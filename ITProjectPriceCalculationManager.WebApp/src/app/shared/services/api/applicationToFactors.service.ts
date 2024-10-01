import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { EvaluationApplication } from "../../models/itProjectsManager/evaluationApplication.model";

@Injectable()
export class ApplicationToFactorsService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'ApplicationToFactorsManager', configService, EvaluationApplication, ServiceType.route, ServiceType.itprojectsmanagerapi);
  }
}
