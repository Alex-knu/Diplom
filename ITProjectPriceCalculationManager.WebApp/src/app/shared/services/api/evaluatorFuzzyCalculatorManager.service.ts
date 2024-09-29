import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import {CalculateConfidenceArea} from "../../models/itProjectsManager/calculateConfidenceArea.model";

@Injectable()
export class EvaluatorFuzzyCalculatorManagerService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'EvaluatorFuzzyCalculatorManager', configService, CalculateConfidenceArea, ServiceType.route, null);
  }
}
