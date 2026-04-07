// src/components/ProductCard.jsx
export default function ProductCard({ item }) {
  return (
    <div style={{ 
      border: '1px solid #ddd', 
      padding: '15px', 
      borderRadius: '12px', 
      width: '240px',
      backgroundColor: '#fff',
      boxShadow: '0 4px 6px rgba(0,0,0,0.1)',
      textAlign: 'center'
    }}>
      <img 
        src={item.imageUrl || 'https://images.unsplash.com/photo-1542291026-7eec264c27ff'} 
        alt={item.name} 
        style={{ width: '100%', height: '180px', objectFit: 'cover', borderRadius: '8px' }} 
      />
      <h3 style={{ fontSize: '18px', margin: '15px 0 10px', height: '45px', overflow: 'hidden' }}>
        {item.name}
      </h3>
      <p style={{ color: '#e44d26', fontSize: '18px', fontWeight: 'bold', margin: '10px 0' }}>
        {item.price.toLocaleString('vi-VN')} VNĐ
      </p>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', fontSize: '14px', color: '#666' }}>
        <span>Kho: {item.stockQuantity}</span>
        <button style={{ 
          padding: '5px 12px', 
          backgroundColor: '#007bff', 
          color: 'white', 
          border: 'none', 
          borderRadius: '4px',
          cursor: 'pointer'
        }}>
          Mua ngay
        </button>
      </div>
    </div>
  );
}