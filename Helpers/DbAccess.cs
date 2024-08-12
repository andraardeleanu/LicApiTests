using System.Data.SqlClient;
using System.Data;
using Dapper;
using BTPopriri.GarnishmentManagement.Api.E2ETests.Core;

namespace LicUiTests.Helpers
{
    public class DbAccess
    {
        public static void CompanyCleanUp(string CUI)
        {
            var sql = "SP_CompanyCleanUp";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        CUI
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static void ResetCompanyName(string Name)
        {
            var sql = "SP_ResetCompanyName";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        Name
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static void WorkpointCleanUp(string Name)
        {
            var sql = "SP_WorkpointCleanUp";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        Name
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static void ResetWorkpointData(string Name)
        {
            var sql = "SP_ResetWorkpointData";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        Name
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static void ProductCleanUp(string Name)
        {
            var sql = "SP_ProductCleanUp";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        Name
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static void ResetProductName(string Name)
        {
            var sql = "SP_ResetProductName";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        Name
                    },
                    commandType: CommandType.StoredProcedure);
            }

        }
        public static void OrderCleanUp(string OrderNo)
        {
            var sql = "SP_OrderCleanUp";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        OrderNo
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static void OrderProductsReset(string productId)
        {
            var sql = "SP_OrderProductsReset";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        productId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static void BillCleanUp(string OrderNo)
        {
            var sql = "SP_BillCleanUp";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        OrderNo
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static void UserCleanUp(string username)
        {
            var sql = "SP_UserCleanUp";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        username
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public static void ResetFirstname(string username)
        {
            var sql = "SP_ResetFirstname";

            using (IDbConnection connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql,
                    param: new
                    {
                        username
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}

