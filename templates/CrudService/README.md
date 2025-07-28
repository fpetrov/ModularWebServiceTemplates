# CrudService Clean Solution

![.NET](https://img.shields.io/badge/.NET-8%2F9-blueviolet?logo=dotnet&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-green)

## О проекте
CrudService Clean Solution — это шаблон чистого CRUD API сервиса на ASP.NET Core, реализующий принципы **Clean Architecture** и **DDD**. Шаблон позволяет быстро стартовать новое микросервис‑приложение с минимальной настройкой.

## Основные возможности
- Чистая архитектура слоёв (Domain → Application → Infrastructure → Presentation).
- Поддержка **PostgreSQL** (подключается через строку подключения `db`).
- Генерация OpenAPI спецификации и **Swagger UI** (*по умолчанию включено*, можно отключить параметром `--swagger false`).
- Выбор целевой версии платформы: **.NET 9** (по умолчанию) или **.NET 8**.
- Подключён **Entity Framework Core**.
- Готовая интеграция с **Docker** и **docker‑compose** для локального запуска.

## Быстрый старт

### Создание нового решения

```bash
dotnet new crud \
  -n MyAwesomeService \
  --db "Host=localhost;Port=5432;Database=mydb;Username=postgres;Password=pass;" \
  --swagger true \
  -f net9.0
```

После выполнения команды будет создана папка `MyAwesomeService` со следующей структурой:

```
MyAwesomeService/
 ├─ src/
 │  ├─ MyAwesomeService.Domain/
 │  ├─ MyAwesomeService.Contracts/
 │  ├─ MyAwesomeService.Infrastructure/
 │  ├─ MyAwesomeService.UnitTests/
 │  └─ MyAwesomeService.Api/
```

### Запуск приложения локально

```bash
cd MyAwesomeService
dotnet build
dotnet ef database update --project src/MyAwesomeService.Infrastructure
dotnet run --project src/MyAwesomeService.Api
```

По умолчанию Swagger UI будет доступен по адресу http://localhost:5000/swagger.

## Параметры шаблона

| Параметр | Тип | Значение по умолчанию | Описание |
|----------|-----|-----------------------|----------|
| `--db` | text | `Server=.;Database=MyDb;` | Строка подключения к PostgreSQL. |
| `--swagger` | bool | `true` | Подключить OpenAPI middleware и SwaggerUI. |
| `--Framework` | choice | `net9.0` | Целевая версия .NET (`net9.0` или `net8.0`). |

## Тесты

```bash
dotnet test
```