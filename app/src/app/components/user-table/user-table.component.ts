import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { User } from 'src/models/user';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
  styleUrls: ['./user-table.component.scss']
})
export class UserTableComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'email', 'phoneNumber', 'dateOfBirth', 'edit'];
  dataSource: User[] = [];
  page: number = 0;
  length: number = 0;

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.getUsers();
  }

  private getUsers() {
    this.userService.getUsers(this.page).subscribe((userList) => {
      this.dataSource = userList.users;
      this.length = userList.length;
    },
    (error) => {
      alert('Erro ao requisitar lista de usuários.' +  + JSON.stringify(error))
    });
  }

  handlePageEvent(e: PageEvent) {
    this.page = e.pageIndex;
    this.getUsers();
  }
}
