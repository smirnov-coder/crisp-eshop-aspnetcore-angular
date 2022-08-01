import { Route } from "@angular/router"
import { HomePage, ProductPage, ShopPage } from "./pages";

const routes: Route[] = [
    { path: "", component: HomePage, pathMatch: "full" },
    { path: "shop", component: ShopPage, pathMatch: "full" },
    { path: "shop/product/:id", component: ProductPage },

//    { path: "shop/:audience", component: ShopPage },
//    { path: "shop/:audience/:category", component: ShopPage },
//    { path: "shop/:audience/:category/:id", component: ProductPage },
]

export default routes;