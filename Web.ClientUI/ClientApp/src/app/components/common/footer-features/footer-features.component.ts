import { Component } from "@angular/core";

@Component({
    selector: "footer-features",
    template: `
        <section>
            <h4 class="footer-section-title">Features</h4>
            <ul class="footer-link-list">
                <li *ngFor="let link of links" class="footer-link-list__item">
                    <a class="footer-link" [routerLink]="link.href">{{ link.text }}</a>
                </li>
            </ul>
        </section>
    `
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