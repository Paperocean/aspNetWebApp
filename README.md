# BlazorApp – Aplikacja do oceny filmów 

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

## 📄 Details.razor
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

W pliku `appsetting.json` należy zmienić domyślny Connection String (`DefaultConnection`) na string wygenerowany po połączeniu z Azure SQL Database.

Przykład wygenerowanego Connection String:
```
Server=tcp:blazorapp1dbserver2.database.windows.net,1433;Initial Catalog=BlazorApp1_db;User Id={userID};Password={passwd}
```

> **Ważne:** W powyższym stringu należy zastąpić `{userID}` oraz `{passwd}` rzeczywistymi danymi uwierzytelniającymi do bazy danych.

### 2. Konfiguracja Entity Framework przy publikacji

Podczas konfiguracji publikacji aplikacji należy włączyć opcję migracji dla platformy Entity Framework. Zapewni to automatyczne zastosowanie migracji bazy danych podczas wdrażania aplikacji.

### Pełny przykład Connection String

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:blazorapp1dbserver2.database.windows.net,1433;Initial Catalog=BlazorApp1_db;User Id=rzeczywisty_użytkownik;Password=rzeczywiste_hasło"
  }
}
```

## Podsumowanie

1. Zmień Connection String w `appsetting.json` na wygenerowany przez Azure
2. Uzupełnij dane uwierzytelniające (User Id i Password)
3. Włącz migracje Entity Framework w ustawieniach publikacji
