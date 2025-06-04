# MiniCRMApp

Мини CRM система для учета клиентов и их заказов.

## Возможности
- Управление клиентами (добавление, редактирование, удаление)
- Управление заказами клиента
- Генерация отчетов в формате PDF через DevExpress
- Удобный интерфейс на основе DevExpress GridControl

## Технологии
- C# WinForms
- .NET Framework 4.7.2
- Entity Framework 6
- DevExpress UI Components
- SQL Server

## Скриншоты

![Скриншот клиентов](screenshots/clients.png)
![Скриншот заказов](screenshots/orders.png)

## Как запустить
1. Открыть в Visual Studio 2022
2. Создать БД `MiniCRM` и запустить SQL скрипты (таблицы `Customers`, `Orders`)
3. Установить NuGet-пакеты:
   - EntityFramework
4. Настроить строку подключения в `App.config`
5. Запустить приложение
