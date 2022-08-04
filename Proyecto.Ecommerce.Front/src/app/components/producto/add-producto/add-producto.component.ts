import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AgregarProductoDto } from 'src/app/models/AgregarProductoDto';
import { ProductService } from 'src/app/services/product-service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-add-producto',
  templateUrl: './add-producto.component.html',
  styleUrls: ['./add-producto.component.css']
})
export class AddProductoComponent implements OnInit {

  addProductForm: FormGroup=new FormGroup({});

  constructor(private form:FormBuilder, private productService:ProductService, private newRute: Router ) { }

  ngOnInit(): void {
    this.CreateForm();
  }

  CreateForm(){
    this.addProductForm=this.form.group({
      nombre:["",Validators.required],
      descripcion:["",Validators.required],
      precio:["",Validators.required],
      stock:["",Validators.required],
      marcaId:["",[Validators.required,Validators.maxLength(4)]],
      tipoProductoId:["",[Validators.required,Validators.maxLength(4)]]
    });
  }

  Enviar(){
    if (this.addProductForm.valid){
      console.log(this.addProductForm)
      this.productService.CreatProduct(this.addProductForm.value as AgregarProductoDto)
      .subscribe(item=>console.log(item));
      Swal.fire({
        icon: 'success',
        title: 'Producto actualizado con exito!',
      }).then(()=>{
        this.newRute.navigate(['admin/producto']);
      });
    }
    console.log(this.addProductForm)
  }

}
