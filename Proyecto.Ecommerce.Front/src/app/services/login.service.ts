import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url="https://localhost:7048/api"
  constructor(private http:HttpClient) { }

  Registro(user:string,password:string):Observable<any>{
    let param = new HttpParams({
      fromObject:{
        "user":user,
        "password":password
      }
    });
    return this.http.post(`${this.url}/Token`,"",{params:param});
  }
}
