import { HttpService } from "./core/http.service";
import { ClientConfigurationService } from "./core/client-configuration.service";
import { ApiService } from "./api/api.service";
import { ApplicationService } from "./api/application.service";
import { BaseApplicationService } from "./api/baseApplication.service";
import { DepartmentService } from "./api/department.service";
import { ProgramLanguageService } from "./api/programLanguage.service";
import { ApplicationToEstimatorsService } from "./api/applicationToEstimators.service";
import { EvaluatorService } from "./api/estimator.service";
import { DifficultyLevelsTypeService } from "./api/difficultyLevelsType.service";
import { EvaluationParametrsInfoService } from "./api/evaluationParametrsInfo.service";
import { ApplicationToFactorsService } from "./api/applicationToFactors.service";
import { DepartmentTreeService } from "./api/departmentTree.service";
import { UserService } from "./api/user.service";
import { RoleService } from "./api/role.service";
import { CalculateApplicationService } from "./api/calculateApplication.service";

export const services = [
  HttpService,
  ClientConfigurationService,
  ApiService,
  ApplicationService,
  ApplicationToEstimatorsService,
  ApplicationToFactorsService,
  BaseApplicationService,
  CalculateApplicationService,
  DepartmentService,
  DepartmentTreeService,
  EvaluatorService,
  ProgramLanguageService,
  DifficultyLevelsTypeService,
  EvaluationParametrsInfoService,
  UserService,
  RoleService
]
