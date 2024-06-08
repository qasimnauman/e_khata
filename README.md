# E-Khata (Inventory Management System)

Welcome to the Khata Inventory Management System repository! E-Khata is a comprehensive inventory management system designed to facilitate CRUD operations and user authentication through login/signup functionalities.

## Table of Contents

1. [Technologies Used](#technologies-used)
2. [Getting Started](#getting-started)
3. [Project Structure](#project-structure)
4. [Setting Up Database](#setting-up-database)
5. [Running the Project](#running-the-project)
6. [Contributing](#contributing)
7. [License](#license)

## Technologies Used

- **Blazor Web Server**: Utilized for the frontend development, providing a rich and interactive user interface.
- **ASP.Net and C#**: The backbone of the application, used for logic building and backend development.
- **SQL Server**: The database management system employed for data storage and retrieval.

## Getting Started

To start working with Khata, follow these steps:

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/qasimnauman/e_khata.git
   ```

2. Open the solution file located in the `E-Khata Project.sln` folder using Visual Studio or VS Code.

## Project Structure

The project is organized into the following folders:

1. **Data Controllers**: Here, you'll find all the files involving the operations with the database and the `DBHelper.cs` file with the connection string

2. **Data Models**: Here, you'll find classes that hold the models for all the classes(tables) that are being used in the whole project

3. **E-Khata Project**: The frontend project responsible for delivering a seamless user experience.

## Setting Up Database

Before running the project, ensure you have set up a SQL Server database with the details of all the tables as in the below attached database daigram and add the connection string to the `DBhelper.cs` file under the Data Controllers.

```C#
// DBHelper.js
{
  SqlConnection connection = new SqlConnection("Your Connection String")
}
```

## Running the Project

Run the project in Visual Studio or VS Code by loading the solution file in the `E-Khata Project` folder. Make sure the database connection string is correctly configured.

## Contributing

Contributions are welcome! If you encounter any issues or have suggestions for improvement, feel free to open an issue or create a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
