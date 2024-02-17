using QuadBillServer.GraphQL.Base;

namespace QuadBillServer.GraphQL.Admin
{
    [ExtendObjectType("Query")]
    public class Company:QueryBase
    {

        public string GetCompanyName()
        {
            return "Quad Coder billing services";
        }
    }
}
