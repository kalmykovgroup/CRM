
using KTSF.Core;
using KTSF.Core.ABAC;
using KTSF.Core.PackingList_;
using KTSF.Core.Product_;
using KTSF.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Object = KTSF.Core.Object; 

namespace KTSF.Persistence
{
    public class AppDbContext : DbContext
    {

        public static string ConnectionString { get; set; } = String.Empty;
    
        public DbSet<KTSF.Core.Object> Objects { get; set; }
        public DbSet<User> MainUsers { get; set; }
        public DbSet<Company> Companies { get; set; }


        #region Employee

        public DbSet<Employee> Employees { get; set; } 
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; } 
        public DbSet<Appointment> Appointments { get; set; }

        #endregion

        #region ABAC

        public DbSet<User> Users { get; set; }

        public DbSet<DataBaseAccessAttribute> DataBaseAccessAttributes { get; set; }

        public DbSet<ComponentAccessAttribute> ComponentAccessAttributes { get; set; }

         public DbSet<EmployeeAction> EmployeeActions { get; set; }
         public DbSet<ASetOfRules> ASetOfRules { get; set; }

        #endregion



        #region PackingList

        //Товарная накладная
        public DbSet<PackingList> PackingLists { get; set; }
             public DbSet<PackingListToProductJoinTable> PackingListProducts { get; set; }

        #endregion

        #region Product

              public DbSet<Article> Articles { get; set; }
              public DbSet<Barcode> Barcodes { get; set; }
              public DbSet<Category> Categories { get; set; }
              public DbSet<ProductToCategoryJoinTable> ProductToCategoryJoinTables { get; set; }
              public DbSet<Price> Prices { get; set; }
              public DbSet<Product> Products { get; set; }
              public DbSet<ProductInformation> ProductInformations { get; set; }
              public DbSet<Unit> Units { get; set; }

        #endregion

        public AppDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseMySQL("Server=127.0.0.1;Database=crm;Uid=root;Pwd=;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasMany(product => product.Categories)
                .WithMany(category => category.Products)
                .UsingEntity<ProductToCategoryJoinTable>();

             


            modelBuilder.Entity<PackingList>()
              .HasMany(packingList => packingList.Products)
              .WithMany(product => product.PackingLists)
              .UsingEntity<PackingListToProductJoinTable>();

       
            modelBuilder.Entity<ProductToCategoryJoinTable>().HasIndex(x => new { x.ProductId, x.CategoryId }).IsUnique(); 
            modelBuilder.Entity<PackingListToProductJoinTable>().HasIndex(x => new { x.ProductId, x.PackingListId }).IsUnique();
             
            modelBuilder.Entity<User>().HasData(GetUsersDefault());
            modelBuilder.Entity<Company>().HasData(GetCompaniesDefault());
            modelBuilder.Entity<Object>().HasData(GetObjectsDefault());
            modelBuilder.Entity<Appointment>().HasData(GetAppointmentsDefault());
            modelBuilder.Entity<ASetOfRules>().HasData(GetASetOfRulesDefault());
            modelBuilder.Entity<EmployeeStatus>().HasData(GetEmployeeStatusesDefault());
            modelBuilder.Entity<Employee>().HasData(GetEmployeesDefault());

            modelBuilder.Entity<Unit>().HasData(GetUnitsDefault());
            modelBuilder.Entity<Category>().HasData(GetCategoriesDefault());
            modelBuilder.Entity<Product>().HasData(GetProductsDefault());
            modelBuilder.Entity<ProductInformation>().HasData(GetProductInformationsDefault());
            modelBuilder.Entity<Barcode>().HasData(GetBarcodesDefault());
            modelBuilder.Entity<Article>().HasData(GetArticlesDefault());
            modelBuilder.Entity<ProductToCategoryJoinTable>().HasData(GetProductToCategoryJoinTableDefault());

            

        }

         

        private User[] GetUsersDefault()
        {
            return [
                new User()
            {
                Id = 1,
                Email = "tester@mail.ru",
                PhoneNumber = "+7111111111",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("tester"),
                Name = "tester",
                Surname = "testerov",
                Patronymic = "testerovich",
            }];
        }
        private Company[] GetCompaniesDefault()
        { 
            return [
                new Company() {
                    Id = 1,
                    UserId = 1,
                    Name = "My company name",
                    
                }, 
            ];
        }

