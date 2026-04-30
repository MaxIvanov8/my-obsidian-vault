Nuget-пакеты
1. Microsoft.Data.Sqlite
2. Microsoft.EntityFrameworkCore.Sqlite.Core

```
public class AbstractBaseClass
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; protected set; }
}
```
```
public class ApplicationContext : DbContext
{
    private readonly string _connection;
    public DbSet<Class1> PriorsDbSet => Set<Class1>();
    public DbSet<Class2> RegionsDbSet => Set<Class2>();

    public ApplicationContext(string con)
    {
        _connection = con;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={_connection};Pooling=False");
}
```
```
 ApplicationContext _dbContext = new ApplicationContext(basePath);
```

Чтобы при публикации не появлялась библиотека e_sqlite3.dll, нужно в файл проекта добавить 
```
<IncludeAllContentForSelfExtract>true</IncludeAllContentForSelfExtract>
```
