import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationRoutingModule } from './application-routing.module';
import { PrimeNgComponentsModule } from 'src/app/modules/primeng-components-module/primeng-components.module';

@NgModule({
  imports: [
    CommonModule,
    ApplicationRoutingModule,
    PrimeNgComponentsModule
  ]
})

export class AuthModule { }
