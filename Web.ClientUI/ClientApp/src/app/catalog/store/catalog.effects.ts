import { HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { of } from "rxjs/internal/observable/of";
import { catchError } from "rxjs/internal/operators/catchError";
import { map } from "rxjs/internal/operators/map";
import { switchMap } from "rxjs/internal/operators/switchMap";
import { ActionTypes } from "../../store";
import { CatalogService } from "../services";
import { loadError, loadProductsSuccess, loadProductSuccess } from "./catalog.actions";

@Injectable()
export class CatalogEffects {

    constructor(private actions$: Actions, private catalogService: CatalogService) {
    }

    loadProducts$ = createEffect(() => this.actions$.pipe(
        ofType(ActionTypes.CatalogLoadProducts),
        switchMap((action: any) => this.catalogService.getProducts(action.request)
            .pipe(
                map(response => loadProductsSuccess({ response })),
                catchError((error: HttpErrorResponse) => of(loadError({ error })))
            )
        )
    ));

    loadProduct$ = createEffect(() => this.actions$.pipe(
        ofType(ActionTypes.CatalogLoadProduct),
        switchMap((action: any) => this.catalogService.getProduct(action.productId)
            .pipe(
                map(response => loadProductSuccess({ response })),
                catchError((error: HttpErrorResponse) => of(loadError({ error })))
            )
        )
    ));

}