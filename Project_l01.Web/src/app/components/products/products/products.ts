import { Component, OnInit, inject, signal } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { Product } from '../../../models/product/product.module';
import { RouterLink } from '@angular/router';
import { CategoryService } from '../../../services/category.service';
import { Category } from '../../../models/category/category.model';

@Component({
  selector: 'app-products',
  imports: [RouterLink],
  templateUrl: './products.html',
  styleUrl: './products.css',
})
export class Products implements OnInit {
  private readonly productService = inject(ProductService);
  private readonly categoryService = inject(CategoryService);

  products = signal<Product[]>([]);
  categories = signal<Category[]>([]);

  currentPage = signal(1);
  pageSize = signal(4);
  totalPages = signal(0);
  totalCount = signal(0);

  search = signal('');
  categoryId = signal<number | undefined>(undefined);
  minPrice = signal<number | undefined>(undefined);
  maxPrice = signal<number | undefined>(undefined);
  lowStock = signal(false);

  sortBy = signal('');
  sortDirection = signal('');

  isLoading = signal<boolean>(false);
  errorMessage = signal<string | null>(null);
  deletingProductId = signal<number | null>(null);

  ngOnInit(): void {
    this.loadProducts();
    this.loadCategories();
  }

  loadProducts(): void {
    this.isLoading.set(true);
    this.errorMessage.set(null);

    this.productService
      .getProducts(
        this.currentPage(),
        this.pageSize(),
        this.search(),
        this.categoryId(),
        this.minPrice(),
        this.maxPrice(),
        this.lowStock(),
        this.sortBy(),
        this.sortDirection(),
      )
      .subscribe({
        next: (result) => {
          this.products.set(result.items);

          this.currentPage.set(result.page);
          this.pageSize.set(result.pageSize);
          this.totalPages.set(result.totalPages);
          this.totalCount.set(result.totalCount);

          this.isLoading.set(false);
        },
        error: (error) => {
          console.error('Error loading products:', error);

          this.errorMessage.set('Unable to load products. Please try again later.');

          this.isLoading.set(false);
        },
      });
  }

  loadCategories(): void {
    this.categoryService.getCategories().subscribe({
      next: (categories) => {
        this.categories.set(categories);
      },
      error: (error) => {
        console.error('Error loading categories:', error);
      },
    });
  }

  deleteProduct(id: number): void {
    const confirmed = confirm('Are you sure you want to delete this product?');

    if (!confirmed) {
      return;
    }

    this.deletingProductId.set(id);
    this.errorMessage.set(null);

    this.productService.deleteProduct(id).subscribe({
      next: () => {
        this.products.update((products) => products.filter((product) => product.id !== id));

        this.deletingProductId.set(null);
      },
      error: (error) => {
        console.error('Error deleting product:', error);

        this.errorMessage.set('Unable to delete product. Please try again later.');

        this.deletingProductId.set(null);
      },
    });
  }

  setCategoryId(value: string): void {
    this.categoryId.set(value === '' ? undefined : Number(value));
  }

  setMinPrice(value: string): void {
    this.minPrice.set(value === '' ? undefined : Number(value));
  }

  setMaxPrice(value: string): void {
    this.maxPrice.set(value === '' ? undefined : Number(value));
  }

  setSortBy(value: string): void {
    this.sortBy.set(value);
  }

  setSortDirection(value: string): void {
    this.sortDirection.set(value);
  }

  applyFilters(): void {
    this.currentPage.set(1);
    this.loadProducts();
  }

  resetFilters(): void {
    this.search.set('');
    this.categoryId.set(undefined);
    this.minPrice.set(undefined);
    this.maxPrice.set(undefined);
    this.lowStock.set(false);
    this.sortBy.set('');
    this.sortDirection.set('');

    this.currentPage.set(1);

    this.loadProducts();
  }

  previousPage(): void {
    if (this.currentPage() <= 1) {
      return;
    }

    this.currentPage.update((page) => page - 1);
    this.loadProducts();
  }

  nextPage(): void {
    if (this.currentPage() >= this.totalPages()) {
      return;
    }

    this.currentPage.update((page) => page + 1);
    this.loadProducts();
  }
}
