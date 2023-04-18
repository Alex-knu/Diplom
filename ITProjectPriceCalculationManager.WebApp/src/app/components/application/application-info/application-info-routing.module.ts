import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApplicationInfoComponent } from './application-info.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: '', component: ApplicationInfoComponent }
    ])],
    exports: [RouterModule]
})
export class ApplicationInfoRoutingModule { }
