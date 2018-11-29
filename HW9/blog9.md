---
title: Homework 9
layout: default
---
# Software Engineering Homework

## Homework 9

For this blog I will give a step by step instruction on how to deploy to Azure web services.

[Final Product](https://abergmanhw9.azurewebsites.net/)

### Step 1
Begin by logging on to Azure and clicking on SQL Databases:
* Click "Add"
* Make Database name
* Set the subscription
* Make a Resource Group
* Make a Server (Server Name, Admin, password)
* set Pricing Tier

![Picture](/HW9/Pictures/Step1.PNG)

![Picture](/HW9/Pictures/NewServer.PNG)

### Step 2 
Open up SQL Server Management Studios, then connect to the azure data base

![Picture](/HW9/Pictures/Step2.PNG)

* Copy the UP script over to SSMS
* Make sure that the connection (Upper corner drop down) is set to the name of the database you made on azure, i.e, not master
* Execute 

![Picture](/HW9/Pictures/Step3p2.PNG)


### Step 3 
 Back on Azure
 * Click "App Services"
 * Click "Add"
 * Click "Web App"
 * Click "Create"

 ![Picture](/HW9/Pictures/Step4.PNG)


### Step 4
Open Visual Studios then right click the solution in the solution explorer
* Click Publish
* Select Microsoft Azure App Service
* Click "Select Existing"
* Click "Publish"

![Picture](/HW9/Pictures/publish1.png)

![Picture](/HW9/Pictures/publish2.png)

![Picture](/HW9/Pictures/publish3.png)

![Picture](/HW9/Pictures/PublishFinal.png)

### Step 5
Open Azure Once Again:
* Click "SQL Databases"
    * Click "Connection Strings"
    * Copy the connection string
* Click "App Services"
    * select your project the click "Application Settings"
    * Scroll until you see "Connection Strings"
        * Enter the name of your Project
        * Paste the Connection String.
            * replace the "your_username" and "your_password" with the ones previously created, and get rid of brackets around them.
    * Click "Save"

![Picture](/HW9/Pictures/lastStep1.png)

![Picture](/HW9/Pictures/lastStep2.png)