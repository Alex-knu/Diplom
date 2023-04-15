import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApplicationTableComponent } from './application-table.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: '', component: ApplicationTableComponent }
    ])],
    exports: [RouterModule]
})
export class ApplicationTableRoutingModule { }
