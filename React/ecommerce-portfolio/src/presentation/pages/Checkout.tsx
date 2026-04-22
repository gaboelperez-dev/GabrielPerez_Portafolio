import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useCartStore } from '../store/useCartStore';
import { useI18nStore } from '../store/useI18nStore';

export const Checkout: React.FC = () => {
  const { items, getTotalPrice, clearCart } = useCartStore();
  const { t } = useI18nStore();
  const navigate = useNavigate();

  const [isSuccess, setIsSuccess] = useState(false);

  const handleCheckout = (e: React.FormEvent) => {
    e.preventDefault();
    clearCart();
    setIsSuccess(true);
  };

  if (isSuccess) {
    return (
      <div className="checkout-success">
        <div className="success-icon">✓</div>
        <h2>{t('checkout.success')}</h2>
        <p>{t('checkout.successMsg')}</p>
        <button className="add-to-cart-btn" onClick={() => navigate('/')}>
          {t('checkout.backHome')}
        </button>
      </div>
    );
  }

  return (
    <div className="checkout-container">
      <h2>{t('checkout.title')}</h2>
      
      <div className="checkout-grid">
        <form className="checkout-form" onSubmit={handleCheckout}>
          <div className="form-group">
            <label>{t('checkout.name')}</label>
            <input type="text" required placeholder="John Doe" />
          </div>
          <div className="form-group">
            <label>{t('checkout.address')}</label>
            <input type="text" required placeholder="123 Main St" />
          </div>
          <button type="submit" className="add-to-cart-btn lg" disabled={items.length === 0}>
            {t('checkout.confirm')}
          </button>
        </form>

        <div className="checkout-summary">
          <h3>{t('cart.title')}</h3>
          {items.map(item => (
            <div key={item.product.id} className="summary-item">
              <span>{item.quantity}x {item.product.title}</span>
              <span>${(item.product.price * item.quantity).toFixed(2)}</span>
            </div>
          ))}
          <div className="summary-total">
            <span>{t('cart.total')}</span>
            <span>${getTotalPrice().toFixed(2)}</span>
          </div>
        </div>
      </div>
    </div>
  );
};
