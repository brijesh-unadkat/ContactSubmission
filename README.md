# Contact Detail Page
A full-stack application with a .NET Core Web API backend, React frontend, and PostgreSQL database. The app allows users to view, add, update, and delete contact details.
 
## Technologies Used
 
- Backend: ASP.NET Core Web API
- Frontend: React
- Database: PostgreSQL
- ORM: Entity Framework Core
- Tooling: Docker (optional)
 
---
 
## Project Structure
/fontend  # React Frontend
/server  # .net core API backend
/server/models # c# data models
/server/Controllers # API controllers
/server/infrastructure # c# datacontext


##Features
ADD, View contact details


##Getting Started 

Prerequisites

.net SDK
node.js and npm
postgreSQL



Setup steps :

1. Update appsettings.json with your PostgreSQL connection string
2. Update env variable with your endpoint APIs
2. docker compose change with docker repositery should be name of azure container registry and should be passed from CI/CD
4. run script (schema, table)

5. APIEndpint
   api/Contact/GetContactDetails
   api/Contact/SaveContactDetails






