import { Routes } from '@angular/router';
import { Dashboard } from './components/dashboard/dashboard';
import { Products } from './components/products/products/products';
import { ProductDetail } from './components/products/product-detail/product-detail';
import { ProductCreate } from './components/products/product-create/product-create';
import { ProductEdit } from './components/products/product-edit/product-edit';
import { Orders } from './components/orders/orders/orders';
import { OrderDetail } from './components/orders/order-detail/order-detail';
import { Customers } from './components/customers/customers/customers';

export const routes: Routes = [
  {
    path: 'dashboard',
    component: Dashboard,
  },
  {
    path: 'products',
    component: Products,
  },
  {
    path: 'products/create',
    component: ProductCreate,
  },
  {
    path: 'products/:id/edit',
    component: ProductEdit,
  },
  {
    path: 'products/:id',
    component: ProductDetail,
  },
  {
    path: 'orders',
    component: Orders,
  },
  {
    path: 'orders/:id',
    component: OrderDetail,
  },
  {
    path: 'customers',
    component: Customers,
  },
];
