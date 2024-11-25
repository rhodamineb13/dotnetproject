migrate:
	dotnet ef migrations add $(name) -o Data/Migrations