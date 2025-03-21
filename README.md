# IPFS Person Storage

## 📌 Описание проекта
Этот проект позволяет сохранять объекты `Person` в IPFS и загружать их обратно по их CID (Content Identifier).
Он использует IPFS HTTP API, сериализует объекты в JSON и предоставляет консольный интерфейс для взаимодействия.

## 🔧 Требования

- .NET 6+
- Запущенный IPFS-демон (`ipfs daemon`)
- Доступ к IPFS API (по умолчанию `http://127.0.0.1:5001/api/v0/`)

## 🚀 Инструкция по запуску

### 1️⃣ Установите IPFS

Если IPFS ещё не установлен, скачайте и установите его, следуя инструкции:
🔗 [Установка IPFS](https://docs.ipfs.tech/install/)

Запустите IPFS-демон:
```sh
ipfs daemon
```

### 2️⃣ Клонируйте репозиторий

```sh
git clone https://github.com/username/ipfs-person-storage.git
cd ipfs-person-storage
```

### 3️⃣ Установите зависимости

```sh
dotnet restore
```

### 4️⃣ Запустите проект

```sh
dotnet run
```

## 📌 Использование

После запуска программа предложит ввести команду:

| Команда          | Описание                                  |
|-----------------|-----------------------------------------|
| `add`          | Добавить нового пользователя в IPFS     |
| `get [CID]`    | Получить пользователя по CID           |
| `exit`         | Выйти из программы                      |

### 🖥 Пример работы

```sh
> add
Введите имя: Хабиб
Введите возраст: 25
Пользователь сохранён в IPFS. CID: Qm123...

> get Qm123...
Имя: Хабиб, Возраст: 25

> exit
```

## 🔍 Реализация методов

### Сохранение объекта Person в IPFS
### Метод SavePerson выполняет следующие шаги:

1. Сериализует объект Person в JSON.

2. Добавляет сериализованный JSON в IPFS с помощью метода 
AddTextAsync из библиотеки Ipfs.Http.Client

3. Возвращает уникальный CID файла.

### Получение объекта Person из IPFS
### Метод GetPerson извлекает объект Person из IPFS по CID. Он выполняет следующие шаги:

1. Отправляет POST-запрос на команду cat, чтобы получить файл по CID.

2. Десериализует полученный JSON в объект Person.

3. Если произошла ошибка при запросе или десериализации, выбрасывает исключение.
