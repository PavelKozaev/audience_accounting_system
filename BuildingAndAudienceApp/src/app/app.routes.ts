import { Routes } from '@angular/router';
import { BuildingListComponent } from './components/building-list/building-list.component';
import { BuildingFormComponent } from './components/building-form/building-form.component';

export const routes: Routes = [
    {
        path:"",
        component:BuildingListComponent
    },
    {
        path:"building-list",
        component:BuildingListComponent
    },
    {
        path:"create-building",
        component:BuildingFormComponent
    },
    {
        path:"building/:id",
        component:BuildingFormComponent
    }      
];
