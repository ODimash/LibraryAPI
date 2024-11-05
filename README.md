# LibraryAPI

LibraryAPI — это RESTful API для управления электронной библиотекой. Построено на ASP.NET Core, позволяет пользователям создавать, читать, обновлять и удалять книги в библиотеке.

## Оглавление

- [Функциональные возможности](#функциональные-возможности)
- [Начало работы](#начало-работы)
  - [Предварительные требования](#предварительные-требования)
  - [Установка](#установка)
  - [Запуск приложения](#запуск-приложения)
- [API Эндпоинты](#api-эндпоинты)
  - [GET /api/books](#get-apibooks)
  - [GET /api/books/{id}](#get-apibooksid)
  - [POST /api/books](#post-apibooks)
  - [PUT /api/books/{id}](#put-apibooksid)
  - [DELETE /api/books/{id}](#delete-apibooksid)
- [Используемые технологии](#используемые-технологии)
- [Внесение вклада](#внесение-вклада)
- [Лицензия](#лицензия)

## Функциональные возможности

- Добавление новых книг в библиотеку
- Получение списка всех книг или информации о конкретной книге по ID
- Обновление информации о существующих книгах
- Удаление книг из библиотеки

## Начало работы

### Предварительные требования

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads) или [SQL Server LocalDB](https://docs.microsoft.com/ru-ru/sql/database-engine/configure-windows/sql-server-express-localdb)

### Установка

1. Клонируйте репозиторий:

    git clone https://github.com/yourusername/LibraryAPI.git
    cd LibraryAPI

2. Восстановите зависимости:

    dotnet restore

3. Обновите базу данных:

    dotnet ef database update

### Запуск приложения

Запустите приложение:

dotnet run

API будет доступно по адресу `http://localhost:5000`.

## API Эндпоинты

### GET /api/books

Получение списка всех книг в библиотеке.

#### Ответ

[
    {
        "id": 1,
        "title": "Пример книги",
        "author": "Иван Иванов",
        "year": 2024
    },
    ...
]

### GET /api/books/{id}

Получение информации о конкретной книге по ID.

#### Ответ

{
    "id": 1,
    "title": "Пример книги",
    "author": "Иван Иванов",
    "year": 2024
}

### POST /api/books

Добавление новой книги в библиотеку.

#### Запрос

{
    "title": "Новая книга",
    "author": "Петр Петров",
    "year": 2024
}

#### Ответ

{
    "id": 2,
    "title": "Новая книга",
    "author": "Петр Петров",
    "year": 2024
}

### PUT /api/books/{id}

Обновление информации о существующей книге.

#### Запрос

{
    "id": 1,
    "title": "Обновленная книга",
    "author": "Иван Иванов",
    "year": 2025
}

### DELETE /api/books/{id}

Удаление книги из библиотеки.

## Используемые технологии

- ASP.NET Core
- Entity Framework Core
- SQL Server

## Внесение вклада

Внесение вклада приветствуется! Пожалуйста, форкните репозиторий и отправьте pull request с вашими изменениями. Для значительных изменений откройте issue для обсуждения того, что вы хотели бы изменить.

1. Форкните проект
2. Создайте ветку для своей функции (`git checkout -b feature/AmazingFeature`)
3. Закоммитьте свои изменения (`git commit -m 'Add some AmazingFeature'`)
4. Запушьте в ветку (`git push origin feature/AmazingFeature`)
5. Откройте Pull Request

## Лицензия

Этот проект лицензируется по лицензии MIT. См. файл [LICENSE](LICENSE) для подробностей.
