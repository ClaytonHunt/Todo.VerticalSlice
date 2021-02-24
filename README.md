# Todo.Hexagonal
A simple Todo application using Hexagonal (Ports and Adapters) Architecture.

## Requirements
Todo: Text describing a task that needs to be completed.

- [ ] Add a Todo
	As a user
	I want to create Todos
	So that I can keep track of tasks that I want to accomplish	
- [ ] Remove a Todo
	As a user
	I want to remove a Todo
	So that I can get rid of tasks that are no longer relevant
- [ ] Complete a Todo
	As a user
	I want the ability to complete a Todo
	So that I can show that it is finished
- [ ] Authentication (Stretch Goal)
	As a user
	I want to have ownership of my own Todos
	So that my tasks are different from everyone elses
- [ ] Journal (Stretch Goal)
	As a user
	I want to see previously completed Todos
	So that I can see my accomplishments over time
- [ ] Hightlight (Stretch Goal)
	As a user
	I want to be able to mark a Todo as important
	So that when I am looking at my accomplishments I can see which ones are most significant

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