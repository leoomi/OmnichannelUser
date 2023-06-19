# OmnichannelUser

Project for a coding interview.

This project requires npm version 9.5.1, and dotnet core 7 and docker (to creeate a PostgreSQL database).
To initialize the database (the version can likely be altered):
```
docker run --name postgres15 -p 5432:5432 -e POSTGRES_USER=root -e POSTGRES_PASSWORD=password -d postgres:15.3-alpine3.18
```
The port and credentials are hardcored in the backend, so these can't be changed.

For the backend project, cd to the server folder and install the necessary dependencies:
```
dotnet restore
dotnet tool install --global dotnet-ef
```
To migrate the database, cd to the OmnichannelUser.Infrastructure folder and run:
```
dotnet ef database update
```
To run the backend server, cd to the OmnichannelUser.API and run:
```
dotnet run
```

For the frontend project, cd to the app folder and install the necessary dependencies:
```
npm install
npm install -g @angular/cli
```
And run the app:
```
ng serve
```

Missing features:
1. Running everything in docker containers.
2. Display errors properly in the frontend (currently just displaying and alert).
3. Create the Solution Design in C4 Model.
4. Create the Architectural Vision design in C4 Model.
