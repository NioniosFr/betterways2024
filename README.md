# BridgingTheGap Project

Welcome to the BridgingTheGap project repository! This repository is intended to complement the talk "Harmonizing Technical Excellence and Team Collaboration" by providing practical
examples and code snippets discussed during the presentation.

## Table of Contents

- [Introduction](#introduction)
- [Project Structure](#project-structure)
- [Architecture](./adrs)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The BridgingTheGap project demonstrates best practices in software architecture, focusing on clean code principles, dependency management, and testing
strategies. It serves as a practical guide for developers looking to improve their coding skills and architectural knowledge.

## Project Structure

The project is organized into the following main directories:

- `src/`: Contains the source code for the core and data layers.
- `tests/`: Contains unit and integration tests.
- `docs/`: Contains documentation and resources related to the project.

## Setup and Installation

To set up the project locally, follow these steps:

1. Clone the repository:
   ```shell
   git clone https://github.com/NioiniosFr/betterways2024.git
   ```
2. Navigate to the project directory:
   ```shell
   cd betterways2024
   ```
3. Install the required dependencies:
   ```shell
   dotnet restore
   ```

## Usage

To run the application, use the following command:

```shell
dotnet run --project src/BridgingTheGap.Host.Api/BridgingTheGap.Host.Api.csproj
```

To run the tests, use the following command:

```shell
dotnet test
```

## Architecture

The project follows a layered architecture with a clear separation of concerns:

- **Host Layer**: Serves as the entry of the application.
- **Api Layer**: Contains the Api models.
- **Abstractions Layer**: Contains the business domain models.
- **Core Layer**: Contains the business logic and domain models.
- **Data Layer**: Contains data access logic and entity models.

We use [ArchUnit.NET](https://github.com/TNG/ArchUnitNET) to enforce architectural rules and ensure that the core layer does not depend on the data
layer.

## Testing

We use [xUnit](https://xunit.net/) for unit testing and [ArchUnit.NET](https://github.com/TNG/ArchUnitNET) for architecture tests. To run the tests,
use the following command:

```shell
dotnet test
```

## Contributing

Contributions are welcome! Please read the [CONTRIBUTING.md](CONTRIBUTING.md) file for guidelines on how to contribute to this project.

## License

This project is licensed under the GNU License. See the [LICENSE](LICENSE) file for more details.

```
