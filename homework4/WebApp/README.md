Add migration for database
Run from command line inside WebApp folder
~~~
dotnet ef database drop -f
rm -rf ./Data/Migrations/
dotnet ef migrations add InitialDbCreation
dotnet ef database update

~~~

~~~
dotnet aspnet-codegenerator controller -name StudentsController -actions -m Student -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name HomeworksController -actions -m Homework -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name GradesController -actions -m Grade -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name CesarsController -actions -m Cesar -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
~~~

