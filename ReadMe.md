
## Requirements
To run the local application in containers, you will need to download and install the following:
- [Docker Desktop](https://docs.docker.com/desktop/#download-and-install)
- [Docker Compose](https://docs.docker.com/compose/install/compose-desktop/)

1. Run Docker Desktop.
2. Open the command prompt (cmd), navigate inside the project "\Vilmar.Realtime.Chat" folder, and type: "docker-compose build" to build the containers (this is only necessary the first time).
3. Type "docker-compose up -d" to start the application containers.
4. Now you can view the application:
	- To run the Web Application, navigate to http://localhost:7039

to stop the execution of the containers, type "docker-compose down"

 - You can also run everything at Visual Studio with docker-compose profile