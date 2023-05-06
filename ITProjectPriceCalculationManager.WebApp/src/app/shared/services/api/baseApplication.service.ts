import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { BaseApplication } from "../../models/baseApplication.model";

@Injectable()
export class BaseApplicationService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'BaseApplicationManager', configService, BaseApplication, ServiceType.route);
  }
}
