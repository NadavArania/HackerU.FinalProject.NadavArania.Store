import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MdbAccordionModule } from 'mdb-angular-ui-kit/accordion';
import { MdbCarouselModule } from 'mdb-angular-ui-kit/carousel';
import { MdbCheckboxModule } from 'mdb-angular-ui-kit/checkbox';
import { MdbCollapseModule } from 'mdb-angular-ui-kit/collapse';
import { MdbDropdownModule } from 'mdb-angular-ui-kit/dropdown';
import { MdbFormsModule } from 'mdb-angular-ui-kit/forms';
import { MdbModalModule } from 'mdb-angular-ui-kit/modal';
import { MdbPopoverModule } from 'mdb-angular-ui-kit/popover';
import { MdbRadioModule } from 'mdb-angular-ui-kit/radio';
import { MdbRangeModule } from 'mdb-angular-ui-kit/range';
import { MdbRippleModule } from 'mdb-angular-ui-kit/ripple';
import { MdbScrollspyModule } from 'mdb-angular-ui-kit/scrollspy';
import { MdbTabsModule } from 'mdb-angular-ui-kit/tabs';
import { MdbTooltipModule } from 'mdb-angular-ui-kit/tooltip';
import { MdbValidationModule } from 'mdb-angular-ui-kit/validation';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { HomeCarouselComponent } from './components/home/home-carousel/home-carousel.component';
import { HomeHotComponent } from './components/home/home-hot/home-hot.component';
import { HomeCollabComponent } from './components/home/home-collab/home-collab.component';
import { ProductService } from './services/product.service';
import { CartComponent } from './components/cart/cart.component';
import { SingleProductComponent } from './components/product/single-product/single-product.component';
import { SettingsComponent } from './components/settings/settings.component';
import { UserService } from './services/user.service';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { NavigateGuardService } from './guards/navigate-guard.service';
import { DiscardChangesGuardService } from './guards/discard-changes-guard.service';
import { ValidationService } from './services/validation.service';
import { AboutComponent } from './components/about/about.component';
import { GamingProductsComponent } from './components/product/gaming-products/gaming-products.component';
import { OfficeProductsComponent } from './components/product/office-products/office-products.component';
import { CasualProductsComponent } from './components/product/casual-products/casual-products.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    HomeCarouselComponent,
    HomeHotComponent,
    HomeCollabComponent,
    CartComponent,
    SingleProductComponent,
    SettingsComponent,
    LoginComponent,
    RegisterComponent,
    AboutComponent,
    GamingProductsComponent,
    OfficeProductsComponent,
    CasualProductsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      { path: 'about', component: AboutComponent },
      { path: 'cart', component: CartComponent, canActivate: [NavigateGuardService] },
      { path: 'gaming-product', component: GamingProductsComponent },
      { path: 'office-product', component: OfficeProductsComponent },
      { path: 'casual-product', component: CasualProductsComponent },
      { path: 'single-product/:id', component: SingleProductComponent },
      { path: 'settings', component: SettingsComponent, canActivate: [NavigateGuardService], canDeactivate: [DiscardChangesGuardService] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent, canDeactivate: [DiscardChangesGuardService] },
      { path: '**', redirectTo: 'home', pathMatch: 'full' }
    ]),
    MdbAccordionModule,
    MdbCarouselModule,
    MdbCheckboxModule,
    MdbCollapseModule,
    MdbDropdownModule,
    MdbFormsModule,
    MdbModalModule,
    MdbPopoverModule,
    MdbRadioModule,
    MdbRangeModule,
    MdbRippleModule,
    MdbScrollspyModule,
    MdbTabsModule,
    MdbTooltipModule,
    MdbValidationModule,
    NoopAnimationsModule
  ],
  providers: [ProductService, UserService, NavigateGuardService, DiscardChangesGuardService, ValidationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
