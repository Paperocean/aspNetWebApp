# BlazorApp – Aplikacja do oceny filmów 

## Struktura projektu
```
BlazorApp1/
├── Components/
│   ├── Account/
│   │   └── Pages/
│   │       ├── Login.razor
│   │       └── Register.razor
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   ├── Pages/
│   │   ├── Counter.razor
│   │   ├── Home.razor
│   │   ├── MoviePages/
│   │   │   ├── Create.razor
│   │   │   ├── Delete.razor
│   │   │   ├── Details.razor
│   │   │   ├── Edit.razor
│   │   │   └── Index.razor
│   │   └── Auth.razor
│   ├── Routes.razor
│   ├── App.razor
│   ├── _Imports.razor
│   └── Movie.cs
├── Data/
│   ├── Migrations/
│   │   ├── 00000000000000_CreateIdentitySchema.cs
│   │   ├── 20250428143533_Init.cs
│   │   ├── 20250428152540_MovieMigration.cs
│   │   ├── 20250428162227_AddImageUrlToMovie.cs
│   │   ├── 20250429095648_NewFeaturesDB.cs
│   │   └── ApplicationDbContextModelSnapshot.cs
│   ├── ApplicationDbContext.cs
│   └── ApplicationUser.cs
├── Program.cs
├── appsettings.json
```

## Movie.cs – Model
- `Id` – identyfikator (int)
- `Title` – wymagane, max 100 znaków
- `Description` – opcjonalne, max 2000 znaków
- `RelaseDate` – data (domyślnie dziś)
- `Rate` – liczba z zakresu 0–10
- `ImageUrl` – URL obrazka
- `Genres` – tekst (CSV gatunków)

## Autoryzacja
Wszystkie widoki (Create, Details) wymagają uwierzytelnienia (`[Authorize]`).

## Create.razor
- **Routowanie**: `/movies/create`
- **Tytuł strony**: `Create`
### Formularz
- `EditForm` z walidacją (`DataAnnotationsValidator`, `ValidationSummary`)
- Pola:
  - `Title` – tekst
  - `Description` – tekst
  - `Release Date` – `InputDate`
  - `Rate` – `InputNumber`
  - `Genres` – checkboxy z listy 20 gatunków
  - `ImageUrl` – tekst z podglądem obrazka
### Logika
- `OnInitialized()` – resetuje dane
- `ToggleGenre()` – aktualizuje zaznaczenia
- `AddMovie()` – zapis do DB, redirect `/movies`
### Nawigacja
- Przycisk „Back to List" → `/movies`

## Details.razor
- **Routowanie**: `/movies/details?id={id}`
- **Tytuł strony**: `Details`
### Dane filmu
- Ładowanie z DB na podstawie `Id`
- Pola:
  - `Title`, `Description`, `ReleaseDate`, `Rate`
  - `Genres` – badge + surowa wartość CSV
  - `ImageUrl` – miniatura lub brak
### Nawigacja
- Link do edycji: `/movies/edit?id={movie.Id}`
- Link powrotny: `/movies`
### Ocena (Rate)
- Formularz z `InputNumber` (1–10)
- Nowa ocena uśredniana z poprzednią
- Zapis do DB i odświeżenie widoku
### Pomocnicze
- `GetGenresList()` – CSV → `List<string>`

---

# Konfiguracja publikowania programu na Azure

## Połączenie z Azure SQL Database

Aby poprawnie skonfigurować połączenie z bazą danych Azure SQL Database dla naszej aplikacji, należy wykonać następujące kroki:

### 1. Zmiana Connection String

W pliku `appsetting.json` należy zmienić domyślny Connection String (`DefaultConnection`) na string wygenerowany po połączeniu z Baza Danych SQL server.

Przykład Connection String:
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Data Source=blazorapp1dbserver2.database.windows.net;Initial Catalog=BlazorApp1_db;Persist Security Info=True;User ID={userID};Password={passwd};Trust Server Certificate=True",
    },
}
```

> **Ważne:** W powyższym stringu należy zastąpić `{userID}` oraz `{passwd}` rzeczywistymi danymi uwierzytelniającymi do bazy danych.

### 2. Konfiguracja Entity Framework przy publikacji

Podczas konfiguracji publikacji aplikacji należy włączyć opcję migracji dla platformy Entity Framework. Zapewni to automatyczne zastosowanie migracji bazy danych podczas wdrażania aplikacji. Należy tam umieścić string wygenerowany po połączeniu z Azure.

Przykład Azure String:

```
Server=tcp:blazorapp1dbserver2.database.windows.net,1433;Initial Catalog=BlazorApp1_db;User Id={userID};Password={passwd}"
```

> **Ważne:** W powyższym stringu należy zastąpić `{userID}` oraz `{passwd}` rzeczywistymi danymi uwierzytelniającymi do bazy danych.

## Podsumowanie

1. Zmień Connection String w `appsetting.json` na wygenerowany przez Baza Danych SQL
2. Uzupełnij dane uwierzytelniające (User Id i Password)
3. Włącz migracje Entity Framework w ustawieniach publikacji i zmień na wygnerowany String Azure
