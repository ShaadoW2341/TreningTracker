# TreningTracker

Aplikacja desktopowa do monitorowania aktywności fizycznej i realizacji celów treningowych. Umożliwia rejestrowanie treningów, śledzenie postępów oraz analizę statystyk.

## Funkcje

- Dodawanie i edycja sesji treningowych (czas, dystans, kalorie, kroki, typ aktywności)
- Wbudowany stoper do pomiaru czasu trwania treningu
- Przegląd historii treningów z filtrowaniem według daty i typu aktywności
- Ustawianie dziennych i tygodniowych celów treningowych
- Podsumowanie dnia i tygodnia (kroki i liczba treningów)
- Statystyki (suma, średnia, maksima dla różnych parametrów)

## Technologie

- .NET Framework / Windows Forms
- Entity Framework Core
- PostgreSQL (domyślna konfiguracja w `appsettings.json`)

## Konfiguracja bazy danych

Zmień dane połączenia w pliku `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=TreningDB;Username=postgres;Password=admin;"
  }
}
```

Domyślnie aplikacja korzysta z bazy PostgreSQL. W razie potrzeby utwórz bazę danych o nazwie `TreningDB`.

## Struktura projektu

- `MainForm` – główne okno aplikacji
- `AddTrainingForm` – formularz dodawania/edycji treningu
- `HistoryForm` – historia treningów
- `StatsForm` – statystyki
- `GoalsForm` – zarządzanie celami
- `AppDbContext` – konfiguracja Entity Framework
- `Models` – klasy: `TrainingSession`, `ActivityType`, `GoalSetting`

## Uruchomienie

1. Otwórz projekt w Visual Studio.
2. Przygotuj bazę danych PostgreSQL.
3. Uruchom aplikację – baza danych zostanie zainicjalizowana z domyślnymi danymi.
