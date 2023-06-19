import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home/home.page/home.page.component';
import { UserFormPageComponent } from './pages/user-form/user-form.page/user-form.page.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'users', component: UserFormPageComponent },
  { path: 'users/:id', component: UserFormPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
