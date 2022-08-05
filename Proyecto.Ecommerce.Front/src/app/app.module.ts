import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductoComponent } from './components/producto/producto.component';
import { AddProductoComponent } from './components/producto/add-producto/add-producto.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UpdateProductoComponent } from './components/producto/update-producto/update-producto.component';
import { MarcaComponent } from './components/marca/marca.component';
import { AddMarcaComponent } from './components/marca/add-marca/add-marca.component';
import { UpdateMarcaComponent } from './components/marca/update-marca/update-marca.component';
import { TipoProductoComponent } from './components/tipo-producto/tipo-producto.component';
import { AddTipoProductoComponent } from './components/tipo-producto/add-tipo-producto/add-tipo-producto.component';
import { UpdateTipoProductoComponent } from './components/tipo-producto/update-tipo-producto/update-tipo-producto.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { AddClienteComponent } from './components/clientes/add-cliente/add-cliente.component';
import { UpdateClienteComponent } from './components/clientes/update-cliente/update-cliente.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { MarcaFilterPipe } from './pipes/marca-filter.pipe';
import { TipoProductoFilterPipe } from './pipes/tipo-producto-filter.pipe';
import { AdminClienteComponent } from './components/clientes/admin-cliente/admin-cliente.component';
import { AdminComponent } from './components/admin/admin.component';
import { AdminMarcaComponent } from './components/marca/admin-marca/admin-marca.component';
import { AdminProductoComponent } from './components/producto/admin-producto/admin-producto.component';
import { AdminTipoProductoComponent } from './components/tipo-producto/admin-tipo-producto/admin-tipo-producto.component';
import { NavBarClienteAdminComponent } from './components/clientes/nav-bar-cliente-admin/nav-bar-cliente-admin.component';
import { NavBarAdminComponent } from './components/admin/nav-bar-admin/nav-bar-admin.component';
import { DetallesComponent } from './components/producto/detalles/detalles.component';
import { CarroComprasComponent } from './components/carro-compras/carro-compras.component';
import { LoginComponent } from './components/login/login.component';
import { AuthInterceptorInterceptor } from './interceptors/auth-interceptor.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    ProductoComponent,
    AddProductoComponent,
    UpdateProductoComponent,
    MarcaComponent,
    AddMarcaComponent,
    UpdateMarcaComponent,
    TipoProductoComponent,
    AddTipoProductoComponent,
    UpdateTipoProductoComponent,
    ClientesComponent,
    AddClienteComponent,
    UpdateClienteComponent,
    NavBarComponent,
    MarcaFilterPipe,
    TipoProductoFilterPipe,
    AdminClienteComponent,
    AdminComponent,
    AdminMarcaComponent,
    AdminProductoComponent,
    AdminTipoProductoComponent,
    NavBarClienteAdminComponent,
    NavBarAdminComponent,
    DetallesComponent,
    CarroComprasComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorInterceptor, multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
