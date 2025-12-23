# M.A.G.U.S. Assistant

A companion MAUI app and tools for managing M.A.G.U.S. characters, encounters and small-scale combat simulation.
Designed for developers and GMs who want an offline helper (character sheets, encounter runner, turn history, simple AI enemies, translations, etc.).

---

# Features

* Character viewer & editor (abilities, equipment, combat values, psi/mana, qualifications).
* Encounter manager: assign enemies to characters, run rounds, record turn history and attacks.
* Pluggable combat system (initiative, attack resolution, hit locations).
* Collection of custom controls: `NumericUpDownWithLabel`, `EntryWithLabel`, `MenuItem`, etc.
* Language service/translator that scans UI elements and replaces strings at runtime.
* MVVM using CommunityToolkit.Mvvm.
* Simple persistence and import/export support (JSON).
* Unit tests (NUnit preferred in this repo).

---

# Quickstart

## Prerequisites

* .NET 10 SDK (installed).
* .NET MAUI workload installed (`dotnet workload install maui`), or use Visual Studio with MAUI support.
* Recommended: Visual Studio 2022/2026 (latest updates) or Visual Studio for Mac with MAUI support.
* (Optional) Android / iOS SDKs if you want device/emulator runs.

## Build & run (CLI)

Open a terminal at repository root:

```bash
# restore
dotnet restore

# build (example: windows)
dotnet build -f net10.0-windows10.0.19041.0

# run locally (Windows)
dotnet run -f net10.0-windows10.0.19041.0 --project M.A.G.U.S.Assistant

# run for Android (emulator) - adjust TFM and project as needed
dotnet build -f net10.0-android
# then deploy using Visual Studio or your preferred tooling
```

## Tests

```bash
dotnet test
```

(Repo uses NUnit for unit tests where applicable.)

---

# Project layout (high level)

```
/src
  /M.A.G.U.S.Assistant          # MAUI app (views, viewmodels, pages)
  /M.A.G.U.S.GameSystem         # Domain: Character, Creature, Combat logic
  /M.A.G.U.S.Bestiary           # Creature definitions
  /Mtf.Maui.Controls            # Shared custom MAUI controls (NumericUpDownWithLabel, EntryWithLabel,...)
  /Mtf.LanguageService.MAUI     # Runtime UI translator & converters
/tests
  /M.A.G.U.S.Tests              # Unit and integration tests (NUnit)
```

Key types you’ll see:

* `Character`, `Creature` – domain models.
* `CharacterViewModel`, `EncounterViewModel`, `AssignmentViewModel`, `TurnViewModel` – MVVM glue.
* `Translator` – runtime UI translation helper (Mtf.LanguageService.MAUI nupkg).
* `NumericUpDownWithLabel` – custom control used throughout the UI (Mtf.Maui.Controls nupkg).

---

# Contributing

1. Fork the repository and create a branch for your feature/bugfix.
2. Make changes, add unit tests (NUnit), and run `dotnet test`.
3. Open a pull request describing the change and why it’s needed.
