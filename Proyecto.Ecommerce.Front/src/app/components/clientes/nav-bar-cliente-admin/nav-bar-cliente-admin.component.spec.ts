import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavBarClienteAdminComponent } from './nav-bar-cliente-admin.component';

describe('NavBarClienteAdminComponent', () => {
  let component: NavBarClienteAdminComponent;
  let fixture: ComponentFixture<NavBarClienteAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavBarClienteAdminComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavBarClienteAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
