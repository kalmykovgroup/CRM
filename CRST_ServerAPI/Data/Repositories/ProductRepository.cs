using Dapper;
using KTSFClassLibrary;
using KTSFClassLibrary.Product_;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRST_ServerAPI.Data.Repositories
{
    public class ProductRepository : Repository
    {
        public override System.Type ClassType => typeof(User);

        public override T? Find<T>(int id) where T : default
        {
            return base.Find<T>(id);
        }


        public override List<T> GetAll<T>()
        {
            return base.GetAll<T>();
        }


        public override T Create<T>(T value)
        {
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);

            db.Open();

            using var tran = db.BeginTransaction();

            try
            {


                tran.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                tran.Rollback();
            }

            return value;
        }

        public override T Update<T>(T value)
        {
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);

            db.Open();

            using var tran = db.BeginTransaction();

            try
            {


                tran.Commit();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                tran.Rollback();
            }

            return value;
        }


        //Получить подробную информацию о товаре
        public List<Product> GetProductFullInfo(int productId)
        {
            using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);
            db.Open();

            //ProductInformation? productInfo = db.QuerySingleOrDefault<ProductInformation>("SELECT * FROM product_informations WHERE ProductId = @ProductId", new { ProductId = productId });





            // не подтягивает из product_informations
            //string query = "SELECT * FROM products p JOIN product_informations pi  ON p.Id = pi.ProductId WHERE p.Id = @ProductId";

            //var test = db.Query<Product>(query, new { ProductId = productId }).FirstOrDefault();


            // не подтягивает из products
            //string query = "SELECT * FROM product_informations pi INNER JOIN products p on pi.ProductId = p.Id";
            //var test = db.Query<ProductInformation>(query).ToList();



            // Норм
            string query = $@"SELECT * 
                            FROM products p 
                            INNER JOIN  product_informations pi ON p.Id = pi.ProductId 
                            WHERE p.Id = {productId}";

            var test = db.Query<Product, ProductInformation, Product>(query, (p , pi) =>
            {                
                p.ProductInformation = pi;
                return p;
            }).ToList();




            //if (productInfo == null) { return null; }
            //return productInfo;

            return test;
        }
    }
}
