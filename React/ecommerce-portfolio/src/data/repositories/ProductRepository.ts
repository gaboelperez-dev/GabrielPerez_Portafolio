import type { Product } from '../../domain/entities/Product';

export class ProductRepository {
  async getProducts(): Promise<Product[]> {
    try {
      const response = await fetch('https://fakestoreapi.com/products');
      if (!response.ok) {
        throw new Error('Failed to fetch products');
      }
      const data: Product[] = await response.json();
      return data;
    } catch (error) {
      console.error('Error fetching products:', error);
      return [];
    }
  }

  async getProductById(id: number): Promise<Product | null> {
    try {
      const response = await fetch(`https://fakestoreapi.com/products/${id}`);
      if (!response.ok) {
        throw new Error('Failed to fetch product');
      }
      const data: Product = await response.json();
      return data;
    } catch (error) {
      console.error(`Error fetching product ${id}:`, error);
      return null;
    }
  }
}

export const productRepository = new ProductRepository();
