import { Route } from "@angular/router"
import { ProductPage, ShopPage } from "./catalog/pages";
import { HomePage } from "./common/pages";

const routes: Route[] = [
    { path: "", component: HomePage, pathMatch: "full" },
    { path: "shop", component: ShopPage, pathMatch: "full" },
    { path: "shop/product/:id", component: ProductPage },
]

export default routes;