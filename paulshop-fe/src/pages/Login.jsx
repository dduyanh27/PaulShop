import { useState } from 'react';
import axios from 'axios';

export default function Login() {
  // 1. Quản lý dữ liệu người dùng nhập vào form
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleLogin = (e) => {
    e.preventDefault(); // Ngăn trang web bị load lại khi nhấn nút
    
    console.log("Đang đăng nhập với:", { email, password });
    
    // Ở đây bạn sẽ gọi API đăng nhập (khi bạn viết xong Login ở Backend)
    // Hiện tại chúng ta giả lập thông báo
    alert(`Đang thử đăng nhập cho: ${email}`);
  };

  return (
    <div style={{ maxWidth: '400px', margin: '50px auto', padding: '20px', border: '1px solid #ddd', borderRadius: '8px', backgroundColor: '#fff' }}>
      <h2 style={{ textAlign: 'center' }}>Đăng nhập PaulShop</h2>
      <form onSubmit={handleLogin} style={{ display: 'flex', flexDirection: 'column', gap: '15px' }}>
        <div>
          <label>Email:</label>
          <input 
            type="email" 
            value={email} 
            onChange={(e) => setEmail(e.target.value)} 
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required 
          />
        </div>
        <div>
          <label>Mật khẩu:</label>
          <input 
            type="password" 
            value={password} 
            onChange={(e) => setPassword(e.target.value)} 
            style={{ width: '100%', padding: '8px', marginTop: '5px' }}
            required 
          />
        </div>
        <button type="submit" style={{ padding: '10px', backgroundColor: '#007bff', color: 'white', border: 'none', borderRadius: '4px', cursor: 'pointer' }}>
          Đăng nhập
        </button>
      </form>
    </div>
  );
}