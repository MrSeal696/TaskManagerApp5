# TaskManagerApp

Приложение для управления задачами, созданное на .NET MAUI с использованием паттерна MVVM.

## Описание

Приложение позволяет создавать, редактировать и удалять задачи, хранить их локально в базе SQLite, а также синхронизировать с облачным REST API.

### Основные возможности

* Просмотр списка задач
* Добавление, редактирование и удаление задач
* Изменение статуса выполнения задачи
* Детальная страница с информацией о задаче
* Локальное хранение через SQLite
* Экспорт и импорт задач в CSV файл
* Синхронизация с облачным API (JSONPlaceholder)
* Обработка сетевых ошибок и автоматический retry

## Структура проекта

* **Models** — модели данных (`TaskItem`)
* **ViewModels** — `BaseViewModel`, `TaskListViewModel`, `TaskDetailViewModel`
* **Pages** — `TaskListPage`, `TaskDetailPage`
* **Services** — `TaskRepository`, `SyncTaskRepository`, `FileService`
* **Services/Api** — `TaskApiService`, `ITaskApiService`, `TaskDto`
* **AppShell** — навигация между страницами

## Технологии

* .NET 10
* .NET MAUI
* XAML
* MVVM, INotifyPropertyChanged, ICommand
* SQLite (sqlite-net-pcl)
* HttpClient для REST API
* Dependency Injection

## Как запустить

1. Открыть проект в Visual Studio
2. Убедиться, что выбран .NET 10
3. Установить NuGet пакет `sqlite-net-pcl`
4. Нажать «Запуск»
5. Выбрать платформу (Windows или Android)


