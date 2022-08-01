import { Audience, Category } from "../enums";

export interface ProductShortModel {
    id: number;
    name: string;
    brand: string;
    price: number;
    colorId: number;
    availableColors: ColoredProductModel[];
    audience: Audience;
    category: Category
}

export interface ColoredProductModel {
    productId: number;
    colorId: number;
    colorName: string;
    colorHex: string;
    imageUrl: string;
}

export interface ProductFullModel extends ProductShortModel {
    code: string;
    size: string;
    coverImageUrl: string;
    imageGallery: string[];
    description: string;
    additionalInfo: string;
    attributes: ProductAttribute[];
    availableSizes: SizedProductModel[];
}

export interface ProductAttribute {
    id: number;
    name: string;
    value: any;
}

export interface SizedProductModel {
    productId: number;
    size: string;
    available: boolean;
}

export interface GetProductsRequest {
    page: number;
    pageSize: number;
}

export interface GetProductsResponse {
    page: number;
    pageSize: number;
    totalPages: number;
    products: ProductShortModel[];
}

export interface GetProductResponse {
    product: ProductFullModel;
}
