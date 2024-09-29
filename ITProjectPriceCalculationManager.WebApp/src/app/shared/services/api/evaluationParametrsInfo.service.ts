import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { EvaluationParametrsInfo } from "../../models/evaluationParametrsInfo.model";

@Injectable()
export class EvaluationParametrsInfoService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'EvaluationParametrsInfoManager', configService, EvaluationParametrsInfo, ServiceType.route, ServiceType.evaluatormanagerapi);
  }
}
