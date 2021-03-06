[Tech Training Tracker](https://techtrainingtracker.azurewebsites.net/)




Red Badge Individual MVC Project 

Using .NET Framework MVC Web Application with an n-tier architecture with layers for Data, Logic, and Presentation, I have built an application that allows a user or users to save
certifications achieved, training courses in progress or potential future courses, the skills learned, user data, and the companies from which the certifications and trainings were
associated.


Tech Training Tracker includes five tables: User, Company, Training, Certification, and Skill. 

Brainstorming and plotting out the project lasted two days: 

* Using Dbdiagram.io, tables were plotted and the foreign keys that would link them were referenced. 
* Using Trello, Agile methods were followed to plot and plan to do lists, user stories, MVP list, 
  stretch goals, and daily and weekly to do lists, as well as completion lists.
* Proposed project was discussed with Instructor Andrew Torr using Zoom to share the Dbdiagram.io link and discuss possible stretch goals.
* Instructor Andrew's advice and feedback was considered when making adjustments to the database and planning materials.
* For the planning document, current plans were listed and described. As the project continues, the database structures are expected to change, as will the planning schedule. Further changes are anticipated as the project progresses.
* Using GitHub, a secondary branch was created from the beginning, and additional branches were added as stretch goals were attempted. 
 

The Tech Training Tracker has been built with the idea that a user will create a login and once signed in will be able to see the headings to view certifications, trainings, users, skills, and companies. The idea is that recruiters and managers might also be able to use this application to keep track of jobseekers and employees.

Upon running the application, a user is able to create a user account or sign in to an existing account.

The user is able to:

1. Create a user identity, ID is automatically assigned upon creation.
2. Create a company. User will add a company that is offering their training and/or certification. An ID will be automatically assigned upon creation, and they can add as many      companies as needed.
3. Create a training. User will add a training course, an ID will be automatically assigned upon creation. When adding a training course, the user will need to know their UserID    and the CompanyID for the company offering the training.
4. Create a certification. User will add a certification, an ID will be automatically assigned upon creation. When adding a certification, the user will need to know their          UserID and the CompanyID, if available, for the company issuing the certification.
5. Create a skill. User will add a skill, an ID will be automatically assigned upon creation. When adding a skill, the user will need to know their UserID.






External Resources
During the creation of this app, progress was tracked using the following:

[Trello](https://trello.com/b/kqMWEYAk/red-badge-project) 

[GitHub](https://github.com/Stacy-Sanders/TechTrainingTracker) 

[dbdiagram.io](https://dbdiagram.io/d/62098ab385022f4ee587e1ae)


