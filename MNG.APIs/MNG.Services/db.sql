IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_AlMax');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_AlMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_AlMin');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_AlMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_CCEMax');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_CCEMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_CCEMin');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_CCEMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_CMax');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_CMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_CMin');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_CMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_CrMax');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_CrMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_CrMin');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_CrMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_CuMax');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_CuMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_CuMin');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_CuMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_MgMax');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_MgMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_MgMin');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_MgMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_MnMax');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_MnMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_MnMin');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_MnMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_MoMax');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_MoMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_MoMin');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_MoMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_NiMax');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_NiMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_NiMin');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_NiMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_PMax');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_PMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_PMin');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_PMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_SMax');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_SMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_SMin');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_SMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_SiMax');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_SiMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_SiMin');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_SiMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_SnMax');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_SnMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_SnMin');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_SnMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_TeMax');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_TeMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_TeMin');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_TeMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_TiMax');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_TiMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_TiMin');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_TiMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_VMax');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_VMax];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalStandard_VMin');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalStandard_VMin];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_V]', N'ChemicalActual_V', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Ti]', N'ChemicalActual_Ti', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_TestDate]', N'ChemicalActual_TestDate', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Te]', N'ChemicalActual_Te', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Sn]', N'ChemicalActual_Sn', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Si]', N'ChemicalActual_Si', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_S]', N'ChemicalActual_S', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_P]', N'ChemicalActual_P', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Ni]', N'ChemicalActual_Ni', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Mo]', N'ChemicalActual_Mo', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Mn]', N'ChemicalActual_Mn', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Mg]', N'ChemicalActual_Mg', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Cu]', N'ChemicalActual_Cu', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Cr]', N'ChemicalActual_Cr', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_CCE]', N'ChemicalActual_CCE', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_C]', N'ChemicalActual_C', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    EXEC sp_rename N'[Chargings].[ChemicalResult_Al]', N'ChemicalActual_Al', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219043240_Update19.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190219043240_Update19.1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219045539_Update19.2')
BEGIN
    ALTER TABLE [ControlPlans] DROP CONSTRAINT [FK_ControlPlans_Specifications_SpecificationCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219045539_Update19.2')
BEGIN
    DROP TABLE [Specifications];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219045539_Update19.2')
BEGIN
    DROP INDEX [IX_ControlPlans_SpecificationCode] ON [ControlPlans];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219045539_Update19.2')
BEGIN
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ControlPlans]') AND [c].[name] = N'SpecificationCode');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [ControlPlans] DROP CONSTRAINT [' + @var32 + '];');
    ALTER TABLE [ControlPlans] DROP COLUMN [SpecificationCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219045539_Update19.2')
BEGIN
    ALTER TABLE [ControlPlans] ADD [ChemicalCompositionInFurnaceCode] nvarchar(20) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219045539_Update19.2')
BEGIN
    CREATE TABLE [ChemicalCompositionsInFurnaces] (
        [Code] nvarchar(20) NOT NULL,
        [CCEMax] real NULL,
        [CCEMin] real NULL,
        [CMax] real NULL,
        [CMin] real NULL,
        [SiMax] real NULL,
        [SiMin] real NULL,
        [MnMax] real NULL,
        [MnMin] real NULL,
        [MgMax] real NULL,
        [MgMin] real NULL,
        [SMax] real NULL,
        [SMin] real NULL,
        [AlMax] real NULL,
        [AlMin] real NULL,
        [CuMax] real NULL,
        [CuMin] real NULL,
        [SnMax] real NULL,
        [SnMin] real NULL,
        [CrMax] real NULL,
        [CrMin] real NULL,
        [PMax] real NULL,
        [PMin] real NULL,
        [MoMax] real NULL,
        [MoMin] real NULL,
        [NiMax] real NULL,
        [NiMin] real NULL,
        [VMax] real NULL,
        [VMin] real NULL,
        [TiMax] real NULL,
        [TiMin] real NULL,
        [TeMax] real NULL,
        [TeMin] real NULL,
        CONSTRAINT [PK_ChemicalCompositionsInFurnaces] PRIMARY KEY ([Code])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219045539_Update19.2')
BEGIN
    CREATE INDEX [IX_ControlPlans_ChemicalCompositionInFurnaceCode] ON [ControlPlans] ([ChemicalCompositionInFurnaceCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219045539_Update19.2')
BEGIN
    ALTER TABLE [ControlPlans] ADD CONSTRAINT [FK_ControlPlans_ChemicalCompositionsInFurnaces_ChemicalCompositionInFurnaceCode] FOREIGN KEY ([ChemicalCompositionInFurnaceCode]) REFERENCES [ChemicalCompositionsInFurnaces] ([Code]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190219045539_Update19.2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190219045539_Update19.2', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223070542_AddTestChemicalCompositionModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190223070542_AddTestChemicalCompositionModel', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    ALTER TABLE [Chargings] DROP CONSTRAINT [FK_Chargings_Products_ProductId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DROP INDEX [IX_Chargings_ProductId] ON [Chargings];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var33 sysname;
    SELECT @var33 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ProductId');
    IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var33 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ProductId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var34 sysname;
    SELECT @var34 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Al');
    IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var34 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Al];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var35 sysname;
    SELECT @var35 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_C');
    IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var35 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_C];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var36 sysname;
    SELECT @var36 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_CCE');
    IF @var36 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var36 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_CCE];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var37 sysname;
    SELECT @var37 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Cr');
    IF @var37 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var37 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Cr];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var38 sysname;
    SELECT @var38 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Cu');
    IF @var38 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var38 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Cu];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var39 sysname;
    SELECT @var39 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Mg');
    IF @var39 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var39 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Mg];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var40 sysname;
    SELECT @var40 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Mn');
    IF @var40 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var40 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Mn];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var41 sysname;
    SELECT @var41 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Mo');
    IF @var41 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var41 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Mo];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var42 sysname;
    SELECT @var42 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Ni');
    IF @var42 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var42 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Ni];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var43 sysname;
    SELECT @var43 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_P');
    IF @var43 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var43 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_P];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var44 sysname;
    SELECT @var44 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_S');
    IF @var44 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var44 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_S];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var45 sysname;
    SELECT @var45 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Si');
    IF @var45 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var45 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Si];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var46 sysname;
    SELECT @var46 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Sn');
    IF @var46 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var46 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Sn];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var47 sysname;
    SELECT @var47 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Te');
    IF @var47 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var47 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Te];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var48 sysname;
    SELECT @var48 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_TestDate');
    IF @var48 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var48 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_TestDate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var49 sysname;
    SELECT @var49 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_Ti');
    IF @var49 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var49 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_Ti];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    DECLARE @var50 sysname;
    SELECT @var50 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'ChemicalActual_V');
    IF @var50 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var50 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [ChemicalActual_V];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071328_AddTestChemicalCompositionModel2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190223071328_AddTestChemicalCompositionModel2', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223071649_AddTestChemicalCompositionModel3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190223071649_AddTestChemicalCompositionModel3', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223072501_AddTestChemicalCompositionModel4')
