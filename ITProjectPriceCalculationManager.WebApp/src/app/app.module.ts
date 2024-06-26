import { NgModule } from '@angular/core';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutModule } from './layout/app.layout.module';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { ApplicationInfoComponent } from './components/application/application-info/application-info.component';
import { ApplicationTableComponent } from './components/application/application-table/application-table.component';
import { PrimeNgComponentsModule } from './modules/primeng-components-module/primeng-components.module';
import { services } from './shared/services';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './shared/services/auth-interceptor.service';
import { DepartmentTreeComponent } from './components/departmets/department-tree/department-tree.component';
import { ApplicationEvaluationComponent } from './components/application/application-evaluation/application-evaluation.component';
import { ApplicationEvaluationGroupComponent } from './components/application/application-evaluation-group/application-evaluation-group.component';
import { DepartmentInfoComponent } from './components/departmets/department-info/department-info.component';
import { ErrorComponent } from './components/auth/error/error.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { AccessComponent } from './components/auth/access/access.component';
import { UserTableComponent } from './components/users/user-table/user-table.component';
import { UserInfoComponent } from './components/users/user-info/user-info.component';
import { EvaluatorTableComponent } from './components/evaluator/evaluator-table/evaluator-table.component';
import { EvaluatorInfoComponent } from './components/evaluator/evaluator-info/evaluator-info.component';
import { ApplicationEvaluationParameterTableComponent } from './components/application/application-evaluate-paramete-table/application-evaluate-paramete-table.component';
import { ApplicationEvaluationParameterInfoComponent } from './components/application/application-evaluate-paramete-info/application-evaluate-paramete-info.component';
import { ApplicationEvaluationParameterDetailsComponent } from "./components/application/application-evaluation-paramete-info/application-evaluation-parameter-info.component";
import { EstimatorParametersComponent } from "./components/application/estimator-parameters/estimator-parameters.component";

@NgModule({
  declarations: [
    AppComponent,
    AccessComponent,
    NotfoundComponent,
    ApplicationInfoComponent,
    ApplicationTableComponent,
    ApplicationEvaluationComponent,
    ApplicationEvaluationGroupComponent,
    ApplicationEvaluationParameterDetailsComponent,
    ApplicationEvaluationParameterInfoComponent,
    ApplicationEvaluationParameterTableComponent,
    EstimatorParametersComponent,
    DepartmentTreeComponent,
    DepartmentInfoComponent,
    ErrorComponent,
    LoginComponent,
    RegisterComponent,
    UserTableComponent,
    UserInfoComponent,
    EvaluatorTableComponent,
    EvaluatorInfoComponent
  ],
  imports: [
    AppRoutingModule,
    AppLayoutModule,
    PrimeNgComponentsModule
  ],
  providers: [
    services,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: LocationStrategy, useClass: HashLocationStrategy }
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
