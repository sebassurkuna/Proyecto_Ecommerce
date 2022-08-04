import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateMarcaComponent } from './update-marca.component';

describe('UpdateMarcaComponent', () => {
  let component: UpdateMarcaComponent;
  let fixture: ComponentFixture<UpdateMarcaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateMarcaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateMarcaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