BEGIN
    CREATE TABLE [TestChemicalCompositions] (
        [Code] nvarchar(20) NOT NULL,
        [TestTime] datetime2 NULL,
        [ProductId] int NOT NULL,
        [ChemicalActual_TestDate] datetime2 NOT NULL,
        [ChemicalActual_CCE] real NULL,
        [ChemicalActual_C] real NULL,
        [ChemicalActual_Si] real NULL,
        [ChemicalActual_Mn] real NULL,
        [ChemicalActual_Mg] real NULL,
        [ChemicalActual_S] real NULL,
        [ChemicalActual_Al] real NULL,
        [ChemicalActual_Cu] real NULL,
        [ChemicalActual_Sn] real NULL,
        [ChemicalActual_Cr] real NULL,
        [ChemicalActual_P] real NULL,
        [ChemicalActual_Mo] real NULL,
        [ChemicalActual_Ni] real NULL,
        [ChemicalActual_V] real NULL,
        [ChemicalActual_Ti] real NULL,
        [ChemicalActual_Te] real NULL,
        CONSTRAINT [PK_TestChemicalCompositions] PRIMARY KEY ([Code]),
        CONSTRAINT [FK_TestChemicalCompositions_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223072501_AddTestChemicalCompositionModel4')
BEGIN
    CREATE INDEX [IX_TestChemicalCompositions_ProductId] ON [TestChemicalCompositions] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223072501_AddTestChemicalCompositionModel4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190223072501_AddTestChemicalCompositionModel4', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223073538_AddTestChemicalCompositionModel5')
BEGIN
    DECLARE @var51 sysname;
    SELECT @var51 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TestChemicalCompositions]') AND [c].[name] = N'ChemicalActual_TestDate');
    IF @var51 IS NOT NULL EXEC(N'ALTER TABLE [TestChemicalCompositions] DROP CONSTRAINT [' + @var51 + '];');
    ALTER TABLE [TestChemicalCompositions] DROP COLUMN [ChemicalActual_TestDate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223073538_AddTestChemicalCompositionModel5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190223073538_AddTestChemicalCompositionModel5', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_V]', N'Result_V', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Ti]', N'Result_Ti', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Te]', N'Result_Te', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Sn]', N'Result_Sn', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Si]', N'Result_Si', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_S]', N'Result_S', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_P]', N'Result_P', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Ni]', N'Result_Ni', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Mo]', N'Result_Mo', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Mn]', N'Result_Mn', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Mg]', N'Result_Mg', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Cu]', N'Result_Cu', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Cr]', N'Result_Cr', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_CCE]', N'Result_CCE', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_C]', N'Result_C', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[ChemicalActual_Al]', N'Result_Al', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    CREATE TABLE [Kanban] (
        [Code] nvarchar(20) NOT NULL,
        [Time] datetime2 NOT NULL,
        [Weight] real NOT NULL,
        [TestChemicalCompositionCode] nvarchar(20) NOT NULL,
        CONSTRAINT [PK_Kanban] PRIMARY KEY ([Code]),
        CONSTRAINT [FK_Kanban_TestChemicalCompositions_TestChemicalCompositionCode] FOREIGN KEY ([TestChemicalCompositionCode]) REFERENCES [TestChemicalCompositions] ([Code]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    CREATE INDEX [IX_Kanban_TestChemicalCompositionCode] ON [Kanban] ([TestChemicalCompositionCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075509_AddTestChemicalCompositionModel6')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190223075509_AddTestChemicalCompositionModel6', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075934_AddTestChemicalCompositionModel7')
BEGIN
    ALTER TABLE [Kanban] DROP CONSTRAINT [FK_Kanban_TestChemicalCompositions_TestChemicalCompositionCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075934_AddTestChemicalCompositionModel7')
BEGIN
    ALTER TABLE [Kanban] DROP CONSTRAINT [PK_Kanban];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075934_AddTestChemicalCompositionModel7')
BEGIN
    EXEC sp_rename N'[Kanban]', N'Kanbans';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075934_AddTestChemicalCompositionModel7')
BEGIN
    EXEC sp_rename N'[Kanbans].[IX_Kanban_TestChemicalCompositionCode]', N'IX_Kanbans_TestChemicalCompositionCode', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075934_AddTestChemicalCompositionModel7')
BEGIN
    ALTER TABLE [Kanbans] ADD CONSTRAINT [PK_Kanbans] PRIMARY KEY ([Code]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075934_AddTestChemicalCompositionModel7')
BEGIN
    ALTER TABLE [Kanbans] ADD CONSTRAINT [FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode] FOREIGN KEY ([TestChemicalCompositionCode]) REFERENCES [TestChemicalCompositions] ([Code]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223075934_AddTestChemicalCompositionModel7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190223075934_AddTestChemicalCompositionModel7', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223080503_AddTestChemicalCompositionModel8')
BEGIN
    ALTER TABLE [Kanbans] ADD [ChargingChargeNo] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223080503_AddTestChemicalCompositionModel8')
BEGIN
    ALTER TABLE [Kanbans] ADD [ChargingCode] nvarchar(20) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223080503_AddTestChemicalCompositionModel8')
BEGIN
    CREATE INDEX [IX_Kanbans_ChargingChargeNo] ON [Kanbans] ([ChargingChargeNo]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223080503_AddTestChemicalCompositionModel8')
BEGIN
    ALTER TABLE [Kanbans] ADD CONSTRAINT [FK_Kanbans_Chargings_ChargingChargeNo] FOREIGN KEY ([ChargingChargeNo]) REFERENCES [Chargings] ([ChargeNo]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223080503_AddTestChemicalCompositionModel8')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190223080503_AddTestChemicalCompositionModel8', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223143218_Update23.1')
BEGIN
    EXEC sp_rename N'[TestChemicalCompositions].[TestTime]', N'Time', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223143218_Update23.1')
BEGIN
    EXEC sp_rename N'[Chargings].[StopTime]', N'MaxTempTime', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223143218_Update23.1')
BEGIN
    EXEC sp_rename N'[Chargings].[StartTime]', N'ChargeTime', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223143218_Update23.1')
BEGIN
    EXEC sp_rename N'[Chargings].[KwHr]', N'StartKwHr', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223143218_Update23.1')
BEGIN
    ALTER TABLE [Kanbans] ADD [KwHr] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223143218_Update23.1')
BEGIN
    ALTER TABLE [Chargings] ADD [MaxTemp] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223143218_Update23.1')
BEGIN
    ALTER TABLE [Chargings] ADD [MaxTempKwHr] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190223143218_Update23.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190223143218_Update23.1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305164907_update050301')
BEGIN
    DROP INDEX [IX_Kanbans_TestChemicalCompositionCode] ON [Kanbans];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305164907_update050301')
BEGIN
    CREATE UNIQUE INDEX [IX_Kanbans_TestChemicalCompositionCode] ON [Kanbans] ([TestChemicalCompositionCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305164907_update050301')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190305164907_update050301', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305165047_update050302')
BEGIN
    ALTER TABLE [Kanbans] DROP CONSTRAINT [FK_Kanbans_Chargings_ChargingChargeNo];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305165047_update050302')
BEGIN
    ALTER TABLE [Kanbans] DROP CONSTRAINT [FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305165047_update050302')
BEGIN
    DROP INDEX [IX_Kanbans_ChargingChargeNo] ON [Kanbans];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305165047_update050302')
BEGIN
    DROP INDEX [IX_Kanbans_TestChemicalCompositionCode] ON [Kanbans];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305165047_update050302')
BEGIN
    DECLARE @var52 sysname;
    SELECT @var52 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'ChargingChargeNo');
    IF @var52 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var52 + '];');
    ALTER TABLE [Kanbans] DROP COLUMN [ChargingChargeNo];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305165047_update050302')
BEGIN
    DECLARE @var53 sysname;
    SELECT @var53 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'ChargingCode');
    IF @var53 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var53 + '];');
    ALTER TABLE [Kanbans] DROP COLUMN [ChargingCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305165047_update050302')
BEGIN
    DECLARE @var54 sysname;
    SELECT @var54 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'TestChemicalCompositionCode');
    IF @var54 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var54 + '];');
    ALTER TABLE [Kanbans] DROP COLUMN [TestChemicalCompositionCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190305165047_update050302')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190305165047_update050302', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190306162251_AddTransaction')
BEGIN
    CREATE TABLE [Transactions] (
        [Code] nvarchar(20) NOT NULL,
        [ChargingChargeNo] nvarchar(20) NULL,
        [ChargingCode] nvarchar(20) NOT NULL,
        [TestChemicalCompositionCode] nvarchar(20) NOT NULL,
        [KanbanCode] nvarchar(20) NOT NULL,
        CONSTRAINT [PK_Transactions] PRIMARY KEY ([Code]),
        CONSTRAINT [FK_Transactions_Chargings_ChargingChargeNo] FOREIGN KEY ([ChargingChargeNo]) REFERENCES [Chargings] ([ChargeNo]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Transactions_Kanbans_KanbanCode] FOREIGN KEY ([KanbanCode]) REFERENCES [Kanbans] ([Code]) ON DELETE CASCADE,
        CONSTRAINT [FK_Transactions_TestChemicalCompositions_TestChemicalCompositionCode] FOREIGN KEY ([TestChemicalCompositionCode]) REFERENCES [TestChemicalCompositions] ([Code]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190306162251_AddTransaction')
BEGIN
    CREATE INDEX [IX_Transactions_ChargingChargeNo] ON [Transactions] ([ChargingChargeNo]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190306162251_AddTransaction')
BEGIN
    CREATE INDEX [IX_Transactions_KanbanCode] ON [Transactions] ([KanbanCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190306162251_AddTransaction')
BEGIN
    CREATE INDEX [IX_Transactions_TestChemicalCompositionCode] ON [Transactions] ([TestChemicalCompositionCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190306162251_AddTransaction')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190306162251_AddTransaction', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308034940_UpdateModel1')
BEGIN
    DROP TABLE [Transactions];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308034940_UpdateModel1')
BEGIN
    ALTER TABLE [Chargings] ADD [FurnaceCode] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308034940_UpdateModel1')
BEGIN
    ALTER TABLE [Chargings] ADD [Shift] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308034940_UpdateModel1')
BEGIN
    CREATE TABLE [Furnace] (
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(max) NULL,
        [Brand] nvarchar(max) NULL,
        [Capacity] int NOT NULL,
        [Power] int NOT NULL,
        CONSTRAINT [PK_Furnace] PRIMARY KEY ([Code])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308034940_UpdateModel1')
BEGIN
    CREATE INDEX [IX_Chargings_FurnaceCode] ON [Chargings] ([FurnaceCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308034940_UpdateModel1')
BEGIN
    ALTER TABLE [Chargings] ADD CONSTRAINT [FK_Chargings_Furnace_FurnaceCode] FOREIGN KEY ([FurnaceCode]) REFERENCES [Furnace] ([Code]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308034940_UpdateModel1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190308034940_UpdateModel1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    ALTER TABLE [Chargings] DROP CONSTRAINT [FK_Chargings_Furnace_FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [ChargingChargeNo] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [ChargingCode] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    ALTER TABLE [Kanbans] ADD [TestChemicalCompositionCode] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    DROP INDEX [IX_Chargings_FurnaceCode] ON [Chargings];
    DECLARE @var55 sysname;
    SELECT @var55 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'FurnaceCode');
    IF @var55 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var55 + '];');
    ALTER TABLE [Chargings] ALTER COLUMN [FurnaceCode] nvarchar(20) NOT NULL;
    CREATE INDEX [IX_Chargings_FurnaceCode] ON [Chargings] ([FurnaceCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    CREATE INDEX [IX_TestChemicalCompositions_ChargingChargeNo] ON [TestChemicalCompositions] ([ChargingChargeNo]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    CREATE INDEX [IX_Kanbans_TestChemicalCompositionCode] ON [Kanbans] ([TestChemicalCompositionCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    ALTER TABLE [Chargings] ADD CONSTRAINT [FK_Chargings_Furnace_FurnaceCode] FOREIGN KEY ([FurnaceCode]) REFERENCES [Furnace] ([Code]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    ALTER TABLE [Kanbans] ADD CONSTRAINT [FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode] FOREIGN KEY ([TestChemicalCompositionCode]) REFERENCES [TestChemicalCompositions] ([Code]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD CONSTRAINT [FK_TestChemicalCompositions_Chargings_ChargingChargeNo] FOREIGN KEY ([ChargingChargeNo]) REFERENCES [Chargings] ([ChargeNo]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040438_UpdateModel2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190308040438_UpdateModel2', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308040913_UpdateModel3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190308040913_UpdateModel3', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308041044_UpdateModel4')
BEGIN
    ALTER TABLE [TestChemicalCompositions] DROP CONSTRAINT [FK_TestChemicalCompositions_Chargings_ChargingChargeNo];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308041044_UpdateModel4')
BEGIN
    DROP INDEX [IX_TestChemicalCompositions_ChargingChargeNo] ON [TestChemicalCompositions];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308041044_UpdateModel4')
BEGIN
    DECLARE @var56 sysname;
    SELECT @var56 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TestChemicalCompositions]') AND [c].[name] = N'ChargingChargeNo');
    IF @var56 IS NOT NULL EXEC(N'ALTER TABLE [TestChemicalCompositions] DROP CONSTRAINT [' + @var56 + '];');
    ALTER TABLE [TestChemicalCompositions] DROP COLUMN [ChargingChargeNo];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308041044_UpdateModel4')
BEGIN
    DECLARE @var57 sysname;
    SELECT @var57 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TestChemicalCompositions]') AND [c].[name] = N'ChargingCode');
    IF @var57 IS NOT NULL EXEC(N'ALTER TABLE [TestChemicalCompositions] DROP CONSTRAINT [' + @var57 + '];');
    ALTER TABLE [TestChemicalCompositions] ALTER COLUMN [ChargingCode] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308041044_UpdateModel4')
BEGIN
    CREATE INDEX [IX_TestChemicalCompositions_ChargingCode] ON [TestChemicalCompositions] ([ChargingCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308041044_UpdateModel4')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD CONSTRAINT [FK_TestChemicalCompositions_Chargings_ChargingCode] FOREIGN KEY ([ChargingCode]) REFERENCES [Chargings] ([ChargeNo]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308041044_UpdateModel4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190308041044_UpdateModel4', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308071304_AddRequired')
BEGIN
    ALTER TABLE [Kanbans] DROP CONSTRAINT [FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308071304_AddRequired')
BEGIN
    ALTER TABLE [TestChemicalCompositions] DROP CONSTRAINT [FK_TestChemicalCompositions_Chargings_ChargingCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308071304_AddRequired')
BEGIN
    DROP INDEX [IX_TestChemicalCompositions_ChargingCode] ON [TestChemicalCompositions];
    DECLARE @var58 sysname;
    SELECT @var58 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TestChemicalCompositions]') AND [c].[name] = N'ChargingCode');
    IF @var58 IS NOT NULL EXEC(N'ALTER TABLE [TestChemicalCompositions] DROP CONSTRAINT [' + @var58 + '];');
    ALTER TABLE [TestChemicalCompositions] ALTER COLUMN [ChargingCode] nvarchar(20) NOT NULL;
    CREATE INDEX [IX_TestChemicalCompositions_ChargingCode] ON [TestChemicalCompositions] ([ChargingCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308071304_AddRequired')
BEGIN
    DROP INDEX [IX_Kanbans_TestChemicalCompositionCode] ON [Kanbans];
    DECLARE @var59 sysname;
    SELECT @var59 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'TestChemicalCompositionCode');
    IF @var59 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var59 + '];');
    ALTER TABLE [Kanbans] ALTER COLUMN [TestChemicalCompositionCode] nvarchar(20) NOT NULL;
    CREATE INDEX [IX_Kanbans_TestChemicalCompositionCode] ON [Kanbans] ([TestChemicalCompositionCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308071304_AddRequired')
BEGIN
    ALTER TABLE [Kanbans] ADD CONSTRAINT [FK_Kanbans_TestChemicalCompositions_TestChemicalCompositionCode] FOREIGN KEY ([TestChemicalCompositionCode]) REFERENCES [TestChemicalCompositions] ([Code]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308071304_AddRequired')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD CONSTRAINT [FK_TestChemicalCompositions_Chargings_ChargingCode] FOREIGN KEY ([ChargingCode]) REFERENCES [Chargings] ([ChargeNo]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190308071304_AddRequired')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190308071304_AddRequired', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190309155150_Update090301')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [IsCompleted] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190309155150_Update090301')
BEGIN
    ALTER TABLE [Chargings] ADD [IsCompleted] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190309155150_Update090301')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190309155150_Update090301', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312161127_CreateLotNoModel1')
BEGIN
    CREATE TABLE [LotNos] (
        [Code] nvarchar(20) NOT NULL,
        [Date] datetime2 NOT NULL,
        CONSTRAINT [PK_LotNos] PRIMARY KEY ([Code])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312161127_CreateLotNoModel1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190312161127_CreateLotNoModel1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162426_CreateLotNoModel2')
BEGIN
    ALTER TABLE [LotNos] ADD [FurnaceCode] nvarchar(20) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162426_CreateLotNoModel2')
BEGIN
    ALTER TABLE [LotNos] ADD [IsCompleted] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162426_CreateLotNoModel2')
BEGIN
    ALTER TABLE [LotNos] ADD [Shift] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162426_CreateLotNoModel2')
BEGIN
    CREATE INDEX [IX_LotNos_FurnaceCode] ON [LotNos] ([FurnaceCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162426_CreateLotNoModel2')
BEGIN
    ALTER TABLE [LotNos] ADD CONSTRAINT [FK_LotNos_Furnace_FurnaceCode] FOREIGN KEY ([FurnaceCode]) REFERENCES [Furnace] ([Code]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162426_CreateLotNoModel2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190312162426_CreateLotNoModel2', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162628_CreateLotNoModel3')
BEGIN
    ALTER TABLE [Chargings] DROP CONSTRAINT [FK_Chargings_Furnace_FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162628_CreateLotNoModel3')
BEGIN
    DROP INDEX [IX_LotNos_FurnaceCode] ON [LotNos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162628_CreateLotNoModel3')
BEGIN
    DROP INDEX [IX_Chargings_FurnaceCode] ON [Chargings];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162628_CreateLotNoModel3')
BEGIN
    DECLARE @var60 sysname;
    SELECT @var60 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'FurnaceCode');
    IF @var60 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var60 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162628_CreateLotNoModel3')
BEGIN
    DECLARE @var61 sysname;
    SELECT @var61 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'Shift');
    IF @var61 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var61 + '];');
    ALTER TABLE [Chargings] DROP COLUMN [Shift];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162628_CreateLotNoModel3')
BEGIN
    CREATE UNIQUE INDEX [IX_LotNos_FurnaceCode] ON [LotNos] ([FurnaceCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162628_CreateLotNoModel3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190312162628_CreateLotNoModel3', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162930_CreateLotNoModel4')
BEGIN
    ALTER TABLE [Chargings] ADD [LotNoCode] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162930_CreateLotNoModel4')
BEGIN
    CREATE INDEX [IX_Chargings_LotNoCode] ON [Chargings] ([LotNoCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162930_CreateLotNoModel4')
BEGIN
    ALTER TABLE [Chargings] ADD CONSTRAINT [FK_Chargings_LotNos_LotNoCode] FOREIGN KEY ([LotNoCode]) REFERENCES [LotNos] ([Code]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312162930_CreateLotNoModel4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190312162930_CreateLotNoModel4', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312163954_CreateLotNoModel5')
BEGIN
    ALTER TABLE [LotNos] DROP CONSTRAINT [FK_LotNos_Furnace_FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312163954_CreateLotNoModel5')
BEGIN
    DROP INDEX [IX_LotNos_FurnaceCode] ON [LotNos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312163954_CreateLotNoModel5')
BEGIN
    DECLARE @var62 sysname;
    SELECT @var62 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LotNos]') AND [c].[name] = N'FurnaceCode');
    IF @var62 IS NOT NULL EXEC(N'ALTER TABLE [LotNos] DROP CONSTRAINT [' + @var62 + '];');
    ALTER TABLE [LotNos] ALTER COLUMN [FurnaceCode] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312163954_CreateLotNoModel5')
BEGIN
    CREATE UNIQUE INDEX [IX_LotNos_FurnaceCode] ON [LotNos] ([FurnaceCode]) WHERE [FurnaceCode] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312163954_CreateLotNoModel5')
BEGIN
    ALTER TABLE [LotNos] ADD CONSTRAINT [FK_LotNos_Furnace_FurnaceCode] FOREIGN KEY ([FurnaceCode]) REFERENCES [Furnace] ([Code]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312163954_CreateLotNoModel5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190312163954_CreateLotNoModel5', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312164931_CreateLotNoModel6')
BEGIN
    ALTER TABLE [LotNos] DROP CONSTRAINT [FK_LotNos_Furnace_FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312164931_CreateLotNoModel6')
BEGIN
    DROP TABLE [Furnace];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312164931_CreateLotNoModel6')
BEGIN
    DROP INDEX [IX_LotNos_FurnaceCode] ON [LotNos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312164931_CreateLotNoModel6')
BEGIN
    DECLARE @var63 sysname;
    SELECT @var63 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LotNos]') AND [c].[name] = N'FurnaceCode');
    IF @var63 IS NOT NULL EXEC(N'ALTER TABLE [LotNos] DROP CONSTRAINT [' + @var63 + '];');
    ALTER TABLE [LotNos] DROP COLUMN [FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312164931_CreateLotNoModel6')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190312164931_CreateLotNoModel6', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312165621_CreateFurnaceModel1')
BEGIN
    CREATE TABLE [Furnaces] (
        [Code] nvarchar(20) NOT NULL,
        [Name] nvarchar(max) NULL,
        [Brand] nvarchar(max) NULL,
        [Capacity] int NOT NULL,
        [Power] int NOT NULL,
        CONSTRAINT [PK_Furnaces] PRIMARY KEY ([Code])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312165621_CreateFurnaceModel1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190312165621_CreateFurnaceModel1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312170251_AddRelationShip1')
BEGIN
    ALTER TABLE [LotNos] ADD [FurnaceCode] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312170251_AddRelationShip1')
BEGIN
    CREATE INDEX [IX_LotNos_FurnaceCode] ON [LotNos] ([FurnaceCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312170251_AddRelationShip1')
BEGIN
    ALTER TABLE [LotNos] ADD CONSTRAINT [FK_LotNos_Furnaces_FurnaceCode] FOREIGN KEY ([FurnaceCode]) REFERENCES [Furnaces] ([Code]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312170251_AddRelationShip1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190312170251_AddRelationShip1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312170745_AddRelationShip2')
BEGIN
    ALTER TABLE [LotNos] DROP CONSTRAINT [FK_LotNos_Furnaces_FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312170745_AddRelationShip2')
BEGIN
    DROP INDEX [IX_LotNos_FurnaceCode] ON [LotNos];
    DECLARE @var64 sysname;
    SELECT @var64 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LotNos]') AND [c].[name] = N'FurnaceCode');
    IF @var64 IS NOT NULL EXEC(N'ALTER TABLE [LotNos] DROP CONSTRAINT [' + @var64 + '];');
    ALTER TABLE [LotNos] ALTER COLUMN [FurnaceCode] nvarchar(20) NOT NULL;
    CREATE INDEX [IX_LotNos_FurnaceCode] ON [LotNos] ([FurnaceCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312170745_AddRelationShip2')
BEGIN
    ALTER TABLE [LotNos] ADD CONSTRAINT [FK_LotNos_Furnaces_FurnaceCode] FOREIGN KEY ([FurnaceCode]) REFERENCES [Furnaces] ([Code]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190312170745_AddRelationShip2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190312170745_AddRelationShip2', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313150219_FurnaceNav')
BEGIN
    ALTER TABLE [LotNos] DROP CONSTRAINT [FK_LotNos_Furnaces_FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313150219_FurnaceNav')
BEGIN
    DROP INDEX [IX_LotNos_FurnaceCode] ON [LotNos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313150219_FurnaceNav')
BEGIN
    DECLARE @var65 sysname;
    SELECT @var65 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LotNos]') AND [c].[name] = N'FurnaceCode');
    IF @var65 IS NOT NULL EXEC(N'ALTER TABLE [LotNos] DROP CONSTRAINT [' + @var65 + '];');
    ALTER TABLE [LotNos] DROP COLUMN [FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313150219_FurnaceNav')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190313150219_FurnaceNav', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313150442_LotNoNavKey')
BEGIN
    ALTER TABLE [Chargings] DROP CONSTRAINT [FK_Chargings_LotNos_LotNoCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313150442_LotNoNavKey')
BEGIN
    DROP INDEX [IX_Chargings_LotNoCode] ON [Chargings];
    DECLARE @var66 sysname;
    SELECT @var66 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Chargings]') AND [c].[name] = N'LotNoCode');
    IF @var66 IS NOT NULL EXEC(N'ALTER TABLE [Chargings] DROP CONSTRAINT [' + @var66 + '];');
    ALTER TABLE [Chargings] ALTER COLUMN [LotNoCode] nvarchar(20) NOT NULL;
    CREATE INDEX [IX_Chargings_LotNoCode] ON [Chargings] ([LotNoCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313150442_LotNoNavKey')
BEGIN
    ALTER TABLE [Chargings] ADD CONSTRAINT [FK_Chargings_LotNos_LotNoCode] FOREIGN KEY ([LotNoCode]) REFERENCES [LotNos] ([Code]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313150442_LotNoNavKey')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190313150442_LotNoNavKey', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313163722_FurnaceNavOnLotNoModel')
BEGIN
    DECLARE @var67 sysname;
    SELECT @var67 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'DimensionCose');
    IF @var67 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var67 + '];');
    ALTER TABLE [Products] DROP COLUMN [DimensionCose];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313163722_FurnaceNavOnLotNoModel')
BEGIN
    ALTER TABLE [LotNos] ADD [FurnaceCode] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313163722_FurnaceNavOnLotNoModel')
BEGIN
    CREATE UNIQUE INDEX [IX_LotNos_FurnaceCode] ON [LotNos] ([FurnaceCode]) WHERE [FurnaceCode] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313163722_FurnaceNavOnLotNoModel')
BEGIN
    ALTER TABLE [LotNos] ADD CONSTRAINT [FK_LotNos_Furnaces_FurnaceCode] FOREIGN KEY ([FurnaceCode]) REFERENCES [Furnaces] ([Code]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313163722_FurnaceNavOnLotNoModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190313163722_FurnaceNavOnLotNoModel', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313164559_FurnaceNavOnLotNoModel1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190313164559_FurnaceNavOnLotNoModel1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313164805_FurnaceNavOnLotNoModel2')
BEGIN
    ALTER TABLE [LotNos] DROP CONSTRAINT [FK_LotNos_Furnaces_FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313164805_FurnaceNavOnLotNoModel2')
BEGIN
    DROP INDEX [IX_LotNos_FurnaceCode] ON [LotNos];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313164805_FurnaceNavOnLotNoModel2')
BEGIN
    DECLARE @var68 sysname;
    SELECT @var68 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LotNos]') AND [c].[name] = N'FurnaceCode');
    IF @var68 IS NOT NULL EXEC(N'ALTER TABLE [LotNos] DROP CONSTRAINT [' + @var68 + '];');
    ALTER TABLE [LotNos] DROP COLUMN [FurnaceCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313164805_FurnaceNavOnLotNoModel2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190313164805_FurnaceNavOnLotNoModel2', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313165718_FurnaceOnLotNoModel')
BEGIN
    ALTER TABLE [Furnaces] ADD [LotNoCode] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313165718_FurnaceOnLotNoModel')
BEGIN
    CREATE INDEX [IX_Furnaces_LotNoCode] ON [Furnaces] ([LotNoCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313165718_FurnaceOnLotNoModel')
BEGIN
    ALTER TABLE [Furnaces] ADD CONSTRAINT [FK_Furnaces_LotNos_LotNoCode] FOREIGN KEY ([LotNoCode]) REFERENCES [LotNos] ([Code]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190313165718_FurnaceOnLotNoModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190313165718_FurnaceOnLotNoModel', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190314153631_UpdateLotNo1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190314153631_UpdateLotNo1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190314155618_UpdateLotNo2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190314155618_UpdateLotNo2', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190314160704_UpdateLotNo3')
BEGIN
    ALTER TABLE [Furnaces] DROP CONSTRAINT [FK_Furnaces_LotNos_LotNoCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190314160704_UpdateLotNo3')
BEGIN
    DROP INDEX [IX_Furnaces_LotNoCode] ON [Furnaces];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190314160704_UpdateLotNo3')
BEGIN
    DECLARE @var69 sysname;
    SELECT @var69 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Furnaces]') AND [c].[name] = N'LotNoCode');
    IF @var69 IS NOT NULL EXEC(N'ALTER TABLE [Furnaces] DROP CONSTRAINT [' + @var69 + '];');
    ALTER TABLE [Furnaces] DROP COLUMN [LotNoCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190314160704_UpdateLotNo3')
BEGIN
    ALTER TABLE [LotNos] ADD [FurnaceCode] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190314160704_UpdateLotNo3')
BEGIN
    CREATE INDEX [IX_LotNos_FurnaceCode] ON [LotNos] ([FurnaceCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190314160704_UpdateLotNo3')
BEGIN
    ALTER TABLE [LotNos] ADD CONSTRAINT [FK_LotNos_Furnaces_FurnaceCode] FOREIGN KEY ([FurnaceCode]) REFERENCES [Furnaces] ([Code]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190314160704_UpdateLotNo3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190314160704_UpdateLotNo3', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190323064127_update23031901')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190323064127_update23031901', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190323064720_update23031902')
BEGIN
    DECLARE @var70 sysname;
    SELECT @var70 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LotNos]') AND [c].[name] = N'Shift');
    IF @var70 IS NOT NULL EXEC(N'ALTER TABLE [LotNos] DROP CONSTRAINT [' + @var70 + '];');
    ALTER TABLE [LotNos] ALTER COLUMN [Shift] nvarchar(1) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190323064720_update23031902')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190323064720_update23031902', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190418064229_TestChemValidation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190418064229_TestChemValidation', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190418081241_TestChemValidation1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190418081241_TestChemValidation1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Al] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_C] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_CCE] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Cr] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Cu] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Mg] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Mn] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Mo] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Ni] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_P] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_S] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Si] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Sn] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Te] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_Ti] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Validation_IsOk_V] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419043148_AddValidation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190419043148_AddValidation', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419050617_AddValidation1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190419050617_AddValidation1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419051119_AddValidation2')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [Result_IsOk_CCE] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190419051119_AddValidation2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190419051119_AddValidation2', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190425152905_UpdateTestChem')
BEGIN
    ALTER TABLE [TestChemicalCompositions] DROP CONSTRAINT [FK_TestChemicalCompositions_Products_ProductId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190425152905_UpdateTestChem')
BEGIN
    DECLARE @var71 sysname;
    SELECT @var71 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TestChemicalCompositions]') AND [c].[name] = N'Result_IsOk_CCE');
    IF @var71 IS NOT NULL EXEC(N'ALTER TABLE [TestChemicalCompositions] DROP CONSTRAINT [' + @var71 + '];');
    ALTER TABLE [TestChemicalCompositions] DROP COLUMN [Result_IsOk_CCE];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190425152905_UpdateTestChem')
BEGIN
    DECLARE @var72 sysname;
    SELECT @var72 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TestChemicalCompositions]') AND [c].[name] = N'ProductId');
    IF @var72 IS NOT NULL EXEC(N'ALTER TABLE [TestChemicalCompositions] DROP CONSTRAINT [' + @var72 + '];');
    ALTER TABLE [TestChemicalCompositions] ALTER COLUMN [ProductId] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190425152905_UpdateTestChem')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD CONSTRAINT [FK_TestChemicalCompositions_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190425152905_UpdateTestChem')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190425152905_UpdateTestChem', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190425162855_UpdateTestChem1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190425162855_UpdateTestChem1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190426053920_UpdateTestChemModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190426053920_UpdateTestChemModel', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190501033717_AddTestInLadleModel1')
BEGIN
    UPDATE TestChemicalCompositions SET [Time]='2019-01-01T00:00:00' 
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190501033717_AddTestInLadleModel1')
BEGIN
    DECLARE @var73 sysname;
    SELECT @var73 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TestChemicalCompositions]') AND [c].[name] = N'Time');
    IF @var73 IS NOT NULL EXEC(N'ALTER TABLE [TestChemicalCompositions] DROP CONSTRAINT [' + @var73 + '];');
    ALTER TABLE [TestChemicalCompositions] ALTER COLUMN [Time] datetime2 NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190501033717_AddTestInLadleModel1')
BEGIN
    CREATE TABLE [TestChemInLadle] (
        [Code] nvarchar(20) NOT NULL,
        [Time] datetime2 NOT NULL,
        [ProductId] int NULL,
        [Result_CCE] real NULL,
        [Result_C] real NULL,
        [Result_Si] real NULL,
        [Result_Mn] real NULL,
        [Result_Mg] real NULL,
        [Result_S] real NULL,
        [Result_Al] real NULL,
        [Result_Cu] real NULL,
        [Result_Sn] real NULL,
        [Result_Cr] real NULL,
        [Result_P] real NULL,
        [Result_Mo] real NULL,
        [Result_Ni] real NULL,
        [Result_V] real NULL,
        [Result_Ti] real NULL,
        [Result_Te] real NULL,
        [Validation_IsOk_CCE] bit NULL,
        [Validation_IsOk_C] bit NULL,
        [Validation_IsOk_Si] bit NULL,
        [Validation_IsOk_Mn] bit NULL,
        [Validation_IsOk_Mg] bit NULL,
        [Validation_IsOk_S] bit NULL,
        [Validation_IsOk_Al] bit NULL,
        [Validation_IsOk_Cu] bit NULL,
        [Validation_IsOk_Sn] bit NULL,
        [Validation_IsOk_Cr] bit NULL,
        [Validation_IsOk_P] bit NULL,
        [Validation_IsOk_Mo] bit NULL,
        [Validation_IsOk_Ni] bit NULL,
        [Validation_IsOk_V] bit NULL,
        [Validation_IsOk_Ti] bit NULL,
        [Validation_IsOk_Te] bit NULL,
        [IsCompleted] bit NOT NULL,
        [KanbanCode] nvarchar(20) NOT NULL,
        CONSTRAINT [PK_TestChemInLadle] PRIMARY KEY ([Code]),
        CONSTRAINT [FK_TestChemInLadle_Kanbans_KanbanCode] FOREIGN KEY ([KanbanCode]) REFERENCES [Kanbans] ([Code]) ON DELETE CASCADE,
        CONSTRAINT [FK_TestChemInLadle_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190501033717_AddTestInLadleModel1')
BEGIN
    CREATE INDEX [IX_TestChemInLadle_KanbanCode] ON [TestChemInLadle] ([KanbanCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190501033717_AddTestInLadleModel1')
BEGIN
    CREATE INDEX [IX_TestChemInLadle_ProductId] ON [TestChemInLadle] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190501033717_AddTestInLadleModel1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190501033717_AddTestInLadleModel1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190604143528_Update19060401')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190604143528_Update19060401', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190604155504_Update19060402')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190604155504_Update19060402', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190607155024_Update19060701')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190607155024_Update19060701', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190607160259_Update19060702')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190607160259_Update19060702', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190607161724_Update19060703')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190607161724_Update19060703', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190611142657_Update19061101')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190611142657_Update19061101', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190611142758_Update19061102')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190611142758_Update19061102', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    DROP TABLE [TestChemInLadle];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [IsCompleted] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Al] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_C] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_CCE] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Cr] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Cu] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Mg] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Mn] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Mo] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Ni] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_P] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_S] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Si] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Sn] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Te] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_Ti] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Result_V] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Al] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_C] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_CCE] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Cr] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Cu] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Mg] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Mn] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Mo] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Ni] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_P] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_S] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Si] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Sn] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Te] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_Ti] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [Kanbans] ADD [Validation_IsOk_V] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [ControlPlans] ADD [ChemicalCompositionInLadleCode] nvarchar(20) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    CREATE TABLE [ChemicalCompositionsInLadles] (
        [Code] nvarchar(20) NOT NULL,
        [CCEMax] real NULL,
        [CCEMin] real NULL,
        [CMax] real NULL,
        [CMin] real NULL,
        [SiMax] real NULL,
        [SiMin] real NULL,
        [MnMax] real NULL,
        [MnMin] real NULL,
        [MgMax] real NULL,
        [MgMin] real NULL,
        [SMax] real NULL,
        [SMin] real NULL,
        [AlMax] real NULL,
        [AlMin] real NULL,
        [CuMax] real NULL,
        [CuMin] real NULL,
        [SnMax] real NULL,
        [SnMin] real NULL,
        [CrMax] real NULL,
        [CrMin] real NULL,
        [PMax] real NULL,
        [PMin] real NULL,
        [MoMax] real NULL,
        [MoMin] real NULL,
        [NiMax] real NULL,
        [NiMin] real NULL,
        [VMax] real NULL,
        [VMin] real NULL,
        [TiMax] real NULL,
        [TiMin] real NULL,
        [TeMax] real NULL,
        [TeMin] real NULL,
        CONSTRAINT [PK_ChemicalCompositionsInLadles] PRIMARY KEY ([Code])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    CREATE INDEX [IX_ControlPlans_ChemicalCompositionInLadleCode] ON [ControlPlans] ([ChemicalCompositionInLadleCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    ALTER TABLE [ControlPlans] ADD CONSTRAINT [FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode] FOREIGN KEY ([ChemicalCompositionInLadleCode]) REFERENCES [ChemicalCompositionsInLadles] ([Code]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190613160100_Update19061301')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190613160100_Update19061301', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618155139_Update19061801')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190618155139_Update19061801', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190626151935_Update19062601')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190626151935_Update19062601', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190626161633_Update19062602')
BEGIN
    ALTER TABLE [ControlPlans] DROP CONSTRAINT [FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190626161633_Update19062602')
BEGIN
    DROP INDEX [IX_ControlPlans_ChemicalCompositionInLadleCode] ON [ControlPlans];
    DECLARE @var74 sysname;
    SELECT @var74 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ControlPlans]') AND [c].[name] = N'ChemicalCompositionInLadleCode');
    IF @var74 IS NOT NULL EXEC(N'ALTER TABLE [ControlPlans] DROP CONSTRAINT [' + @var74 + '];');
    ALTER TABLE [ControlPlans] ALTER COLUMN [ChemicalCompositionInLadleCode] nvarchar(20) NOT NULL;
    CREATE INDEX [IX_ControlPlans_ChemicalCompositionInLadleCode] ON [ControlPlans] ([ChemicalCompositionInLadleCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190626161633_Update19062602')
BEGIN
    ALTER TABLE [ControlPlans] ADD CONSTRAINT [FK_ControlPlans_ChemicalCompositionsInLadles_ChemicalCompositionInLadleCode] FOREIGN KEY ([ChemicalCompositionInLadleCode]) REFERENCES [ChemicalCompositionsInLadles] ([Code]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190626161633_Update19062602')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190626161633_Update19062602', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190627151809_Update19062701')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190627151809_Update19062701', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190629060931_Update19062901')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190629060931_Update19062901', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191014164512_Update19101401')
BEGIN
    CREATE TABLE [TestLogs] (
        [Id] int NOT NULL IDENTITY,
        [TestCode] nvarchar(max) NULL,
        [Type] nvarchar(max) NULL,
        [Time] datetime2 NOT NULL,
        CONSTRAINT [PK_TestLogs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191014164512_Update19101401')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191014164512_Update19101401', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191023164609_Update19102301')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191023164609_Update19102301', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191023165643_Update19102302')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191023165643_Update19102302', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191023170005_Update19102303')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191023170005_Update19102303', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191024150520_Update19102401')
BEGIN
    CREATE TABLE [Notifications] (
        [Id] int NOT NULL IDENTITY,
        [Source] nvarchar(max) NULL,
        [Code] nvarchar(max) NULL,
        [Type] nvarchar(max) NULL,
        [Time] datetime2 NOT NULL,
        CONSTRAINT [PK_Notifications] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191024150520_Update19102401')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191024150520_Update19102401', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191211150113_Update19121101')
BEGIN
    ALTER TABLE [Notifications] ADD [Application] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191211150113_Update19121101')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191211150113_Update19121101', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200123151701_Update20012301')
BEGIN
    ALTER TABLE [TestChemicalCompositions] ADD [IsPassed] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200123151701_Update20012301')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200123151701_Update20012301', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200124162354_Update20012401')
BEGIN
    ALTER TABLE [Kanbans] ADD [IsPassed] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200124162354_Update20012401')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200124162354_Update20012401', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200209170333_Update20021001')
BEGIN
    ALTER TABLE [PourStandards] ADD [ChillMax] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200209170333_Update20021001')
BEGIN
    ALTER TABLE [PourStandards] ADD [Magnesium] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200209170333_Update20021001')
BEGIN
    ALTER TABLE [Kanbans] ADD [Copper] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200209170333_Update20021001')
BEGIN
    ALTER TABLE [Kanbans] ADD [Inoculant] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200209170333_Update20021001')
BEGIN
    ALTER TABLE [Kanbans] ADD [Magnesium] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200209170333_Update20021001')
BEGIN
    ALTER TABLE [Kanbans] ADD [Tin] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200209170333_Update20021001')
BEGIN
    ALTER TABLE [Kanbans] ADD [WireInoculant] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200209170333_Update20021001')
BEGIN
    ALTER TABLE [Kanbans] ADD [WireMagnesium] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200209170333_Update20021001')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200209170333_Update20021001', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212150411_UpdatePourStd')
BEGIN
    ALTER TABLE [PourStandards] ADD [CuTol] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212150411_UpdatePourStd')
BEGIN
    ALTER TABLE [PourStandards] ADD [InoculantTol] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212150411_UpdatePourStd')
BEGIN
    ALTER TABLE [PourStandards] ADD [MagnesiumTol] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212150411_UpdatePourStd')
BEGIN
    ALTER TABLE [PourStandards] ADD [SnTol] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212150411_UpdatePourStd')
BEGIN
    ALTER TABLE [PourStandards] ADD [WiredInocTol] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212150411_UpdatePourStd')
BEGIN
    ALTER TABLE [PourStandards] ADD [WiredMgTol] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212150411_UpdatePourStd')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200212150411_UpdatePourStd', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212155453_UpdatePourStd1')
BEGIN
    ALTER TABLE [PourStandards] ADD [FeddTempTol] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212155453_UpdatePourStd1')
BEGIN
    ALTER TABLE [PourStandards] ADD [FeedTemp] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212155453_UpdatePourStd1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200212155453_UpdatePourStd1', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212161552_UpdateKanbanModel')
BEGIN
    ALTER TABLE [Kanbans] ADD [Chill] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212161552_UpdateKanbanModel')
BEGIN
    ALTER TABLE [Kanbans] ADD [FeedTemp] real NOT NULL DEFAULT CAST(0 AS real);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200212161552_UpdateKanbanModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200212161552_UpdateKanbanModel', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200213160029_UpdateKanban01')
BEGIN
    ALTER TABLE [Kanbans] ADD [MatValidation_IsOk_Chill] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200213160029_UpdateKanban01')
BEGIN
    ALTER TABLE [Kanbans] ADD [MatValidation_IsOk_Copper] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200213160029_UpdateKanban01')
BEGIN
    ALTER TABLE [Kanbans] ADD [MatValidation_IsOk_FeedTemp] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200213160029_UpdateKanban01')
BEGIN
    ALTER TABLE [Kanbans] ADD [MatValidation_IsOk_Inoculant] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200213160029_UpdateKanban01')
BEGIN
    ALTER TABLE [Kanbans] ADD [MatValidation_IsOk_Magnesium] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200213160029_UpdateKanban01')
BEGIN
    ALTER TABLE [Kanbans] ADD [MatValidation_IsOk_Tin] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200213160029_UpdateKanban01')
BEGIN
    ALTER TABLE [Kanbans] ADD [MatValidation_IsOk_WireInoculant] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200213160029_UpdateKanban01')
BEGIN
    ALTER TABLE [Kanbans] ADD [MatValidation_IsOk_WireMagnesium] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200213160029_UpdateKanban01')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200213160029_UpdateKanban01', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var75 sysname;
    SELECT @var75 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'WiredMgTol');
    IF @var75 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var75 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [WiredMgTol] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var76 sysname;
    SELECT @var76 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'WiredMg');
    IF @var76 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var76 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [WiredMg] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var77 sysname;
    SELECT @var77 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'WiredInocTol');
    IF @var77 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var77 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [WiredInocTol] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var78 sysname;
    SELECT @var78 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'WiredInoc');
    IF @var78 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var78 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [WiredInoc] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var79 sysname;
    SELECT @var79 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'SnTol');
    IF @var79 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var79 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [SnTol] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var80 sysname;
    SELECT @var80 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'Sn');
    IF @var80 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var80 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [Sn] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var81 sysname;
    SELECT @var81 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'MagnesiumTol');
    IF @var81 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var81 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [MagnesiumTol] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var82 sysname;
    SELECT @var82 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'Magnesium');
    IF @var82 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var82 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [Magnesium] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var83 sysname;
    SELECT @var83 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'InoculantTol');
    IF @var83 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var83 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [InoculantTol] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var84 sysname;
    SELECT @var84 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'Inoculant');
    IF @var84 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var84 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [Inoculant] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var85 sysname;
    SELECT @var85 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'FeedTemp');
    IF @var85 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var85 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [FeedTemp] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var86 sysname;
    SELECT @var86 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'FeddTempTol');
    IF @var86 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var86 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [FeddTempTol] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var87 sysname;
    SELECT @var87 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'CuTol');
    IF @var87 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var87 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [CuTol] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var88 sysname;
    SELECT @var88 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'Cu');
    IF @var88 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var88 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [Cu] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    DECLARE @var89 sysname;
    SELECT @var89 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PourStandards]') AND [c].[name] = N'ChillMax');
    IF @var89 IS NOT NULL EXEC(N'ALTER TABLE [PourStandards] DROP CONSTRAINT [' + @var89 + '];');
    ALTER TABLE [PourStandards] ALTER COLUMN [ChillMax] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200215163441_UpdatePourStd01')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200215163441_UpdatePourStd01', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218055330_UpdateKanbanModel01')
BEGIN
    DECLARE @var90 sysname;
    SELECT @var90 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'WireMagnesium');
    IF @var90 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var90 + '];');
    ALTER TABLE [Kanbans] ALTER COLUMN [WireMagnesium] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218055330_UpdateKanbanModel01')
BEGIN
    DECLARE @var91 sysname;
    SELECT @var91 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'WireInoculant');
    IF @var91 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var91 + '];');
    ALTER TABLE [Kanbans] ALTER COLUMN [WireInoculant] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218055330_UpdateKanbanModel01')
BEGIN
    DECLARE @var92 sysname;
    SELECT @var92 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'Tin');
    IF @var92 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var92 + '];');
    ALTER TABLE [Kanbans] ALTER COLUMN [Tin] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218055330_UpdateKanbanModel01')
BEGIN
    DECLARE @var93 sysname;
    SELECT @var93 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'Magnesium');
    IF @var93 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var93 + '];');
    ALTER TABLE [Kanbans] ALTER COLUMN [Magnesium] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218055330_UpdateKanbanModel01')
BEGIN
    DECLARE @var94 sysname;
    SELECT @var94 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'Inoculant');
    IF @var94 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var94 + '];');
    ALTER TABLE [Kanbans] ALTER COLUMN [Inoculant] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218055330_UpdateKanbanModel01')
