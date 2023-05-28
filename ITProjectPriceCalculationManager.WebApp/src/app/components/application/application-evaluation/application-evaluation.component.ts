import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-application-evaluation',
  templateUrl: './application-evaluation.component.html',
  styleUrls: ['./application-evaluation.component.scss']
})

export class ApplicationEvaluationComponent {
  countries: any[] = [];

  filteredCountries: any[] = [];

  selectedCountryAdvanced: any[] = [];

  valSlider = 50;

  valColor = '#424242';

  valRadio: string = '';

  valCheck: string[] = [];

  valCheck2: boolean = false;

  valSwitch: boolean = false;

  cities: any[] = [];

  selectedCity: any;

  constructor(private route: ActivatedRoute){}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      const name = params['applicationId'];
      console.log('Name:', name);
      // Process the received data as needed
    });

    this.cities = [
      { name: 'Наднизький', code: 'RM' },
      { name: 'Дуже низький', code: 'NY' },
      { name: 'Низький', code: 'LDN' },
      { name: 'Номінальний', code: 'IST' },
      { name: 'Високий', code: 'PRS' },
      { name: 'Дуже високий', code: 'PRS' },
      { name: 'Надвисокий', code: 'PRS' }
    ];
  }

  filterCountry(event: any) {
    const filtered: any[] = [];
    const query = event.query;
    for (let i = 0; i < this.countries.length; i++) {
      const country = this.countries[i];
      if (country.name.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(country);
      }
    }

    this.filteredCountries = filtered;
  }
}
