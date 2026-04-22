import React from 'react';
import { ProductList } from '../components/ProductList';
import { useI18nStore } from '../store/useI18nStore';

export const Home: React.FC = () => {
  const { t } = useI18nStore();

  return (
    <>
      <div className="hero-section">
        <div className="hero-content">
          <h1>{t('home.hero.title')}</h1>
          <p>{t('home.hero.subtitle')}</p>
        </div>
      </div>
      <header className="page-header">
        <h2>{t('home.featured')}</h2>
        <p>{t('home.discover')}</p>
      </header>
      <ProductList />
    </>
  );
};
