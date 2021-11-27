import { PurchaseComponent } from './views/purchase/purchase.component';
import { ProductsComponent } from './views/products/products.component';
import { AccountComponent } from './views/account/account.component';
import { LoginRegisterComponent } from './views/login-register/login-register.component';
import { HomeComponent } from './views/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './views/about/about.component';

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "login", component: LoginRegisterComponent},
  {path: "account", component: AccountComponent},
  {path: "about", component: AboutComponent},
  {path: "products", component: ProductsComponent},
  {path: "purchase", component: PurchaseComponent},
 ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
