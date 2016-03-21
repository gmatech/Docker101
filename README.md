# Docker 101

## General Development Tool Setup

	1. Install Docker Toolbox
    
        https://www.docker.com/products/docker-toolbox
    
    2. Install nodejs
    
        https://nodejs.org/en/
        
	2. Install Yeoman
    
        npm install -g yo
        
	3. Install Bower
    
        npm install -g bower
    
	4. Install Gulp
    
        npm install -g gulp
        
	5. Install Yeoman generator for ASP.NET
    
        npm install -g generator-aspnet
        
	6. Install ASP.NET Core 1.0 (ASP.NET 5)
    
        https://get.asp.net/
        
    7. Install VSCode
    
        https://code.visualstudio.com/
        

## ASP.NET Core 1.0 on Linux
        
	1. Install Linux runtime
    
        dnvm install latest –r coreclr –OS linux
        
    2. Build Docker image linuxcoreserver using dockerfile.lcore
    
        docker build -t linuxcoreserver .
        
## Create container with an ASP.NET 1.0 Core Web App
        
	1. Scaffold Web app (folder with name of app will be created)
    
        yo aspnet
        
    2. Restore Nuget Packages (in app folder from step 1)
        dnu restore
        
    3. Cause web server (kestrel) to run on port 8080
        Create file "hosting.json" with following contents (in app folder from step 1):
        {
            "server.urls": "http://0.0.0.0:8080"
        }
        
	4. Publish App (in app folder from step 1)
    
        dnu publish --no-source --out ./release/app --runtime dnx-coreclr-linux-x64.1.0.0-rc1-update1 --configuration release
        
        You will get errors if full path to publish folder is too long
        
	5. Copy Docker.lrel (from github dockerfiles) to [app folder]/release
    
	6. Build Docker image from [app folder]/release
    
        docker build –t [image name:tag] .
        
	7. Run the App
    
        docker run –d –-name [some arbitrary name] –p 8080:8080 [image name:tag]
        
    8. Get VM IP address
    
        docker-machine ip [VM name]
        
	9. View ASP.NET Core sample app app in browser
    
        Browse to http://docker-machine ip:8080/

***

## Docker on Azure

docker-machine create -d azure --azure-subscription-id="[from 3 above]" --azure-subscription-cert="yourcert.pem [from 3 above]" [machine-name]

***

## Resources

### General

1. [Excellent documention on Docker site](http://www.docker.com/)
2. [Docker High Level Whiteboard (Channel 9 Presentation)](https://channel9.msdn.com/Blogs/Regular-IT-Guy/Docker-High-Level-Whiteboard)

### Docker on Windows

[Windows Containers Quick Start - Docker](https://msdn.microsoft.com/en-us/virtualization/windowscontainers/quick_start/manage_docker)

### Docker with Linux on Azure

1. Getting started: https://azure.microsoft.com/en-us/documentation/articles/virtual-machines-docker-vm-extension/
2. Install the Azure CLI: https://azure.microsoft.com/en-us/documentation/articles/xplat-cli-install/
3. Docker Machine: https://azure.microsoft.com/en-us/documentation/articles/virtual-machines-docker-machine/

### VSCode

1. [Using VSCode with ASP.NET Core](https://code.visualstudio.com/docs/runtimes/aspnet5)




