import { Component } from '@angular/core';
import { FamiliaService } from '../../services/familia.service';
import { Usuario } from '../../interfaces/usuario';

@Component({
  selector: 'familia-por-identificacion-page',
  templateUrl: './por-identificacion-page.component.html',
  styles: [
  ]
})
export class PorIdentificacionPageComponent {
  
  public usuarios: Usuario[]=[];

  constructor(private familiaService: FamiliaService){
  }

  buscarPorIdentificacion(identificiacion:string)  :void{
    let numeroIdent = identificiacion as unknown as number;
    this.familiaService.buscarUsuarioPorDocumento(numeroIdent)
      .subscribe( usua => {
        this.usuarios = usua;
      });
    console.log(identificiacion);
  }
}
