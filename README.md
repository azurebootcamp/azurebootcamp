# Azure Bootcamp Template

This is the GitHub repository for Azure Bootcamp - Singapore Chapter. 
The live version of 2015 bootcamp website (hosted as Azure Website) is available at 
- Main website: **[Singapore Azure Bootcamp](http://singapore.azurebootcamp.net)**
- Routed website: **[Singapore Azure Bootcamp](http://globalazurebootcampsg.azurewebsites.net)**

Feel free to **fork** it and use it, but do remember to update the Speaker and Sponsors photographs

## Technology Stack

- HTML5
- jQuery
- CSS3
- Google API
- Facebook API

## How to use it?

- Fork the master branch
- Clone on desktop
- Use Visual Studio or  Sublime Text
- Start editing html/js/css files
- Google Map: To change location of your map, you can follow steps provided here [Embed Maps](https://developers.google.com/maps/documentation/embed/guide)
- After going live, you may want to scrape new Facebook link for your site address at [Facebook Debugger](https://developers.facebook.com/tools/debug/)

## Wishlist

- Read the list of speakers (and their profile pic) and agenda from JSON file

## Continous Deployment to Azure WebApp

- When setting up the GitHub URL, please make sure you are using the Forked version
- After the deployment has succeeded, you will get HTTP 404 or HTTP 403 error
- To fix that, in the WebApp > Configure tab, make sure that the virtual path settings look like /  points to      site\wwwroot\2015\src
- Once changed, save the settings and refresh the website

## Configuring subdomain like region.azurebootcamp.net

- Login to [Gloabl Site](http://global.azurebootcamp.net)
- Select your host (say, singapore.azurebootcamp.net) and add CNAME to your Azure WebApp (like, globalazurebootcampsg.azurewebsites.net)
- On Azure website (globalazurebootcampsg.azurewebsites.net), add DNS (singapore.azurebootcamp.net) and set Mode=Standard/Basic (but not free)
- Now access sub-domain website (say, singapore.azurebootcamp.net) and it will route to globalazurebootcampsg.azurewebsites.net

## Other regions who have adopted this design (in 2015)

- Singapore: [http://singapore.azurebootcamp.net](http://singapore.azurebootcamp.net)
- Sri Lanka: [http://colombo-bootcamp.azurewebsites.net](http://colombo-bootcamp.azurewebsites.net)
- Bhubhaneswar, India: [http://bhubaneswar.azurebootcamp.net/](http://bhubaneswar.azurebootcamp.net/)
- Mexico: [http://bootcamp.azurewebsites.net/](http://bootcamp.azurewebsites.net/)
- Melbourne: [http://melbourne.azurebootcamp.net/](http://melbourne.azurebootcamp.net/)
- Malaysia: [http://malaysiaazurebootcamp.azurewebsites.net/](http://malaysiaazurebootcamp.azurewebsites.net/) or [http://malaysia.azurebootcamp.net/](http://malaysia.azurebootcamp.net/)
- Jakarta, Indonesia: [http://azurebootcamp.nozyra.com/](http://azurebootcamp.nozyra.com/) or [http://jakarta.azurebootcamp.net/](http://jakarta.azurebootcamp.net/)
- Batam, Indonesia: [http://azurebootcamp.uib.ac.id/](http://azurebootcamp.uib.ac.id/)
- Bandung, Indonesia: [http://bandung.azurebootcamp.net/](http://bandung.azurebootcamp.net/)
- Pune, India: [http://www.puneusergroup.org/events/gabc2015/index.html](http://www.puneusergroup.org/events/gabc2015/index.html)

## Windows and Windows Phone Application

- To have your region included in the Windows and Windows Phone application, drop a note to [Senthamil Selvan](mailto:altfo@hotmail.com) with the link to site using this template
- Download [Windows Phone App](http://www.windowsphone.com/en-us/store/app/azure-bootcamp/7bfca9ec-ab1d-4f12-a7c3-ee5605bc1c2d)
- Download [Windows Store App](http://apps.microsoft.com/windows/en-sg/app/azure-bootcamp/8145678d-480b-43f8-b5e5-f6fcc31565fb)
