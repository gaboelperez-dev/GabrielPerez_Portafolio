import React, { useEffect } from 'react';
import { useProductStore } from '../store/useProductStore';
import { ProductCard } from './ProductCard';
import { useI18nStore } from '../store/useI18nStore';

export const ProductList: React.FC = () => {
  const { products, isLoading, error, fetchProducts } = useProductStore();
  const { t } = useI18nStore();

  useEffect(() => {
    fetchProducts();
  }, [fetchProducts]);

  if (isLoading) {
    return (
      <div className="loading-state">
        <div className="spinner"></div>
        <p>{t('product.loading')}</p>
      </div>
    );
  }

  if (error) {
    return (
      <div className="error-state">
        <p>{error}</p>
        <button onClick={() => fetchProducts()}>Try Again</button>
      </div>
    );
  }

  return (
    <div className="products-grid">
      {products.map(product => (
        <ProductCard key={product.id} product={product} />
      ))}
    </div>
  );
};
