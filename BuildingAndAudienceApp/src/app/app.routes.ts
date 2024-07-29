import { Routes } from '@angular/router';
import { BuildingListComponent } from './components/building-list/building-list.component';
import { BuildingFormComponent } from './components/building-form/building-form.component';
import { AudienceListComponent } from './components/audience-list/audience-list.component';
import { AudienceFormComponent } from './components/audience-form/audience-form.component';


export const routes: Routes = [
  {
    path: '',
    redirectTo: '/building-list',
    pathMatch: 'full'
  },
  {
    path: 'building-list',
    component: BuildingListComponent
  },
  {
    path: 'create-building',
    component: BuildingFormComponent
  },
  {
    path: 'building/:id',
    component: BuildingFormComponent
  },
  {
    path: 'audience-list',
    component: AudienceListComponent
  },
  {
    path: 'create-audience',
    component: AudienceFormComponent
  },
  {
    path: 'audience/:id',
    component: AudienceFormComponent
  },
  {
    path: '**',
    redirectTo: '/building-list'
  }
];
