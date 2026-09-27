-- Base de datos para CS-003: Directorio de Empleados y Departamentos
-- Script compatible con SQL Server

CREATE DATABASE EmployeeDirectory;
GO

USE EmployeeDirectory;
GO

CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Position VARCHAR(100) NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    Department VARCHAR(100) NOT NULL
);
GO
