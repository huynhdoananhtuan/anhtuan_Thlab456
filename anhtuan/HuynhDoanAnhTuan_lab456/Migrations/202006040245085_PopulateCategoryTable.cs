namespace NguyenDuyNam_lab456.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES(ID, NAME) VALUES (1, 'Development' )");
            Sql("INSERT INTO CATEGORIES(ID, NAME) VALUES (2, 'Busines' )");
            Sql("INSERT INTO CATEGORIES(ID, NAME) VALUES (3, 'Marketing' )");
        }
        
        public override void Down()
        {
        }
    }
}
