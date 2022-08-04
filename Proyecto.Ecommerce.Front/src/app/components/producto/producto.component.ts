import { Component, OnInit, ɵɵqueryRefresh } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductoDto } from 'src/app/models/ProductoDto';
import { ProductService } from 'src/app/services/product-service';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {

  productos:ProductoDto[]=[];
  pipeMarca:string="";
  pipeTipoProducto:string="";
  constructor(private productService:ProductService, private ruta: ActivatedRoute) { }

  ngOnInit(): void {

    this.ruta.params.subscribe(param=>{
      if(param['pipeMarca']){
        this.pipeMarca=param['pipeMarca'];
      }
      if(param['pipeTipoProducto']){
        this.pipeTipoProducto=param['pipeTipoProducto'];
      }
      this.productService.GetProducts().subscribe(item=>{
        this.productos=item;
        console.log(item)
      })
    });
    console.log(this.productos)
    
  }

  ObtenerxId(Id:string){
   this.productService.GetById(Id).subscribe(item=>{
    console.log(item);
   })
  }

  Delete(Id:string){
    this.productService.DeleteProductById(Id).subscribe(item=>{
      console.log(item);
      if(item){
        window.location.reload();
      }
    });
  }
}
