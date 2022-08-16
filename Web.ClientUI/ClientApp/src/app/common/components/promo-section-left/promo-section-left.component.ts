import { Component, Input } from "@angular/core";

@Component({
    selector: "promo-section-left",
    templateUrl: "promo-section-left.component.html",
    styleUrls: ["promo-section-left.component.scss"]
})
export class PromoSectionLeftComponent {

    @Input() backgroundImageUrl?: string;
    @Input() title?: string;
    @Input() text?: string;
    @Input() buttonText?: string;
    @Input() buttonLink?: string;
    @Input() sectionHeight?: string;
    @Input() contentWidth?: string;

    getBackground() {
        return `url('${this.backgroundImageUrl}') no-repeat center / cover`
    }
}