import { Component } from "@angular/core";

@Component({
    selector: "footer-menu",
    templateUrl: "footer-menu.component.html"
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