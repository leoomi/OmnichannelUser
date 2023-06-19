import { Component } from '@angular/core';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-home.page',
  templateUrl: './home.page.component.html',
  styleUrls: ['./home.page.component.scss']
})
export class HomePageComponent {
  constructor(private userService: UserService) {}
}
