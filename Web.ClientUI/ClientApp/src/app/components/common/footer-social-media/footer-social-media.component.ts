import { Component } from "@angular/core";

@Component({
    selector: "footer-social-media",
    template: `
        <section>
            <h4 class="footer-section-title">Follow Us</h4>
            <ul class="footer-link-list">
                <li *ngFor="let socialMedia of items" class="footer-link-list__item">
                    <a class="footer-link" [href]="socialMedia.link">
                        <img [src]="socialMedia.icon" [alt]="socialMedia.name" />
                        {{ socialMedia.name }}
                    </a>
                </li>
            </ul>
        </section>
    `,
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