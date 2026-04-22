import React from 'react';
import { X, Trash2, Plus, Minus } from 'lucide-react';
import { useNavigate } from 'react-router-dom';
import { useCartStore } from '../store/useCartStore';
import { useI18nStore } from '../store/useI18nStore';

export const CartSidebar: React.FC = () => {
  const { isCartOpen, toggleCart, items, removeFromCart, addToCart, getTotalPrice } = useCartStore();
  const { t } = useI18nStore();
  const navigate = useNavigate();

  if (!isCartOpen) return null;

  const handleCheckout = () => {
    toggleCart();
    navigate('/checkout');
  };

  return (
    <>
      <div className="cart-overlay" onClick={toggleCart} />
      <div className="cart-sidebar">
        <div className="cart-header">
          <h2>{t('cart.title')}</h2>
          <button className="icon-btn" onClick={toggleCart} aria-label="Close cart">
            <X size={24} />
          </button>
        </div>

        <div className="cart-items">
          {items.length === 0 ? (
            <div className="empty-cart">
              <p>{t('cart.empty')}</p>
              <button className="continue-shopping" onClick={toggleCart}>
                {t('cart.continue')}
              </button>
            </div>
          ) : (
            items.map(item => (
              <div key={item.product.id} className="cart-item">
                <img src={item.product.image} alt={item.product.title} />
                <div className="cart-item-details">
                  <h4>{item.product.title}</h4>
                  <p className="item-price">${item.product.price.toFixed(2)}</p>
                  <div className="quantity-controls">
                    <button 
                      onClick={() => {
                        if(item.quantity === 1) removeFromCart(item.product.id)
                        else {
                          removeFromCart(item.product.id);
                          // Simplified decrement for UI:
                          for(let i=0; i<item.quantity-1; i++) addToCart(item.product as any);
                        }
                      }}
                      className="qty-btn"
                    >
                      <Minus size={16} />
                    </button>
                    <span>{item.quantity}</span>
                    <button 
                      onClick={() => addToCart(item.product)}
                      className="qty-btn"
                    >
                      <Plus size={16} />
                    </button>
                  </div>
                </div>
                <button 
                  className="remove-btn icon-btn" 
                  onClick={() => removeFromCart(item.product.id)}
                  aria-label="Remove item"
                >
                  <Trash2 size={20} />
                </button>
              </div>
            ))
          )}
        </div>

        {items.length > 0 && (
          <div className="cart-footer">
            <div className="cart-total">
              <span>{t('cart.total')}</span>
              <span>${getTotalPrice().toFixed(2)}</span>
            </div>
            <button className="checkout-btn" onClick={handleCheckout}>
              {t('cart.checkout')}
            </button>
          </div>
        )}
      </div>
    </>
  );
};
