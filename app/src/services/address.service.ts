import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Address } from 'src/models/address';

@Injectable()
export class AddressService {
  constructor(private http: HttpClient) { }

  getAddressByZipCode(zipCode: string): Observable<Address> {
    return this.http.get<Address>(`/api/addresses/zipCode/${zipCode}`);
  }
}