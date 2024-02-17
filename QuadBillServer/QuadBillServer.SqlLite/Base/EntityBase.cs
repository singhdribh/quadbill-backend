namespace QuadBillServer.SqlLite.Base
{
    public abstract class EntityBase : ITable
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
