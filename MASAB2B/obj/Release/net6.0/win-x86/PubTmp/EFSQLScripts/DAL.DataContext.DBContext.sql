IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE TABLE [attributes] (
        [AttributeID] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_attributes] PRIMARY KEY ([AttributeID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE TABLE [brandss] (
        [Brand_ID] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_brandss] PRIMARY KEY ([Brand_ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE TABLE [categories] (
        [Categories_ID] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [slug] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_categories] PRIMARY KEY ([Categories_ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE TABLE [Orderss] (
        [order_ID] int NOT NULL IDENTITY,
        [country] nvarchar(max) NOT NULL,
        [firstaname] nvarchar(max) NOT NULL,
        [lastname] nvarchar(max) NOT NULL,
        [companyname] nvarchar(max) NOT NULL,
        [city] nvarchar(max) NOT NULL,
        [zip] nvarchar(max) NOT NULL,
        [state] nvarchar(max) NOT NULL,
        [address1] nvarchar(max) NOT NULL,
        [address2] nvarchar(max) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [phone] nvarchar(max) NOT NULL,
        [ordernotes] nvarchar(max) NOT NULL,
        [totalcbm] nvarchar(max) NOT NULL,
        [totalprice] nvarchar(max) NOT NULL,
        [datetime] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Orderss] PRIMARY KEY ([order_ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE TABLE [subcategoriess] (
        [Subid] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [categoryname] nvarchar(max) NOT NULL,
        [category_id] int NULL,
        [Categories_ID] int NULL,
        CONSTRAINT [PK_subcategoriess] PRIMARY KEY ([Subid]),
        CONSTRAINT [FK_subcategoriess_categories_Categories_ID] FOREIGN KEY ([Categories_ID]) REFERENCES [categories] ([Categories_ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE TABLE [productss] (
        [Product_ID] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [category_id] int NULL,
        [Categories_ID] int NULL,
        [Subid] int NULL,
        [subCategoriesSubid] int NULL,
        [price] nvarchar(max) NOT NULL,
        [brand_id] int NULL,
        [BrandsBrand_ID] int NULL,
        [specification] nvarchar(max) NOT NULL,
        [specificationright] nvarchar(max) NOT NULL,
        [Attributevalue] nvarchar(max) NOT NULL,
        [shortdesc] nvarchar(max) NOT NULL,
        [longdesc] nvarchar(max) NOT NULL,
        [singleImage] nvarchar(max) NOT NULL,
        [Images] nvarchar(max) NOT NULL,
        [brandname] nvarchar(max) NOT NULL,
        [categoryname] nvarchar(max) NOT NULL,
        [subcategoryname] nvarchar(max) NOT NULL,
        [variations] nvarchar(max) NOT NULL,
        [dod] nvarchar(max) NOT NULL,
        [bs] nvarchar(max) NOT NULL,
        [na] nvarchar(max) NOT NULL,
        [fa] nvarchar(max) NOT NULL,
        [modelno] nvarchar(max) NOT NULL,
        [height] nvarchar(max) NOT NULL,
        [width] nvarchar(max) NOT NULL,
        [depth] nvarchar(max) NOT NULL,
        [cbm] nvarchar(max) NOT NULL,
        [cbmcalculation] nvarchar(max) NOT NULL,
        [cl20gp] nvarchar(max) NOT NULL,
        [cl40gp] nvarchar(max) NOT NULL,
        [cl40hq] nvarchar(max) NOT NULL,
        [minqty] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_productss] PRIMARY KEY ([Product_ID]),
        CONSTRAINT [FK_productss_brandss_BrandsBrand_ID] FOREIGN KEY ([BrandsBrand_ID]) REFERENCES [brandss] ([Brand_ID]),
        CONSTRAINT [FK_productss_categories_Categories_ID] FOREIGN KEY ([Categories_ID]) REFERENCES [categories] ([Categories_ID]),
        CONSTRAINT [FK_productss_subcategoriess_subCategoriesSubid] FOREIGN KEY ([subCategoriesSubid]) REFERENCES [subcategoriess] ([Subid])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE TABLE [OrderItemss] (
        [orderItems_ID] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [quantity] nvarchar(max) NOT NULL,
        [cbm] nvarchar(max) NOT NULL,
        [qtyordered] nvarchar(max) NOT NULL,
        [price] nvarchar(max) NOT NULL,
        [singleimage] nvarchar(max) NOT NULL,
        [Product_ID_custom] nvarchar(max) NOT NULL,
        [order_ID_custom] nvarchar(max) NOT NULL,
        [product_id] int NULL,
        [ProductsProduct_ID] int NULL,
        [order_id] int NOT NULL,
        [Ordersorder_ID] int NOT NULL,
        CONSTRAINT [PK_OrderItemss] PRIMARY KEY ([orderItems_ID]),
        CONSTRAINT [FK_OrderItemss_Orderss_Ordersorder_ID] FOREIGN KEY ([Ordersorder_ID]) REFERENCES [Orderss] ([order_ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderItemss_productss_ProductsProduct_ID] FOREIGN KEY ([ProductsProduct_ID]) REFERENCES [productss] ([Product_ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE INDEX [IX_OrderItemss_Ordersorder_ID] ON [OrderItemss] ([Ordersorder_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE INDEX [IX_OrderItemss_ProductsProduct_ID] ON [OrderItemss] ([ProductsProduct_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE INDEX [IX_productss_BrandsBrand_ID] ON [productss] ([BrandsBrand_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE INDEX [IX_productss_Categories_ID] ON [productss] ([Categories_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE INDEX [IX_productss_subCategoriesSubid] ON [productss] ([subCategoriesSubid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    CREATE INDEX [IX_subcategoriess_Categories_ID] ON [subcategoriess] ([Categories_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118133649_orders')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221118133649_orders', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118134755_orderrelation')
BEGIN
    ALTER TABLE [OrderItemss] DROP CONSTRAINT [FK_OrderItemss_Orderss_Ordersorder_ID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118134755_orderrelation')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderItemss]') AND [c].[name] = N'Ordersorder_ID');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [OrderItemss] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [OrderItemss] ALTER COLUMN [Ordersorder_ID] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118134755_orderrelation')
BEGIN
    ALTER TABLE [OrderItemss] ADD CONSTRAINT [FK_OrderItemss_Orderss_Ordersorder_ID] FOREIGN KEY ([Ordersorder_ID]) REFERENCES [Orderss] ([order_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221118134755_orderrelation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221118134755_orderrelation', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221122062817_brand_details')
BEGIN
    ALTER TABLE [brandss] ADD [Image] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221122062817_brand_details')
BEGIN
    ALTER TABLE [brandss] ADD [details] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221122062817_brand_details')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221122062817_brand_details', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221124083714_banners')
BEGIN
    CREATE TABLE [bannerss] (
        [banner_ID] int NOT NULL IDENTITY,
        [bnum] nvarchar(max) NOT NULL,
        [image] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_bannerss] PRIMARY KEY ([banner_ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221124083714_banners')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221124083714_banners', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221125113128_banners_updated')
BEGIN
    ALTER TABLE [bannerss] ADD [productid] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221125113128_banners_updated')
BEGIN
    ALTER TABLE [bannerss] ADD [type] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221125113128_banners_updated')
BEGIN
    ALTER TABLE [bannerss] ADD [value] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221125113128_banners_updated')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221125113128_banners_updated', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221129061909_users')
BEGIN
    ALTER TABLE [productss] ADD [id] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221129061909_users')
BEGIN
    ALTER TABLE [productss] ADD [usersid] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221129061909_users')
BEGIN
    CREATE TABLE [queriess] (
        [id] int NOT NULL IDENTITY,
        [firstname] nvarchar(max) NULL,
        [lastname] nvarchar(max) NULL,
        [email] nvarchar(max) NULL,
        [phone] nvarchar(max) NULL,
        [subject] nvarchar(max) NULL,
        [message] nvarchar(max) NULL,
        CONSTRAINT [PK_queriess] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221129061909_users')
BEGIN
    CREATE TABLE [signups] (
        [id] int NOT NULL IDENTITY,
        [firstname] nvarchar(max) NOT NULL,
        [lastname] nvarchar(max) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [phone] nvarchar(max) NOT NULL,
        [password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_signups] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221129061909_users')
BEGIN
    CREATE INDEX [IX_productss_usersid] ON [productss] ([usersid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221129061909_users')
BEGIN
    ALTER TABLE [productss] ADD CONSTRAINT [FK_productss_signups_usersid] FOREIGN KEY ([usersid]) REFERENCES [signups] ([id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221129061909_users')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221129061909_users', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221129134611_contacts')
BEGIN
    CREATE TABLE [contactss] (
        [id] int NOT NULL IDENTITY,
        [firstname] nvarchar(max) NOT NULL,
        [lastname] nvarchar(max) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [phone] nvarchar(max) NOT NULL,
        [subject] nvarchar(max) NOT NULL,
        [desc] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_contactss] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221129134611_contacts')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221129134611_contacts', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206075525_add_userto_orders')
BEGIN
    ALTER TABLE [productss] DROP CONSTRAINT [FK_productss_signups_usersid];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206075525_add_userto_orders')
BEGIN
    DROP INDEX [IX_productss_usersid] ON [productss];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206075525_add_userto_orders')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[productss]') AND [c].[name] = N'id');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [productss] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [productss] DROP COLUMN [id];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206075525_add_userto_orders')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[productss]') AND [c].[name] = N'usersid');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [productss] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [productss] DROP COLUMN [usersid];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206075525_add_userto_orders')
BEGIN
    ALTER TABLE [Orderss] ADD [id] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206075525_add_userto_orders')
BEGIN
    ALTER TABLE [Orderss] ADD [usersid] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206075525_add_userto_orders')
BEGIN
    CREATE INDEX [IX_Orderss_usersid] ON [Orderss] ([usersid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206075525_add_userto_orders')
BEGIN
    ALTER TABLE [Orderss] ADD CONSTRAINT [FK_Orderss_signups_usersid] FOREIGN KEY ([usersid]) REFERENCES [signups] ([id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221206075525_add_userto_orders')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221206075525_add_userto_orders', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221217120900_admin-users')
BEGIN
    CREATE TABLE [adminuserss] (
        [id] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [type] nvarchar(max) NOT NULL,
        [password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_adminuserss] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221217120900_admin-users')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221217120900_admin-users', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221227074718_blogs')
BEGIN
    ALTER TABLE [productss] ADD [keywords] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221227074718_blogs')
BEGIN
    ALTER TABLE [productss] ADD [metadesc] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221227074718_blogs')
BEGIN
    ALTER TABLE [productss] ADD [metatitle] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221227074718_blogs')
BEGIN
    CREATE TABLE [Blogss] (
        [blogid] int NOT NULL IDENTITY,
        [title] nvarchar(max) NOT NULL,
        [image] nvarchar(max) NOT NULL,
        [desc] nvarchar(max) NOT NULL,
        [metatitle] nvarchar(max) NOT NULL,
        [metdesc] nvarchar(max) NOT NULL,
        [keywords] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Blogss] PRIMARY KEY ([blogid])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221227074718_blogs')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221227074718_blogs', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230113115720_emailsend')
BEGIN
    ALTER TABLE [signups] ADD [verification] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230113115720_emailsend')
BEGIN
    CREATE TABLE [Otps] (
        [id] int NOT NULL IDENTITY,
        [email] nvarchar(max) NOT NULL,
        [code] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Otps] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230113115720_emailsend')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230113115720_emailsend', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230202104235_seoaltag')
BEGIN
    ALTER TABLE [productss] ADD [alttag] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230202104235_seoaltag')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230202104235_seoaltag', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230202132748_metamain')
BEGIN
    CREATE TABLE [metamains] (
        [id] int NOT NULL IDENTITY,
        [metatitle] nvarchar(max) NOT NULL,
        [metadesc] nvarchar(max) NOT NULL,
        [metakeyword] nvarchar(max) NOT NULL,
        [bnum] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_metamains] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230202132748_metamain')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230202132748_metamain', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230220075652_dealoftheday')
BEGIN
    CREATE TABLE [dods] (
        [banner_ID] int NOT NULL IDENTITY,
        [bnum] nvarchar(max) NOT NULL,
        [details] nvarchar(max) NOT NULL,
        [dealcounter] nvarchar(max) NOT NULL,
        [image] nvarchar(max) NOT NULL,
        [value] nvarchar(max) NOT NULL,
        [productid] nvarchar(max) NOT NULL,
        [type] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_dods] PRIMARY KEY ([banner_ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230220075652_dealoftheday')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230220075652_dealoftheday', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230221081041_dodprice')
BEGIN
    ALTER TABLE [dods] ADD [price] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230221081041_dodprice')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230221081041_dodprice', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230810083926_whishlist')
BEGIN
    CREATE TABLE [whish] (
        [whishid] int NOT NULL IDENTITY,
        [product_id] int NULL,
        [ProductsProduct_ID] int NULL,
        CONSTRAINT [PK_whish] PRIMARY KEY ([whishid]),
        CONSTRAINT [FK_whish_productss_ProductsProduct_ID] FOREIGN KEY ([ProductsProduct_ID]) REFERENCES [productss] ([Product_ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230810083926_whishlist')
BEGIN
    CREATE INDEX [IX_whish_ProductsProduct_ID] ON [whish] ([ProductsProduct_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230810083926_whishlist')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230810083926_whishlist', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812082520_whish-user')
BEGIN
    ALTER TABLE [whish] ADD [id] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812082520_whish-user')
BEGIN
    ALTER TABLE [whish] ADD [signupid] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812082520_whish-user')
BEGIN
    CREATE INDEX [IX_whish_signupid] ON [whish] ([signupid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812082520_whish-user')
BEGIN
    ALTER TABLE [whish] ADD CONSTRAINT [FK_whish_signups_signupid] FOREIGN KEY ([signupid]) REFERENCES [signups] ([id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230812082520_whish-user')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230812082520_whish-user', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901120602_ratings')
BEGIN
    CREATE TABLE [ratings] (
        [id] int NOT NULL IDENTITY,
        [email] nvarchar(max) NOT NULL,
        [comment] nvarchar(max) NOT NULL,
        [producttitle] nvarchar(max) NOT NULL,
        [prodid] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ratings] PRIMARY KEY ([id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230901120602_ratings')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230901120602_ratings', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230913104850_compare')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ratings]') AND [c].[name] = N'producttitle');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ratings] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [ratings] ALTER COLUMN [producttitle] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230913104850_compare')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ratings]') AND [c].[name] = N'prodid');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ratings] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [ratings] ALTER COLUMN [prodid] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230913104850_compare')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ratings]') AND [c].[name] = N'email');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ratings] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [ratings] ALTER COLUMN [email] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230913104850_compare')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ratings]') AND [c].[name] = N'comment');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ratings] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [ratings] ALTER COLUMN [comment] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230913104850_compare')
BEGIN
    ALTER TABLE [productss] ADD [compare] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230913104850_compare')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230913104850_compare', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231120054436_3dmodel')
BEGIN
    ALTER TABLE [productss] ADD [three_d] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231120054436_3dmodel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231120054436_3dmodel', N'6.0.7');
END;
GO

COMMIT;
GO

