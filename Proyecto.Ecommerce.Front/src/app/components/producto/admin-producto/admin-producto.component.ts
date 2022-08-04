import { Component, OnInit } from '@angular/core';
import { ProductoDto } from 'src/app/models/ProductoDto';
import { ProductService } from 'src/app/services/product-service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-admin-producto',
  templateUrl: './admin-producto.component.html',
  styleUrls: ['./admin-producto.component.css']
})
export class AdminProductoComponent implements OnInit {

  productos:ProductoDto[]=[];
  constructor(private productService:ProductService) { }

  ngOnInit(): void {

    this.productService.GetProducts().subscribe(item=>{
      this.productos=item;
      console.log(item)
    });
    console.log(this.productos)
  }

  Delete(Id:string){
    Swal.fire({
      title: '¿Está Seguro de eliminar el producto?',
      icon: 'info',
      showCloseButton: true,
      showCancelButton: true,
      focusConfirm: false,
      confirmButtonText:
        'Si',
      confirmButtonAriaLabel: 'Thumbs up, great!',
      cancelButtonText:
        'No',
      cancelButtonAriaLabel: 'Thumbs down'
    }).then(resp=>{
      if(resp.isConfirmed){
        console.log(resp.isConfirmed)
        this.productService.DeleteProductById(Id).subscribe(item=>{
          console.log(item);
          if(item){
            window.location.reload();
          }
        });
      }else{
        return;
      }
    })

    
  }

}
