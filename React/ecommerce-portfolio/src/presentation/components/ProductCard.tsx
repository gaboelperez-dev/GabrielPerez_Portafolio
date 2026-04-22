import React from 'react';
import { Link } from 'react-router-dom';
import type { Product } from '../../domain/entities/Product';
import { useCartStore } from '../store/useCartStore';
import { useI18nStore } from '../store/useI18nStore';

interface ProductCardProps {
  product: Product;
}

export const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
  const { addToCart } = useCartStore();
  const { t } = useI18nStore();

  return (
    <div className="product-card">
      <Link to={`/product/${product.id}`} className="product-card-link">
        <div className="product-image-container">
          <img src={product.image} alt={product.title} className="product-image" loading="lazy" />
        </div>
        <div className="product-info">
          <span className="product-category">{product.category}</span>
          <h3 className="product-title" title={product.title}>{product.title}</h3>
          <p className="product-price">${product.price.toFixed(2)}</p>
        </div>
      </Link>
      <div style={{ padding: '0 1.5rem 1.5rem 1.5rem' }}>
        <button 
          className="add-to-cart-btn"
          onClick={() => addToCart(product)}
        >
          {t('product.addToCart')}
        </button>
      </div>
    </div>
  );
};
