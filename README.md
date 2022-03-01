# dotnet-barista-console
currently using .net Core 5.0

## Initial thoughts
This section were my initial thoughts on the project and how I was thinking of handling it: I see the project is broken up into two sections

-Obtaining data
-Calculating said obtained data

Obtaining: Luckily for me I have a common library that I update with a few tools that I use regularly. Which will come in handy with the "obtaining data" side if the project.
This will obtain the data and convert it to a json format.

Calculating: I would convert the users list into a dictionary which will then allow me to calucalte any existing users data via LINQ.

Note: Looking through my common library i see that the functions are only solutions without large scaling error handlings. Ill repurpose them while I code the solution.