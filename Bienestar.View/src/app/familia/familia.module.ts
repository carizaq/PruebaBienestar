import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { FamiliaPageComponent } from './pages/familia-page/familia-page.component';
import { PorIdentificacionPageComponent } from './pages/por-identificacion-page/por-identificacion-page.component';
import { FamiliaRoutingModule } from './familia-routing.module';
import { SharedModule } from '../shared/shared.module';
import { FamiliaTableComponent } from './components/familia-table/familia-table.component';
import { PorNombrePageComponent } from './pages/por-nombre-page/por-nombre-page.component';



@NgModule({
  declarations: [
    FamiliaPageComponent,
    PorIdentificacionPageComponent,
    FamiliaTableComponent,
    PorNombrePageComponent
  ],
  imports: [
    CommonModule,
    FamiliaRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ]
})
export class FamiliaModule { }
