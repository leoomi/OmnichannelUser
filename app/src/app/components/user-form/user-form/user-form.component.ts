import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { Address } from 'src/models/address';
import { User } from 'src/models/user';
import { AddressService } from 'src/services/address.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent implements OnInit {
  editing: boolean = false;
  originalUser: User | undefined;
  formGroup = new FormGroup({
    name: new FormControl('', [
      Validators.required
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    phoneNumber: new FormControl('', [
      Validators.required
    ]),
    dateOfBirth: new FormControl('', [
      Validators.required
    ]),
    address: new FormGroup({
      zipCode: new FormControl('',
        Validators.required
      ),
      line1: new FormControl('', [
        Validators.required
      ]),
      line2: new FormControl(''),
      number: new FormControl('', [
        Validators.required
      ]),
      district: new FormControl('', [
        Validators.required
      ]),
      city: new FormControl('', [
        Validators.required
      ]),
      state: new FormControl('', [
        Validators.required,
        Validators.maxLength(2)
      ])
    })
  });

  constructor(
    private addressService: AddressService,
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const id = params.get('id');
      if (id) {
        this.editing = true;
        this.userService.getUser(Number(id))
          .subscribe((data: User) => {
            this.originalUser = data;
            this.formGroup.patchValue({
              name: data.name,
              phoneNumber: data.phoneNumber,
              email: data.email,
              dateOfBirth: String(data.dateOfBirth)
            })
            this.fillAddress(data.address!);
          },
            (error) => {
              alert('Erro ao requisitar usuário.')
            });
      }
    });
  }

  getAddressFromZipCode() {
    const zipCodeForm = this.formGroup.get('address')?.get('zipCode');
    const zipCode = zipCodeForm?.value;
    if (zipCode && zipCode.length == 9) {
      this.addressService.getAddressByZipCode(zipCode)
        .subscribe((data: Address) => {
          this.fillAddress(data);
        },
          (error) => {
            alert('Erro ao procurar cep')
          });
    }
  }

  private fillAddress(data: Address) {
    const address = this.formGroup.get('address');
    address?.patchValue({
      line1: data.line1!,
      line2: data.line2!,
      number: String(data.number),
      district: data.district!,
      city: data.city!,
      state: data.state!,
      zipCode: data.zipCode!
    });
  }

  onSubmit() {
    const address = this.formGroup.get('address');
    const user = <User>{
      name: this.formGroup.get('name')?.value,
      phoneNumber: this.formGroup.get('phoneNumber')?.value,
      email: this.formGroup.get('email')?.value,
      dateOfBirth: this.formGroup.get('dateOfBirth')?.value,
      address: <Address>{
        line1: address?.get('line1')?.value,
        line2: address?.get('line2')?.value,
        number: address?.get('number')?.value,
        district: address?.get('district')?.value,
        city: address?.get('city')?.value,
        state: address?.get('state')?.value,
        zipCode: address?.get('zipCode')?.value
      }
    }

    if (this.editing) {
      user.id = this.originalUser?.id;
      user.address!.id = this.originalUser?.address?.id
      this.userService.updateUser(user.id!, user).subscribe(
        (data: User) => {
          this.router.navigate([`/`])
        },
        (error) => { alert('Erro ao criar usuário' + JSON.stringify(error.error.errors)); }
      );
      return;
    }
    this.userService.createUser(user).subscribe(
      (data: User) => {
        this.router.navigate([`/users/${data.id}`])
      },
      (error) => { alert('Erro ao criar usuário' + JSON.stringify(error.error.errors)); }
    );
  }
}
