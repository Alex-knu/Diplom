import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { Department } from "../../models/department.model";

@Injectable()
export class DepartmentTreeService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'DepartmentTreeManager', configService, Department, ServiceType.route, ServiceType.itprojectsmanagerapi);
  }
}
