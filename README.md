# CrimValut

## Overview

**CrimValut** is a C# project aimed at studying how to implement a solution using the **Clean Architecture** framework. The project serves as a crime data store, providing a structure to handle crime-related information in a modular, maintainable, and scalable manner.

### Purpose

The main objective of this project is to explore the implementation of a C# solution using Clean Architecture principles while focusing on the following functionalities:

- **Crime Data Storage**: Collect, store, and retrieve crime data.
- **Modular Design**: Separation of concerns using Clean Architecture to ensure maintainability.
- **Scalability**: Making the solution flexible and scalable to accommodate future requirements.

### Key Concepts

- **Clean Architecture**: A framework that emphasizes separation of concerns and a well-defined structure for an application. It consists of layers such as the `Core`, `Application`, and `Infrastructure`, ensuring that the business logic remains decoupled from external dependencies like databases and APIs.
  
- **Crime Store**: A centralized storage to handle and manage crime-related data. This will include storing information such as crime types, locations, timestamps, and case statuses.

## Features

- **CRUD Operations**: The ability to create, read, update, and delete crime records.
- **Data Validation**: Ensures the integrity of the crime data with appropriate checks.
- **Reporting**: Ability to generate basic reports based on stored crime data.
- **Search and Filter**: Searching and filtering crimes based on criteria such as crime type, location, and date.
- **Modular Components**: Each layer is designed to be independent, making it easier to test, maintain, and extend.

## Architecture

The architecture of CrimValut follows the principles of Clean Architecture, which includes:

1. **Core**: Contains the domain models and business logic (e.g., `Crime` class, services for crime data processing).
2. **Application**: Contains the use cases or application services. This layer interacts with the Core to perform specific tasks such as crime data management.
3. **Infrastructure**: This layer contains the implementation details for external services such as databases, APIs, and other external dependencies.
4. **UI/Presentation**: An optional layer where you can implement a user interface (e.g., API, console app) to interact with the system.

## Technologies Used

- **C#**: The primary language used for the project.
- **.NET Core**: Framework for building the application.
- **Entity Framework Core**: ORM for data access.
- **SQL Server**: Database for storing crime data (hosted using Docker).
- **Docker**: Containerization platform for running the database in a container.
