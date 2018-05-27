namespace LogisticEngine.DBAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientBranches",
                c => new
                    {
                        ClientBranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Zip = c.String(),
                        PAN = c.String(),
                        GST = c.String(),
                        ConcernEmails = c.String(),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientBranchId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PAN = c.String(),
                        GST = c.String(),
                        ConcernEmails = c.String(),
                        LogisticUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.LogisticUsers", t => t.LogisticUserId, cascadeDelete: true)
                .Index(t => t.LogisticUserId);
            
            CreateTable(
                "dbo.LogisticUsers",
                c => new
                    {
                        LogisticUserId = c.Int(nullable: false, identity: true),
                        SystemUserId = c.String(),
                        CompanyName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.LogisticUserId);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        InvoiceItemId = c.Int(nullable: false, identity: true),
                        SerialNo = c.Int(nullable: false),
                        ItemName = c.String(),
                        ItemQuantity = c.Int(nullable: false),
                        PerItemPrice = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        InAmount = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceItemId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        FromTime = c.DateTime(nullable: false),
                        ToTime = c.DateTime(nullable: false),
                        InvoiceNumber = c.String(),
                        PoNO = c.String(),
                        GST = c.String(),
                        SACNo = c.String(),
                        InvoiceType = c.String(),
                        CompanyAddressId = c.Int(nullable: false),
                        CGSTRate = c.Double(nullable: false),
                        CGSTAmount = c.Double(nullable: false),
                        SGSTRate = c.Double(nullable: false),
                        SGSTAmount = c.Double(nullable: false),
                        TotalWithoutTax = c.Double(nullable: false),
                        TotalWithTax = c.Double(nullable: false),
                        LogisticUserId = c.Int(nullable: false),
                        InvoiceTo_ClientBranchId = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.ClientBranches", t => t.InvoiceTo_ClientBranchId)
                .ForeignKey("dbo.LogisticUsers", t => t.LogisticUserId, cascadeDelete: true)
                .Index(t => t.LogisticUserId)
                .Index(t => t.InvoiceTo_ClientBranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "LogisticUserId", "dbo.LogisticUsers");
            DropForeignKey("dbo.Invoices", "InvoiceTo_ClientBranchId", "dbo.ClientBranches");
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Clients", "LogisticUserId", "dbo.LogisticUsers");
            DropForeignKey("dbo.ClientBranches", "ClientId", "dbo.Clients");
            DropIndex("dbo.Invoices", new[] { "InvoiceTo_ClientBranchId" });
            DropIndex("dbo.Invoices", new[] { "LogisticUserId" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            DropIndex("dbo.Clients", new[] { "LogisticUserId" });
            DropIndex("dbo.ClientBranches", new[] { "ClientId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.LogisticUsers");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientBranches");
        }
    }
}
