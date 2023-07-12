import { Component, Input } from '@angular/core';
import { Usuario } from '../../interfaces/usuario';

@Component({
  selector: 'familia-table',
  templateUrl: './familia-table.component.html',
  styles: [    
  ]
})
export class FamiliaTableComponent {

  @Input()
  public usuarios: Usuario[]=[];

}
