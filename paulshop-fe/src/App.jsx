import { useState, useEffect } from 'react'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import axios from 'axios'
import Header from './components/Header'
import ProductCard from './components/ProductCard'
import Login from './pages/Login';

// Chúng ta tách phần Danh sách sản phẩm thành một Component riêng để App.jsx gọn hơn
function HomePage({ products, loading }) {
  if (loading) return <div style={{ textAlign: 'center', padding: '50px' }}>Đang tải sản phẩm...</div>;

  return (
    <div style={{ display: 'flex', gap: '25px', flexWrap: 'wrap', justifyContent: 'center', padding: '0 20px' }}>
      {products.map(item => (
        <ProductCard key={item.id} item={item} />
      ))}
    </div>
  );
}

function App() {
  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Gọi API từ Backend .NET của bạn
    axios.get('https://localhost:7205/api/Products')
      .then(res => {
        setProducts(res.data);
        setLoading(false);
      })
      .catch(err => {
        console.error("Lỗi:", err);
        setLoading(false);
      });
  }, []);

  return (
    <BrowserRouter> {/* <--- PHẢI BẮT ĐẦU TỪ ĐÂY */}
      <div style={{ fontFamily: 'Arial, sans-serif' }}>
        
        {/* Header bây giờ đã nằm TRONG BrowserRouter nên sẽ dùng được thẻ <Link> */}
        <Header /> 

        <Routes>
          <Route path="/" element={<HomePage products={products} loading={loading} />} />
          <Route path="/cart" element={<h2>Trang Giỏ hàng</h2>} />
          <Route path="/login" element={<h2>Trang Đăng nhập</h2>} />
          <Route path="/login" element={<Login />} />
        </Routes>

      </div>
    </BrowserRouter>
  )
}

export default App