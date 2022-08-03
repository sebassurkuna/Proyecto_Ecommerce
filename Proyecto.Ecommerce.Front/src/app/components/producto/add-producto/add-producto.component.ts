import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AgregarProductoDto } from 'src/app/models/AgregarProductoDto';
import { ProductService } from 'src/app/services/product-service';

@Component({
  selector: 'app-add-producto',
  templateUrl: './add-producto.component.html',
  styleUrls: ['./add-producto.component.css']
})
export class AddProductoComponent implements OnInit {

  addProductForm: FormGroup=new FormGroup({});

  constructor(private form:FormBuilder, private productService:ProductService ) { }

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
      alert("Producto agregado con éxito!");
    }
    console.log(this.addProductForm)
  }

}
