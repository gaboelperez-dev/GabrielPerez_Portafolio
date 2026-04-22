import React from 'react';
import { ShoppingCart, Globe } from 'lucide-react';
import { useCartStore } from '../store/useCartStore';
import { useI18nStore } from '../store/useI18nStore';
import { Link } from 'react-router-dom';

export const Navbar: React.FC = () => {
  const { items, toggleCart } = useCartStore();
  const { t, lang, toggleLang } = useI18nStore();
  const itemCount = items.reduce((total, item) => total + item.quantity, 0);

  return (
    <nav className="navbar">
      <div className="navbar-container">
        <Link to="/" className="navbar-logo">
          {t('nav.title')}
        </Link>
        <div className="navbar-actions">
          <button className="icon-btn lang-toggle" onClick={toggleLang} aria-label="Toggle language">
            <Globe size={20} />
            <span className="lang-text">{lang.toUpperCase()}</span>
          </button>
          <button className="cart-button icon-btn" onClick={toggleCart} aria-label="Open cart">
            <ShoppingCart size={24} />
            {itemCount > 0 && <span className="cart-badge">{itemCount}</span>}
          </button>
        </div>
      </div>
    </nav>
  );
};
