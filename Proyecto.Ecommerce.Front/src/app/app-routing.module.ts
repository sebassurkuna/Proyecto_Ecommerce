import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { NavBarAdminComponent } from './components/admin/nav-bar-admin/nav-bar-admin.component';
import { CarroComprasComponent } from './components/carro-compras/carro-compras.component';
import { AddClienteComponent } from './components/clientes/add-cliente/add-cliente.component';
import { AdminClienteComponent } from './components/clientes/admin-cliente/admin-cliente.component';
import { UpdateClienteComponent } from './components/clientes/update-cliente/update-cliente.component';
import { LoginComponent } from './components/login/login.component';
import { AddMarcaComponent } from './components/marca/add-marca/add-marca.component';
import { AdminMarcaComponent } from './components/marca/admin-marca/admin-marca.component';
import { MarcaComponent } from './components/marca/marca.component';
import { UpdateMarcaComponent } from './components/marca/update-marca/update-marca.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { AddProductoComponent } from './components/producto/add-producto/add-producto.component';
import { AdminProductoComponent } from './components/producto/admin-producto/admin-producto.component';
import { DetallesComponent } from './components/producto/detalles/detalles.component';
import { ProductoComponent } from './components/producto/producto.component';
import { UpdateProductoComponent } from './components/producto/update-producto/update-producto.component';
import { AddTipoProductoComponent } from './components/tipo-producto/add-tipo-producto/add-tipo-producto.component';
import { AdminTipoProductoComponent } from './components/tipo-producto/admin-tipo-producto/admin-tipo-producto.component';
import { TipoProductoComponent } from './components/tipo-producto/tipo-producto.component';
import { UpdateTipoProductoComponent } from './components/tipo-producto/update-tipo-producto/update-tipo-producto.component';

const routes: Routes = [

  {path:"",component:NavBarComponent, 
  children:[
    {path:"",component:ProductoComponent},
    {path:"productos",component:ProductoComponent},
    {path:"productos/marca/:pipeMarca",component:ProductoComponent},
    {path:"productos/tipoProducto/:pipeTipoProducto",component:ProductoComponent},
    {path:"marcas",component:MarcaComponent},
    {path:"tipoProducto",component:TipoProductoComponent},
    {path:"detalle-producto/:id",component:DetallesComponent}
  ]},
  {path:"admin",component:NavBarAdminComponent,children:[
    {path:"",component:AdminComponent},
    {path:"marca", component:AdminMarcaComponent},
    {path:"marca/add",component:AddMarcaComponent},
    {path:"marca/update/:id", component:UpdateMarcaComponent},
    {path:"cliente", component:AdminClienteComponent},
    {path:"producto", component:AdminProductoComponent},
    {path:"tipoProducto", component:AdminTipoProductoComponent},
    {path:"producto/add",component:AddProductoComponent},
    {path:"producto/update/:id", component:UpdateProductoComponent},
    {path:"tipoProducto/add",component:AddTipoProductoComponent},
    {path:"tipoProducto/update/:id", component:UpdateTipoProductoComponent},
    {path:"cliente/add",component:AddClienteComponent},
    {path:"cliente/update/:id", component:UpdateClienteComponent}
  ]},
  {path:"carro-compras",component:CarroComprasComponent},
  {path:"login/:option",component:LoginComponent},
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
