import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { AppLayoutComponent } from "./layout/app.layout.component";

const routes: Routes = [
  {
    path: '', component: AppLayoutComponent,
    children: [
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'application', loadChildren: () => import('./components/application/application.module').then(m => m.ApplicationModule) },
      { path: 'department', loadChildren: () => import('./components/departmets/department.module').then(m => m.DepartmentModule) },
      { path: 'user', loadChildren: () => import('./components/users/user.module').then(m => m.UserModule) },
      { path: 'evaluator', loadChildren: () => import('./components/evaluator/evaluator.module').then(m => m.EvaluatorModule) }
    ]
  },
  { path: 'auth', loadChildren: () => import('./components/auth/auth.module').then(m => m.AuthModule) },
  { path: 'notfound', component: NotfoundComponent },
  { path: '**', redirectTo: '/notfound' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      routes,
      {
        scrollPositionRestoration: 'enabled',
        anchorScrolling: 'enabled',
        onSameUrlNavigation: 'reload'
      })
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
