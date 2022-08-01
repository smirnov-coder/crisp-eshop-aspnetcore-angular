import { Component, Input, OnInit } from "@angular/core";
import { ColoredProductModel, ProductShortModel } from "../../../models";
import { ColorItem } from "../../shop/color-picker/color-picker.component";

@Component({
    selector: "product-thumbnail",
    templateUrl: "product-thumbnail.component.html",
    styleUrls: ["product-thumbnail.component.scss"]
})
export class ProductThumbnailComponent implements OnInit {

    @Input() product?: ProductShortModel;
    selectedColor?: ColoredProductModel;

    ngOnInit(): void {
        this.selectedColor = this.product?.availableColors.find(c => c.productId === this.product?.id);
    }

    changeColor(color: ColorItem): void {
        this.selectedColor = this.product?.availableColors.find(c => c.colorId === color.id);
    }

    getImageUrl() {
        return this.product?.availableColors.find(c => c === this.selectedColor)?.imageUrl;
    }

    getColors() {
        return this.product?.availableColors?.map(c => ({
            id: c.colorId,
            hex: c.colorHex,
            isSelected: c === this.selectedColor,
            name: c.colorName
        } as ColorItem));
    }
}