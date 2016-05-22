# Test site

### How to set up work environment
1. Install Visual Studio 2013 or higher
2. Install SQL Server Management Studio 2012 or higher
3. Open project and generate initial migration for database from NuGet console (`Add-Migration Initial`).
4. Roll out migration to database from NuGet console (`Update-Database`)
5. Run project.
6. ...
7. PROFIT!

### How to delete database
1. Run SQL Server Management Studio
2. Connect to `(LocalDb)\v11.0`
3. Open `Databases` folder
4. Find database with `aspnet-` prefix
5. Delete.

