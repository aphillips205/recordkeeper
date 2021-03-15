# Record Keeper
A simple .NET Core application designed to parse multiple record files and merge the contents of the files into one file.  The application consist of two projects: (1) a CLI and (2) an API.  There are four test files (records-comma.txt, records-piped.txt, records-spaced.txt and file1.text for testing) that can be place at a location of your choice.

## CLI

To use the CLI, you must run the console application and enter the appropriate parameters.  After the welcome message, enter the filepath(s) and the sort patterns(s) to display the data in the format you like.  The following are examples of the commands.

### Sort By Email Descending and then Last Name Ascending

    c:\records-comma.txt,C:\records-piped.txt,C:\records-spaced.txt email-desc,lastName-asc

### Sort By Birth Date Ascending

     c:\records-comma.txt,C:\records-piped.txt,C:\records-spaced.txt dateOfBirth-asc

### Sort By Last Name Descending

     c:\records-comma.txt,C:\records-piped.txt,C:\records-spaced.txt lastName-desc
     
## API

To use the API, set the API project as the Startup project.  You can connect to the following endpoints. 

### Post New Record

    POST /records - Add a new record line to a file.
   
 ### Get Records Sorted By Email
 
    GET /records/email - Returns records sorted by email.
    
 ### Get Records Sorted By Birth Date
    
    GET /records/birthdate - Returns records sorted by birthdate.
    
 ### Get Records Sorted By Name
 
    GET /records/name - Returns records sorted by name.
