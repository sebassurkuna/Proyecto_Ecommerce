import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user:string="";
  password:string="";
  token:string="";
  constructor(private loginService:LoginService, private rute:ActivatedRoute,
    private newRute: Router) { }

  ngOnInit(): void {
  }

  Registrarse(){
    this.rute.params.subscribe(param=>{
      let option = param['option'];
      this.loginService.Registro(this.user,this.password).subscribe(item=>{
        console.log(item.token)
        this.token=item.token;
        localStorage.setItem('token',this.token)
        if(option==1){
          this.newRute.navigate(['/admin']);
        }else{
          this.newRute.navigate(['/carro-compras']);
        }
      })
    })
    
  }
}
