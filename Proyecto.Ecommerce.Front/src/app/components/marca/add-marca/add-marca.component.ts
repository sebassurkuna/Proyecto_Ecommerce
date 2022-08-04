import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AgregarMarcaDto } from 'src/app/models/AgregarMarcaDto';
import { MarcaService } from 'src/app/services/marca.service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-add-marca',
  templateUrl: './add-marca.component.html',
  styleUrls: ['./add-marca.component.css']
})
export class AddMarcaComponent implements OnInit {

  addMarcaForm: FormGroup=new FormGroup({});

  constructor(private form:FormBuilder, private marcaService:MarcaService, private newRute: Router ) { }

  ngOnInit(): void {
    this.CreateForm();
  }

  CreateForm(){
    this.addMarcaForm=this.form.group({
      nombre:["",Validators.required]
    });
  }

  Enviar(){
    if (this.addMarcaForm.valid){
      console.log(this.addMarcaForm)
      this.marcaService.CreatMarca(this.addMarcaForm.value as AgregarMarcaDto)
      .subscribe(item=>console.log(item));
      Swal.fire({
        icon: 'success',
        title: 'Marca creada con exito!',
      }).then(()=>{
        this.newRute.navigate(['admin/marca']);
      });
    }
    console.log(this.addMarcaForm)
  }

}
