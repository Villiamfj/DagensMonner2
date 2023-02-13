# DagensMonner2
 A service that serves a daily suggestion of Monster Energy Drink, the idea of such service came from my chrome plugin at https://github.com/Villiamfj/MorgenMonner. The service is made with asp.net and uses mssql for storage, an instance of this service is currently running on https://dev-villiam.dk/monner.

## Requirements
- Docker

## How to run
1. Open the docker-compose file and change the password (remember this password)
2. Change the password in the connection string within `\DagensMonnerWithEntityFramework\appsettings` to match the given password.
3. call ```docker-compose up``` in a terminal
4. check localhost
5. Monner?

## Things that maybe change
- ConnectionString within a enviroment file
- A monner calendar? (a definite maybe)

## How monners are chosen
1. Fetch all but the last chosen monner from the database
2. Find the least chosen monner(Mmin) and the most taken monner(Mmax)
3. Calulate limit: `limit = (Mmin.TimesTaken + Mmax.TimesTaken)/2`
4. Choose a random monner from monners where the times taken is less than or equal to the limti.

## known issues
-  A race condition might occur, If the db is not completely started it may give connections issues, if this happens try again or start the database seperately like this:
    ```
    docker-compose up monner-db
    ( give it a minute )
    docker-compose up monner-service
    ```
-  There are no *edit* feature, the service simply expects there to be monners within the database, adding or removing monners can be done manually with software such as azure data studio.
-  The service is currently made to be used with a reverse proxy that handles https. However an instance running exposed to the world would probably need it.