        private Object[] GetObjectsDefault()
        { 
            return [
                new Object() {
                    Id = 1,
                    CompanyId = 1,
                    Name = "Продуктовый на Арбате", 
                    Address = "ул. Новый Арбат, 15",
                }
            ];
        }

        private Appointment[] GetAppointmentsDefault()
        { 
            return [
             new Appointment() { Id = 1, Name = "Администратор", Description = "" },
             new Appointment() { Id = 2, Name = "Менеджер по закупкам", Description = "" },
             new Appointment() { Id = 3, Name = "Старший кассир", Description = "" },
             new Appointment() { Id = 4, Name = "Кассир", Description = "" },
             new Appointment() { Id = 5, Name = "Бугалтер", Description = "" },
             new Appointment() { Id = 6, Name = "Охранник", Description = "" },
             new Appointment() { Id = 7, Name = "Уборщик", Description = "" },
             new Appointment() { Id = 8, Name = "Водитель", Description = "" },
             new Appointment() { Id = 9, Name = "Грущик", Description = "" },
             new Appointment() { Id = 10, Name = "Слесарь", Description = "" },
            ];
        }
        private ASetOfRules[] GetASetOfRulesDefault()
        { 
            return [
             new ASetOfRules() {Id = 1, Name = "Администратор", Description = "" },
             new ASetOfRules() {Id = 2, Name = "Старший кассир", Description = "" },
             new ASetOfRules() {Id = 3, Name = "Менеджер по закупкам", Description = "" },
             new ASetOfRules() {Id = 4, Name = "Кассир", Description = "" },
             new ASetOfRules() {Id = 5, Name = "Кассир Евгений", Description = "Установленные дополнительные права доступа на изменение цены для товаров" },
             new ASetOfRules() {Id = 6, Name = "Бухгалтер", Description = "" },
            ];
        }
        private EmployeeStatus[] GetEmployeeStatusesDefault()
        { 
            return [
             new EmployeeStatus() { Id = 1, Name = "Не трудоустроен" },
             new EmployeeStatus() { Id = 2, Name = "На испытательном сроке" },
             new EmployeeStatus() { Id = 3, Name = "Трудоустроен" },
             new EmployeeStatus() { Id = 4, Name = "Уволен" }, 
            ];
        }

        private Employee[] GetEmployeesDefault()
        { 

            return [new Employee()
                {
                    Id = 1,
                    ObjectId = 1,
                    AppointmentId = 1,
                    ASetOfRulesId = 1,
                    EmployeeStatusId = 1,
                    AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEifQ.GQm1j57RyZMHdwsolLnzhoB9A49mC0KusQBpHS9_-kQ",
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
                    Password = "tester",
                    ApplyingDate = DateTime.Now,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now,

                },
                new Employee()
                {
                    Id = 2,
                    ObjectId = 1,
                    AppointmentId = 1,
                    ASetOfRulesId = 2,
                    EmployeeStatusId = 1,
                    AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIifQ.cbpuaPB0oVEkmkgFvfQUcaRb58xRn5zlClDroWd75JA",
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
                    Password = "tester",
                    ApplyingDate = DateTime.Now,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now,

                },
                new Employee()
                {
                    Id = 3,
                   ObjectId = 1,
                    AppointmentId = 1,
                    ASetOfRulesId = 3,
                    EmployeeStatusId = 1,
                    AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjMifQ.n0AxopvGMqJUdvyuXVuBZOurMD2Tiah-EqFi-a-lR6E",
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
                    Password = "tester",
                    ApplyingDate = DateTime.Now,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now,

                },
                new Employee()
                {
                    Id = 4,
                    ObjectId = 1,
                    AppointmentId = 1,
                    ASetOfRulesId = 4,
                    EmployeeStatusId = 1,
                    AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQifQ.NiQnkH09RTP1QMiS9rbWLQ3iDJbZ2CV3RsBflk5QjXs",
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
                    Password = "tester",
                    ApplyingDate = DateTime.Now,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now,

                },
                new Employee()
                {
                    Id = 5,
                    ObjectId = 1,
                    AppointmentId = 1,
                    ASetOfRulesId = 5,
                    EmployeeStatusId = 1,
                    AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjUifQ.t9QlQfK-k6WS2yA2KlKgn0JRCQhDaz5Ujo8UBVTJWCM",
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
                    Password = "tester",
                    ApplyingDate = DateTime.Now,
                    Created_At = DateTime.Now,
                    Updated_At = DateTime.Now,

                }
            ];
        }


