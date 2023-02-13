# DagensMonner2
 A service that serves a daily suggestion of Monster Energy Drink, the idea of such service came from my chrome plugin at https://github.com/Villiamfj/MorgenMonner. The service is made with ASP.NET and uses MSSQL for storage, an instance of this service is currently running on https://dev-villiam.dk/monner.

## Requirements
- Docker

## How to run
1. Open the docker-compose file and change the password (remember this password)
2. Change the password in the connection string within `\DagensMonnerWithEntityFramework\appsettings` to match the given password.
3. Call ```docker-compose up``` in a terminal
4. Check localhost
5. Monner?

## How monners are chosen
- I wanted randomness and variation this led to a pseudo-random algorithm with inforced variation.
1. Fetch all but the last chosen monner from the database
2. Find the least taken monner(Mmin) and the most taken monner(Mmax)
3. Calulate limit: `limit = (Mmin.TimesTaken + Mmax.TimesTaken)/2`
4. Choose a random monner from monners where the times taken are less than or equal to the limit.

## Things that maybe change
- ConnectionString within an enviroment file
- A monner calendar? (a definite maybe)

## Known issues
-  If the database is not completely started the service might fail to connect, if this happens try again or start the database seperately like this:
    ```
    docker-compose up monner-db
    ( give it a minute )
    docker-compose up monner-service
    ```
-  There are no *edit* feature, the service simply expects there to be monners within the database, adding or removing monners can be done manually with software such as azure data studio.
-  The service is currently made to be used with a reverse proxy that handles HTTPS. However an instance running exposed to the world would probably need to enable HTTPS.
