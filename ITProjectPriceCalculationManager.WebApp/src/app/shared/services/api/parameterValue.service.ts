import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { ParameterValue } from "../../models/parameterValue.model";

@Injectable()
export class ParameterValueService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'ParameterValueApi', configService, ParameterValue, ServiceType.route);
  }
}
