import { Component, ViewEncapsulation } from "@angular/core";
import { SwiperOptions } from "swiper";

@Component({
    selector: "brands-carousel",
    templateUrl: "brands-carousel.component.html",
    styleUrls: ["brands-carousel.component.scss"],
    encapsulation: ViewEncapsulation.None
})
export class BrandsCarouselComponent {
    public config: SwiperOptions = {
        slidesPerView: 7,
        spaceBetween: 20,
    }
}