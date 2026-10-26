import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

import { ProductService } from '../../../services/product.service';

import { Category } from '../../../models/category/category.model';
import { CategoryService } from '../../../services/category.service';

@Component({
  selector: 'app-product-create',
  imports: [ReactiveFormsModule],
  templateUrl: './product-create.html',
  styleUrl: './product-create.css',
})
export class ProductCreate {
  private readonly formBuilder = inject(FormBuilder);
  private readonly productService = inject(ProductService);
  private readonly categoryService = inject(CategoryService);

  categories = signal<Category[]>([]);

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
    this.loadCategories();
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

  createProduct(): void {
    if (this.productForm.invalid) {
      this.productForm.markAllAsTouched();
      return;
    }

    this.isLoading.set(true);
    this.errorMessage.set(null);

    const product = this.productForm.getRawValue();

    this.productService.createProduct(product).subscribe({
      next: (createdProduct) => {
        console.log('Product created:', createdProduct);
        this.isLoading.set(false);
      },
      error: (error) => {
        console.error('Error creating product:', error);

        this.errorMessage.set('Unable to create product. Please try again later.');

        this.isLoading.set(false);
      },
    });
  }
}
