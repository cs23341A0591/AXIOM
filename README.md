# AcxiomCRM - Enterprise Web CRM Application

**AcxiomCRM** is a production-grade, full-stack web-based Customer Relationship Management (CRM) application built with **ASP.NET Core MVC 8.0**, **ASP.NET Core Identity**, **Entity Framework Core**, **Bootstrap 5**, **REST API Controllers**, and **Chart.js**.

---

## 🌟 Key Features

1. **Secure Authentication & Account Security**:
   - Integrated with ASP.NET Core Identity with secure password hashing (`PBKDF2`).
   - Account lockout tracking (locks account for 15 minutes after 5 consecutive failed login attempts).
   - Strict password complexity policy (minimum 8 characters, uppercase, lowercase, digit, special character).
   - Persistent cookie authentication and Anti-Forgery token protection (`[ValidateAntiForgeryToken]`).

2. **Role-Based Authorization & Ownership Scoping**:
   - **Admin**: Complete system control across Users, Roles, Audit Logs, CRM entities, and System Reports.
   - **Manager**: Team-level visibility across direct reports' assigned Customers, Leads, Opportunities, and Follow-Ups.
   - **Sales Executive**: Scope-restricted access strictly limited to assigned CRM records. Server-side validation prevents URL tampering or unauthorized record access (403 Forbidden).

3. **Interactive CRM Dashboard & Analytics**:
   - KPI metrics: Total Customers, Total Leads, Open Leads, Total Opportunities, Open Opportunities, Won Opportunities, Lost Opportunities, and Total Pipeline Value.
   - Dynamic Date Range Filtering (Today, This Week, This Month, Custom Range).
   - **Chart.js Visualizations**: Lead Status Breakdown, Opportunity Pipeline Stage Distribution, and Monthly Sales Trends.

4. **Complete CRM Lifecycle Management**:
   - **Customer Management**: Full CRUD, email/phone uniqueness validation, search, filter, sort, pagination, and deactivation.
   - **Lead Management**: Lifecycle tracking (New, Contacted, Qualified, Unqualified, Converted, Lost) and **Lead-to-Customer Conversion Workflow**.
   - **Opportunity Management**: Stage tracking (Qualification, Proposal, Negotiation, Won, Lost), Weighted Pipeline calculation (`Amount × Probability / 100`), and strict business validation rules.
   - **Follow-Up Management**: Scheduling, completion, rescheduling, overdue task tracking, and enforced rule: **Follow-Up Date cannot be in the past for new follow-ups**.
   - **Activity Management**: Log and history tracking for Calls, Meetings, Emails, and Tasks.

5. **Security & Business Audit Logging**:
   - Immutable audit trail capturing authentication events (Login, Failed Login, Lockout, Logout), CRM entity changes (Create, Update, Delete, Conversion), and administrative security events.

6. **REST API Controllers**:
   - Authenticated REST APIs returning clean JSON (`/api/customers`, `/api/leads`, `/api/opportunities`, `/api/auth/login`, `/api/reports/pipeline`).
   - Standard HTTP status codes (`200 OK`, `201 Created`, `400 Bad Request`, `401 Unauthorized`, `403 Forbidden`, `409 Conflict`).
   - Strict usage of DTOs (Data Transfer Objects) to never expose password hashes or domain entity internals.

---

## 🏗️ Technology Stack

- **Backend**: C#, ASP.NET Core 8.0 MVC, ASP.NET Core Identity, Entity Framework Core 8.0, REST API Controllers.
- **Database**: SQLite (default zero-config) / SQL Server / LocalDB support.
- **Frontend**: Razor Views, Bootstrap 5, HTML5, CSS3, JavaScript, jQuery, jQuery Unobtrusive Validation, Chart.js.
- **Security**: Anti-Forgery protection, Cookie Authentication, Server-side role/ownership scoping, Account Lockout policies.

---

## 📐 Architecture & Project Structure

The project follows a clean layered architecture:

