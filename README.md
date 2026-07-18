# Training Management System (TMS)

## Project Overview

The **Training Management System (TMS)** is a desktop application developed using **C# WinForms** that streamlines the daily operations of a training center. Rather than serving as a simple CRUD application, the system focuses on solving real-world administrative challenges by managing people, courses, classrooms, enrollments, and class schedules through well-defined business rules.

The application centralizes training center operations, improves data organization, reduces manual work, and ensures scheduling accuracy while maintaining data integrity throughout the system.

---

## Features

* Comprehensive management of people, students, teachers, courses, and classes.
* Student enrollment management.
* Classroom availability and capacity management.
* Class appointment scheduling.
* Validation rules to maintain consistent and reliable data.
* Prevention of scheduling conflicts and overlapping appointments.
* Organized management of relationships between entities.
* User-friendly Windows Forms interface.
* SQL Server database integration using ADO.NET.
* Layered architecture for better maintainability and scalability.

---

## Technologies Used

* **Programming Language:** C#
* **Framework:** Windows Forms (WinForms)
* **Database:** Microsoft SQL Server
* **Data Access:** ADO.NET
* **Architecture:** Three-Tier Architecture

  * Presentation Layer (UI)
  * Business Logic Layer (BLL)
  * Data Access Layer (DAL)

---

## System Modules

### People Management

Provides complete CRUD operations for managing all people within the training center, serving as the foundation for students and teachers.

### Student Management

Manages student information, allowing administrators to add, update, search, and remove student records while maintaining their enrollment history.

### Teacher Management

Handles teacher profiles and information required for assigning instructors to classes and courses.

### Course Management

Maintains course information including course details and related training programs.

### Enrollment Management

Manages student enrollments into available classes while enforcing business rules and maintaining enrollment records.

### Classroom Management

Provides read-only access to classroom information, allowing administrators to view classroom details, availability, and capacity for scheduling purposes.

### Class Management

Creates and manages training classes by connecting courses, teachers, and classrooms into structured training sessions.

### Class Appointment Management

Schedules class appointments while validating business rules to prevent overlapping appointments and resource conflicts.

---

## Key Functionalities

The Training Management System implements real-world business logic to improve operational efficiency, including:

* Managing relationships between students, teachers, courses, classrooms, and class appointments.
* Organizing and maintaining structured training schedules.
* Preventing overlapping class appointments and scheduling conflicts.
* Managing classroom availability and capacity.
* Handling student enrollment into training classes.
* Enforcing business rules to ensure data consistency and integrity.
* Validating user input before committing changes to the database.
* Simplifying administrative tasks through a centralized management system.

---

## Project Structure

The project follows the **Three-Tier Architecture**, separating responsibilities into independent layers:

```text
Presentation Layer (WinForms UI)
        │
        ▼
Business Logic Layer (BLL)
        │
        ▼
Data Access Layer (DAL)
        │
        ▼
SQL Server Database
```

This architecture improves:

* Code organization
* Maintainability
* Scalability
* Reusability
* Separation of concerns

---

## Future Improvements

Possible future enhancements include:

* User authentication and role-based authorization.
* Attendance tracking.
* Payment and billing management.
* Dashboard with reports and analytics.
* Email and SMS notifications.
* Exporting reports to PDF and Excel.
* Automated backup and restore functionality.

---

## Conclusion

The **Training Management System (TMS)** demonstrates the development of a practical desktop application that addresses real operational needs within a training center. By combining a structured database design, business logic, and a layered software architecture, the project goes beyond basic CRUD operations to provide a reliable and maintainable management solution.

This project showcases skills in desktop application development, database design, ADO.NET, software architecture, and implementing business rules to solve real-world problems, making it a strong portfolio project for demonstrating software engineering capabilities.
