# 🎨 art

**l2art** is a website dedicated to enhancing the Lineage II gaming community by providing valuable resources, guides, and tools to enrich the player experience. The project is developed using principles from Domain-Driven Design (DDD) and Clean Architecture to ensure flexibility, scalability, and maintainability.

## 🚀 Features

- **Comprehensive Guides**: In-depth articles and tutorials to assist both new and veteran players.
- **Interactive Tools**: Web-based utilities to calculate character stats, plan builds, and more.
- **News Updates**: Stay informed with the latest news and updates related to Lineage II.

## 🛠️ Technologies Used

- **DDD (Domain-Driven Design)**: An approach to software development that emphasizes collaboration with domain experts to model complex business domains effectively. DDD focuses on creating a common language between technical and non-technical team members and structuring the code to reflect the business domain accurately. :contentReference[oaicite:2]{index=2}

- **Clean Architecture**: An architectural style that organizes code into layers with clear dependencies, promoting separation of concerns. The core principles include:
  - **Independence from Frameworks**: The business logic is not tied to specific technologies or frameworks.
  - **Testability**: The system is designed to be easily testable in isolation.
  - **Independence from UI and Database**: The business rules can function without the user interface or database, allowing for flexibility in changing external components.

  By integrating DDD with Clean Architecture, the project ensures that the domain model remains at the center, with external concerns like UI and data access implemented in separate layers. :contentReference[oaicite:3]{index=3}

- **Front-End**:
  - **HTML5 & CSS3**: For structuring and styling the website.
  - **TypeScript**: Enhancing JavaScript with static typing for improved development.
  - **Angular 2+**: Building dynamic and responsive user interfaces.

- **Back-End**:
  - **C#**: Server-side logic and operations.
  - **ASP.NET Core**: Framework for building scalable web applications.
  - **Entity Framework Core**: Object-relational mapping (ORM) for database interactions.

- **Database**:
  - **SQL Server**: Managing and storing application data.

- **DevOps**:
  - **Docker**: Containerization for consistent development and deployment environments.
  - **Nginx**: Web server and reverse proxy for handling client requests.
  - **Certbot**: Automated SSL certificate generation and renewal.

## 🏗️ Project Structure

The project follows the Clean Architecture principles, organized into distinct layers:

- `L2Art.Domain/`: Contains the core business logic and domain entities, adhering to DDD principles.
- `L2Art.Application/`: Implements use cases and application-specific business rules, coordinating between the domain and external layers.
- `L2Art.Infrastructure/`: Handles interactions with external systems such as databases, file storage, and network services.
- `L2Art.Api/`: Includes components for user interfaces and APIs, facilitating interaction with users and client applications.

## 🔧 Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/dir724/l2art.git
