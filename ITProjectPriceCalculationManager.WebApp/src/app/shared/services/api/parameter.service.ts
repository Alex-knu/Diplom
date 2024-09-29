import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { Parameter } from "../../models/parameter.model";

@Injectable()
export class ParameterService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'ParametersApi', configService, Parameter, ServiceType.route, ServiceType.evaluatormanagerapi);
  }
}
