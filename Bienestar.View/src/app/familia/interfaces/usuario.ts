export interface Usuario {
    idUsuario:number,
    numeroIdentificacion: number;
    nombres:              string;
    apellidos:            string;    
    fechaNacimiento:      string;
    genero:               TipoEmpleoEnum;
    padre: Progenitor;
    madre: Progenitor;
    hijos: Descendiente[];
}

export interface Descendiente {
    idDescendiente:       number;
    idPadre:              number;
    idMadre:              number;
    numeroIdentificacion: number;
    nombres:              string;
    apellidos:            string;
    fechaNacimiento:      string;
    genero:               string;
    estudia:              string;
    estaturaCms:          string;
    descripcionFisica:    string;
}

export interface Progenitor {
    idDescendiente:       number;
    idHijo:               number;
    numeroIdentificacion: number;
    nombres:              string;
    apellidos:            string;
    fechaNacimiento:      string;
    genero:               string;
    tipoEmpleo:           string;
    experienciaLaboral:   number;
    observaciones:        string;
}


export enum TipoEmpleoEnum{
    I = "Independiente",
    E = "Empleado"
}

export enum GeneroEnum{
    M = "Masculino",
    F = "Femenino"
}