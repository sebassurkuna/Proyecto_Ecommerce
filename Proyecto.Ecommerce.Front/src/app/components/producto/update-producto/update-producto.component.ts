import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AgregarProductoDto } from 'src/app/models/AgregarProductoDto';
import { ProductoDto } from 'src/app/models/ProductoDto';
import { ProductService } from 'src/app/services/product-service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-update-producto',
  templateUrl: './update-producto.component.html',
  styleUrls: ['./update-producto.component.css']
})
export class UpdateProductoComponent implements OnInit {

  updateProductForm: FormGroup=new FormGroup({});
  productById:any;
  Id:string="";

  constructor(private form:FormBuilder, private productService:ProductService,
     private ruta: ActivatedRoute, private newRute: Router) { }

  ngOnInit(): void {
    this.ruta.params.subscribe(param=>{
      this.Id = param['id'];
      this.productService.GetById(this.Id).subscribe(item=>{
        this.productById=item;
        this.CreateForm(this.productById as ProductoDto);
      });
    })
  }

  CreateForm(product:ProductoDto){
    this.updateProductForm=this.form.group({
      nombre:[product.nombre,Validators.required],
      descripcion:[product.descripcion,Validators.required],
      precio:[product.precio,Validators.required],
      stock:[product.stock,Validators.required],
      marcaId:[product.marcaId,[Validators.required,Validators.maxLength(4)]],
      tipoProductoId:[product.tipoProductoId,[Validators.required,Validators.maxLength(4)]]
    });
  }

  Enviar(){
    if (this.updateProductForm.valid){
      console.log(this.updateProductForm)
      this.productService.UpdateProduct(this.Id,this.updateProductForm.value as AgregarProductoDto)
      .subscribe(item=>console.log(item));
      Swal.fire({
        icon: 'success',
        title: 'Producto actualizado con exito!',
      }).then(()=>{
        this.newRute.navigate(['admin/producto']);
      });
    }
    console.log(this.updateProductForm)
  }
}
