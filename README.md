# TRW

[![.NET](https://img.shields.io/badge/.NET-8.0-blue)](https://dotnet.microsoft.com/)
[![Language](https://img.shields.io/badge/language-C%23-green)](https://learn.microsoft.com/dotnet/csharp/)
[![Build](https://img.shields.io/badge/build-passing-brightgreen)](#)
[![License](https://img.shields.io/badge/license-Unspecified-lightgrey)](#)

A collection of **C# libraries, applications, and sample projects** designed to demonstrate reusable components, game logic, and testing utilities.  
The repository includes shared libraries, example applications, and unit testing infrastructure, making it a versatile base for experimenting with **.NET 8** projects.

---

## 📂 Repository Structure

- **AppLibraries/** — GUI components and supporting libraries (e.g., `GuiWords`).
- **Apps/** — Example applications showcasing usage of the libraries.
- **BuildProcessTemplates/** — Project templates and build configuration files.
- **CommonLibraries/** — Shared utilities and foundational code used across projects.
- **GameLibraries/** — Core game logic libraries.
- **Games/** — Example games, including **Pong** (updated to .NET 8).
- **UnitTesting/** — Base framework for unit tests, including binary tree usage in seek phases.
- **Configuration Files** — `.gitignore`, `.gitattributes`, `.tfignore`, `NuGet.config`.

---

## 🚀 Features

- Modular **application libraries** for GUI and common utilities.
- **Game libraries** with reusable logic for interactive applications.
- Example **Pong game** upgraded to .NET 8.
- **Unit testing framework** with binary tree search implementations.
- Build process templates for consistent project setup.

---

## 🔧 Getting Started

Clone the repository and build with .NET 8:

```bash
git clone https://github.com/winkert/TRW.git
cd TRW
dotnet build
