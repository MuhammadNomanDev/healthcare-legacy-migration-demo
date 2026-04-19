# Legacy Clinic System → Microservices Migration (Phase 1)

## Overview
This project simulates a **real-world legacy ASP.NET WebForms system** as the starting point of a structured migration to a backend-focused microservices architecture.

It is intentionally built using outdated patterns commonly found in enterprise environments, providing a practical foundation for demonstrating **system modernisation, backend architecture, and migration strategy**.

---

## Project Purpose
This project forms **Phase 1 of a multi-stage migration journey**, focused on:

- Understanding legacy monolithic systems in real-world scenarios  
- Identifying backend service boundaries and decomposition strategies  
- Demonstrating how technical debt impacts scalability and maintainability  
- Preparing for migration to a modern microservices-based backend  

---

## Core Functionality
The system models a basic healthcare clinic domain, including:

- Patient registration and management  
- Doctor profile management  
- Appointment scheduling and tracking  
- Billing and payment processing  
- Reporting dashboards (appointments, revenue)  

---

## Technical Stack (Legacy)
- **Framework**: ASP.NET WebForms (.NET Framework 4.8)  
- **Architecture**: Monolithic, tightly coupled  
- **Data Access**: ADO.NET with raw SQL  
- **State Management**: ViewState / Session  
- **Frontend**: WebForms UI (legacy, non-focus area)  

---

## Key Architectural Challenges
This project deliberately reflects common enterprise legacy issues:

- Tight coupling between UI, business logic, and data access  
- Direct SQL usage across multiple pages (no abstraction layer)  
- Limited testability due to static dependencies  
- Poor scalability (single deployable unit)  
- High maintenance overhead and regression risk  
- Lack of clear domain boundaries  

These constraints mirror challenges frequently encountered in **large-scale legacy systems across enterprise environments**.

---

## Migration Vision (Next Phases)
This system is designed to evolve into a **modern backend microservices architecture**:

### Target Architecture
- **UserService** – authentication and user management  
- **Domain Services** – core business capabilities (appointments, billing, etc.)  
- **API Gateway (YARP)** – centralised routing and cross-cutting concerns  
- **Event-Driven Communication** – Azure Service Bus  
- **Database per Service** – independent data ownership  
- **Containerisation** – Docker & docker-compose  
- **CI/CD Pipelines** – GitHub Actions  

### Migration Strategy
- Strangler Fig pattern for incremental backend extraction  
- API-first approach for service development  
- Gradual decomposition of monolith into bounded contexts  
- Introduction of asynchronous communication between services  

---

## Why This Project Matters
This project demonstrates:

- Practical understanding of **legacy backend systems**  
- Ability to **analyse and refactor monolithic architectures**  
- Strong focus on **backend design and distributed systems**  
- Awareness of **real-world migration strategies used in industry**  

This aligns closely with backend and platform engineering roles, particularly in organisations modernising legacy systems.

---

## Technologies
- ASP.NET WebForms (.NET Framework 4.8)  
- C#  
- ADO.NET  
- SQL Server  

---

## Future Phases
Planned backend-focused enhancements include:

- Microservices implementation using .NET  
- API Gateway with YARP  
- Azure Service Bus integration  
- Docker-based deployment  
- CI/CD pipelines  

---

## Summary
This project provides a realistic representation of a legacy backend system and serves as the foundation for a **complete migration to a microservices-based architecture**.

It highlights not only development capability, but also **backend architectural thinking and system modernisation strategy** — key skills expected in modern software engineering roles.