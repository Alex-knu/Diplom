import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { Application } from "../../models/itProjectsManager/application.model";

@Injectable()
export class ApplicationService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'ApplicationManager', configService, Application, ServiceType.route, ServiceType.itprojectsmanagerapi);
  }
}
