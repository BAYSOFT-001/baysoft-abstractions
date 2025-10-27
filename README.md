# BAYSOFT.Abstractions ![Nuget](https://img.shields.io/nuget/v/BAYSOFT.Abstractions)

**BAYSOFT.Abstractions** is a core .NET library developed by BAYSOFT, providing abstraction layers and foundational interfaces for building clean architecture, domain-driven design and application services in C# (.NET).  
It supports projects leveraging CQRS, MediatR, FluentValidation and other modern patterns.

## 🔍 Overview

In enterprise or modular .NET applications, it's beneficial to define **abstraction layers** that decouple infrastructure from domain and application logic.  
BAYSOFT.Abstractions provides:

- Common base interfaces and marker types for commands, queries, results and domain services.  
- Contract definitions (abstractions) for application layers — enabling greater testability and adherence to dependency inversion.  
- Patterns following CQRS + MediatR + FluentValidation, allowing you to build application logic with consistency and minimal boilerplate.  
- A shared library to reduce duplication, enforce uniform architecture and accelerate new service development.

## ✅ Key Features

- Core abstractions for Commands (`ICommand`), Queries (`IQuery<TResult>`), and Handlers (`ICommandHandler<TCommand>`, `IQueryHandler<TQuery, TResult>`).  
- Integration friendly with libraries such as `MediatR`, `FluentValidation`, and other modular frameworks.  
- Helps define contracts (interfaces) in the *Application* layer, keeping dependencies one-way (inward) and domain logic clean.  
- Published as a NuGet package [`BAYSOFT.Abstractions`](https://www.nuget.org/packages/BAYSOFT.Abstractions)

## 🚀 Installation

### Using NuGet Package Manager

```powershell
Install-Package BAYSOFT.Abstractions
```

### Using .NET CLI
```bash
dotnet add package BAYSOFT.Abstractions
```

## 💻 Example Usage
Here’s a minimal example to illustrate how you might use the abstractions in your application layer:

```csharp
// Define a command
public class CreateOrderCommand : ICommand<OrderResult>
{
    public string CustomerId { get; set; }
    public List<OrderItemDto> Items { get; set; }
}

// Define handler
public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, OrderResult>
{
    public async Task<OrderResult> Handle(CreateOrderCommand command, CancellationToken ct)
    {
        // business logic, domain work, persistence, etc.
        ...
        return new OrderResult { OrderId = createdOrder.Id, Success = true };
    }
}
```
Because these types leverage the abstractions from BAYSOFT.Abstractions, the infrastructure (e.g., MediatR, dependency injection) and application layers can remain loosely coupled and maintainable.

## 📚 Documentation & Resources
- GitHub Repository: [`https://github.com/BAYSOFT-001/baysoft-abstractions`](https://github.com/BAYSOFT-001/baysoft-abstractions)
- NuGet Package Info: [`https://www.nuget.org/packages/BAYSOFT.Abstractions`](https://www.nuget.org/packages/BAYSOFT.Abstractions)
- Versioning: ![Nuget](https://img.shields.io/nuget/v/BAYSOFT.Abstractions)


## 💡 Why Use This Library?
- Keeps your architecture consistent across multiple services or microservices.
- Helps maintain separation of concerns: infrastructure, application logic, domain.
- Makes code easier to test, evolve and scale.
- Provides a standard foundation for new services, reducing startup overhead.

## 🧠 Best Practices
- Use the abstractions in the Application layer only. Do not reference infrastructure implementation details here.
- Keep domain entities and business rules inside the Domain layer; abstractions here help the boundary but do not replace domain logic.
- Define commands / queries / handlers following the interface patterns provided by the library.
- Combine with FluentValidation for request validation and MediatR for dispatching commands/queries to handlers.
- Document new abstraction interfaces clearly and keep them lightweight — this library is meant to define contracts, not heavy logic.

## 🤝 Contributing
Contributions are welcome!
If you would like to propose improvements, bug-fixes or new abstractions:

1. Fork the repository.
2. Create a branch for your change (e.g., feature/my-new-abstraction).
3. Ensure your changes include tests if applicable.
4. Submit a pull request and describe the purpose/impact of your change.

## 🧾 License
This project is licensed under the MIT License.

You are free to use, modify, and distribute it, provided you credit the original author.