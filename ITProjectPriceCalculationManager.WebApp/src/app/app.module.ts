import { NgModule } from '@angular/core';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppLayoutModule } from './layout/app.layout.module';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { ApplicationInfoComponent } from './components/application/application-info/application-info.component';
import { ApplicationTableComponent } from './components/application/application-table/application-table.component';
import { PrimeNgComponentsModule } from './modules/primeng-components-module/primeng-components.module';

@NgModule({
    declarations: [
        AppComponent,
        NotfoundComponent,
        ApplicationInfoComponent,
        ApplicationTableComponent
    ],
    imports: [
        AppRoutingModule,
        AppLayoutModule,
        PrimeNgComponentsModule
    ],
    providers: [
        {
            provide: LocationStrategy,
            useClass: HashLocationStrategy
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
