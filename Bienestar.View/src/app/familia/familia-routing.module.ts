import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PorIdentificacionPageComponent } from './pages/por-identificacion-page/por-identificacion-page.component';
import { FamiliaPageComponent } from './pages/familia-page/familia-page.component';
import { PorNombrePageComponent } from './pages/por-nombre-page/por-nombre-page.component';

const routes: Routes=[
    {
        path:"por-identificacion",
        component:PorIdentificacionPageComponent
    },
    {
        path:"por-nombre",
        component:PorNombrePageComponent
    },
     {
        path:"crear",
        component:FamiliaPageComponent
    },
    {
        path:"by/:id",
        component: FamiliaPageComponent
    }
]

@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [],    
})
export class FamiliaRoutingModule { }
