import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthRoutingModule } from './auth-routing.module';
import { PrimeNgComponentsModule } from 'src/app/modules/primeng-components-module/primeng-components.module';

@NgModule({
  imports: [
    CommonModule,
    AuthRoutingModule,
    PrimeNgComponentsModule
  ]
})
export class AuthModule { }
