using QuadBillServer.SqlLite.Base;

namespace QuadBillServer.SqlLite.Data.Tables
{
    public class RefreshTokenEntity : EntityBase
    {
        public DateTimeOffset ExpiryDate { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshTokenFor { get; set; }
        public bool IsActive { get; set; }
    }
}
