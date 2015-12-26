# Azure Bootcamp Template

## Technology Stack

- ASP.NET 5.0 (MVC 6)
- HTML5
- jQuery
- CSS3
- Google API
- Facebook API

## How to use it?

- You don't need to Fork it (unlike 2015 template) and you don't need to edit HTML code, or deploy this as well
- You just need to submit a pull request to create a json file with your event details and voila, the site is up!
- Detailed steps for json file and the entire process is documented at [AzureBootcamp-Data Wiki](https://github.com/punitganshani/azurebootcamp-data/wiki)

## Configuring subdomain like region.azurebootcamp.net

- Login to [Gloabl Site](http://global.azurebootcamp.net)
- Select your host (say, singapore.azurebootcamp.net) and add CNAME to your Azure WebApp (like, azurebootcamp2016.azurewebsites.net/**your-location**)
- Now access sub-domain website (say, singapore.azurebootcamp.net) and it will route to azurebootcamp2016.azurewebsites.net/**your-location**
