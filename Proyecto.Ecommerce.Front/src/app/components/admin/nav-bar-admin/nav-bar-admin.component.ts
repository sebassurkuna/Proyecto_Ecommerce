import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar-admin',
  templateUrl: './nav-bar-admin.component.html',
  styleUrls: ['./nav-bar-admin.component.css']
})
export class NavBarAdminComponent implements OnInit {

  adminZone:string="Administración"
  constructor() { }

  ngOnInit(): void {
  }

}
