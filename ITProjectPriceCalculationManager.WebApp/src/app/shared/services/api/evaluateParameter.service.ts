import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { EvaluateParameter } from "../../models/evaluateParameter.model";

@Injectable()
export class EvaluateParameterService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'EvaluateParameterApi', configService, EvaluateParameter, ServiceType.route, ServiceType.evaluatormanagerapi);
  }
}
