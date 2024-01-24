# Guide за работа с проекта.

## Това е web проект за библиотечна система. Той улеснява работата с книги и потребители чрез база от данни. Могат да се манипулират данни за книги, потребители и връзките между тях.


## Инсталация и конфигурация

### 1. Сваляне на проекта.
### 2. Създаване на база от данни в SQL с име "LibrarySystem".
### 3. Осъществяване на връзка между проекта и базата от данни чрез Server Explorer инструмента във Visual Studio.
### 4. Копиране на connection string-а от полето Properties.
### 5. Отваряне на файла appsettings.json чрез Solution Explorer-a.
### 6. Поставяне на connection string-a след кода: "Default": 
### !  В края на кавичките след connection string-а да се добави следния код: MultipleActiveResultSets=true;
### Примерен код:

{
  "ConnectionStrings": {
    "Default": "Data Source=DESKTOP-5HSFG33;Initial Catalog=LibrarySystem;Integrated Security=True;MultipleActiveResultSets=true;"
  },

  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

### 8. Актуализиране на базата от данни чрез командата Update-Database в Package Мanager конзолата.


## Функционалности

### 1. Регистриране на записи за книги, потребители и връзките между тях.
### 2. Изтриване на записи за книги, потребители и връзките между тях.
###  ! Изтриването на книги става чрез ID на книгата.
###  ! Изтриването на потребители и връзки става чрез ID на потребителя.
###  ! Номерацията на ID-тата не се променя.
### 3. Изчистване на записи.
###  ! Изтрива всички записи за съответния тип данни, като рестартира номерацията на ID-тата.
### 4. Вземане на книги от потребител. Създаване на връзки.
###  ! Един потребител може да вземе много книги, но една книга може да се вземе само от един потребител.
###  ! Не може да се взимат неналични книги.

### Цялата информация за записите е представена таблично.
