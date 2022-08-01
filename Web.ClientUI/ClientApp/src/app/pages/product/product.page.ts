import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Store } from "@ngrx/store";
import { takeWhile } from "rxjs/internal/operators/takeWhile";
import { Observable } from "rxjs/internal/Observable";
import { ProductFullModel } from "../../models";
import { getProduct, loadProduct } from "../../store/catalog";

@Component({
    templateUrl: "product.page.html"
})
export class ProductPage implements OnInit {

    private subscribed = true;
    product$?: Observable<ProductFullModel | undefined>;

    constructor(private store: Store, private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.product$ = this.store.select(getProduct);

        this.route.paramMap.pipe(
                takeWhile(() => this.subscribed)
            )
            .subscribe(params => {
                let id = params.get("id");
                if (id && +id) {
                    this.store.dispatch(loadProduct({ productId: +id }));
                }
            });
    }
}