```
AcxiomCRM/
├── Controllers/         # MVC Controllers handling web requests
├── Api/                 # REST API Controllers
├── Data/                # EF Core ApplicationDbContext & DbSeeder
├── Models/              # Domain Entities (Customer, Lead, Opportunity, etc.)
├── ViewModels/          # Strongly-typed Razor ViewModels
├── DTOs/                # Data Transfer Objects for REST APIs
├── Services/            # Business & Service Layer (Scoping, Rules, Auditing)
│   ├── Interfaces/      # Service Contracts
├── Authorization/       # Role Constants & Permission helpers
├── Validation/          # Custom validation attributes and business rules
├── Views/               # Razor Views (Dashboard, Modules, Reports, Account)
├── wwwroot/             # Static Assets (CSS, JS, Libraries)
├── appsettings.json     # Application Configuration
└── Program.cs           # Dependency Injection & Middleware Pipeline
```

---

## 🔐 Seed Demo Credentials

| Role | Email | Password | Scope / Privileges |
| :--- | :--- | :--- | :--- |
| **Admin** | `admin@acxiomcrm.com` | `P@ssword123!` | Full System Administration, Audit Logs, All Records |
| **Manager** | `manager@acxiomcrm.com` | `P@ssword123!` | Team Data, Team Pipeline, Performance Reports |
| **Sales Executive** | `sales@acxiomcrm.com` | `P@ssword123!` | Assigned Records, Sales Dashboard |
| **Sales Executive 2** | `sales2@acxiomcrm.com` | `P@ssword123!` | Assigned Records, Sales Dashboard |

> **Security Note**: Demo credentials are provided for development and demonstration purposes. Change passwords prior to production deployment.

---

## 🚀 How to Run the Application

### Prerequisites
- .NET 8.0 SDK installed.

### Steps to Run
1. Open terminal in the project directory:
   ```bash
   cd c:\Users\satis\Downloads\AXIOM\AcxiomCRM
   ```
2. Build and run the project:
   ```bash
   dotnet run
   ```
3. Open your browser and navigate to:
   ```
   https://localhost:7001  or  http://localhost:5000
   ```
4. Log in using any of the demo credentials above. The database will automatically initialize and populate with rich demo data on startup!

---

## 🌐 REST API Endpoints

| Method | Endpoint | Description | Auth Required |
| :--- | :--- | :--- | :--- |
| `POST` | `/api/auth/login` | Authenticate user & return role profile | No |
| `POST` | `/api/auth/logout` | Terminate session | Yes |
| `GET` | `/api/customers` | Get list of scoped customers | Yes |
| `GET` | `/api/customers/{id}` | Get customer details by ID | Yes |
| `POST` | `/api/customers` | Create a new customer | Yes |
| `PUT` | `/api/customers/{id}` | Update existing customer | Yes |
| `DELETE` | `/api/customers/{id}` | Deactivate customer | Yes |
| `GET` | `/api/leads` | Get list of scoped leads | Yes |
| `POST` | `/api/leads` | Create a new lead | Yes |
| `GET` | `/api/opportunities` | Get list of scoped opportunities | Yes |
| `POST` | `/api/opportunities` | Create a new opportunity | Yes |
| `GET` | `/api/reports/pipeline` | Get pipeline summary report | Yes |

---

## ✅ Acceptance Test Checklist

- [x] Anonymous user cannot access protected CRM routes (redirected to Login).
- [x] ASP.NET Core Identity authentication with secure password hashing.
- [x] Account lockout after repeated failed login attempts.
- [x] Client-side & Server-side validation for email format, phone format, and uniqueness.
- [x] Server-side business validation for Opportunity Amount (`> 0`), Probability (`0-100`), Close Date.
- [x] Server-side business validation for Follow-Up Date (`>= Today`).
- [x] Server-side ownership / role-based scope enforcement preventing IDOR attacks.
- [x] Interactive Chart.js charts on Dashboard with dynamic date filtering.
- [x] Complete Lead-to-Customer conversion workflow.
- [x] 8 Mandatory CRM & Security Reports.
- [x] Comprehensive append-only Audit Logging.
- [x] Full REST API implementation with DTOs and clean JSON responses.
