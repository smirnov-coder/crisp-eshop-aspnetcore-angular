import { Component, Input } from "@angular/core";

@Component({
    selector: "promo-section-left",
    templateUrl: "promo-section-left.component.html",
    styleUrls: ["promo-section-left.component.scss"]
})
export class PromoSectionLeftComponent {
    @Input()
    public backgroundImageUrl?: string;

    @Input()
    public title?: string;

    @Input()
    public text?: string;

    @Input()
    public buttonText?: string;

    @Input()
    public buttonLink?: string;

    @Input()
    public sectionHeight?: string;

    @Input()
    public contentWidth?: string;

    public getBackground() {
        return `url('${this.backgroundImageUrl}') no-repeat center / cover`
    }
}