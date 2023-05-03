import { Component, OnInit } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';
import { ConfigModel } from './shared/models/config.model';
import { ClientConfigurationService } from './shared/services/core/client-configuration.service';
import { ConfigService } from './shared/services/api/config.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  constructor(
    private primengConfig: PrimeNGConfig,
    private clientConfigService: ClientConfigurationService) { }

  ngOnInit() {
    this.primengConfig.ripple = true;
    this.clientConfigService.config = environment.serveces;
  }
}
