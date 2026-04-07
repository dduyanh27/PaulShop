// src/components/Header.jsx
import { Link } from 'react-router-dom';

export default function Header() {
  return (
    <nav style={{
      display: 'flex',
      justifyContent: 'space-between',
      alignItems: 'center',
      padding: '10px 50px',
      backgroundColor: '#333',
      color: 'white',
      marginBottom: '30px'
    }}>
      <h2 style={{ margin: 0 }}>
        <Link to="/" style={{ color: 'white', textDecoration: 'none' }}>PaulShop</Link>
      </h2>
      <ul style={{ display: 'flex', listStyle: 'none', gap: '20px', margin: 0 }}>
        <li><Link to="/" style={{ color: 'white', textDecoration: 'none' }}>Trang chủ</Link></li>
        <li><Link to="/cart" style={{ color: 'white', textDecoration: 'none' }}>Giỏ hàng</Link></li>
        <li><Link to="/login" style={{ color: 'white', textDecoration: 'none' }}>Đăng nhập</Link></li>
      </ul>
      <div style={{ fontWeight: 'bold' }}>🛒 (0)</div>
    </nav>
  );
}