# CrudService Solution

![.NET](https://img.shields.io/badge/.NET-8%2F9-blueviolet?logo=dotnet&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-green)

## О проекте
CrudService Solution — это шаблон простого CRUD API сервиса.

## Основная информация
- Используется **PostgreSQL**.
- Генерация OpenAPI спецификации и **Swagger UI** (*по умолчанию включено*, можно отключить параметром `--swagger false`).
- Выбор целевой версии платформы: **.NET 9** (по умолчанию) или **.NET 8**.
- Готовая интеграция с **Docker** и **docker‑compose** для локального запуска.

## Быстрый старт

### Создание нового решения

```bash
dotnet new crud \
  -n MyAwesomeService \
  --swagger true \
  -f net9.0
```

После выполнения команды будет создана папка `MyAwesomeService` со следующей структурой:

```
MyAwesomeService/
 └─ src/
    ├─ MyAwesomeService.Domain/
    ├─ MyAwesomeService.Contracts/
    ├─ MyAwesomeService.Infrastructure/
    ├─ MyAwesomeService.UnitTests/
    └─ MyAwesomeService.WebHost/
```

### Запуск приложения локально

```bash
cd MyAwesomeService
dotnet build
dotnet ef database update --project src/MyAwesomeService.Infrastructure
dotnet run --project src/MyAwesomeService.Api
```

По умолчанию Swagger UI будет доступен по адресу http://localhost:5011/swagger.

## Параметры шаблона

| Параметр | Тип | Значение по умолчанию | Описание |
|----------|-----|-----------------------|----------|
| `--swagger` | bool | `true` | Подключить OpenAPI middleware и SwaggerUI. |
| `--Framework` | choice | `net9.0` | Целевая версия .NET (`net9.0` или `net8.0`). |

## Тесты

```bash
dotnet test
```