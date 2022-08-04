import { TestBed } from '@angular/core/testing';

import { CarroComprasService } from './carro-compras.service';

describe('CarroComprasService', () => {
  let service: CarroComprasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarroComprasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
