import { createAction, props } from "@ngrx/store";
import { ProductSorting } from "../../enums";
import { GetProductResponse, GetProductsRequest, GetProductsResponse } from "../../models";
import { ActionTypes } from "../app.actions";

export const setSorting = createAction(
    ActionTypes.CatalogSetSorting,
    props<{ sorting: ProductSorting }>()
);

export const setPage = createAction(
    ActionTypes.CatalogSetPage,
    props<{ page: number }>()
);

export const setPageSize = createAction(
    ActionTypes.CatalogSetPageSize,
    props<{ pageSize: number }>()
);

export const loadProducts = createAction(
    ActionTypes.CatalogLoadProducts,
    props<{ request: GetProductsRequest }>()
);

export const loadProductsSuccess = createAction(
    ActionTypes.CatalogLoadProductsSuccess,
    props<{ response: GetProductsResponse }>()
);

export const loadError = createAction(
    ActionTypes.CatalogLoadError,
    props<{ error: any }>()
);

export const loadProduct = createAction(
    ActionTypes.CatalogLoadProduct,
    props<{ productId: string }>()
);

export const loadProductSuccess = createAction(
    ActionTypes.CatalogLoadProductSuccess,
    props<{ response: GetProductResponse }>()
);
