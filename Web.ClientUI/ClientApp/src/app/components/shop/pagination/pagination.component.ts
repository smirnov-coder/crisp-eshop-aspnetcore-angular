import { Component, OnDestroy, OnInit } from "@angular/core";
import { select, Store } from "@ngrx/store";
import { Observable, takeWhile } from "rxjs";
import { GetProductsRequest } from "../../../models";
import { getPaginationParams, getProductsRequestParams, } from "../../../store/catalog";

@Component({
    selector: "pagination",
    templateUrl: "pagination.component.html",
    styleUrls: ["pagination.component.scss"]
})
export class PaginationComponent implements OnInit, OnDestroy {

    private subscribed = true;
    linkParams$?: Observable<GetProductsRequest>;
    pages: number[] = [];
    page: number = 0;
    totalPages: number = 0;

    constructor(private store: Store) {
    }

    ngOnInit(): void {
        this.linkParams$ = this.store.pipe(select(getProductsRequestParams));
        this.store.pipe(
                select(getPaginationParams),
                takeWhile(() => this.subscribed)
            )
            .subscribe(params => {
                this.page = params.page;
                this.totalPages = params.totalPages;
                this.pages = this.createPagesArray(params.totalPages)
            });
    }

    ngOnDestroy(): void {
        this.subscribed = false;
    }

    private createPagesArray(totalPages: number): number[] {
        if (totalPages <= 10) {
            return [...Array<number>(totalPages).keys()].map((v, i) => v = i + 1)
        }

        if (totalPages > 10 && this.page < 5) {
            return [1, 2, 3, 4, 5, 6, 7, 0, totalPages];
        }

        if (totalPages > 10 && this.page > totalPages - 5) {
            return [1, 0, totalPages - 6, totalPages - 5, totalPages - 4, totalPages - 3, totalPages - 2, totalPages - 1, totalPages];
        }

        return [1, 0, this.page - 2, this.page - 1, this.page, this.page + 1, this.page + 2, 0, totalPages];
    }

    public getQueryParams(linkParams: GetProductsRequest, page: number) {
        return { ...linkParams, page };
    }
}