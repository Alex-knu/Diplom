import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];

    constructor(public layoutService: LayoutService) { }

    ngOnInit() {
        this.model = [
            {
                label: 'Home',
                items: [
                    { label: 'Головна', icon: 'pi pi-fw pi-home', routerLink: ['/'] }
                ]
            },
            {
                label: 'Заявка',
                items: [
                    { label: 'Заявка', icon: 'pi pi-fw pi-home', routerLink: ['/application/application-info'] },
                    { label: 'Заявки', icon: 'pi pi-fw pi-users', routerLink: ['/application/application-table'] }
                ]
            },
            {
                label: 'Експерти',
                items: [
                    { label: 'Експерти', icon: 'pi pi-fw pi-users', routerLink: ['/units/list'] },
                    { label: 'Додати експерта', icon: 'pi pi-fw pi-user-plus', routerLink: ['/units/add'] }
                ]
            },
            {
              label: 'Експертні групи',
              items: [
                { label: 'Експертні групи', icon: 'pi pi-fw pi-users', routerLink: ['/divisions/list'] },
                { label: 'Додати експертну групу', icon: 'pi pi-fw pi-user-plus', routerLink: ['/divisions/new'] }
              ]
            }
        ];
    }
}
