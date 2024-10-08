import { BaseModel } from '../../models/base.model';
import { HttpService } from './http.service';
import { ClientConfigurationService } from './client-configuration.service';
import { ServiceType } from './serviceType';
import { BaseCollectionService } from './baseCollection.service';
import { BaseSingleService } from './baseSingle.service';

export abstract class BaseService<TModel extends BaseModel>  {
  public single: BaseSingleService<TModel>;
  public collection: BaseCollectionService<TModel>;

  protected constructor(
    HttpService: HttpService,
    controllerName: string,
    configService: ClientConfigurationService,
    createModel: new (id: string | null) => TModel,
    serviceType: ServiceType = ServiceType.web,
    calledService: ServiceType | null  = ServiceType.web) {
    this.single = new BaseSingleService<TModel>(HttpService, calledService != null ? `${calledService}/${controllerName}` : controllerName, configService, createModel, serviceType);
    this.collection = new BaseCollectionService<TModel>(HttpService, calledService != null ? `${calledService}/${controllerName}/collection` : `${controllerName}/collection`, configService, createModel, serviceType);
  }
}
