import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AgregarMarcaDto } from 'src/app/models/AgregarMarcaDto';
import { MarcasDto } from 'src/app/models/MarcasDto';
import { MarcaService } from 'src/app/services/marca.service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-update-marca',
  templateUrl: './update-marca.component.html',
  styleUrls: ['./update-marca.component.css']
})
export class UpdateMarcaComponent implements OnInit {

  updateMarcaForm: FormGroup=new FormGroup({});
  marcaById:any;
  Id:string="";

  constructor(private form:FormBuilder, private marcaService:MarcaService,
     private ruta: ActivatedRoute, private newRute: Router) { }

  ngOnInit(): void {
    this.ruta.params.subscribe(param=>{
      this.Id = param['id'];
      this.marcaService.GetById(this.Id).subscribe(item=>{
        this.marcaById=item;
        this.CreateForm(this.marcaById as MarcasDto);
      });
    })
  }

  CreateForm(marca:MarcasDto){
    this.updateMarcaForm=this.form.group({
      nombre:[marca.nombre,Validators.required]
    });
  }

  Enviar(){
    if (this.updateMarcaForm.valid){
      console.log(this.updateMarcaForm)
      this.marcaService.UpdateMarca(this.Id,this.updateMarcaForm.value as AgregarMarcaDto)
      .subscribe(item=>console.log(item));
      Swal.fire({
        icon: 'success',
        title: 'Marca actualizada con exito!',
      }).then(()=>{
        this.newRute.navigate(['admin/marca']);
      });
    }
    console.log(this.updateMarcaForm)
  }

}
