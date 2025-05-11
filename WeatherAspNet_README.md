# BlazorApp – Strona z filtrowaniem pogody

## Struktura projektu

```
FilmReviewApp/
├── FilmReviewApp.Shared/
│   ├── Pages/
│   │   ├── Weather.razor
│   │   ├── Home.razor
│   ├── Routes.razor
│   ├── Services/
│   │   ├── IdentityAuthenticationStateProvider.cs
│   ├── \_Imports.razor
│   ├── FilmReviewApp.Shared.csproj
├── FilmReviewApp.Web/
│   ├── Components/
│   │   ├── App.razor
│   │   ├── Pages/
│   │   │   ├── Account/
│   │   │   │   ├── Login.razor
│   │   │   │   ├── Logout.razor
│   │   │   │   ├── Register.razor
│   ├── Program.cs
│   ├── FilmReviewApp.Web.csproj
```

## Kluczowe funkcjonalności – komponent `Weather.razor`

### Funkcje:
- Generowanie 10 losowych prognoz pogody (data, temperatura, podsumowanie).
- Filtrowanie prognoz według słowa kluczowego w polu „Summary”.
- Przycisk **Filter Warm Days** filtruje dni z temperaturą > 15°C.
- Przycisk **Restore** przywraca pierwotną listę prognoz.
- Wyświetlanie liczby ciepłych dni.

### Interfejs użytkownika:
- Pole tekstowe do dynamicznego filtrowania.
- Tabela z datą, temperaturą (C/F) i opisem pogody.
- Dwa przyciski: filtrowanie i przywracanie danych.

### Logika działania:
- Dane są generowane w metodzie `OnInitializedAsync()`.
- Filtrowanie działa zarówno po temperaturze, jak i po tekście.
- Liczba ciepłych dni (>15°C) jest obliczana dynamicznie.
