import { create } from 'zustand';
import type { Product } from '../../domain/entities/Product';
import type { CartItem } from '../../domain/entities/CartItem';

interface CartState {
  items: CartItem[];
  isCartOpen: boolean;
  toggleCart: () => void;
  addToCart: (product: Product, quantity?: number) => void;
  removeFromCart: (productId: number) => void;
  clearCart: () => void;
  getTotalPrice: () => number;
}

export const useCartStore = create<CartState>((set, get) => ({
  items: [],
  isCartOpen: false,
  toggleCart: () => set((state) => ({ ...state, isCartOpen: !state.isCartOpen })),
  addToCart: (product: Product, quantity: number = 1) => {
    set((state) => {
      const existingItem = state.items.find(item => item.product.id === product.id);
      if (existingItem) {
        return {
          items: state.items.map(item =>
            item.product.id === product.id
              ? { ...item, quantity: item.quantity + quantity }
              : item
          )
        };
      }
      return { items: [...state.items, { product, quantity }] };
    });
  },
  removeFromCart: (productId: number) => {
    set((state) => ({
      items: state.items.filter(item => item.product.id !== productId)
    }));
  },
  clearCart: () => set({ items: [] }),
  getTotalPrice: () => {
    const { items } = get();
    return items.reduce((total, item) => total + (item.product.price * item.quantity), 0);
  }
}));
