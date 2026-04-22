import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Navbar } from './presentation/components/Navbar';
import { CartSidebar } from './presentation/components/CartSidebar';
import { Home } from './presentation/pages/Home';
import { ProductDetails } from './presentation/pages/ProductDetails';
import { Checkout } from './presentation/pages/Checkout';

function App() {
  return (
    <Router>
      <div className="app-container">
        <Navbar />
        <main className="main-content">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/product/:id" element={<ProductDetails />} />
            <Route path="/checkout" element={<Checkout />} />
          </Routes>
        </main>
        <CartSidebar />
      </div>
    </Router>
  );
}

export default App;
