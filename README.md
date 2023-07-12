# Programming Laboratory Class - Project: Multi Dictionary
### author: Dominik Mikołajczyk

## The task the of project
The aim of the project was to write a console application that loads from JSON (or XML) files a list of words of a given language. For each word entered by the user it will write out what language it comes from or that there is no such word in the database. The program has to allow user to add his own language and word list and save it to a JSON (or XML) file. The next time the program is run, such a file should be taken into account by the program.

## Requirements:        
.NET 7.0 is required to run this application in IDE, otherwise you have to fix potential errors.
        
## Functionalities
When the main menu is displayed, user has to type the number of desirable action. Invalid input results in cancellation of the action and return to the main menu. Each dictionary of language is saved in JSON format under "MultiDictionary" folder so it is possible to add, delete or modify data using only text editor. Also user can generate statistics PDF file which is saved under "Statistics" folder and it contains information such as how many words were referenced by user on last program usage or from which languages the referenced words came from. All functionalitites of application are as follows:
- ADD A NEW WORD IN AN EXISTING LANGUAGE - user enters the existing language he wants to update then specifies how many words he wants to add. If there were no errors the dictionary is successfully updated and saved to a file.
- ADD A NEW LANGUAGE - user enters the name of new language he wants to add and after that a new JSON file is created.
- CHECK THE ORIGIN OF THE WORD - user enters the word he is looking for and a message is displayed in console containing languages which the word is included in or that no such word exists in any of saved dictionaries.
- GENERATE STATISTICS FILE - generates PDF file containing information about application usage mentioned in the Functionalities introduction above.
- EXIT THE PROGRAM - exits the program.
