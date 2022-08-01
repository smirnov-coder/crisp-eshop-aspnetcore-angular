import { Component } from "@angular/core";

@Component({
    selector: "footer-menu",
    template: `
        <section>
            <h4 class="footer-section-title">Menu</h4>
            <ul class="footer-link-list">
                <li *ngFor="let link of links" class="footer-link-list__item">
                    <a class="footer-link" [routerLink]="link.href">{{ link.text }}</a>
                </li>
            </ul>
        </section>
    `
})
export class FooterMenuComponent {
    public links = [
        { text: "About Us", href: "/about-us" },
        { text: "Contact Us", href: "/contact-us" },
        { text: "My account", href: "/my-account" },
        { text: "Orders History", href: "/orders-history" },
        { text: "My Wishlist", href: "/my-wishlist" },
        { text: "Blog", href: "/blog" },
        { text: "Login", href: "/login" },
    ]
}