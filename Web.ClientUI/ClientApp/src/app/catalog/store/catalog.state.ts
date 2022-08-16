import { ProductSorting } from "../../enums";
import { ProductFullModel, ProductShortModel } from "../../models";

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