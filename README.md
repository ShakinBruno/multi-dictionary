# Multi Dictionary

### Author: Dominik Mikołajczyk

## Project Overview

The Multi Dictionary project is a console application designed to manage and query dictionaries of various languages. It allows users to load words from JSON files, add new languages and words, and generate statistical reports in PDF format. The application is built using .NET 7.0 and leverages libraries such as Aspose.Pdf for PDF generation.

## Project Objectives

The primary goal of this project is to provide a simple yet effective tool for managing multilingual dictionaries. Users can query the origin of words, add new entries, and generate usage statistics. The application ensures that all changes are persisted in JSON files, allowing for easy data management and retrieval.

## Requirements

- .NET 7.0 SDK is required to build and run this application.
- Aspose.Pdf library is used for generating PDF reports.

## Features

- **Add a New Word in an Existing Language**: Users can update an existing language dictionary by specifying the number of words they wish to add. The updated dictionary is then saved to a JSON file.
- **Add a New Language**: Users can introduce a new language to the system. A new JSON file is created to store the dictionary for this language.
- **Check the Origin of a Word**: Users can input a word to find out which languages it belongs to. The application searches through all loaded dictionaries and displays the results.
- **Generate Statistics File**: The application can generate a PDF report containing statistics about word references during the last session. This includes the number of times words were queried and the languages they belong to.
- **Exit the Program**: Users can exit the application gracefully.

## Usage

Upon starting the application, users are presented with a menu to select their desired action. The options include adding words, adding languages, checking word origins, generating statistics, and exiting the program. Invalid inputs are handled gracefully, returning the user to the main menu.

## Data Management

- **JSON Files**: Each language dictionary is stored in a separate JSON file within the `MultiDictionary` directory. Users can manually edit these files if needed.
- **PDF Reports**: Statistical reports are generated as PDF files and stored in the `Statistics` directory. These reports provide insights into the application's usage patterns.

## Getting Started

1. **Build the Application**: 
   Ensure you have .NET 7.0 SDK installed, then run:
   ```bash
   dotnet build
   ```

2. **Run the Application**: 
   ```bash
   dotnet run
   ```

3. **Follow the On-Screen Instructions**: 
   Use the menu to navigate through the application's features.
