import { Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ColorItem, SizeItem } from "..";
import { ProductFullModel } from "../../../models";

@Component({
    selector: "product-details",
    templateUrl: "product-details.component.html",
    styleUrls: ["product-details.component.scss"]
})
export class ProductDetailsComponent implements OnInit {

    @Input() product?: ProductFullModel;
    sizes: SizeItem[] = [];
    colors: ColorItem[] = []
    quantity: number = 1;
    totalPrice: number = 0;

    constructor(private router: Router) {
    }

    ngOnInit(): void {
        this.sizes = this.product?.availableSizes.map(s => ({
            size: s.size,
            available: s.available,
            isSelected: s.size === this.product?.size
        } as SizeItem)) ?? [];

        this.colors = this.product?.availableColors?.map(c => ({
            id: c.colorId,
            hex: c.colorHex,
            isSelected: c.colorId === this.product?.colorId,
            name: c.colorName
        } as ColorItem)) ?? [];

        this.calcTotalPrice(this.quantity);
    }

    sizeChanged(item: SizeItem) {
        let productId = this.product?.availableSizes.find(s => s.size === item.size)?.productId;
        if (productId) {
            this.router.navigate(["/shop/product", productId]);
        }
    }

    hasManyColors() {
        return this.product?.availableColors && this.product.availableColors.length > 1;
    }

    colorChanged(item: ColorItem) {
        let productId = this.product?.availableColors.find(c => c.colorId === item.id)?.productId;
        if (productId) {
            this.router.navigate(["/shop/product", productId]);
        }
    }

    calcTotalPrice(quantity: number) {
        this.totalPrice = quantity * (this.product?.price ?? 0);
    }

    getImageGallery() {
        let imageGallery = [...this.product!.imageGallery];
        imageGallery.unshift(this.product!.coverImageUrl);
        return imageGallery;
    }
}