import { Component } from "@angular/core";

@Component({
    selector: "footer-contacts",
    template: `
        <section>
            <h4 class="footer-section-title">Contact us</h4>
            <ul class="contact-list">
                <li *ngFor="let contact of contacts" class="contact-list__item">
                    <div class="contact-title">{{ contact.title }}</div>
                    <div class="contact-text">{{ contact.text }}</div>
                </li>
            </ul>
        </section>
    `,
    styleUrls: ["footer-contacts.component.scss"]
})
export class FooterContactsComponent {
    public contacts = [
        { title: "Address:", text: "123 STREET NAME, CITY, ENGLAND" },
        { title: "Phone:", text: "(123) 456-7890" },
        { title: "Email:", text: "mail@example.com" },
        { title: "Working days/hours", text: "Mon - Sun / 9:00am - 8:00pm" }
    ]
}