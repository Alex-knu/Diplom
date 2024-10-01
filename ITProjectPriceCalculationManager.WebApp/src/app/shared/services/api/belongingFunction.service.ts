import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { BelongingFunction } from "../../models/fuzzyLogic/belongingFunction.model";

@Injectable()
export class BelongingFunctionService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'BelongingFunctionApi', configService, BelongingFunction, ServiceType.route, ServiceType.evaluatormanagerapi);
  }
}
