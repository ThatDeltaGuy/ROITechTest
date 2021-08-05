# ROITechTest
Tech Test for roiltd.co.uk


C# Interview task.
----------------

The purpose of this task is to
demonstrate your knowledge of c# and linq. We do not expect you to spend
more than a couple of hours on this, we are looking for just enough to
provide some talking points.
Due
to the time constraints you may have a lot of ideas, for improvements
and extra functionality you could add. Feel free to include these with
your submission.

Command Line To-Do
----------------
The purpose of this task is to create a console app in c# that can maintain a To-Do list.
You
can save the data where ever you want. But the program should be
portable and not depend on any external programs being installed
You can use any NuGet packages you like to facilitate your implementation.

Required Functionality
* A user can add an entry to the To-Do list via the command line
* The To-Do entity will have at minimum a title, due date and can be marked as done
* A user can list all entries in the To-Do list via the command line
* A user can mark an entry as done via the command line
* The console app should not be interactive, but accept arguments for example creating a To_Do entry may look like:
     c:\todo.exe -add -title "New Item" -date "01/01/2020"

Desirable Functionality
* Data should be human-readable outside of the application you create
* Sorting the list
* Filtering
* Filter and Bulk update.  i.e. Set all tasks on Tuesday to done

-------------------------

# Usage

ToDoList.exe [verb] [-options]

Verbs
----------------

Verb | Description
------------ | -------------
add | Adds a Task
view | (Default Verb) Views Tasks
complete | Completes a Task
help | Display more information on a specific command.


add
----------------

ToDoList.exe add [-options]

Option | Description
------------ | -------------
  -t, --title | (Required) Task Title
  -d, --due-date | (Required) Task Due Date (in format dd/mm/yyyy)
  --description | Task Description
  --help | Display help screen
  
  
complete
----------------

ToDoList.exe complete [-options]

Option | Description
------------ | -------------
  -i, --id | Id of task to complete
  --help | Display help screen

view
----------------

ToDoList.exe view [-options]

Option | Description
------------ | -------------
  -c, --complete | Sets Returned Tasks To Complete
  -f, --filter | Filters Tasks By Title or Due Date (in format dd/mm/yyyy)
  -s, --sort | Sort Tasks By Field.
  --help | Display help screen
