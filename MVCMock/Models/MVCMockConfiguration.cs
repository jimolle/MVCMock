using System.Data.Entity;
using System.Data.Entity.SqlServer;
namespace MVCMock
{
    // Obs! Detta gäller egentligen AZURE
    // Vad strategin gör är att den tillåter dig fånga
    // RetryLimitExceededException när du ska skriva till db:n.
    public class MVCMockConfiguration : DbConfiguration
    {
        public MVCMockConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new
            SqlAzureExecutionStrategy());
        }
    }
}