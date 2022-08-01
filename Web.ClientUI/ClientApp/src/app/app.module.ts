import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { SwiperModule } from 'swiper/angular';
import {
    AppFooterComponent,
    AppHeaderComponent,
    BrandLogoComponent,
    BreadCrumbsComponent,
    DropdownListComponent,
    FooterContactsComponent,
    FooterFeaturesComponent,
    FooterMenuComponent,
    FooterSocialMediaComponent,
    ProductThumbnailComponent,
    PromoSectionLeftComponent,
    StepperComponent,
    SubscribeFormComponent
} from './components/common';
import { HomePage, ProductPage, ShopPage } from './pages';
import {
    BrandsCarouselComponent,
    PromoGridComponent,
    PromoSliderComponent
} from './components/home';
import routes from './app.routes';
import {
    ProductCatalogComponent,
    ProductListComponent,
    PaginationComponent,
    ProductDetailsComponent,
    SizePickerComponent,
    ColorPickerComponent,
    ProductGalleryComponent
} from './components/shop';
import { StoreModule } from '@ngrx/store';
import { appReducer } from './store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';
import { CatalogEffects, CatalogService } from './store/catalog';

@NgModule({
    declarations: [
        AppComponent,
        AppHeaderComponent,
        AppFooterComponent,
        HomePage,
        ShopPage,
        ProductPage,
        BrandLogoComponent,
        FooterFeaturesComponent,
        FooterMenuComponent,
        FooterContactsComponent,
        FooterSocialMediaComponent,
        SubscribeFormComponent,
        PromoSliderComponent,
        BrandsCarouselComponent,
        PromoGridComponent,
        PromoSectionLeftComponent,
        BreadCrumbsComponent,
        ProductCatalogComponent,
        ProductListComponent,
        ProductThumbnailComponent,
        PaginationComponent,
        DropdownListComponent,
        ProductDetailsComponent,
        SizePickerComponent,
        ColorPickerComponent,
        StepperComponent,
        ProductGalleryComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        RouterModule.forRoot(routes),
        StoreModule.forRoot(appReducer),
        StoreDevtoolsModule.instrument(),
        EffectsModule.forRoot([CatalogEffects]),
        FormsModule,
        SwiperModule,
    ],
    providers: [CatalogService],
    bootstrap: [AppComponent]
})
export class AppModule { }
