import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateTipoProductoComponent } from './update-tipo-producto.component';

describe('UpdateTipoProductoComponent', () => {
  let component: UpdateTipoProductoComponent;
  let fixture: ComponentFixture<UpdateTipoProductoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateTipoProductoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateTipoProductoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
