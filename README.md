# CarDealer Projesi ( NET 10 Onion Architecture - PostgreSQL)
Bu projede, Onion Architecture mimarisi kullanılarak; CQRS, Unit of Work, Generic Repository ve Result Pattern içeren modern bir CarDealer (Araba Galerisi) Web API'si geliştirilecektir. Veritabanı olarak PostgreSQL kullanılacaktır.

## Proje Oluşturma ve Referanslar
```bash
# 1. Ana Klasörü Oluştur
mkdir CarDealer
cd CarDealer

# 2. Solution Dosyasını Oluştur
dotnet new sln -n CarDealer

# 3. Katmanları (Projeleri) Oluştur (.NET 10 Hedefli)
dotnet new classlib -n CarDealer.Domain -f net10.0
dotnet new classlib -n CarDealer.Application -f net10.0
dotnet new classlib -n CarDealer.Persistence -f net10.0
dotnet new classlib -n CarDealer.Infrastructure -f net10.0
dotnet new webapi -n CarDealer.WebAPI -f net10.0

# 4. Projeleri Solution'a Ekle
dotnet sln add CarDealer.Domain/CarDealer.Domain.csproj
dotnet sln add CarDealer.Application/CarDealer.Application.csproj
dotnet sln add CarDealer.Persistence/CarDealer.Persistence.csproj
dotnet sln add CarDealer.Infrastructure/CarDealer.Infrastructure.csproj
dotnet sln add CarDealer.WebAPI/CarDealer.WebAPI.csproj

# 5. Referans Bağlantılarını Kurma (Onion Bağımlılıkları)
# Application -> Domain
dotnet add CarDealer.Application/CarDealer.Application.csproj reference CarDealer.Domain/CarDealer.Domain.csproj

# Persistence -> Application & Domain
dotnet add CarDealer.Persistence/CarDealer.Persistence.csproj reference CarDealer.Application/CarDealer.Application.csproj
dotnet add CarDealer.Persistence/CarDealer.Persistence.csproj reference CarDealer.Domain/CarDealer.Domain.csproj

# Infrastructure -> Application & Domain
dotnet add CarDealer.Infrastructure/CarDealer.Infrastructure.csproj reference CarDealer.Application/CarDealer.Application.csproj
dotnet add CarDealer.Infrastructure/CarDealer.Infrastructure.csproj reference CarDealer.Domain/CarDealer.Domain.csproj

# WebAPI -> Application, Persistence, Infrastructure
dotnet add CarDealer.WebAPI/CarDealer.WebAPI.csproj reference CarDealer.Application/CarDealer.Application.csproj
dotnet add CarDealer.WebAPI/CarDealer.WebAPI.csproj reference CarDealer.Persistence/CarDealer.Persistence.csproj
dotnet add CarDealer.WebAPI/CarDealer.WebAPI.csproj reference CarDealer.Infrastructure/CarDealer.Infrastructure.csproj
```

## Nuget Paketlerinin Yüklenmesi
```bash
# Application Katmanı Paketleri (CQRS, Mapper, Validation)
dotnet add CarDealer.Application package MediatR
dotnet add CarDealer.Application package AutoMapper
dotnet add CarDealer.Application package FluentValidation.DependencyInjectionExtensions

# Persistence Katmanı Paketleri (PostgreSQL & EF Core)
dotnet add CarDealer.Persistence package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add CarDealer.Persistence package Microsoft.EntityFrameworkCore.Tools

# WebAPI Katmanı Paketleri (EF Core Design - Migration için gerekli)
dotnet add CarDealer.WebAPI package Microsoft.EntityFrameworkCore.Design
```