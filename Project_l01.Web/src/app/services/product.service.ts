import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Product } from '../models/product/product.module';
import { CreateProduct } from '../models/product/create-product.model';
import { PagedResult } from '../models/common/paged-result.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private readonly apiUrl = 'http://localhost:5130/api/products';

  constructor(private readonly http: HttpClient) {}

  getProducts(
    page: number = 1,
    pageSize: number = 10,
    search?: string,
    categoryId?: number,
    minPrice?: number,
    maxPrice?: number,
    lowStock?: boolean,
    sortBy?: string,
    sortDirection?: string,
  ): Observable<PagedResult<Product>> {
    let params = new HttpParams().set('page', page).set('pageSize', pageSize);

    if (search) {
      params = params.set('search', search);
    }

    if (categoryId !== undefined) {
      params = params.set('categoryId', categoryId);
    }

    if (minPrice !== undefined) {
      params = params.set('minPrice', minPrice);
    }

    if (maxPrice !== undefined) {
      params = params.set('maxPrice', maxPrice);
    }

    if (lowStock !== undefined) {
      params = params.set('lowStock', lowStock);
    }

    if (sortBy) {
      params = params.set('sortBy', sortBy);
    }

    if (sortDirection) {
      params = params.set('sortDirection', sortDirection);
    }

    return this.http.get<PagedResult<Product>>(this.apiUrl, { params });
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }

  createProduct(product: CreateProduct): Observable<Product> {
    return this.http.post<Product>(this.apiUrl, product);
  }

  updateProduct(id: number, product: CreateProduct): Observable<Product> {
    return this.http.put<Product>(`${this.apiUrl}/${id}`, product);
  }

  deleteProduct(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
