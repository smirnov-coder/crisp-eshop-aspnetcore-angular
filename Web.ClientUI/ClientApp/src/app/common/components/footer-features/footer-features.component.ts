import { Component } from "@angular/core";

@Component({
    selector: "footer-features",
    templateUrl: "footer-features.component.html"
})
export class FooterFeaturesComponent {
    public links = [
        { text: "Men", href: "/shop" },
        { text: "Women", href: "/shop" },
        { text: "Boys", href: "/shop" },
        { text: "Girls", href: "/shop" },
        { text: "New arrivals", href: "/shop" },
        { text: "Shoes", href: "/shop" },
        { text: "Clothes", href: "/shop" },
    ]
}