import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { GetProductResponse, GetProductsRequest, GetProductsResponse } from "../../models";

@Injectable()
export class CatalogService {

    constructor(private httpClient: HttpClient) {
    }

    getProducts(request: GetProductsRequest): Observable<GetProductsResponse> {
        return this.httpClient.get<GetProductsResponse>("/api/products", { params: { ...request } });
    }

    getProduct(productId: number): Observable<GetProductResponse> {
        return this.httpClient.get<GetProductResponse>(`/api/products/${productId}`);
    }
}