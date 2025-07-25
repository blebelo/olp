# Important

Issues of this repository are tracked on https://github.com/aspnetboilerplate/aspnetboilerplate. Please create your issues on https://github.com/aspnetboilerplate/aspnetboilerplate/issues.

# Introduction

This is a template to create **ASP.NET Core MVC / Angular** based startup projects for [ASP.NET Boilerplate](https://aspnetboilerplate.com/Pages/Documents). It has 2 different versions:

1. [ASP.NET Core MVC & jQuery](https://aspnetboilerplate.com/Pages/Documents/Zero/Startup-Template-Core) (server rendered multi-page application).
2. [ASP.NET Core & Angular](https://aspnetboilerplate.com/Pages/Documents/Zero/Startup-Template-Angular) (single page application).
 
User Interface is based on [AdminLTE theme](https://github.com/ColorlibHQ/AdminLTE).
 
# Download

Create & download your project from https://aspnetboilerplate.com/Templates

# Screenshots

#### Sample Dashboard Page
![](_screenshots/module-zero-core-template-ui-home.png)

#### User Creation Modal
![](_screenshots/module-zero-core-template-ui-user-create-modal.png)

#### Login Page

![](_screenshots/module-zero-core-template-ui-login.png)

# Documentation

* [ASP.NET Core MVC & jQuery version.](https://aspnetboilerplate.com/Pages/Documents/Zero/Startup-Template-Core)
* [ASP.NET Core & Angular  version.](https://aspnetboilerplate.com/Pages/Documents/Zero/Startup-Template-Angular)

# License

[MIT](LICENSE).
# Online Learning Platform (OLP)

![Logo](https://avatars.githubusercontent.com/u/222741493?v=4)

## Ì∫Ä Overview

**Online Learning Platform (OLP)** is a production-ready web application for online education, built for **instructors** and **students**. OLP enables instructors to create, manage, and deliver courses, lessons, and quizzes, while providing students with a seamless experience to enroll, learn, take quizzes, and track their progress.

Built with a robust **ASP.NET Core backend** (ABP Framework) and a modern **Next.js frontend**, OLP offers high security, scalability, and a responsive user experience.

---

## Ì∑ÇÔ∏è Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Screenshots](#screenshots)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Customization](#customization)
- [Documentation](#documentation)
- [FAQ](#faq)
- [Contributing](#contributing)
- [License](#license)
- [Author & Contact](#author--contact)

---

## ‚ú® Features

### Instructor Features
- Create, edit, publish, and manage courses
- Add lessons with materials, videos, and documents
- Create and grade quizzes
- Track student enrollments and progress

### Student Features
- Browse and enroll in courses
- Access lessons, materials, and videos
- Take quizzes and view results
- Track learning progress and completion

### Platform Features
- Multi-tenancy (support for multiple organizations/learning spaces)
- Role-based access control (Student, Instructor, Admin)
- Secure JWT authentication
- Real-time notifications (SignalR)
- Localization (multi-language support, e.g., English, Persian)
- Auditing and analytics
- Responsive UI (Ant Design & custom CSS modules)
- Sample data for quick demonstration

---

## ÌøóÔ∏è Architecture

### Backend (ASP.NET Core, ABP Framework)
- **Domain-driven design**: Courses, lessons, quizzes, users, tenants
- **RESTful APIs**: Endpoints for all core features
- **Authentication & Authorization**: JWT tokens, roles, multi-tenancy
- **Auditing & Localization**
- **Swagger UI**: Interactive API docs
- **SignalR**: Real-time communication

### Frontend (Next.js, React)
- **App Directory Structure**: Modular, scalable components & pages
- **Role-based Routing**: Separate experiences for instructors and students
- **Context Providers**: Auth, courses, instructors, students
- **UI Library**: Ant Design (components, modals, navigation)
- **Custom CSS Modules**: Extendable and brandable styles
- **Sample Data**: For fast onboarding and demonstrations

---

## Ì∂ºÔ∏è Screenshots

### Dashboard
![Dashboard](./_screenshots/module-zero-core-template-ui-home.png)

### User Creation Modal
![User Creation](./_screenshots/module-zero-core-template-ui-user-create-modal.png)

### Login Page
![Login](./_screenshots/module-zero-core-template-ui-login.png)

---

## Ì≥¶ Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Node.js & npm](https://nodejs.org/)
- [Next.js](https://nextjs.org/)
- SQL Server or compatible database

### Installation

```bash
# Clone the repository
git clone https://github.com/xolani000god/olp.git

# Backend setup
cd aspnet-core
dotnet run --project src/OnlineLearningPlatform.Migrator      # Run database migrations
dotnet run --project src/OnlineLearningPlatform.Web.Host      # Start backend API server

# Frontend setup
cd front-end
npm install
npm run dev     # Start Next.js frontend
```

> **Note:** Update your backend connection string in `aspnet-core/appsettings.json` as needed.

---

## Ì∫Ä Usage

- Access the landing page at `http://localhost:3000`
- Students can browse, enroll, and track courses
- Instructors can create and manage courses, lessons, and quizzes
- Use the dashboards for each role to access dedicated features

---

## Ìª†Ô∏è Customization

- Add new modules/features for your educational needs
- Extend UI with custom CSS modules or Ant Design theming
- Integrate with third-party services (payments, notifications, analytics)
- Update sample data in `front-end/src/utils/sample-courses/`
- Brand the platform with your own logos and colors

---

## Ì≥ö Documentation

- [ASP.NET Boilerplate Docs](https://aspnetboilerplate.com/Pages/Documents)
- [Next.js Documentation](https://nextjs.org/docs)
- [Swagger UI](http://localhost:5000/swagger) (once backend is running)

---

## ‚ùì FAQ

**Q:** Can I use this platform for my own organization or school?  
**A:** Yes, OLP is production-ready and customizable for any educational institution.

**Q:** Is there demo/sample data?  
**A:** Yes, the platform comes with sample courses, lessons, and quizzes for quick demonstration.

**Q:** How do I add a new feature?  
**A:** Follow the modular structure in both backend and frontend, using context providers and service modules.

---

## Ì¥ù Contributing

Pull requests and issues are welcome!  
For bug reports, please create issues on [aspnetboilerplate/aspnetboilerplate](https://github.com/aspnetboilerplate/aspnetboilerplate/issues).

---

## Ì≥ù License

This project is licensed under the [MIT License](LICENSE).

---

## Ì±§ Author & Contact

Developed by the **OLP Team**

Questions, feedback, or collaboration?  
Reach out via [GitHub](https://github.com/xolani000god).
