import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Usuario } from '../interfaces/usuario';

@Injectable({ providedIn: 'root' })
export class FamiliaService {

   private apiUrl: string = 'https://localhost:44398/api/Familia';

   constructor(private http: HttpClient) { }


   crearFamilia(pFamiliaDto: Usuario): Observable<Usuario> {
      debugger;
      const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
      return this.http.post<Usuario>(`${this.apiUrl}/CrearFamilia/`, pFamiliaDto, { headers: headers });
   }

   buscarUsuarioPorDocumento(pDocumento: number): Observable<Usuario[]> {
      return this.http.get<Usuario[]>(`${this.apiUrl}/UsuarioPorNumeroIdentificacion?pIdentificacion=${pDocumento}`);

   }

   buscarUsuarioPorNombre(pNombre: string): Observable<Usuario[]> {
      return this.http.get<Usuario[]>(`${this.apiUrl}/UsuarioPorNombre?pNombre=${pNombre}`);

   }

}