# RDITechChallenge

RDITechChallenge is a solution that implements the technical test required by RDI Software.

# Technologies

- C#
- EF Core
- AutoMapper
- XUnit

# Getting Started

## Requirements

You need [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) to run this project.

## Running the project

```bash
# Restore NuGet packages
$ dotnet restore

# Build project
$ dotnet build

# Run the project
$ dotnet run
```

# Routes

## POST Customer Card

``` https://localhost:7118/card ```

```json
	{
		"customerId": 1,
		"cardNumber": 1234567891234567,
		"cvv": 12345
	}
```

## POST Validate Token

``` https://localhost:7118/token ```

```json
	{
		"customerId": 1,
		"cardId": 1,
		"token": 7456,
		"CVV": 123454
	}
```