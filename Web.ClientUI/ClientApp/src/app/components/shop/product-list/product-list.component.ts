import { Component, Input } from "@angular/core";
import { ProductShortModel } from "../../../models";

@Component({
    selector: "product-list",
    templateUrl: "product-list.component.html",
    styleUrls: ["product-list.component.scss"]
})
export class ProductListComponent {
    @Input()
    public products?: ProductShortModel[];
}