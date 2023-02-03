using System;
using System.Collections.Generic;
using DoAn1.Areas.Identity.Data;
using DoAn1.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DoAn1.Models
{
    public partial class DoAn1Context : IdentityDbContext<DoAn1User>
    {
        public string ConnectionString { get; set; }

        private SqlConnection GetConnection()
        {
            this.ConnectionString = @"Data Source=TA1O9ER\SQLEXPRESS;Initial Catalog=DoAn1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return new SqlConnection(ConnectionString);
        }

        public DoAn1Context(DbContextOptions<DoAn1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerPayment> CustomerPayments { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DoAn1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.ToTable("AGENT");

                entity.Property(e => e.AgentId).HasColumnName("AgentID");

                entity.Property(e => e.AgentName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Agent_Name");

                entity.Property(e => e.Introduction).HasColumnType("text");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Star).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

       
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Category_Name");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMERS");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Gender).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            

            modelBuilder.Entity<CustomerPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__Customer__9B556A58685D4AE3");

                entity.ToTable("Customer_payment");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PaymentID")
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(20)
                    .HasColumnName("Payment_type");

                entity.Property(e => e.Provider).HasMaxLength(30);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerPayments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Customer___Custo__34C8D9D1");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("MANAGER");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__ORDERS__Customer__440B1D61");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("FK__ORDERS__ShipperI__47DBAE45");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.ProductId })
                    .HasName("PK__ORDER_DE__825E8DFC8185AABF");

                entity.ToTable("ORDER_DETAIL");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDER_DET__ORDER__4AB81AF0");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ORDER_DET__Produ__4BAC3F29");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.AgentId).HasColumnName("AgentID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductName).HasMaxLength(30);

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUCT__AgentID__398D8EEE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__PRODUCT__Categor__3A81B327");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("SHIPPER");

                entity.Property(e => e.ShipperId).HasColumnName("ShipperID");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("UserID");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public void sqlReportOrder(ref int success, ref int cancel, ref int revenue)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "Exec successorder;";
                SqlCommand cmd = new SqlCommand(str, conn);
                var reader = cmd.ExecuteReader();
                success = Convert.ToInt32(reader[0].ToString());
                str = "Excel cancelorder;";
                cmd = new SqlCommand(str, conn);
                reader = cmd.ExecuteReader();
                cancel = Convert.ToInt32(reader[0].ToString());
                str = "Excel MRevenue;";
                cmd = new SqlCommand(str, conn);
                reader = cmd.ExecuteReader();
                revenue = Convert.ToInt32(reader[0].ToString());
            }
        }
        public string sqlFullName(int id)
        {
            string fullname;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select Last_Name, First_Name from customers where customerid = @id;";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    fullname = reader[0].ToString() + " " + reader[1].ToString();
                    conn.Close();
                }
            }
            return fullname;
        }
        /* #######################sql Account######################## */
        public int sqlCustomerId(string id)
        {
            int cusid;
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from customers where userid = @id;";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    cusid = Convert.ToInt32(reader[0].ToString());
                    conn.Close();
                }
            }
            return cusid;
        }
        /* #######################sql Order######################## */

        public int sqlCreateOrder(int cusid, string address, string telephone, ref string errormess)
        {
            using (SqlConnection conn = GetConnection())
            {

                conn.Open();
                var str = "insert into orders (Customerid,address,freight,shipperid,telephone) values (@cusid,@adid,@freight,@shipid,@tele)";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("cusid", cusid);
                cmd.Parameters.AddWithValue("adid", address);
                cmd.Parameters.AddWithValue("freight", 20);
                cmd.Parameters.AddWithValue("shipid", 1);
                cmd.Parameters.AddWithValue("tele", telephone);
                try
                {
                    errormess = "Đã thêm thành công";
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    errormess = "Đã có lỗi xảy ra. Vui lòng thử lại nhan!";
                    return 0;
                }

            }
        }
        public int sqlCreateOrderDetail(int orderid, int prodId, int quantity, double unitprice, ref string errormess)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string str = "insert into Order_detail values (@orderid,@prodid,@quantity,@unitprice);";
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("orderid", orderid);
                    cmd.Parameters.AddWithValue("prodid", prodId);
                    cmd.Parameters.AddWithValue("unitprice",unitprice);
                    cmd.Parameters.AddWithValue("quantity", quantity);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                errormess = ex.Message;
                return 0;
            }
        }
        public int sqlGetOrderID()
        {
            using (SqlConnection conn = GetConnection())
            {

                conn.Open();
                var str = "select top 1 orderid from [orders] order by OrderID desc;";
                SqlCommand cmd = new SqlCommand(str, conn);
                using(var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return Convert.ToInt32(reader[0]);
                }
                conn.Close();
            }
        }


        /* #######################sql Product######################## */

        //public int EditProduct()
        //{

        //}
        public CSProductViewModel sqlInforProduct(int id)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select ProductName, prod.UnitPrice, agt.Agent_Name, prod.Description" +
                             " from PRODUCT prod join AGENT agt on prod.AgentID = agt.AgentID" +
                             " where prod.ProductId = @id";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int Id = id;
                    string nameprod = reader[0].ToString();
                    double price = Convert.ToDouble(reader[1].ToString());
                    string nameagent = reader[2].ToString();
                    string des = reader[3].ToString();
                    CSProductViewModel record = new CSProductViewModel(Id, nameprod, price, nameagent, des);
                    return record;
                }
                conn.Close();
            }
        }

        public List<CSProductViewModel> sqlCSListProducts()
        {
            List<CSProductViewModel> list = new List<CSProductViewModel>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select ProductID, ProductName, agt.Agent_Name, prod.Description, prod.Unitprice" +
                             " from PRODUCT prod join AGENT agt on prod.AgentID = agt.AgentID";
                SqlCommand cmd = new SqlCommand(str, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int Id = Convert.ToInt32(reader[0]);
                    string nameprod = reader[1].ToString();
                    string nameagent = reader[2].ToString();
                    string des = reader[3].ToString();
                    double price = Convert.ToDouble(reader[4]);
                    CSProductViewModel record = new CSProductViewModel(Id, nameprod, price, nameagent, des);
                    list.Add(record);
                }
                conn.Close();
            }
            return list;
        }

        public ManagerProductViewModel sqlMDetailProduct(int prodId)
        {
            int Id;
            string nameprod;
            string nameagent;
            string des;
            decimal price;
            string namecategory;
            using (SqlConnection conn = GetConnection())
            {

                conn.Open();
                var str = "select ProductName, agt.Agent_Name, prod.Description, UnitPrice, cate.Category_Name" +
                             " from PRODUCT prod join AGENT agt on prod.AgentID = agt.AgentID" +
                                " join CATEGORY cate on prod.CategoryID = cate.CategoryID " +
                                "where prod.ProductId = @id;";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("id", prodId);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    Id = prodId;
                    nameprod = reader[0].ToString();
                    nameagent = reader[1].ToString();
                    des = reader[2].ToString();
                    price = Convert.ToDecimal(reader[3].ToString());
                    namecategory = reader[4].ToString();
                }

                conn.Close();
            }
            ManagerProductViewModel record = new ManagerProductViewModel(Id, nameprod, price, des, nameagent, namecategory);
            return record;
        }

        public List<ManagerProductViewModel> sqlMListProducts()
        {
            List<ManagerProductViewModel> list = new List<ManagerProductViewModel>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select ProductID, ProductName, agt.Agent_Name, prod.Description, UnitPrice, cate.Category_Name" +
                             " from PRODUCT prod join AGENT agt on prod.AgentID = agt.AgentID" +
                                " join CATEGORY cate on prod.CategoryID = cate.CategoryID;";
                SqlCommand cmd = new SqlCommand(str, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int Id = Convert.ToInt32(reader[0]);
                    string nameprod = reader[1].ToString();
                    string nameagent = reader[2].ToString();
                    string des = reader[3].ToString();
                    decimal price = Convert.ToDecimal(reader[4].ToString());
                    string namecategory = reader[5].ToString();
                    ManagerProductViewModel record = new ManagerProductViewModel(Id, nameprod, price, des, nameagent, namecategory);
                    list.Add(record);
                }
                conn.Close();
            }
            return list;
        }

        public int sqlSetStatusProduct(int Id, int status)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update Product set Status = @status where ProductId = @Id;";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("status", status);
                return cmd.ExecuteNonQuery();
            }
        }

        public int sqlCheckExistProduct(int Id)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from Product where ProductId = @Id";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("Id", Id);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) return 1;
                else return 0;
            }
        }

    }
}
