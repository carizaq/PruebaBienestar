import { Component } from '@angular/core';
import { Usuario } from '../../interfaces/usuario';
import { FamiliaService } from '../../services/familia.service';

@Component({
  selector: 'familia-por-nombre-page',
  templateUrl: './por-nombre-page.component.html',
  styles: [
  ]
})
export class PorNombrePageComponent {
  public usuarios: Usuario[]=[];

  constructor(private familiaService: FamiliaService){
  }

  buscarPorNombre(identificiacion:string)  :void{
    this.familiaService.buscarUsuarioPorNombre(identificiacion)
      .subscribe( usua => {
        this.usuarios = usua;
      });
    
  }
}
