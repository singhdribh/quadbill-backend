using QuadBillServer.SqlLite.Base;

namespace QuadBillServer.SqlLite.Data.Tables
{
    public class VerificationEntity : EntityBase
    {
        public string Code { get; set; }
        public string VerificationType { get; set; } // Email | Mobile
        public string PageType { get; set; } // Identity | ForgetPassword | Reset Password
        public string UserId { get; set; }

    }
}
