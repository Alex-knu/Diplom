import { HttpService } from "./core/http.service";
import { ClientConfigurationService } from "./core/client-configuration.service";
import { ApiService } from "./api/api.service";
import { ApplicationService } from "./api/application.service";
import { BaseApplicationService } from "./api/baseApplication.service";

export const services = [
    HttpService,
    ClientConfigurationService,
    ApiService,
    ApplicationService,
    BaseApplicationService
]
