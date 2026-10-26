export interface CreateProduct {
  sku: string;
  name: string;
  description: string | null;
  price: number;
  stockQuantity: number;
  minimumStock: number;
  categoryId: number;
}
