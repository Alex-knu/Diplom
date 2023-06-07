import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';
import { AuthService } from '../shared/services/auth.service';
import { ROLE_ADMIN, ROLE_EVALUATOR, ROLE_USER } from '../shared/constants';

@Component({
  selector: 'app-menu',
  templateUrl: './app.menu.component.html'
})

export class AppMenuComponent implements OnInit {
  admin = ROLE_ADMIN;
  evaluator = ROLE_EVALUATOR;
  user = ROLE_USER;

  model: any[] = [];

  constructor(
    public layoutService: LayoutService,
    public authService: AuthService) { }

  ngOnInit() {
    this.model = [
      {
        label: 'Головна',
        visible: true,
        items: [
          {
            label: 'Головна',
            icon: 'pi pi-fw pi-home',
            routerLink: ['/']
          }
        ]
      },
      {
        label: 'Заявка',
        visible: this.isVisible(this.user) || this.isVisible(this.evaluator),
        items: [
          {
            label: 'Заявки',
            icon: 'pi pi-fw pi-users',
            routerLink: ['/application/application-table'], visible: this.isVisible(this.user) || this.isVisible(this.evaluator)
          }
        ]
      },
      {
        label: 'Експерти',
        items: [
          {
            label: 'Експерти', icon: 'pi pi-fw pi-users',
            routerLink: ['/units/list'],
            visible: this.isVisible(this.admin)
          }
        ]
      },
      {
        label: 'Експертні групи',
        visible: this.isVisible(this.admin),
        items: [
          {
            label: 'Експертні групи',
            icon: 'pi pi-fw pi-users',
            routerLink: ['/divisions/list'],
            visible: this.isVisible(this.admin)
          }
        ]
      },
      {
        label: 'Підрозділи',
        visible: this.isVisible(this.admin),
        items: [
          {
            label: 'Ієрархія підрозділів',
            icon: 'pi pi-fw pi-users',
            routerLink: ['/department/department-tree'],
            visible: this.isVisible(this.admin)
          }
        ]
      },
      {
        label: 'Логін',
        visible: true,
        items: [
          {
            label: 'Логін',
            icon: 'pi pi-fw pi-users',
            routerLink: ['/auth/register']
          },
          {
            label: 'Додати експертну групу',
            icon: 'pi pi-fw pi-user-plus',
            routerLink: ['/auth/access']
          }
        ]
      }
    ];
  }

  isVisible(role: string): boolean {
    return this.authService.checkRole(role);
  }
}
