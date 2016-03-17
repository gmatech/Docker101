# Docker 101

## Docker on Windows

Getting started: https://msdn.microsoft.com/en-us/virtualization/windowscontainers/quick_start/manage_docker

***
## ASP.NET Core 1.0 on Linux
	1. Install nodejs (can use version managers nodist on Win and nvm on Mac)
        https://nodejs.org/en/
        
	2. Install ASP.NET Core 1.0 (ASP.NET 5)
        https://get.asp.net/
        
	3. Install Linux runtime
        dnvm install latest –r coreclr –OS linux
        
	4. Install Yeoman
        npm install -g yo
        
	5. Install Bower
        npm install -g bower
    
	6. Install Gulp
        npm install -g gulp
        
	7. Install Yeoman generator for ASP.NET
        npm install -g generator-aspnet
        
	8. Scaffold app
        yo aspnet
        
	9. Add the file hosting.json to scafolded folder with the contents:
        {
            "server.urls": "http://0.0.0.0:8080"
        }
        This causes the web server (kestrel) to listen on port 80
        
	10. Install Nuget packages
        dnu restore
        
	11. Publish app (You will get errors if full path to publish folder is too long)
        dnu publish --no-source --out .\release\app --runtime dnx-coreclr-linux-x64.1.0.0-rc1-update1 --configuration release
        
	12. Copy Docker.release file to .\release
    
    13. Build base image first
    
	14. Build Docker image from .\release
        docker build –t app1 .
        
	15. Run the app
        docker run –d –-name app1 –p 8080:8080 app1
        
    16. Get VM IP address
        docker-machine ip [VM name]
        
	16. View ASP.NET Core sample app app in browser
        Browse to http://docker-machine ip:8080/

***


