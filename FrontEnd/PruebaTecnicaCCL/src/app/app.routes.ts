import { Routes } from '@angular/router';
import { LoginComponent } from '../public/login/login.component';
import { ProductsComponent } from '../core/products/products.component';

export const routes: Routes = [
    {path: '', redirectTo: 'login', pathMatch: 'full'},
    {path:"login", component: LoginComponent},
    {path:"products",component:ProductsComponent}
];
