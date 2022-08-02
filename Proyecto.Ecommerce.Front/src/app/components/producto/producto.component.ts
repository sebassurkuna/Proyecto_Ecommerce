import { Component, OnInit } from '@angular/core';
import { ProductoDto } from 'src/app/models/ProductoDto';
import { ProductService } from 'src/app/services/product-service';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {

  productos:ProductoDto[]=[];
  constructor(private productService:ProductService) { }

  ngOnInit(): void {

    this.productService.GetProducts().subscribe(item=>{
      this.productos=item;
      console.log(item)
    })
    console.log(this.productos)
    
  }

  ObtenerxId(Id:string){
   this.productService.GetById(Id).subscribe(item=>{
    console.log(item);
   })
  }

}
