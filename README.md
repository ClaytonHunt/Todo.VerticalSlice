# Todo.VerticalSlice
A simple Todo application using Vertical Slice Architecture.

## Requirements
### Personas
- Larry Lister
	Larry likes to make lists, lists for everything. A list to track stuff at work. 
	A list to track jobs around the house. A list for groceries. A list for any and every thing.
- Gina GTD (Getting Things Done)
	Gina is all about Getting Things Done. She wants to keep her lists small by completing items
	and removing any clutter. Gina only wants a single list for everything she plans to do, but
	she likes to organize by calendar date. Prescheduling list items that absolutely must be done and
	reviewing what has previously happened.
- Forgetful Frank
	Frank is not very good at using a todo list. He wants to be more organized but struggles to
	remember that the list exists. Franks want a system that is so easy to put stuff in that there
	is no reason not to. He also needs the occasional reminder to check things off the list.
- Allie Acheiver
	Allie is an over achiever. Everything she does is motivated by the rewards that come with
	an achievment. A todo list is a perfect way to let her know she is meeting her goals.
- Worker Wallace
	Wallace is a working in the corporate environment. Every year at review time, his boss asks
	him to provide a list of acheivements from the past year. Wallace has trouble creating this
	list every year.

### Dictionary / Domain Language
User: A generic nonpersona that applies to all personas
Todo: A reminder of a task that needs to be completed.
Task: The actual work needed to complete a Todo.
Achievement: any kind of reward that comes with the completion of one or many todos.
Journal: A listing of previously defined and completed todos.
Flag: A named piece of meta data that can be applied to a Todo for filtering purposes.
	  Each Todo may have multiple Flags.
List: A group of Todos. Each user may have multiple Lists

### Features and Scenarios
- [ ] Add a Todo
	Applies to: Larry, Gina, Frank, Allie, Wallace
	Concepts: Todo, Task

	Frank 
	Wants to Create a Todo
	So that he can keep track of all his Tasks

	Scenarios:
	Disruptive Todo Creation 
	(Most helpful when adding to a different list from the one you are viewing)
	------------------------
	When Wallace is selecting to Add a Todo
	Then view is changed to Todo creation view
	
	NonDisruptive Todo Creation
	(Most helpful when adding to the currently viewed list)
	---------------------------
	When Gina is selecting to Add a Todo
	Then Todo creation view is appended to current Todo List

	Digital Personal Assistant Todo Creation
	(Most helpful when the Todo application is not the active application)
	----------------------------------------
	Given Frank's Digital Personal Assistant is activated
	When speaking to Add a Todo
	Then voice input is used to create Todo

- [ ] Complete a Todo
	Applies to: Larry, Gina, Frank, Allie, Wallace
	Concepts: Todo, Task, Achievement

	Allie
	Wants to Complete a Todo
	So that she can reach her next Acheivment goal

- [ ] Remove a Todo
	Applies to: Larry, Gina, Frank, Allie, Wallace
	Concepts: Todo

	Gina
	Wants to Remove no longer relavent Todos
	So that she can keep her List short and uncluttered

- [ ] Journal (Stretch Goal)
- [ ] Hightlight (Stretch Goal)
	Applies to: Wallace
	Concepts: Todo, Task, Flag

	Wallace
	Wants a way to Flag a Todo
	So that he can quickly find high impact things he as done for his year end review

- [ ] Authentication
	Login and Password will be used to Authenticate a User and keep each Users Todos separate.

## Application Structure
The application is broken into 2 intrinsic parts, Client side and Server side. The Client is a
Xamarin mobile application designed for both Android and iOS. The Server is an ASP.net core API.

### Client
Xamarin is by default configured to use the MVVM (Model, View, ViewModel) pattern. In this pattern, 
the application is broken into the 3 parts of the pattern.

The Model is a representation of business level information. The Model is intended to only be a bag of 
data. There should be no functionality that is contained within the Model, or that interacts directly with
the Model.

The View is a representation of what the user of the application should see. The View is bound to the ViewModel
and uses the ViewModel to interact with any business logic in the system. All actions and data being used
and/or represented by the View must be contained within the ViewModel.

the ViewModel is a representation of the data being displayed by the view and the actions that can be taken
by the View. The ViewModel may reference the Model in communication with the business logic, but should not
pass the Model directly through to the View as this causes complications within the Xamarin MVVM structure.

Our Xamarin Application, for this architecture exercise, will keep the MVVM pattern. The changes we will making 
are going to impact the Model and ViewModel the most. We will be breaking the application into several pieces
in an attempt to isolate the business functionality from the mobile application design. Here is a folder/project
breakdown for the application.

- UI
	- ToDo.Mobile (Main Xamarin.Forms application)
		- Behaviors (Helpers to allow interaction with the ViewModel)
		- ViewModels
		- Views
	- ToDo.Mobile.Android (Android specific styles and functionality)
	- ToDo.Mobile.iOS (iOS specific styles and functionality)
- Business
	- ToDo.Mobile.Business (business logic as it pertains to the Client application)
		- DataAbstraction (Interface for dealing with the data store)
- Data
	- ToDo.Mobile.Data (application data management)
- Shared
	- ToDo.Shared (Models for MVVM, same as Models for MVC)

### Server
ASP.net Core API is be default configured to use the MVC (Model, View, Controller) pattern. In this pattern, 
the application is broken into the 3 parts of the pattern.

The Model is a representation of business level information. The Model is intended to only be a bag of 
data. There should be no functionality that is contained within the Model, or that interacts directly with
the Model.

The View is a representation of what the user of the application should see. In the case of an API, the View
is the response sent as JSON from the API. There is no data binding for an API and the View directly represents
a serialization of the Model with some meta data added as part of the HTTP specification.

The Controller is a collection of methods that represent related actions available via the API.
The purpose of the controller is to provide an HTTP route and to wrap each action in an HTTP shell representing
both the request and the response. The Controller generaly configures HTTP responsabilities and then calls
down to a business layer which is where all the actual work takes place.

Our ASP.net application, for this architecture exercise, will keep the MVC pattern. The application will be
broken into multiple layers for the purpose of isolating the business logic from any changes made in the MVC layers.
Here is a folder/project breakdown for the application.

- UI
	- ToDo.Api (ASP.net Core MVC Application)
		- Controllers
- Business
	- ToDo.Business (business logic as it pertains to the Server application)
		- DataAbstractions
- Data
	- ToDo.Data
-Shared
	- ToDo.Shared (Models for MVC, same as Models for MVVM)