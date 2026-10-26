export interface Product {
  id: number;
  sku: string;
  name: string;
  description: string | null;
  price: number;
  stockQuantity: number;
  minimumStock: number;
  categoryId: number;
}