BEGIN
    DECLARE @var95 sysname;
    SELECT @var95 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'FeedTemp');
    IF @var95 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var95 + '];');
    ALTER TABLE [Kanbans] ALTER COLUMN [FeedTemp] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218055330_UpdateKanbanModel01')
BEGIN
    DECLARE @var96 sysname;
    SELECT @var96 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'Copper');
    IF @var96 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var96 + '];');
    ALTER TABLE [Kanbans] ALTER COLUMN [Copper] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218055330_UpdateKanbanModel01')
BEGIN
    DECLARE @var97 sysname;
    SELECT @var97 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Kanbans]') AND [c].[name] = N'Chill');
    IF @var97 IS NOT NULL EXEC(N'ALTER TABLE [Kanbans] DROP CONSTRAINT [' + @var97 + '];');
    ALTER TABLE [Kanbans] ALTER COLUMN [Chill] real NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200218055330_UpdateKanbanModel01')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200218055330_UpdateKanbanModel01', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220171053_AddPouringModel01')
BEGIN
    CREATE TABLE [Pouring] (
        [Code] nvarchar(20) NOT NULL,
        [Time] datetime2 NOT NULL,
        [Line] int NOT NULL,
        [LineCode] nvarchar(max) NULL,
        [FirstTemp] int NULL,
        [LastTemp] int NULL,
        [NumberOfMold] int NULL,
        [KanbanCode] nvarchar(20) NOT NULL,
        CONSTRAINT [PK_Pouring] PRIMARY KEY ([Code]),
        CONSTRAINT [FK_Pouring_Kanbans_KanbanCode] FOREIGN KEY ([KanbanCode]) REFERENCES [Kanbans] ([Code]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220171053_AddPouringModel01')
BEGIN
    CREATE INDEX [IX_Pouring_KanbanCode] ON [Pouring] ([KanbanCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220171053_AddPouringModel01')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200220171053_AddPouringModel01', N'2.1.14-servicing-32113');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220172040_AddMoldingModel01')
BEGIN
    EXEC sp_rename N'[Pouring].[NumberOfMold]', N'NoOfPouredMold', N'COLUMN';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220172040_AddMoldingModel01')
BEGIN
    ALTER TABLE [Pouring] ADD [MoldingCode] nvarchar(20) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220172040_AddMoldingModel01')
BEGIN
    CREATE TABLE [Molding] (
        [Code] nvarchar(20) NOT NULL,
        [Time] datetime2 NOT NULL,
        [Line] int NOT NULL,
        [LineCode] nvarchar(max) NULL,
        [ToolingCode] nvarchar(20) NULL,
        [NoOfMold] int NOT NULL,
        [Compressibility] real NULL,
        CONSTRAINT [PK_Molding] PRIMARY KEY ([Code]),
        CONSTRAINT [FK_Molding_Toolings_ToolingCode] FOREIGN KEY ([ToolingCode]) REFERENCES [Toolings] ([Code]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220172040_AddMoldingModel01')
BEGIN
    CREATE INDEX [IX_Pouring_MoldingCode] ON [Pouring] ([MoldingCode]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220172040_AddMoldingModel01')
BEGIN
    CREATE UNIQUE INDEX [IX_Molding_ToolingCode] ON [Molding] ([ToolingCode]) WHERE [ToolingCode] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220172040_AddMoldingModel01')
BEGIN
    ALTER TABLE [Pouring] ADD CONSTRAINT [FK_Pouring_Molding_MoldingCode] FOREIGN KEY ([MoldingCode]) REFERENCES [Molding] ([Code]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200220172040_AddMoldingModel01')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200220172040_AddMoldingModel01', N'2.1.14-servicing-32113');
END;

GO

