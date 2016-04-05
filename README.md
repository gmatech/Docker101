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
            "server.urls": "http://0.0.0.0:80"
        }
        
	4. Publish App (in app folder from step 1)
    
        dnu publish --no-source --out ./release/app --runtime dnx-coreclr-linux-x64.1.0.0-rc1-update1 --configuration release
        
        You will get errors if full path to publish folder is too long
        
	5. Copy Docker.lrel (from github repo folder dockerfiles) to [project folder]/release
    
	6. Build Docker image from [project folder]/release
    
        docker build –t name[:tag] .
        
	7. Run the Web App
    
        docker run –d --name [some arbitrary name] –p 8080:80 name[:tag]
        
    8. Get VM IP address
    
        docker-machine ip [VM name]
        
	9. View ASP.NET Core sample app app in browser
    
        Browse to http://docker-machine ip:8080/

***

## Commands

***

### .Net Core

dnu publish --no-source --out ./release/app --runtime dnx-coreclr-linux-x64.1.0.0-rc1-update1 --configuration release

### ASP.NET Core Docker Build [in projects release folder created by dnu publish]

docker build -t CatalogService[:tag] -f dockerfile.lrel .

docker build -t WebApp[:tag] -f dockerfile.lrel .

### Node Docker Build [in project folder]

docker build -t ShippingService[:tag] -f dockerfile.nrel .

### Docker Run

docker run --name CatalogService -d -p 8081:80 -v /Users/gerald/docker101/data:/data/app gmatech/docker101:CatalogService-v1

docker run --name ShippingService -d -p 8082:80 gmatech/docker101:ShippingService-v1

docker run --name WebApp -e "ASPNET_ENV=Staging" --link CatalogService --link ShippingService -d -p 8080:80 gmatech/docker101:WebApp-v1

***

## Docker on Azure

docker-machine create -d azure --azure-subscription-id="[from 3 above]" --azure-subscription-cert="yourcert.pem [from 3 above]" [machine-name]

***

## Resources

### General

1. [Excellent documention on Docker site](http://www.docker.com/)
2. [List of Docker Resources](https://github.com/veggiemonk/awesome-docker)
2. [NewStack Blog,Podcast and free ebooks](http://thenewstack.io/)

### Docker on Windows

1. [Windows Containers Quick Start - Docker](https://msdn.microsoft.com/en-us/virtualization/windowscontainers/quick_start/manage_docker)

### Docker with Linux on Azure

1. Install the Azure CLI: https://azure.microsoft.com/en-us/documentation/articles/xplat-cli-install/
2. Docker Machine: https://azure.microsoft.com/en-us/documentation/articles/virtual-machines-docker-machine/

### VSCode

1. [Using VSCode with ASP.NET Core](https://code.visualstudio.com/docs/runtimes/aspnet5)




