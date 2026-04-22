import { create } from 'zustand';

type Language = 'es' | 'en';

interface Translations {
  [key: string]: { es: string; en: string };
}

const translations: Translations = {
  // Navbar
  'nav.title': { es: 'ModernaStore', en: 'ModernStore' },
  'nav.cart': { es: 'Carrito', en: 'Cart' },
  // Home
  'home.hero.title': { es: 'Eleva tu Estilo', en: 'Elevate Your Style' },
  'home.hero.subtitle': { es: 'Descubre nuestra última colección con ofertas increíbles', en: 'Discover our premium collection with incredible details' },
  'home.featured': { es: 'Productos Destacados', en: 'Featured Products' },
  'home.discover': { es: 'Encuentra exactamente lo que necesitas', en: 'Find exactly what you are looking for' },
  // Products
  'product.addToCart': { es: 'Añadir al Carrito', en: 'Add to Cart' },
  'product.back': { es: '← Volver a Productos', en: '← Back to Products' },
  'product.notFound': { es: 'Producto no encontrado.', en: 'Product not found.' },
  'product.loading': { es: 'Cargando...', en: 'Loading...' },
  // Cart
  'cart.title': { es: 'Tu Carrito', en: 'Your Cart' },
  'cart.empty': { es: 'Tu carrito está vacío.', en: 'Your cart is empty.' },
  'cart.continue': { es: 'Seguir Comprando', en: 'Continue Shopping' },
  'cart.total': { es: 'Total:', en: 'Total:' },
  'cart.checkout': { es: 'Proceder al Pago', en: 'Proceed to Checkout' },
  // Checkout
  'checkout.title': { es: 'Finalizar Compra', en: 'Checkout' },
  'checkout.name': { es: 'Nombre Completo', en: 'Full Name' },
  'checkout.address': { es: 'Dirección de Envío', en: 'Shipping Address' },
  'checkout.confirm': { es: 'Confirmar Pedido', en: 'Confirm Order' },
  'checkout.success': { es: '¡Pedido Confirmado!', en: 'Order Confirmed!' },
  'checkout.successMsg': { es: 'Gracias por tu compra.', en: 'Thank you for your purchase.' },
  'checkout.backHome': { es: 'Volver al Inicio', en: 'Back to Home' }
};

interface I18nState {
  lang: Language;
  toggleLang: () => void;
  t: (key: string) => string;
}

export const useI18nStore = create<I18nState>((set, get) => ({
  lang: 'es',
  toggleLang: () => set((state) => ({ lang: state.lang === 'es' ? 'en' : 'es' })),
  t: (key: string) => {
    const { lang } = get();
    return translations[key]?.[lang] || key;
  }
}));
