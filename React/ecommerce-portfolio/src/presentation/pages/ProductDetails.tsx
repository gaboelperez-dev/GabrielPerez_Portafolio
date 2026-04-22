import React, { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import { Minus, Plus } from 'lucide-react';
import type { Product } from '../../domain/entities/Product';
import { productRepository } from '../../data/repositories/ProductRepository';
import { useCartStore } from '../store/useCartStore';
import { useI18nStore } from '../store/useI18nStore';

export const ProductDetails: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const [product, setProduct] = useState<Product | null>(null);
  const [loading, setLoading] = useState(true);
  const [quantity, setQuantity] = useState(1);
  const { addToCart } = useCartStore();
  const { t } = useI18nStore();

  useEffect(() => {
    const fetchProduct = async () => {
      setLoading(true);
      const data = await productRepository.getProductById(Number(id));
      setProduct(data);
      setLoading(false);
    };
    if (id) fetchProduct();
  }, [id]);

  const decreaseQuantity = () => setQuantity(prev => Math.max(1, prev - 1));
  const increaseQuantity = () => setQuantity(prev => prev + 1);

  if (loading) return <div className="loading-state"><div className="spinner"></div><p>{t('product.loading')}</p></div>;
  if (!product) return <div className="error-state"><p>{t('product.notFound')}</p><Link to="/" className="back-link">← {t('product.back')}</Link></div>;

  return (
    <div className="product-details-container">
      <Link to="/" className="back-link">{t('product.back')}</Link>
      <div className="product-details-grid">
        <div className="details-image-container">
          <img src={product.image} alt={product.title} />
        </div>
        <div className="details-info">
          <span className="product-category">{product.category}</span>
          <h2 className="details-title">{product.title}</h2>
          <p className="details-price">${product.price.toFixed(2)}</p>
          <p className="details-description">{product.description}</p>
          
          <div className="purchase-controls">
            <div className="quantity-selector">
              <button onClick={decreaseQuantity} className="qty-btn" aria-label="Decrease quantity">
                <Minus size={16} />
              </button>
              <span className="qty-display">{quantity}</span>
              <button onClick={increaseQuantity} className="qty-btn" aria-label="Increase quantity">
                <Plus size={16} />
              </button>
            </div>
            
            <button className="add-to-cart-btn lg" onClick={() => addToCart(product, quantity)}>
              {t('product.addToCart')}
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};
