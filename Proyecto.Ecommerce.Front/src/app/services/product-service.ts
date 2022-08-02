import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { ProductoDto } from '../models/ProductoDto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url="https://localhost:7048/api";
  productos:Array<ProductoDto>=[];

  constructor(private http : HttpClient) { }

  GetProducts():Observable<any>{
    return this.http.get(`${this.url}/Producto`);
  }

  GetById(Id:string):Observable<any>{
    return this.http.get(`${this.url}/Producto/${Id}`)
  }
}
