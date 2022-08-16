import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { select, Store } from "@ngrx/store";
import { Observable } from "rxjs/internal/Observable";
import { DropdownListItem } from "../../../common/components";
import { ProductSorting } from "../../../enums";
import { ProductShortModel } from "../../../models";
import { getProducts, setPageSize, setSorting } from "../../store";

@Component({
    selector: "product-catalog",
    templateUrl: "product-catalog.component.html",
    styleUrls: ["product-catalog.component.scss"]
})
export class ProductCatalogComponent implements OnInit {

    products$?: Observable<ProductShortModel[]>;
    sortings: DropdownListItem[] = [
        { value: ProductSorting.PriceAsc, text: "Price (Low to High)" },
        { value: ProductSorting.PriceDesc, text: "Price (High to Low)" },
        { value: ProductSorting.ArrivalsAsc, text: "Arrivals (New to Old)" },
        { value: ProductSorting.ArrivalsDesc, text: "Arrivals (Old to New)" },
    ];
    pageSizes: DropdownListItem[] = [
        { value: 24, text: "24" },
        { value: 36, text: "36" },
        { value: 48, text: "48" },
    ];

    constructor(private store: Store, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.products$ = this.store.pipe(select(getProducts));
    }

    sortingChanged(sorting: ProductSorting) {
        this.store.dispatch(setSorting({ sorting }));
    }

    pageSizeChanged(pageSize: number) {
        this.store.dispatch(setPageSize({ pageSize }));
    }
}