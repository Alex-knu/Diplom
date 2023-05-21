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

@NgModule({
  declarations: [
    AppComponent,
    NotfoundComponent,
    ApplicationInfoComponent,
    ApplicationTableComponent,
    ApplicationEvaluationComponent,
    DepartmentTreeComponent
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
