import { createFeatureSelector, createSelector } from "@ngrx/store";
import { GetProductsRequest } from "../../models";
import { CatalogState } from "./catalog.state";

const getCatalogState = createFeatureSelector<CatalogState>("catalog");

export const getSorting = createSelector(
    getCatalogState,
    (state) => state.sorting
);

//export const getPage = createSelector(
//    getCatalogState,
//    (state) => state.page
//);

export const getPageSize = createSelector(
    getCatalogState,
    (state) => state.pageSize
);

export const getProducts = createSelector(
    getCatalogState,
    (state) => state.products
);

export const getProduct = createSelector(
    getCatalogState,
    (state) => state.product
);

//export const getTotalPages = createSelector(
//    getCatalogState,
//    (state) => state.totalPages
//);

export const getProductsRequestParams = createSelector(
    getCatalogState,
    (state) => ({
        page: state.page,
        pageSize: state.pageSize,
        sorting: state.sorting
    } as GetProductsRequest)
);

export const getPaginationParams = createSelector(
    getCatalogState,
    (state) => ({ page: state.page, totalPages: state.totalPages })
)
