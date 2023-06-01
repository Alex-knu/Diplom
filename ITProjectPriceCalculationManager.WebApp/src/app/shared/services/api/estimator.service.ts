import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { Evaluator } from "../../models/evaluator.model";

@Injectable()
export class EstimatorService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'EvaluatorManager', configService, Evaluator, ServiceType.route);
  }
}
