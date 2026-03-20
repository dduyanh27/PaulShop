using Minio;
using Minio.DataModel.Args;

namespace PaulShop.API.Services
{
    public class MinioService
    {
        private readonly IMinioClient _minioClient;
        private readonly string _bucketName;

        public MinioService(IConfiguration configuration)
        {
            _bucketName = configuration["Minio:BucketName"] ?? "paulshop-images";
            _minioClient = new MinioClient()
                .WithEndpoint(configuration["Minio:Endpoint"])
                .WithCredentials(configuration["Minio:AccessKey"], configuration["Minio:SecretKey"])
                .Build();
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            // 1. Kiểm tra xem thùng chứa đã có chưa, chưa có thì tự tạo
            bool found = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(_bucketName));
            if (!found)
            {
                await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(_bucketName));
            }

            // 2. DÙNG CODE ÉP MỞ QUYỀN PUBLIC (Giải quyết triệt để lỗi giao diện)
            string policy = $@"{{""Version"":""2012-10-17"",""Statement"":[{{""Action"":[""s3:GetObject""],""Effect"":""Allow"",""Principal"":{{""AWS"":[""*""]}},""Resource"":[""arn:aws:s3:::{_bucketName}/*""]}}]}}";
            await _minioClient.SetPolicyAsync(new SetPolicyArgs().WithBucket(_bucketName).WithPolicy(policy));

            // 3. Đổi tên file ảnh bằng mã ngẫu nhiên để không bao giờ bị trùng
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // 4. Bơm dữ liệu file lên MinIO
            using var stream = file.OpenReadStream();
            await _minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(fileName)
                .WithStreamData(stream)
                .WithObjectSize(stream.Length)
                .WithContentType(file.ContentType));

            // 5. Trả về đường link thật để lưu vào Database
            return $"http://localhost:9000/{_bucketName}/{fileName}";
        }
    }
}