import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrimeNgComponentsModule } from '../primeng-components-module/primeng-components.module';
import { ApplicationComponent } from './pages/application/application.component';
import { ApplicationTableComponent } from './pages/application-table/application-table.component';
import { ApplicationRoutingModule } from './pages/application-routing.module';

@NgModule({
  declarations: [
    ApplicationComponent,
    ApplicationTableComponent
  ],
  imports: [
    CommonModule,
    ApplicationRoutingModule,
    PrimeNgComponentsModule
  ]
})
export class ApplicationModule { }