        private Unit[] GetUnitsDefault()
        {
            return [
             new Unit() { Id = 1, Name = "Шт." },
             new Unit() { Id = 2, Name = "Кг." },
             new Unit() { Id = 3, Name = "М." },
            ];
        }

        private Product[] GetProductsDefault()
        {
            Unit[] Units = GetUnitsDefault();

            return [
                new Product()
                {
                    Id = 1,
                    Name = "Пассатижи",
                    UnitId = Units[0].Id,
                    BuyPrice = 200,
                    BuySales = 450,
                    OldPrice = 560,
                    UpdatedAt = DateTime.Now
                },
                new Product()
                {
                    Id = 2,
                    Name = "Набор профессиональных отверток и бит DEKO SS100 с удобной подставкой (100 предметов)",
                    UnitId = Units[0].Id,
                    BuyPrice = 1109,
                    BuySales = 2409,
                    OldPrice = 2750,
                    UpdatedAt = DateTime.Now
                },
                new Product()
                {
                    Id = 3,
                    Name = "Набор слесарного инстр-та в чем. 72пр. Волат (1/4\", 1/2\", 6 граней) (18530-72) (18530-72)",
                    UnitId = Units[0].Id,
                    BuyPrice = 1600,
                    BuySales = 4932,
                    OldPrice = 6700,
                    UpdatedAt = DateTime.Now
                },
                new Product()
                {
                    Id = 4,
                    Name = "Дрель-шуруповерт с набором инструмента TOTAL THKTHP11282 (с 1-им АКБ, кейс, 128 предметов)",
                    UnitId = Units[0].Id,
                    BuyPrice = 1600,
                    BuySales = 4932,
                    OldPrice = 6700,
                    UpdatedAt = DateTime.Now
                },
                new Product()
                {
                    Id = 5,
                    Name = "Клещи (пресс-клещи) для обжима наконечников электропроводов с сечением 0.25-8 мм2 Gross",
                    UnitId = Units[0].Id,
                    BuyPrice = 500,
                    BuySales = 1883,
                    OldPrice = 2200,
                    UpdatedAt = DateTime.Now
                },
                new Product()
                {
                    Id = 6,
                    Name = "Смартфон Samsung Galaxy Z Fold6 12/256 ГБ, Dual: nano SIM + eSIM, серебристый",
                    UnitId = Units[0].Id,
                    BuyPrice = 116268,
                    BuySales = 176268,
                    OldPrice = 220268,
                    UpdatedAt = DateTime.Now
                },
                new Product()
                {
                    Id = 7,
                    Name = "Перфоратор SDS+ 2.7Дж - 780Вт Makita HR2470",
                    UnitId = Units[0].Id,
                    BuyPrice = 10400,
                    BuySales = 16460,
                    OldPrice = 18900,
                    UpdatedAt = DateTime.Now
                }
            ];
        }

