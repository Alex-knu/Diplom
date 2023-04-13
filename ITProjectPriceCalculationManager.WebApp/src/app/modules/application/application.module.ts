import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationTableComponent } from './application.table/application.table.component';
import { ApplicationInfoComponent } from './application.info/application.info.component';
import { ApplicationRoutingModule } from './application.route.module';
import { PrimeNgComponentsModule } from '../primeng-components-module/primeng-components.module';



@NgModule({
  declarations: [
    ApplicationTableComponent,
    ApplicationInfoComponent
  ],
  imports: [
    CommonModule,
    ApplicationRoutingModule,
    PrimeNgComponentsModule
  ]
})
export class ApplicationModule { }
