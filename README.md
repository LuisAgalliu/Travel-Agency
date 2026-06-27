# Travel Agency - ASP.NET Web Forms

A web application for managing a travel agency, developed with **ASP.NET Web Forms**, **C#**, **Bootstrap**, **jQuery**, and **SQL Server**. The project provides a user-facing interface for viewing travel packages and making reservations, together with an admin area for managing packages, users, and bookings.

## Features

- Home page with travel agency presentation
- Travel package listing and destination images
- User login system
- Reservation form for travel packages
- Booking confirmation page
- User area for checking personal reservations
- Admin dashboard
- Package management: add, edit, and manage travel offers
- User management: view and edit users
- Reservation management for administrators
- Responsive front-end layout using Bootstrap
- Custom styling with CSS

## Technologies Used

- ASP.NET Web Forms
- C#
- .NET Framework
- SQL Server
- ADO.NET / Web.config database connection
- Bootstrap
- jQuery
- HTML5
- CSS3
- JavaScript

## Project Structure

```text
agjensi_udhetimi/
├── agjensi_udhetimi.sln
├── agjensi_udhetimi/
│   ├── App_Start/
│   ├── Content/
│   ├── Scripts/
│   ├── assets/
│   │   ├── css/
│   │   └── images/
│   ├── admin.aspx
│   ├── index.aspx
│   ├── Login.aspx
│   ├── Rezervimet.aspx
│   ├── rezervimet_mia.aspx
│   ├── Kontrollo_rezervimet.aspx
│   ├── menaxhim_paketash.aspx
│   ├── menaxhim_users.aspx
│   ├── edit_paketen.aspx
│   ├── edit_user.aspx
│   ├── Konfirmim_Rezervimi.aspx
│   ├── RrethNesh.aspx
│   ├── Site1.Master
│   └── Web.config
```

## Main Pages

| Page | Description |
|---|---|
| `index.aspx` | Main landing page of the travel agency |
| `RrethNesh.aspx` | About page |
| `Login.aspx` | User authentication page |
| `Rezervimet.aspx` | Reservation page |
| `Konfirmim_Rezervimi.aspx` | Reservation confirmation page |
| `rezervimet_mia.aspx` | User's personal reservations |
| `admin.aspx` | Admin dashboard |
| `menaxhim_paketash.aspx` | Package management |
| `edit_paketen.aspx` | Edit travel package |
| `menaxhim_users.aspx` | User management |
| `edit_user.aspx` | Edit user information |
| `Kontrollo_rezervimet.aspx` | Reservation control and administration |

## How to Run the Project

1. Clone the repository:

```bash
git clone https://github.com/your-username/agjensi_udhetimi.git
```

2. Open the solution file in Visual Studio:

```text
agjensi_udhetimi.sln
```

3. Restore NuGet packages if Visual Studio asks for them.

4. Configure the database connection in `Web.config`.

5. Run the project using IIS Express.

## Database Configuration

The project uses a database connection configured in `Web.config`. For security reasons, do not publish real database passwords, usernames, server names, or connection strings in a public repository.

For GitHub, use a safe example like this:

```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="YOUR_CONNECTION_STRING_HERE"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

## Security Note

Before publishing this project on GitHub, make sure that sensitive files and data are not included, especially:

```text
Web.config
*.mdf
*.ldf
.vs/
bin/
obj/
packages/
```

If `Web.config` contains a real database connection string or password, keep it only on your local computer and upload a `Web.config.example` file instead.

## Screenshots

You can add screenshots here after uploading the project:

```text
assets/images/hero-banner.jpg
assets/images/paris.jpg
assets/images/rome.jpg
assets/images/barcelona.jpg
```

Example:

```markdown
![Home Page](screenshots/home.png)
```

## Future Improvements

- Add online payment integration
- Add email confirmation for reservations
- Add role-based access control for users and admins
- Improve validation for reservation forms
- Add search and filtering for travel packages
- Add reporting dashboard for reservations and users
- Improve database structure and error handling

## Author

Developed by **Luis Agalliu** as a web application project for a travel agency management system.