        private ProductInformation[] GetProductInformationsDefault()
        {
            Product[] products = GetProductsDefault();
            return [
                new ProductInformation()
                {
                    Id = 1,
                    ProductId = products[0].Id,
                    NameToPrint = "Пассатижи",
                    Description = "Пассатижи эконом класса",

                    Width = 150,
                    Height = 25,
                    Length = 50,
                    Weight = 0.1,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },

                    new ProductInformation()
                    {
                        Id = 2,
                        ProductId = products[1].Id,
                        NameToPrint = "Набор проф. отверток DEKO SS100",
                        Description = "Набор профессиональных отверток и бит DEKO SS100 с удобной подставкой (100 предметов).",

                        Width = 275,
                        Height = 315,
                        Length = 143,
                        Weight = 2.75,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new ProductInformation()
                {
                    Id = 3,
                    ProductId = products[2].Id,
                    NameToPrint = "Набор слесарного инстр-та 72пр.",
                    Description = "Набор инструментов 1/4\", 1/2\" 6 граней 72 предмета волат (18530-72) - многофункциональный набор предназначен для ремонта и обслуживания автомобиля, а также для выполнения других слесарных работ. Рабочие части изготовлены из инструментальной стали. Покрытие сатинированное. Профиль головок шестигранный. Кейс из прочного противоударного пластика, с металлическими замками.",

                    Width = 300,
                    Height = 300,
                    Length = 70,
                    Weight = 7.38,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new ProductInformation()
                {
                    Id = 4,
                    ProductId = products[3].Id,
                    NameToPrint = "Дрель-шуруповерт (с 1-им АКБ, кейс, 128 предметов)",
                    Description = "Комплектация набора подобрана так, что домашний мастер закроет все бытовые вопросы, связанные с ремонтом и благоустройством, сборкой/разборкой мебели, монтажа/демонтажа",
                    Width = 300,
                    Height = 300,
                    Length = 70,
                    Weight = 1.3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new ProductInformation()
                {
                    Id = 5,
                    ProductId = products[4].Id,
                    NameToPrint = "Клещи Gross",
                    Description = "Пресс-клещи Gross 17724 используются для обжима наконечников электропроводов с сечением 0,25-8 м2. Позволяют добиться качественного соединения проводов при подключении бытовых приборов и электрооборудования. Клещи с автозажимом значительно повышают скорость работы, пригодятся в быту и профессиональной сфере. Преимущества 6-ступенчатая регулировка усилия сжатия позволяет выбрать оптимальный режим для работы с различными проводами. Двухкомпонентные рельефные рукоятки повышают удобство работы, обеспечивая надежный хват без риска проскальзывания инструмента. За счет функции авторазжима не нужно прикладывать усилия для раскрытия рабочих частей. Клещи упакованы в слайд карту для практичного хранения и транспортировк",
                    Width = 100,
                    Height = 180,
                    Length = 03,
                    Weight = 0.3,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new ProductInformation()
                {
                    Id = 6,
                    ProductId = products[5].Id,
                    NameToPrint = "Смартфон Samsung Galaxy Z Fold6 12/256 ГБ, Dual: nano SIM + eSIM, серебристый",
                    Description = "Сверхлегкий, тонкий дизайн\r\nТоньше и легче, идеально ложится в карман, и с еще более ярким раскрывающимся экраном, от которого захватывает дух.\r\nСамый простой способ составить сводку в заметках на складных Galaxy\r\nЗаметки со встреч и лекций всего в несколько касаний, даже в условиях многозадачности. Ассистент для заметок превращает записи в текст и организует их в заметки, создавая удобные сводки. Для всего остального пользуйтесь электронным пером пером S Pen, которое на большом экране способно творить чудеса.",
                    Width = 150,
                    Height = 135,
                    Length = 10,
                    Weight = 0.180,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new ProductInformation()
                {
                    Id = 7,
                    ProductId = products[6].Id,
                    NameToPrint = "Перфоратор Makita HR2470",
                    Description = "Три режима работы (сверление, сверление с ударом, долбление). Расцепляющая муфта для защиты инструмента и оператора при заклинивании. 40 осевых положений зубила для удобства эксплуатации. Спусковая кнопка с переменной скоростью.",
                    Width = 84,
                    Height = 214,
                    Length = 370,
                    Weight = 2.9,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                ];
        }

        private Barcode[] GetBarcodesDefault()
        {

            return [
                   new Barcode()
                {
                       Id = 1,
                    ProductId = 1,
                    Code = "barcode_1",
                    Type = KTSF.Core.Product_.Type.Code128,

                },
                   new Barcode()
                {
                        Id = 2,
                    ProductId = 2,
                    Code = "barcode_2",
                    Type = KTSF.Core.Product_.Type.Code128,

                },
                   new Barcode()
                {
                        Id = 3,
                    ProductId = 3,
                    Code = "barcode_3",
                    Type = KTSF.Core.Product_.Type.Code128,

                },
                   new Barcode()
                {
                        Id = 4,
                    ProductId = 4,
                    Code = "barcode_4",
                    Type = KTSF.Core.Product_.Type.Code128,

                },
                   new Barcode()
                {
                        Id = 5,
                    ProductId = 5,
                    Code = "barcode_5",
                    Type = KTSF.Core.Product_.Type.Code128,

                },
                   new Barcode()
                {
                        Id = 6,
                    ProductId = 6,
                    Code = "barcode_6",
                    Type = KTSF.Core.Product_.Type.Code128,

                },
                   new Barcode()
                {
                        Id = 7,
                    ProductId = 7,
                    Code = "barcode_7",
                    Type = KTSF.Core.Product_.Type.Code128,

                },
                   new Barcode()
                {
                        Id = 8,
                    ProductId = 7,
                    Code = "barcode_7.1",
                    Type = KTSF.Core.Product_.Type.Code128,

                },
                ];
        }
        private Article[] GetArticlesDefault()
        {

            return [
                   new Article()
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "article_1",
                },

                   new Article()
                {
                       Id = 2,
                    ProductId = 2,
                    Name = "article_2",
                },
                   new Article()
                {
                       Id = 3,
                    ProductId = 2,
                    Name = "article_2.1",
                },

                   new Article()
                {
                       Id = 4,
                    ProductId = 3,
                    Name = "article_3",
                },

                   new Article()
                {
                       Id = 5,
                    ProductId = 4,
                    Name = "article_4",
                },
                   new Article()
                {
                       Id = 6,
                    ProductId = 4,
                    Name = "article_4.1",
                },
                   new Article()
                {
                       Id = 7,
                    ProductId = 4,
                    Name = "article_4.2",
                },

                   new Article()
                {
                       Id = 8,
                    ProductId = 5,
                    Name = "article_5",
                },

                   new Article()
                {
                       Id = 9,
                    ProductId = 6,
                    Name = "article_6",
                },

                   new Article()
                {
                       Id = 10,
                    ProductId = 7,
                    Name = "article_7",
                },
                ];
        }

        private Category[] GetCategoriesDefault()
        {
            return [
              new Category() { Id = 1, Name = "Одежда", ParentId = null },
              new Category() { Id = 2, Name = "Дом", ParentId = null },
              new Category() { Id = 3, Name = "Детям", ParentId = null },
              new Category() { Id = 4, Name = "Красота", ParentId = null },
              new Category() { Id = 5, Name = "Электроника", ParentId = null },
              new Category() { Id = 6, Name = "Продукты", ParentId = null },
              new Category() { Id = 7, Name = "Инструмент", ParentId = null },

              new Category() { Id = 8, Name = "Электроинструмент", ParentId = 7 },
              new Category() { Id = 9, Name = "Перфораторы", ParentId = 7 },

              new Category() { Id = 10, Name = "Makita", ParentId = 9 },
            ];
        }

        private ProductToCategoryJoinTable[] GetProductToCategoryJoinTableDefault()
        {
            return [
                 new ProductToCategoryJoinTable()
                 {
                     Id = 1,
                    ProductId = 1,
                    CategoryId = 7,
                 },
                 new ProductToCategoryJoinTable()
                 {
                     Id = 2,
                    ProductId = 2,
                    CategoryId = 7,
                 },
                 new ProductToCategoryJoinTable()
                 {
                     Id = 3,
                    ProductId = 3,
                    CategoryId = 7,
                 },
                 new ProductToCategoryJoinTable()
                 {
                    Id = 4,
                    ProductId = 4,
                    CategoryId = 7,
                 },
                 new ProductToCategoryJoinTable()
                 {
                     Id = 5,
                    ProductId = 5,
                    CategoryId = 7,
                 },
                 new ProductToCategoryJoinTable()
                 {
                     Id = 6,
                    ProductId = 7,
                    CategoryId = 7,
                 },
                ];
        }
    }
}
