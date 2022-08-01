import { createReducer, on } from "@ngrx/store";
import { ProductSorting } from "../../enums";
import { ProductFullModel, ProductShortModel } from "../../models";
import {
    loadProducts, loadError, loadProductsSuccess, setPage, setPageSize, setSorting, loadProduct, loadProductSuccess
} from "./catalog.actions";

export interface CatalogState {
    sorting: ProductSorting;
    page: number;
    pageSize: number;
    totalPages: number;
    products: ProductShortModel[];
    error: any;
    isLoadingData: boolean;
    product?: ProductFullModel;
}

const initialState: CatalogState = {
    sorting: ProductSorting.PriceAsc,
    page: 1,
    pageSize: 24,
    totalPages: 0,
    products: [],
    error: null,
    isLoadingData: true,
    product: undefined,
}

export const catalogReducer = createReducer(
    initialState,
    on(setSorting, (state: CatalogState, { sorting }) => ({ ...state, sorting })),
    on(setPage, (state: CatalogState, { page }) => ({ ...state, page })),
    on(setPageSize, (state: CatalogState, { pageSize }) => ({ ...state, pageSize })),
    on(loadProducts, (state: CatalogState) => ({ ...state, isLoadingData: true })),
    on(loadProductsSuccess, (state: CatalogState, { response }) => ({
        ...state,
        products: response.products,
        totalPages: response.totalPages,
        isLoadingData: false
    })),
    on(loadError, (state: CatalogState, { error }) => ({ ...state, error, isLoadingData: false })),
    on(loadProduct, (state: CatalogState) => ({ ...state, isLoadingData: true })),
    on(loadProductSuccess, (state: CatalogState, { response }) => ({
        ...state,
        product: response.product,
        isLoadingData: false
    })),
);