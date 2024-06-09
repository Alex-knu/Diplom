import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {EstimatorParametersComponent} from "./estimator-parameters.component";

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: EstimatorParametersComponent }
  ])],
  exports: [RouterModule]
})

export class EstimatorParametersRoutingModule { }
