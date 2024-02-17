using QuadBillServer.SqlLite.Base;

namespace QuadBillServer.SqlLite.Data.Tables
{
    public class AuthenticationEntity : EntityBase
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
