import { Component, OnDestroy, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { select, Store } from "@ngrx/store";
import { debounce } from "rxjs/internal/operators/debounce";
import { distinctUntilChanged } from "rxjs/internal/operators/distinctUntilChanged";
import { takeWhile } from "rxjs/internal/operators/takeWhile";
import { getProductsRequestParams, loadProducts, setPage } from "../../store/catalog";
import { isEqual } from "lodash";
import { timer } from "rxjs";

@Component({
    templateUrl: "shop.page.html",
    styleUrls: ["shop.page.scss"]
})
export class ShopPage implements OnInit, OnDestroy  {

    private subscribed = true;

    constructor(private store: Store, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.store.pipe(
                select(getProductsRequestParams),
                debounce(() => timer(100)),
                takeWhile(() => this.subscribed),
                distinctUntilChanged(isEqual)
            )
            .subscribe(request => this.store.dispatch(loadProducts({ request })));

        this.activatedRoute.queryParamMap
            .pipe(takeWhile(() => this.subscribed))
            .subscribe(params => {
                let page = 1;
                let pageParam = params.get("page");
                if (pageParam && +pageParam) {
                    page = +pageParam;
                }
                this.store.dispatch(setPage({ page }));
            });
    }

    ngOnDestroy(): void {
        this.subscribed = false;
    }
}
