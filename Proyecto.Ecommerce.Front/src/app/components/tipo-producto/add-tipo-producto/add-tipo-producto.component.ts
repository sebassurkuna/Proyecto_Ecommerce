import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AgregarTipoProductoDto } from 'src/app/models/AgregarTipoProductoDto';
import { TipoProductoService } from 'src/app/services/tipo-producto.service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-add-tipo-producto',
  templateUrl: './add-tipo-producto.component.html',
  styleUrls: ['./add-tipo-producto.component.css']
})
export class AddTipoProductoComponent implements OnInit {

  addTipoProductoForm: FormGroup=new FormGroup({});

  constructor(private form:FormBuilder, private marcaService:TipoProductoService, private newRute: Router ) { }

  ngOnInit(): void {
    this.CreateForm();
  }

  CreateForm(){
    this.addTipoProductoForm=this.form.group({
      nombre:["",Validators.required]
    });
  }

  Enviar(){
    if (this.addTipoProductoForm.valid){
      console.log(this.addTipoProductoForm)
      this.marcaService.CreatTipoProducto(this.addTipoProductoForm.value as AgregarTipoProductoDto)
      .subscribe(item=>console.log(item));
      Swal.fire({
        icon: 'success',
        title: 'Tipo de producto actualizado con exito!',
      }).then(()=>{
        this.newRute.navigate(['admin/tipoProducto']);
      });
    }
    console.log(this.addTipoProductoForm)
  }


}
