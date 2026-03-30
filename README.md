Приложение для управления задачами на .NET MAUI с использованием паттерна MVVM и синхронизацией с облачным API.

## Описание

Приложение позволяет:

* вести список задач,
* просматривать детали задачи,
* редактировать и удалять задачи,
* сохранять данные локально в SQLite,
* экспортировать и импортировать задачи в CSV,
* синхронизировать задачи с облачным API.

---

## Основные возможности

### КТ-3 (MVVM)

* Модели данных с Id, Title, Description, DueDate, IsCompleted, Priority
* ViewModel с INotifyPropertyChanged и командами для действий пользователя
* Страница списка задач с CollectionView
* Страница деталей задачи с редактированием и кнопкой "Назад"
* Навигация между страницами через Shell

### КТ-4 (Локальное хранилище)

* Интерфейс ITaskRepository и реализация TaskRepository с SQLite
* Сохранение задач между запусками приложения
* CRUD операции (создание, чтение, обновление, удаление)
* Экспорт/импорт задач через CSV
* Обработка ошибок при работе с данными

### КТ-5 (Облачная синхронизация)

* API клиент ITaskApiService и TaskApiService для работы с JSONPlaceholder
* DTO классы для передачи данных
* SyncTaskRepository для объединения локального и облачного хранилища
* Синхронизация задач с приоритетом облака
* Обработка сетевых ошибок и retry логика

---

## Структура проекта

```
TaskManagerApp/
│ Models/
│   TaskItem.cs
│ ViewModels/
│   BaseViewModel.cs
│   TaskListViewModel.cs
│   TaskDetailViewModel.cs
│ Pages/
│   TaskListPage.xaml
│   TaskListPage.xaml.cs
│   TaskDetailPage.xaml
│   TaskDetailPage.xaml.cs
│ Services/
│   ITaskRepository.cs
│   TaskRepository.cs
│   FileService.cs
│   SyncTaskRepository.cs
│   Api/
│     ITaskApiService.cs
│     TaskApiService.cs
│     TaskDto.cs
│ AppShell.xaml
│ AppShell.xaml.cs
│ App.xaml
│ App.xaml.cs
```

---

## Технологии

* .NET 10
* .NET MAUI
* MVVM (INotifyPropertyChanged, ICommand)
* SQLite
* HttpClient + JSON
* Shell для навигации

---

## Как запустить

1. Открыть проект в Visual Studio
2. Убедиться, что выбран .NET 10
3. Установить пакет `sqlite-net-pcl` через NuGet
4. Собрать проект
5. Выбрать платформу (Windows или Android)
6. Запустить приложение

---

<img width="1280" height="685" alt="изображение" src="https://github.com/user-attachments/assets/dd83be4d-dd7f-4bff-803d-1a1ff6699b13" />

