

# Gym Tracker

**Gym Tracker** is a web application designed to help users track their workouts, progress, and fitness data. The application provides an intuitive interface for logging different types of workouts, such as cardio, strength, and flexibility training, along with their duration, intensity, calories burned, and other related metrics.

This project is built using **Angular** for the frontend, **Material Design** for UI components, and integrates with a backend API for managing workout data.

## Features

- **User Authentication**: Sign up, login, and log out functionality.
- **Dashboard**: View your workout history and track progress.
- **Workout Log**: Add workouts and keep track of them all in one place
- **Progress Tracking**: Monitor your calories burned, intensity, and fatigue levels over time.
- **Responsive Design**: Optimized for use on both mobile and desktop devices.

## Technologies Used

- **Frontend**: 
  - [Angular](https://angular.io/) – A platform for building web applications.
  - [Angular Material](https://material.angular.io/) – UI component library based on Material Design.
  - [Vite](https://vitejs.dev/) – Next-generation frontend build tool.

- **Backend**: 
  - [ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet) – For building RESTful APIs.
  - [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) – ORM for database interactions.
  - [NeonDB](https://neon.tech/) – PostgreSQL database for storing data

- **Authentication**:
  - [JWT](https://jwt.io/) – JSON Web Tokens for secure user authentication.

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- [Node.js](https://nodejs.org/) (LTS version)
- [Angular CLI](https://angular.io/cli)
- [ASP.NET Core SDK](https://dotnet.microsoft.com/download/dotnet) (for the backend)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/SaladVlad/GymTracker.git
   cd GymTracker
   ```

2. Install the frontend dependencies:

   ```bash
   cd gym-tracker-frontend
   npm install
   ```

3. Set up the backend (ASP.NET Core API):

   ```bash
   cd ..
   dotnet restore
   dotnet build
   ```


5. Run the backend server:

   ```bash
   dotnet run
   ```

6. Run the frontend:

   ```bash
   cd ../gym-tracker-frontend
   ng serve
   ```

   This will start the development server, and you can access the application at `http://localhost:4200`.

### Running Tests

#### Backend Tests

For backend tests, navigate to the backend project directory and use:

```bash
dotnet test
```

### Environment Variables

- **Frontend**: The frontend expects the backend API to be available at `http://localhost:5000`. You can change this in the environment settings if needed.

- **Backend**: Ensure that the backend has the correct API URLs and database configurations set in `appsettings.json` before running the application. The connection strings are intentially left, if the project should go into production, the environmental variables should be set up independently and separated for security.


## License

This project is licensed under the MIT License – see the [LICENSE](LICENSE) file for details.


