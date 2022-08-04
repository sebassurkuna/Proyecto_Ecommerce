import { ClienteDto } from "./ClienteDto"
import { MetodoEntregaDto } from "./MetodoEntregaDto"
import { OrdenItemsDto } from "./OrdenItemsDto"

export interface OrdenCarroDto{
    ordenItemsDtos:OrdenItemsDto[],
    cliente:ClienteDto,
    metodoEntrega:MetodoEntregaDto,
    subTotal:number,
    iva:number,
    total:number,
}