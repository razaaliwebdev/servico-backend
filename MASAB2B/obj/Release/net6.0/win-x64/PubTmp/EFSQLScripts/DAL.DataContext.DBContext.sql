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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910132948_productmodule')
BEGIN
    CREATE TABLE [attributes] (
        [AttributeID] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_attributes] PRIMARY KEY ([AttributeID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910132948_productmodule')
BEGIN
    CREATE TABLE [brandss] (
        [Brand_ID] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_brandss] PRIMARY KEY ([Brand_ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910132948_productmodule')
BEGIN
    CREATE TABLE [categories] (
        [Categories_ID] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [slug] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_categories] PRIMARY KEY ([Categories_ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910132948_productmodule')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910132948_productmodule')
BEGIN
    CREATE TABLE [productss] (
        [Product_ID] int NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [category_id] int NOT NULL,
        [Categories_ID] int NOT NULL,
        [Subid] int NOT NULL,
        [subCategoriesSubid] int NOT NULL,
        [price] nvarchar(max) NOT NULL,
        [brand_id] int NOT NULL,
        [BrandsBrand_ID] int NOT NULL,
        [specification] nvarchar(max) NOT NULL,
        [Attributevalue] nvarchar(max) NOT NULL,
        [shortdesc] nvarchar(max) NOT NULL,
        [longdesc] nvarchar(max) NOT NULL,
        [singleImage] nvarchar(max) NOT NULL,
        [Images] nvarchar(max) NOT NULL,
        [brandname] nvarchar(max) NOT NULL,
        [categoryname] nvarchar(max) NOT NULL,
        [subcategoryname] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_productss] PRIMARY KEY ([Product_ID]),
        CONSTRAINT [FK_productss_brandss_BrandsBrand_ID] FOREIGN KEY ([BrandsBrand_ID]) REFERENCES [brandss] ([Brand_ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_productss_categories_Categories_ID] FOREIGN KEY ([Categories_ID]) REFERENCES [categories] ([Categories_ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_productss_subcategoriess_subCategoriesSubid] FOREIGN KEY ([subCategoriesSubid]) REFERENCES [subcategoriess] ([Subid]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910132948_productmodule')
BEGIN
    CREATE INDEX [IX_productss_BrandsBrand_ID] ON [productss] ([BrandsBrand_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910132948_productmodule')
BEGIN
    CREATE INDEX [IX_productss_Categories_ID] ON [productss] ([Categories_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910132948_productmodule')
BEGIN
    CREATE INDEX [IX_productss_subCategoriesSubid] ON [productss] ([subCategoriesSubid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910132948_productmodule')
BEGIN
    CREATE INDEX [IX_subcategoriess_Categories_ID] ON [subcategoriess] ([Categories_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910132948_productmodule')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220910132948_productmodule', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    ALTER TABLE [productss] DROP CONSTRAINT [FK_productss_brandss_BrandsBrand_ID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    ALTER TABLE [productss] DROP CONSTRAINT [FK_productss_categories_Categories_ID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    ALTER TABLE [productss] DROP CONSTRAINT [FK_productss_subcategoriess_subCategoriesSubid];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[productss]') AND [c].[name] = N'subCategoriesSubid');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [productss] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [productss] ALTER COLUMN [subCategoriesSubid] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[productss]') AND [c].[name] = N'category_id');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [productss] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [productss] ALTER COLUMN [category_id] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[productss]') AND [c].[name] = N'brand_id');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [productss] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [productss] ALTER COLUMN [brand_id] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[productss]') AND [c].[name] = N'Subid');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [productss] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [productss] ALTER COLUMN [Subid] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[productss]') AND [c].[name] = N'Categories_ID');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [productss] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [productss] ALTER COLUMN [Categories_ID] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[productss]') AND [c].[name] = N'BrandsBrand_ID');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [productss] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [productss] ALTER COLUMN [BrandsBrand_ID] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    ALTER TABLE [productss] ADD CONSTRAINT [FK_productss_brandss_BrandsBrand_ID] FOREIGN KEY ([BrandsBrand_ID]) REFERENCES [brandss] ([Brand_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    ALTER TABLE [productss] ADD CONSTRAINT [FK_productss_categories_Categories_ID] FOREIGN KEY ([Categories_ID]) REFERENCES [categories] ([Categories_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    ALTER TABLE [productss] ADD CONSTRAINT [FK_productss_subcategoriess_subCategoriesSubid] FOREIGN KEY ([subCategoriesSubid]) REFERENCES [subcategoriess] ([Subid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220913072808_foreignkeyFix')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220913072808_foreignkeyFix', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914111804_variations')
BEGIN
    ALTER TABLE [productss] ADD [variations] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220914111804_variations')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220914111804_variations', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916073354_homepage_display_name')
BEGIN
    ALTER TABLE [productss] ADD [bs] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916073354_homepage_display_name')
BEGIN
    ALTER TABLE [productss] ADD [dod] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916073354_homepage_display_name')
BEGIN
    ALTER TABLE [productss] ADD [fa] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916073354_homepage_display_name')
BEGIN
    ALTER TABLE [productss] ADD [modelno] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916073354_homepage_display_name')
BEGIN
    ALTER TABLE [productss] ADD [na] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220916073354_homepage_display_name')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220916073354_homepage_display_name', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919084945_rightspecification')
BEGIN
    ALTER TABLE [productss] ADD [specificationright] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220919084945_rightspecification')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220919084945_rightspecification', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221003062924_cbm_admin_height_width')
BEGIN
    EXEC sp_rename N'[productss].[weight]', N'depth', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221003062924_cbm_admin_height_width')
BEGIN
    ALTER TABLE [productss] ADD [cbm] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221003062924_cbm_admin_height_width')
BEGIN
    ALTER TABLE [productss] ADD [cbmcalculation] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221003062924_cbm_admin_height_width')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221003062924_cbm_admin_height_width', N'6.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011071924_containerhq_products')
BEGIN
    ALTER TABLE [productss] ADD [cl20gp] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011071924_containerhq_products')
BEGIN
    ALTER TABLE [productss] ADD [cl40gp] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011071924_containerhq_products')
BEGIN
    ALTER TABLE [productss] ADD [cl40hq] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011071924_containerhq_products')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221011071924_containerhq_products', N'6.0.7');
END;
GO

COMMIT;
GO

