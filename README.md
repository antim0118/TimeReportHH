[Собранный проект под Windows](https://github.com/antim0118/TimeReportHH/releases/download/Windows/TimeReportHH.zip)

## Пользователи
#### GET /user/get/ - Получить список пользователей
#### GET /user/get/{id} - Получить пользователя по Id

#### POST /user/add/ - Добавить пользователя
Передаётся с JSON в теле запроса (Body -> raw -> JSON):
```json
{
    "email": "mail@mail.ru",
    "firstname": "Имя",
    "secondname": "Фамилия",
    "patronymic": "Отчество"
}
```

#### POST /user/update/ - Обновить пользователя по Id
Передаётся с JSON в теле запроса (Body -> raw -> JSON):
```json
{
	"id": 5,
    "email": "mail@mail.ru",
    "firstname": "Имя",
    "secondname": "Фамилия",
    "patronymic": "Отчество"
}
```

#### POST /user/delete/{id} - Удалить пользователя по Id


## Отчёты

#### GET /report/get/{id}/{date} - Получить список отчётов пользователя по Id за указанный месяц.
Пример: http://localhost:5295/report/get/5/2024-05

#### POST /report/add/{id} - Добавить отчет пользователя (id)
Передаётся с JSON в теле запроса (Body -> raw -> JSON):
```json
{
	"note": "Примечание",
	"hours": 10,
	"date": "2024-01-01"
}
```

#### POST /report/update/ - Обновить отчет по Id
Передаётся с JSON в теле запроса (Body -> raw -> JSON):
```json
{
	"id": 5,
	"note": "Примечание",
	"hours": 10,
	"date": "2024-01-01"
}
```

#### POST /report/delete/{id} - Удалить отчет по Id
