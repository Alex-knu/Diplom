import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-application-evaluation',
  templateUrl: './application-evaluation.component.html',
  styleUrls: ['./application-evaluation.component.scss']
})

export class ApplicationEvaluationComponent {
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

  save(){}
}
