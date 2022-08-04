import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AgregarTipoProductoDto } from 'src/app/models/AgregarTipoProductoDto';
import { TipoProductoDto } from 'src/app/models/TipoProductoDto';
import { TipoProductoService } from 'src/app/services/tipo-producto.service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-update-tipo-producto',
  templateUrl: './update-tipo-producto.component.html',
  styleUrls: ['./update-tipo-producto.component.css']
})
export class UpdateTipoProductoComponent implements OnInit {

  updateTipoProductoForm: FormGroup=new FormGroup({});
  tipoProductoById:any;
  Id:string="";

  constructor(private form:FormBuilder, private tipoProductoService:TipoProductoService,
     private ruta: ActivatedRoute, private newRute: Router) { }

  ngOnInit(): void {
    this.ruta.params.subscribe(param=>{
      this.Id = param['id'];
      this.tipoProductoService.GetById(this.Id).subscribe(item=>{
        this.tipoProductoById=item;
        this.CreateForm(this.tipoProductoById as TipoProductoDto);
      });
    })
  }

  CreateForm(tipoProducto:TipoProductoDto){
    this.updateTipoProductoForm=this.form.group({
      nombre:[tipoProducto.nombre,Validators.required]
    });
  }

  Enviar(){
    if (this.updateTipoProductoForm.valid){
      console.log(this.updateTipoProductoForm)
      this.tipoProductoService.UpdateTipoProducto(this.Id,this.updateTipoProductoForm.value as AgregarTipoProductoDto)
      .subscribe(item=>console.log(item));
      Swal.fire({
        icon: 'success',
        title: 'Tipo de producto actualizado con exito!',
      }).then(()=>{
        this.newRute.navigate(['admin/tipoProducto']);
      });
    }
    console.log(this.updateTipoProductoForm)
  }

}
