import { Component, Input, ViewEncapsulation } from "@angular/core";
import SwiperCore, { EffectFade, Thumbs } from "swiper";

SwiperCore.use([Thumbs, EffectFade]);

@Component({
    selector: "product-gallery",
    templateUrl: "product-gallery.component.html",
    styleUrls: ["product-gallery.component.scss"],
    encapsulation: ViewEncapsulation.None,
})
export class ProductGalleryComponent {

    @Input() images?: string[];
    thumbsSwiper: any;
}