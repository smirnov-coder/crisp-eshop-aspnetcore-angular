import { Component } from "@angular/core";

@Component({
    selector: "footer-social-media",
    templateUrl: "footer-social-media.component.html",
    styles: [`
        img { margin-right: 10px; }
        li:not(:last-of-type) { margin-bottom: 25px; }
    `]
})
export class FooterSocialMediaComponent {
    public items = [
        { name: "Facebook", icon: "/assets/images/facebook.svg", link: "https://www.facebook.com" },
        { name: "Twitter", icon: "/assets/images/twitter.svg", link: "https://www.twitter.com" },
        { name: "Instagram", icon: "/assets/images/instagram.svg", link: "https://www.instagram.com" },
    ]
}