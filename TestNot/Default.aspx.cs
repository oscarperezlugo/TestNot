using System;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.Caching;
using System.Security.Permissions;

namespace TestNot
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Cache Refresh: " + DateTime.Now.ToLongTimeString();
            CanRequestNotifications();
            // Create a dependency connection to the database.
            SqlDependency.Start(GetConnectionString());
            

            using (SqlConnection connection =
                new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command =
                    new SqlCommand(GetSQL(), connection))
                {
                    SqlCacheDependency dependency =
                        new SqlCacheDependency(command);
                    // Refresh the cache after the number of minutes
                    // listed below if a change does not occur.
                    // This value could be stored in a configuration file.
                    int numberOfMinutes = 1;
                    DateTime expires =
                        DateTime.Now.AddMinutes(numberOfMinutes);
                    
                    Response.Cache.SetExpires(expires);
                    Response.Cache.SetCacheability(HttpCacheability.Public);
                    Response.Cache.SetValidUntilExpires(true);

                    Response.AddCacheDependency(dependency);

                    connection.Open();

                    GridView1.DataSource = command.ExecuteReader();
                    GridView1.DataBind();
                    Label2.Text = "Cache Refresh: " + expires;
                }
            }
        }
        private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            return "workstation id=rallivery.mssql.somee.com;packet size=4096;user id=rallivery_SQLLogin_1;pwd=1xs4b8qv22;data source=rallivery.mssql.somee.com;persist security info=False;initial catalog=rallivery";
        }
        private string GetSQL()
        {
            return "SELECT * From tbl_Users";
        }
        private bool CanRequestNotifications()
        {
            SqlClientPermission permission =
                new SqlClientPermission(
                PermissionState.Unrestricted);
            try
            {
                permission.Demand();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}