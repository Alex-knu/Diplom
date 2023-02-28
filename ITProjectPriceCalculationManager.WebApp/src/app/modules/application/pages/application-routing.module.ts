import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ApplicationTableComponent } from "./application-table/application-table.component";

const routes: Routes = [
    {
      path: '',
      component: ApplicationTableComponent
    }
  ];
  
  @NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class ApplicationRoutingModule { }