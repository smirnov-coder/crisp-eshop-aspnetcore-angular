import { Component } from "@angular/core";

@Component({
    selector: "footer-contacts",
    templateUrl: "footer-contacts.component.html",
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