import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, FormArray, ValidatorFn, AbstractControl } from '@angular/forms';
import { FamiliaService } from '../../services/familia.service';
import { Usuario } from '../../interfaces/usuario';


@Component({
  selector: 'familia-page',
  templateUrl: './familia-page.component.html',
  styles: [],

})
export class FamiliaPageComponent {

  progenitoresSeleccionadosControl: FormControl;
  numeroHijos: number = 1;
  showDivPadre: boolean = true;
  showDivMadre: boolean = true;

  public myForm: FormGroup = this.fb.group({
    madre: this.fb.group({
      numeroIdentificacion: ['', [Validators.required]],
      nombres: ['', [Validators.required]],
      apellidos: ['', [Validators.required]],
      fechaNacimiento: ['', [Validators.required,this.dateValidator ]],
      genero: new FormControl('F'),
      tipoEmpleo: new FormControl('I'),
      experienciaLaboral: [0, [Validators.max(30), Validators.min(0)]],
      observaciones: [],
    }),

    padre: this.fb.group({
      numeroIdentificacion: ['', [Validators.required]],
      nombres: ['', [Validators.required]],
      apellidos: ['', [Validators.required]],
      fechaNacimiento: ['', [Validators.required]],
      genero: new FormControl('M'),
      tipoEmpleo: new FormControl('I'),
      experienciaLaboral: [0, [Validators.max(30), Validators.min(0)]],
      observaciones: []
    }),

    hijosArray: this.fb.array([])
  });


  constructor(private fb: FormBuilder, private familiaService: FamiliaService) {
    this.progenitoresSeleccionadosControl = new FormControl('A');
  }

  public nuevoHijo: FormGroup = new FormGroup({
    numeroIdentificacion: new FormControl<number>(0, { nonNullable: true }),
  })


  get hijosControl() {
    return this.myForm.get('hijosArray') as FormArray;
  }

  onAgregarHijosControl(): void {
    const controlGroup = this.fb.group({
      numeroIdentificacion: ['', [Validators.required]],
      nombres: ['', [Validators.required]],
      apellidos: ['', [Validators.required]],
      fechaNacimiento: ['', [Validators.required, this.dateValidator]],
      genero: new FormControl('M'),
      estudia: new FormControl('N'),
      estaturaCms: [50.00, [Validators.required, Validators.min(50), Validators.max(200)]],
      descripcionFisica: [""]
    });
    this.hijosControl.push(controlGroup);

  }


  OnEliminarhijo(indice: number) {
    this.hijosControl.removeAt(indice);
  }


  dateValidator() {
    debugger;  
    return (control: AbstractControl): { [key: string]: any } | null => {
      const inputDate = new Date(control.value);
      const currentDate = new Date();
      debugger;

      if (inputDate > currentDate) {
        return { futureDate: true };
      }

      return { futureDate: false };
    };
  }

  public dynamicValueForm: FormGroup = this.fb.group({
    numeroIdentificacion: new FormControl<number>(0, { nonNullable: true }),
    nombres: ['', [Validators.required]],
  });
  hijos: any[] = [];


  onProgenitoresSeleccionados(): void {
    const opcion = this.progenitoresSeleccionadosControl.value;
    this.showDivPadre = opcion === 'A' || opcion === 'P';
    this.showDivMadre = opcion === 'A' || opcion === 'M';

  }

  isValidField(group: string, field: string): boolean | null {
    const groupControl: FormGroup = this.myForm.controls[group] as FormGroup;

    if (this.progenitoresSeleccionadosControl.value == 'M' && group === 'padre' || this.progenitoresSeleccionadosControl.value == 'P' && group === 'madre')
      return false;

    return groupControl.controls[field].errors && groupControl.controls[field].touched;
  }

  isValidFieldInArray(formArray: FormArray, index: number) {
    return formArray.controls[index].errors && formArray.controls[index].touched;
  }

  getFieldError(group: string, field: string): string | null {
    const groupControl: FormGroup = this.myForm.controls[group] as FormGroup;

    console.log(groupControl.controls["fechaNacimiento"].errors)
    if (!groupControl.controls[field])
      return null;

    const errores = groupControl.controls[field].errors || {};
    debugger;
    for (const key of Object.keys(errores)) {
      switch (key) {
        case 'required':
          return 'Campo Requerido'
        case 'minlength':
          return `Mínimo ${errores['minlength'].requiredLength} caracteres`;
        case 'maxlength':
          return `Máximo ${errores['maxlength'].requiredLength} caracteres`;
        case 'dateValidator':
          return 'validar fecha'
      }

    }
    return '';
  }

  onSave(): void {
    var almacenarCambios: Boolean = false;

    debugger;
    if (this.myForm.value['hijosArray'].length > 0 && this.myForm.value['hijosArray'].valid) {
      var jsonSalida = this.myForm.value;

      switch (this.progenitoresSeleccionadosControl.value) {
        case 'P':
          if (this.myForm.controls['padre'].valid) {
            almacenarCambios = true;
            jsonSalida['madre'] = null;
          }
          break;
        case 'M':
          if (this.myForm.controls['madre'].valid)
            almacenarCambios = true;            
            jsonSalida['padre'] = null;
          break;
        case 'A':
          if (this.myForm.invalid)
            almacenarCambios = true;
          break;
        default:
          break;
      }      

      if (almacenarCambios)
      {
        this.familiaService.crearFamilia(jsonSalida)
        .subscribe();        
      }
    }
    else {
      
      console.log("Falta incluir Hijos...");
    }
    this.myForm.markAllAsTouched();
    

  } 

}
