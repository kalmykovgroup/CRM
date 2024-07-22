using CRST_ServerAPI.Data;
using KTSFClassLibrary;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Dapper;
using Object = KTSFClassLibrary.Object;
using KTSFClassLibrary.Product_;

#nullable disable

namespace CRST_ServerAPI.Migrations
{
/// <inheritdoc />
public partial class AddData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        using IDbConnection db = new MySqlConnection(AppDbContext.ConnectionString);

        db.Open();

        using var tran = db.BeginTransaction();

        try
        {


            User user = new User()
            {
                Email = "kalmykov@mail.ru",
                Phone = "+79260128187",
                Password = "tester",
                AccessToken = "bgUYGBvkuybjkyGJGVjhyvbjyuBKYJ",
                Name = "Ivan",
                Surname = "Kalmykov",
                Patronymic = "Alexeevich",
            };

            string sqlQuery = $@"insert into {GetTableName(typeof(User))}
               ({nameof(User.Email)}, 
                {nameof(User.Phone)},  
                {nameof(User.Password)}, 
                {nameof(User.AccessToken)}, 
                {nameof(User.Name)}, 
                {nameof(User.Surname)}, 
                {nameof(User.Patronymic)})
               values (
               @{nameof(User.Email)}, 
               @{nameof(User.Phone)},  
               @{nameof(User.Password)}, 
               @{nameof(User.AccessToken)}, 
               @{nameof(User.Name)}, 
               @{nameof(User.Surname)}, 
               @{nameof(User.Patronymic)}); select LAST_INSERT_ID();";


            int userId = db.ExecuteScalar<int>(sqlQuery, user);



            sqlQuery = $@"insert into {GetTableName(typeof(Company))}
               ({nameof(Company.UserId)}, 
                {nameof(Company.Name)})
               values(
               @{nameof(Company.UserId)}, 
               @{nameof(Company.Name)}); select LAST_INSERT_ID();";


            int companyId = db.ExecuteScalar<int>(sqlQuery, new Company() { Name = "Kalmykov Group", UserId = userId });



            sqlQuery = $@"insert into {GetTableName(typeof(Object))}
               ({nameof(Object.CompanyId)}, 
                {nameof(Object.Address)},
                {nameof(Object.Name)})
               values (
                @{nameof(Object.CompanyId)}, 
                @{nameof(Object.Address)},
                @{nameof(Object.Name)}); select LAST_INSERT_ID();";

            int objectId = db.ExecuteScalar<int>(sqlQuery, new Object() { Name = "Продуктовый на Арбате", Address = "ул. Новый Арбат, 15", CompanyId = companyId });

            sqlQuery = $@"insert into {GetTableName(typeof(Appointment))}
               ({nameof(Appointment.Name)}, 
                {nameof(Appointment.Description)} )
               values(
                @{nameof(Appointment.Name)}, 
                @{nameof(Appointment.Description)}); select LAST_INSERT_ID();";

            int AppointmentId1 = db.ExecuteScalar<int>(sqlQuery, new Appointment() { Name = "Администратор", Description = "" });
            int AppointmentId2 = db.ExecuteScalar<int>(sqlQuery, new Appointment() { Name = "Старший кассир", Description = "" });
            int AppointmentId3 = db.ExecuteScalar<int>(sqlQuery, new Appointment() { Name = "Кассир", Description = "" });
            int AppointmentId4 = db.ExecuteScalar<int>(sqlQuery, new Appointment() { Name = "Кассир Евгений", Description = "Установленные дополнительные права доступа на изменение цены для товаров" });
            int AppointmentId5 = db.ExecuteScalar<int>(sqlQuery, new Appointment() { Name = "Бугалтер", Description = "" });

            sqlQuery = $@"insert into {GetTableName(typeof(Employee))} 
               ({nameof(Employee.ObjectId)}, 
                {nameof(Employee.AppointmentId)},
                {nameof(Employee.AccessToken)},
                {nameof(Employee.Name)},
                {nameof(Employee.Surname)},
                {nameof(Employee.Patronymic)},
                {nameof(Employee.PassportSeries)},
                {nameof(Employee.PassportNumber)},
                {nameof(Employee.Tin)},
                {nameof(Employee.Snils)},
                {nameof(Employee.Address)},
                {nameof(Employee.Phone)},
                {nameof(Employee.Email)},
                {nameof(Employee.ApplyingDate)},
                {nameof(Employee.Created_At)},
                {nameof(Employee.Updated_At)})
               values (
                @{nameof(Employee.ObjectId)}, 
                @{nameof(Employee.AppointmentId)}, 
                @{nameof(Employee.AccessToken)}, 
                @{nameof(Employee.Name)}, 
                @{nameof(Employee.Surname)}, 
                @{nameof(Employee.Patronymic)}, 
                @{nameof(Employee.PassportSeries)}, 
                @{nameof(Employee.PassportNumber)}, 
                @{nameof(Employee.Tin)}, 
                @{nameof(Employee.Snils)}, 
                @{nameof(Employee.Address)}, 
                @{nameof(Employee.Phone)}, 
                @{nameof(Employee.Email)}, 
                @{nameof(Employee.ApplyingDate)}, 
                @{nameof(Employee.Created_At)}, 
                @{nameof(Employee.Updated_At)})";

            Employee employee1 = new Employee()
            {
                ObjectId = objectId,
                AppointmentId = AppointmentId1,
                AccessToken = "lkvbmekjlgnwieufhwyueigf",
                Name = "Иван",
                Surname = "Калмыков",
                Patronymic = "Алексеевич",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "12345678901",
                Snils = "123456789012",
                Address = "Красная прощать 4",
                Phone = "+79260128187",
                Email = "admin@mail.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,

            };

            db.Execute(sqlQuery, employee1);


            Employee employee2 = new Employee()
            {
                ObjectId = objectId,
                AppointmentId = AppointmentId2,
                AccessToken = "weifubsudyvbwirugniewrug",
                Name = "Артур",
                Surname = "Соколов",
                Patronymic = "Игоревич",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "12345678901",
                Snils = "123456789012",
                Address = "Арбатская 6",
                Phone = "+79260125434",
                Email = "admin2@mail.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,

            };

            db.Execute(sqlQuery, employee2);

            Employee employee3 = new Employee()
            {
                ObjectId = objectId,
                AppointmentId = AppointmentId3,
                AccessToken = "aslkgfoiaerjglisermhl",
                Name = "Александр",
                Surname = "Трунин",
                Patronymic = "Владимирович",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "12345678901",
                Snils = "123456789012",
                Address = "Шевченко 4",
                Phone = "+79267654356",
                Email = "admin3@mail.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,

            };

            db.Execute(sqlQuery, employee3);

            Employee employee4 = new Employee()
            {
                ObjectId = objectId,
                AppointmentId = AppointmentId4,
                AccessToken = "lvjerwkhnfwaeljkmg",
                Name = "Алексей",
                Surname = "Федосов",
                Patronymic = "Александрович",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "12345678901",
                Snils = "123456789012",
                Address = "Ново Павловка 16/3",
                Phone = "+79266455553",
                Email = "admin4@mail.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,

            };

            db.Execute(sqlQuery, employee4);


            Employee employee5 = new Employee()
            {
                ObjectId = objectId,
                AppointmentId = AppointmentId5,
                AccessToken = "jkhsabefkwiauenfgoauiwjrf",
                Name = "Ансар",
                Surname = "Агадуллин",
                Patronymic = "Нуруллович",
                PassportSeries = "1234",
                PassportNumber = "123456",
                Tin = "12345678901",
                Snils = "123456789012",
                Address = "Дальний восток 13/3",
                Phone = "+79266726545",
                Email = "admin5@mail.ru",
                ApplyingDate = DateTime.Now,
                Created_At = DateTime.Now,
                Updated_At = DateTime.Now,

            };

            db.Execute(sqlQuery, employee5);


            sqlQuery = $@"insert into {GetTableName(typeof(Unit))}
            ({nameof(Unit.Name)} )
            values(
            @{nameof(Unit.Name)}); select LAST_INSERT_ID();";

            int UnitId1 = db.ExecuteScalar<int>(sqlQuery, new Unit() { Name = "Шт." });
            db.ExecuteScalar<int>(sqlQuery, new Unit() { Name = "Кг." });
            db.ExecuteScalar<int>(sqlQuery, new Unit() { Name = "М." });

           
            sqlQuery = $@"insert into {GetTableName(typeof(EmployeeStatus))}
            ({nameof(EmployeeStatus.Name)} )
            values(
            @{nameof(EmployeeStatus.Name)}); select LAST_INSERT_ID();";

            db.ExecuteScalar<int>(sqlQuery, new EmployeeStatus() { Name = "Не трудоустроен" });
            db.ExecuteScalar<int>(sqlQuery, new EmployeeStatus() { Name = "Трудоустроен" });
            db.ExecuteScalar<int>(sqlQuery, new EmployeeStatus() { Name = "Временный трудовой договор" });
            db.ExecuteScalar<int>(sqlQuery, new EmployeeStatus() { Name = "Уволен" });
            db.ExecuteScalar<int>(sqlQuery, new EmployeeStatus() { Name = "Временно заблокирован" });
            db.ExecuteScalar<int>(sqlQuery, new EmployeeStatus() { Name = "В декрете" });
            db.ExecuteScalar<int>(sqlQuery, new EmployeeStatus() { Name = "Самозанятый" });
            db.ExecuteScalar<int>(sqlQuery, new EmployeeStatus() { Name = "Договор ГПХ" });


                string sqlQueryCategory = $@"insert into {GetTableName(typeof(Category))}
                ( 
                 {nameof(Category.Name)},
                 {nameof(Category.ParentId)})
                values( 
                 @{nameof(Category.Name)},
                 @{nameof(Category.ParentId)}); select LAST_INSERT_ID();";

 

                db.ExecuteScalar<int>(sqlQueryCategory, new Category() {  Name = "Одежда",  ParentId = null });
                db.ExecuteScalar<int>(sqlQueryCategory, new Category() {  Name = "Дом",  ParentId = null });
                db.ExecuteScalar<int>(sqlQueryCategory, new Category() {  Name = "Детям",  ParentId = null });
                db.ExecuteScalar<int>(sqlQueryCategory, new Category() {  Name = "Красота",  ParentId = null });
                db.ExecuteScalar<int>(sqlQueryCategory, new Category() {  Name = "Электроника",  ParentId = null });
                db.ExecuteScalar<int>(sqlQueryCategory, new Category() {  Name = "Продукты",  ParentId = null });
                int categoryId1 =  db.ExecuteScalar<int>(sqlQueryCategory, new Category() {  Name = "Инструмент",  ParentId = null });

                categoryId1 = db.ExecuteScalar<int>(sqlQueryCategory, new Category() { Name = "Электроинструмент", ParentId = categoryId1 });
              int categoryPerforators = db.ExecuteScalar<int>(sqlQueryCategory, new Category() { Name = "Перфораторы", ParentId = categoryId1 });
              int categoryMakita = db.ExecuteScalar<int>(sqlQueryCategory, new Category() { Name = "Makita", ParentId = categoryPerforators });



                sqlQuery = $@"insert into {GetTableName(typeof(Product))}
            ({nameof(Product.Name)},  
             {nameof(Product.UnitId)}, 
             {nameof(Product.BuyPrice)},
             {nameof(Product.BuySales)},
             {nameof(Product.OldPrice)},
             {nameof(Product.UpdatedAt)})
            values(
             @{nameof(Product.Name)}, 
             @{nameof(Product.UnitId)},
             @{nameof(Product.BuyPrice)},
             @{nameof(Product.BuySales)},
             @{nameof(Product.OldPrice)},
             @{nameof(Product.UpdatedAt)}); select LAST_INSERT_ID();";

            string sqlQueryProductInformation = $@"insert into {GetTableName(typeof(ProductInformation))}
            ( 
             {nameof(ProductInformation.NameToPrint)},
             {nameof(ProductInformation.Description)}, 
             {nameof(ProductInformation.Width)},
             {nameof(ProductInformation.Height)},
             {nameof(ProductInformation.Length)},
             {nameof(ProductInformation.Weight)}, 
             {nameof(ProductInformation.CreatedAt)},
             {nameof(ProductInformation.UpdatedAt)})
            values( 
             @{nameof(ProductInformation.NameToPrint)},
             @{nameof(ProductInformation.Description)}, 
             @{nameof(ProductInformation.Width)},
             @{nameof(ProductInformation.Height)},
             @{nameof(ProductInformation.Length)},
             @{nameof(ProductInformation.Weight)}, 
             @{nameof(ProductInformation.CreatedAt)},
             @{nameof(ProductInformation.UpdatedAt)}); select LAST_INSERT_ID();";


         string sqlQueryBarcode = $@"insert into {GetTableName(typeof(Barcode))}
            ( 
             {nameof(Barcode.ProductId)},
             {nameof(Barcode.Code)}, 
             {nameof(Barcode.Type)})
            values( 
             @{nameof(Barcode.ProductId)},
             @{nameof(Barcode.Code)}, 
             @{nameof(Barcode.Type)}); select LAST_INSERT_ID();";

         string sqlQueryArticle = $@"insert into {GetTableName(typeof(Article))}
            ( 
             {nameof(Article.ProductId)},
             {nameof(Article.Name)})
            values( 
             @{nameof(Article.ProductId)},
             @{nameof(Article.Name)}); select LAST_INSERT_ID();";



                int productId =  db.ExecuteScalar<int>(sqlQuery, new Product()
                {
                    Name = "Пассатижи", 
                    UnitId = UnitId1,
                    BuyPrice = 200,
                    BuySales = 450,
                    OldPrice = 560, 
                   UpdatedAt = DateTime.Now
               });

                db.ExecuteScalar<int>(sqlQueryProductInformation, new ProductInformation()
                {
                    ProductId = productId,
                    NameToPrint = "Пассатижи",
                    Description = "Пассатижи эконом класса",

                    Width = 150,
                    Height = 25,
                    Length = 50,
                    Weight = 0.1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQuery, new Barcode() {
                    ProductId = productId,
                    Code = "barcode test",
                    Type = KTSFClassLibrary.Product_.Type.Code128, 

                });

                db.ExecuteScalar<int>(sqlQueryArticle, new Article() {
                    ProductId = productId,
                    Name = "article test", 
                });




                 productId = db.ExecuteScalar<int>(sqlQuery, new Product()
                {
                     Name = "Набор профессиональных отверток и бит DEKO SS100 с удобной подставкой (100 предметов)", 
                     UnitId = UnitId1,
                    
                     BuyPrice = 1109,
                     BuySales = 2409,
                     OldPrice = 2750, 
                     UpdatedAt = DateTime.Now
                 });

                db.ExecuteScalar<int>(sqlQueryProductInformation, new ProductInformation()
                {

                    ProductId = productId,
                    NameToPrint = "Набор проф. отверток DEKO SS100",
                    Description = "Набор профессиональных отверток и бит DEKO SS100 с удобной подставкой (100 предметов).",

                    Width = 275,
                    Height = 315,
                    Length = 143,
                    Weight = 2.75,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQuery, new Barcode()
                {
                    ProductId = productId,
                    Code = "barcode test 1",
                    Type = KTSFClassLibrary.Product_.Type.Code128,

                });

                db.ExecuteScalar<int>(sqlQuery, new Barcode()
                {
                    ProductId = productId,
                    Code = "barcode test 2",
                    Type = KTSFClassLibrary.Product_.Type.Code128,

                });

                db.ExecuteScalar<int>(sqlQueryArticle, new Article()
                {
                    ProductId = productId,
                    Name = "article test 1",
                });
                db.ExecuteScalar<int>(sqlQueryArticle, new Article()
                {
                    ProductId = productId,
                    Name = "article test 2",
                });


                productId = db.ExecuteScalar<int>(sqlQuery, new Product()
                {
                    Name = "Набор слесарного инстр-та в чем. 72пр. Волат (1/4\", 1/2\", 6 граней) (18530-72) (18530-72)", 
                    UnitId = UnitId1,
                    BuyPrice = 1600,
                    BuySales = 4932,
                    OldPrice = 6700, 
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQueryProductInformation, new ProductInformation()
                {

                    ProductId = productId,
                    NameToPrint = "Набор слесарного инстр-та 72пр.",
                    Description = "Набор инструментов 1/4\", 1/2\" 6 граней 72 предмета волат (18530-72) - многофункциональный набор предназначен для ремонта и обслуживания автомобиля, а также для выполнения других слесарных работ. Рабочие части изготовлены из инструментальной стали. Покрытие сатинированное. Профиль головок шестигранный. Кейс из прочного противоударного пластика, с металлическими замками.",

                    Width = 300,
                    Height = 300,
                    Length = 70,
                    Weight = 7.38, 
                     CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQuery, new Barcode()
                {
                    ProductId = productId,
                    Code = "barcode test 3",
                    Type = KTSFClassLibrary.Product_.Type.Code128,

                });

                db.ExecuteScalar<int>(sqlQuery, new Barcode()
                {
                    ProductId = productId,
                    Code = "barcode test 4",
                    Type = KTSFClassLibrary.Product_.Type.Code128,

                });
                db.ExecuteScalar<int>(sqlQuery, new Barcode()
                {
                    ProductId = productId,
                    Code = "barcode test 5",
                    Type = KTSFClassLibrary.Product_.Type.Code128,

                });

                db.ExecuteScalar<int>(sqlQueryArticle, new Article()
                {
                    ProductId = productId,
                    Name = "article test 3",
                }); 



                productId = db.ExecuteScalar<int>(sqlQuery, new Product()
                {
                    Name = "Дрель-шуруповерт с набором инструмента TOTAL THKTHP11282 (с 1-им АКБ, кейс, 128 предметов)", 
                    UnitId = UnitId1, 
                    BuyPrice = 1600,
                    BuySales = 4932,
                    OldPrice = 6700, 
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQueryProductInformation, new ProductInformation()
                {
                    ProductId = productId,
                    NameToPrint = "Дрель-шуруповерт (с 1-им АКБ, кейс, 128 предметов)",
                    Description = "Комплектация набора подобрана так, что домашний мастер закроет все бытовые вопросы, связанные с ремонтом и благоустройством, сборкой/разборкой мебели, монтажа/демонтажа",
                    Width = 300,
                    Height = 300,
                    Length = 70,
                    Weight = 1.3, 
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQuery, new Barcode()
                {
                    ProductId = productId,
                    Code = "barcode test 6",
                    Type = KTSFClassLibrary.Product_.Type.Code128,

                });

                db.ExecuteScalar<int>(sqlQueryArticle, new Article()
                {
                    ProductId = productId,
                    Name = "article test 4",
                });


                productId = db.ExecuteScalar<int>(sqlQuery, new Product()
                {
                    Name = "Клещи (пресс-клещи) для обжима наконечников электропроводов с сечением 0.25-8 мм2 Gross", 
                    UnitId = UnitId1,
                    BuyPrice = 500,
                    BuySales = 1883,
                    OldPrice = 2200,
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQueryProductInformation, new ProductInformation()
                {
                    ProductId = productId,
                    NameToPrint = "Клещи Gross",
                    Description = "Пресс-клещи Gross 17724 используются для обжима наконечников электропроводов с сечением 0,25-8 м2. Позволяют добиться качественного соединения проводов при подключении бытовых приборов и электрооборудования. Клещи с автозажимом значительно повышают скорость работы, пригодятся в быту и профессиональной сфере. Преимущества 6-ступенчатая регулировка усилия сжатия позволяет выбрать оптимальный режим для работы с различными проводами. Двухкомпонентные рельефные рукоятки повышают удобство работы, обеспечивая надежный хват без риска проскальзывания инструмента. За счет функции авторазжима не нужно прикладывать усилия для раскрытия рабочих частей. Клещи упакованы в слайд карту для практичного хранения и транспортировк",
                    Width = 100,
                    Height = 180,
                    Length = 03,
                    Weight = 0.3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQuery, new Barcode()
                {
                    ProductId = productId,
                    Code = "barcode test 7",
                    Type = KTSFClassLibrary.Product_.Type.Code128,

                });

                db.ExecuteScalar<int>(sqlQueryArticle, new Article()
                {
                    ProductId = productId,
                    Name = "article test 5",
                });


                productId = db.ExecuteScalar<int>(sqlQuery, new Product()
                {
                    Name = "Смартфон Samsung Galaxy Z Fold6 12/256 ГБ, Dual: nano SIM + eSIM, серебристый", 
                    UnitId = UnitId1,
                    BuyPrice = 116268,
                    BuySales = 176268,
                    OldPrice = 220268,
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQueryProductInformation, new ProductInformation()
                {
                    ProductId = productId,
                    NameToPrint = "Смартфон Samsung Galaxy Z Fold6 12/256 ГБ, Dual: nano SIM + eSIM, серебристый",
                    Description = "Сверхлегкий, тонкий дизайн\r\nТоньше и легче, идеально ложится в карман, и с еще более ярким раскрывающимся экраном, от которого захватывает дух.\r\nСамый простой способ составить сводку в заметках на складных Galaxy\r\nЗаметки со встреч и лекций всего в несколько касаний, даже в условиях многозадачности. Ассистент для заметок превращает записи в текст и организует их в заметки, создавая удобные сводки. Для всего остального пользуйтесь электронным пером пером S Pen, которое на большом экране способно творить чудеса.",
                    Width = 150,
                    Height = 135,
                    Length = 10,
                    Weight = 0.180,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQuery, new Barcode()
                {
                    ProductId = productId,
                    Code = "barcode test 8",
                    Type = KTSFClassLibrary.Product_.Type.Code128,

                });

                db.ExecuteScalar<int>(sqlQueryArticle, new Article()
                {
                    ProductId = productId,
                    Name = "article test 6",
                });


                productId = db.ExecuteScalar<int>(sqlQuery, new Product()
                {
                    Name = "Перфоратор SDS+ 2.7Дж - 780Вт Makita HR2470",
                    UnitId = UnitId1,
                    BuyPrice = 10400,
                    BuySales = 16460,
                    OldPrice = 18900,
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQueryProductInformation, new ProductInformation()
                {
                    ProductId = productId,
                    NameToPrint = "Перфоратор Makita HR2470",
                    Description = "Три режима работы (сверление, сверление с ударом, долбление). Расцепляющая муфта для защиты инструмента и оператора при заклинивании. 40 осевых положений зубила для удобства эксплуатации. Спусковая кнопка с переменной скоростью.",
                    Width = 84,
                    Height = 214,
                    Length = 370,
                    Weight = 2.9,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                db.ExecuteScalar<int>(sqlQuery, new Barcode()
                {
                    ProductId = productId,
                    Code = "barcode test 9",
                    Type = KTSFClassLibrary.Product_.Type.Code128,

                });

                db.ExecuteScalar<int>(sqlQueryArticle, new Article()
                {
                    ProductId = productId,
                    Name = "article test 7",
                });


                string sqlQueryProductCategory = $@"insert into {GetTableName(typeof(ProductToCategoryJoinTable))}
                ( 
                 {nameof(ProductToCategoryJoinTable.ProductId)},
                 {nameof(ProductToCategoryJoinTable.CategoryId)})
                values( 
                 @{nameof(ProductToCategoryJoinTable.ProductId)},
                 @{nameof(ProductToCategoryJoinTable.CategoryId)}); select LAST_INSERT_ID();";

                db.ExecuteScalar<int>(sqlQueryProductCategory, new ProductToCategoryJoinTable()
                {
                    ProductId = productId,
                    CategoryId = categoryPerforators,
                });

                db.ExecuteScalar<int>(sqlQueryProductCategory, new ProductToCategoryJoinTable()
                {
                    ProductId = productId,
                    CategoryId = categoryMakita,
                });
 
                tran.Commit();

        }
        catch
        {
            tran.Rollback();
        }



    }

    private string GetTableName(System.Type type)
    {
        foreach (Attribute attribute in Attribute.GetCustomAttributes(type))
        {
            if (attribute is TableAttribute tableAttribute)
            {
                return tableAttribute.Name;
            }
        }
        throw new Exception("Not table attribute");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
}
}

     