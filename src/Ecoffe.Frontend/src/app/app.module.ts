//Extern Modules
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgxMaskModule, IConfig } from 'ngx-mask';

//Pre-made Components
import { AppComponent } from './app.component';

//Material
import { MatToolbarModule} from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav'
import { MatListModule } from '@angular/material/list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card'
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';

//Created Components
import { FooterComponent } from './components/template/footer/footer.component';
import { BodyComponent } from './components/template/body/body.component';
import { HomeComponent } from './views/home/home.component';
import { HeaderComponent } from './components/template/header/header.component';
import { LoginRegisterComponent } from './views/login-register/login-register.component';
import { AccountComponent } from './views/account/account.component';
import { ProductsComponent } from './views/products/products.component' 
import { AboutComponent } from './views/about/about.component';
import { CardListComponent } from './components/card-list/card-list.component';

//Utils
import { HideCardNumberPipe } from './utils/mask';
import { CardTypePipe } from './utils/mask';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { CardNewComponent } from './components/card-new/card-new.component';
import { PersonalInfoComponent } from './components/personal-info/personal-info.component';
import { CartSidenavComponent } from './components/cart-sidenav/cart-sidenav.component';
import { ProductsDetailsComponent } from './components/products-details/products-details.component';
import { PurchaseComponent } from './views/purchase/purchase.component';
import { PurchaseDetailsComponent } from './components/purchase-details/purchase-details.component';
import { PurchaseHistoryComponent } from './components/purchase-history/purchase-history.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    BodyComponent,
    HomeComponent,
    LoginRegisterComponent,
    AccountComponent,
    ProductsComponent,
    AboutComponent,
    CardListComponent,
    HideCardNumberPipe,
    CardTypePipe,
    ConfirmDialogComponent,
    CardNewComponent,
    PersonalInfoComponent,
    ProductsDetailsComponent,
    CartSidenavComponent,
    PurchaseComponent,
    PurchaseDetailsComponent,
    PurchaseHistoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    HttpClientModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule,
    MatExpansionModule,
    MatDialogModule,
    MatSnackBarModule,
    MatSelectModule,
    MatCheckboxModule,
    NgxMaskModule.forRoot()

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
