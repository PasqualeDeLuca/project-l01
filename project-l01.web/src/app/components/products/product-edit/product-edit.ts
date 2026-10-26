import { Component, OnInit, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductService } from '../../../services/product.service';

import { Category } from '../../../models/category/category.model';
import { CategoryService } from '../../../services/category.service';

@Component({
  selector: 'app-product-edit',
  imports: [ReactiveFormsModule],
  templateUrl: './product-edit.html',
  styleUrl: './product-edit.css',
})
export class ProductEdit implements OnInit {
  private readonly route = inject(ActivatedRoute);
  private readonly formBuilder = inject(FormBuilder);
  private readonly productService = inject(ProductService);
  private readonly categoryService = inject(CategoryService);

  categories = signal<Category[]>([]);
  productId!: number;
  isLoading = signal<boolean>(false);
  errorMessage = signal<string | null>(null);

  productForm = this.formBuilder.nonNullable.group({
    sku: ['', Validators.required],
    name: ['', Validators.required],
    description: [''],
    price: [0, [Validators.required, Validators.min(0)]],
    stockQuantity: [0, [Validators.required, Validators.min(0)]],
    minimumStock: [0, [Validators.required, Validators.min(0)]],
    categoryId: [0, [Validators.required, Validators.min(1)]],
  });

  ngOnInit(): void {
    this.productId = Number(this.route.snapshot.paramMap.get('id'));

    this.loadCategories();
    this.loadProduct();
  }

  private loadCategories(): void {
    this.categoryService.getCategories().subscribe({
      next: (categories) => {
        this.categories.set(categories);
      },
      error: (error) => {
        console.error('Error loading categories:', error);
      },
    });
  }

  private loadProduct(): void {
    this.productService.getProduct(this.productId).subscribe((product) => {
      this.productForm.patchValue({
        sku: product.sku,
        name: product.name,
        description: product.description ?? '',
        price: product.price,
        stockQuantity: product.stockQuantity,
        minimumStock: product.minimumStock,
        categoryId: product.categoryId,
      });
    });
  }

  updateProduct(): void {
    if (this.productForm.invalid) {
      this.productForm.markAllAsTouched();
      return;
    }

    this.isLoading.set(true);
    this.errorMessage.set(null);

    const product = this.productForm.getRawValue();

    this.productService.updateProduct(this.productId, product).subscribe({
      next: (updatedProduct) => {
        console.log('Product updated:', updatedProduct);

        this.isLoading.set(false);
      },
      error: (error) => {
        console.error('Error updating product:', error);

        this.errorMessage.set('Unable to update product. Please try again later.');

        this.isLoading.set(false);
      },
    });
  }
}
