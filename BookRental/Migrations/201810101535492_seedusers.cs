namespace BookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c98f5131-b1e8-454d-8147-c905fae1d017', N'admin@elocalize.com', 0, N'ADKL5pJtvT8Io2WViGf/82f28tIacV9phVB9TKNCEYYWa+zfALhXlkB0Mu0H7IoCcQ==', N'0d7a4bb5-e3be-4ac3-99bb-c5129f51809c', NULL, 0, 0, NULL, 1, 0, N'admin@elocalize.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fa0be8f5-e0cf-4406-a879-cf5940f64e74', N'nurhanelchiaty@gmail.com', 0, N'AHiOWJhfurqQoj2x4gxL0n3Wb4hyEAxZEkNTsbr7pWqxWS+RV1GN9ENh9sO3QlAAjg==', N'98e78982-ce64-4e7e-8a83-94208859c4cb', NULL, 0, 0, NULL, 1, 0, N'nurhanelchiaty@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f8adba5a-672b-4cd0-bc23-50fe91eb6023', N'CanManageBook')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c98f5131-b1e8-454d-8147-c905fae1d017', N'f8adba5a-672b-4cd0-bc23-50fe91eb6023')

");
        }
        
        public override void Down()
        {
        }
    }
}
