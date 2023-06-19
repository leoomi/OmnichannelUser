import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserList } from 'src/models/user-list';
import { User } from 'src/models/user';

@Injectable()
export class UserService {
  constructor(private http: HttpClient) { }

  getUsers(page: number): Observable<UserList> {
    return this.http.get<UserList>(`/api/users?page=${page}`);
  }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(`/api/users/${id}`);
  }

  createUser(user: User) {
    return this.http.post<User>(`/api/users`, user);
  }

  updateUser(id: number, user: User) {
    return this.http.put<User>(`/api/users/${1}`, user);
  }
}