jqSuite for ASP.NET MVC 4.6.0.0

===========================
Installlation
===========================

Download and unzip the contents of the archive to any convenient location. The package contains the following folders

- [VS2010_MVC3_Razor_SampleProject] - this is a sample working startup project for Visual Studio 2010 using MVC3 and the Razor View Engine syntax. The project contains a several different pages (view/controllers) demonstrating how to setup and use the different products in jqSuite - grid, chart, treeview, dropdownlist, etc. You can directly load the project file in VS2008 and run the project  to see the products in action.

- [VS2008_MVC2_SampleProject] - this is a sample working startup project for Visual Studio 2008, using MVC2 and the ASPX View Engine syntax. The project contains a several different pages (view/controllers) demonstrating how to setup and use the different products in jqSuite - grid, chart, treeview, dropdownlist, etc. You can directly load the project file in VS2008 and run the project  to see the products in action.

- [Files] - this is the folder that contains the files needed by jqSuite - binaries, javascript and css files. It contains the following subfolders:
	- [bin] - Contains the assembly DLL of the product (Trirand.Web.Mvc.dll). This is the assembly that you can reference directly in your MVC project.
	- [js] - Contains the javascript files required by jqSuite products.
	- [css] - contains the CSS files needed by individual products. 

============================
Adding to your project
============================

We recommend starting the sample projects in the [VS2010_MVC3_Razor_SampleProject] or [VS2008_MVC2_SampleProject] folders - it will immediately show you working solutions for all jqSuite products like grid, chart, treeview, dropdownlist, etc. A brief info on prerequisites below (we assume MVC3 and Razor syntax - for MVC2 / ASPX syntax, take a look at the VS2008 sample project).

1. Copy the files needed from the [Files] folder to your own project
	1.1 Reference Trirand.Web.Mvc.dll in your project (or directly copy it to the /bin folder)
	1.2 Copy the javascript files of the products you need to your [Scripts] folder. 
	1.3 Copy the CSS files of the jqSuite products to your [Content] folder.
2. A typical Razor *.cshtml View will look like this - note, that the Model of the grid needs to be defined in the [Models] folder:

@model sample_project.Models.OrdersJqGridModel
@using Trirand.Web.Mvc

<!doctype html>
<html lang="en">
<head>
    <title>Performance Linq</title>
    <!-- The jQuery UI theme that will be used by the grid. We reference it from the Microsoft CDN. -->    
    <link rel="stylesheet" type="text/css" media="screen" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.0/themes/redmond/jquery-ui.css" />
    <!-- The Css UI theme extension of jqGrid -->
    <link rel="stylesheet" type="text/css" href="../../Content/themes/ui.jqgrid.css" />    
    <!-- jQuery library is a prerequisite for jqGrid. We reference it from the Microsoft CDN.  -->
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.9.0.min.js" type="text/javascript"></script>
    <!-- language pack - MUST be included before the jqGrid javascript -->
    <script type="text/javascript" src="../../Scripts/trirand/i18n/grid.locale-en.js"></script>
    <!-- the jqGrid javascript runtime -->
    <script type="text/javascript" src="../../Scripts/trirand/jquery.jqGrid.min.js"></script>    
    <style type="text/css">
        body { font-size: 60%; }
    </style>
</head>
<body>
    <div>
        @Html.Trirand().JQGrid(Model.OrdersGrid, "JQGrid1")
    </div>
</body>
</html>

3. If you enounter any difficulties while defining the code in your View, Controller or Model, please refer to the sample project attached.
4. If this still does not help, take a look at our online demos here - http://trirand.net/demo.aspx
5. If you still have issues, post your questions in our public forums here - http://trirand.net/forum/ . Note that the forum is searchable and has more than 10,000 posts - it is possible that the question you have has already been asked and answered.

============================
Licensing
============================
This is our evaluation free 30-day trial license. We are very helpful to ALL customers, including trial customers and will gladly assist you 
with any problems you might have (send questions to support@trirand.net or better yet - to our public forums). 

To remove the trial message after the 30-day trial, just purchase the licensed versions and we will send you a download link to unrestricted licensed versions. It's as simple as that, no cryptic settings in configs, no registry settings - complete license freedom (so you can use it on test/deployment servers, 
have QA look it at without licenses issues, etc)

You can purchase developer versions here (http://www.trirand.net/licensing.aspx)

Regards,
Trirand Inc