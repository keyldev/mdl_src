### Задача

Разработать веб-сервис, позволяющий формировать и отправлять письма адресатам и логировать результат в БД.

1. Сервис должен принимать POST-запрос по URL: `/api/mails/`. Тело запроса в формате JSON:
```json
{
  "subject": "string",
  "body": "string",
  "recipients": [
    "string@email.site", "string2@email.site"
  ]
}
```
2. Метод обработки должен: <br>
* Сформировать email сообщение и отправить его.<br>
* Добавить запись в БД. В записи указать все поля из сообщения, дату создания, результат отправки (OK, Failed) и поле FailedMessage, отвечающее за ошибку отсылки уведомления.

3. Веб-сервис должен отвечать на GET запросы по URL `/api/mails/`. Результатом должен быть список всех отправленных сообщений из БД.

4. Закомментировать все `public` свойства и методы согласно [XML Documentation Comments](https://learn.microsoft.com/ru-RU/dotnet/csharp/language-reference/xmldoc/?redirectedfrom=MSDN)

5. Конфигурацию SMTP вынести в файл конфигурации.

6. Разработку выполнить на C# .NET (MVS 2019-2022, Rider, VS Code), использовать ASP.NET Core последней версии.

7. В качестве СУБД любая реляционная (MySQL, PgSql, MS SQL etc)

8. В качестве ORM - Entity или Dapper. Для Entity требуется наличие миграции.

9. Библиотека отправки сообщений на свое усмотрение.

## Результат разработки
Запуск приложения происходит согласно настройкам указанным в файле [launchSettings.json](/src/MailService/Properties/launchSettings.json), например, `https` профиль запускается на 7063 или 5194 портах:
```json
"https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7063;http://localhost:5194",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
```
Проверка контроллера производилась при помощи инструмента Swagger. Настройка строки подключения к базе данных производится в файле [appsettings.json](/src/MailService/appsettings.json)
```json
"ConnectionStrings": {
    "DefaultString": "server=localhost;user=root;password=toor;database=mailsdb"
  }
```
Настройка подключения к SMTP-серверу находится в том же файле [appsettings.json](/src/MailService/appsettings.json)
```json
"MailConfig": {
    "SmtpServer": "smtp.server.address",
    "SmtpPort": 25,
    "Email": "email@email.com",
    "Password": "password"
  }
```

Результат работы GET-запроса `api/mails/`
```json
  {
    "id": "08dc169d-90b7-4269-87b2-9833bfc6f175",
    "subject": "ASP NET Core Works?",
    "body": "Yes",
    "result": "OK",
    "failedMessage": "",
    "createdAt": "2024-01-16T14:15:16.873548",
    "recipients": [
      {
        "recipient": "mail1@email.com"
      },
      {
        "recipient": "mail2@email.com"
      }
    ]
  }
```
## Список используемых технологий

* ASP.NET Core
* .NET 7
* Entity Framework, Entity Framework Tools (с миграциями)
* СУБД: MySQL
* Dependency Injection
* MailKit в качестве библиотеки для отправки Email

## Вопросы касаемо ТЗ

1. Согласно ТЗ, необходимо реализовать 2 эндпоинта по одинаковым адресам `api/mails/`, почему бы не придать контекста добавив, к примеру, для POST-запроса `api/mails/send`, а для GET-запроса `api/mails/get`?

<br>
<h3 align="center">developed by keyl (c) 2024</h1>
