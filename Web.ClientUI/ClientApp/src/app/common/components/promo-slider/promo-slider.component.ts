import { Component, ViewEncapsulation } from "@angular/core";

import SwiperCore, { Pagination, Navigation, SwiperOptions } from "swiper";

SwiperCore.use([Pagination, Navigation]);

@Component({
    selector: "promo-slider",
    templateUrl: "promo-slider.component.html",
    styleUrls: ["promo-slider.component.scss"],
    encapsulation: ViewEncapsulation.None
})
export class PromoSliderComponent {

    config: SwiperOptions = {
        loop: true,
        navigation: {
            nextEl: ".promo-slider-nav-btn__next",
            prevEl: ".promo-slider-nav-btn__prev",
        },
        pagination: {
            type: "bullets",
            clickable: true,
            el: ".promo-slider-bullets",
            bulletClass: "promo-slider-bullet",
            bulletActiveClass: "active",
        },
    };
}