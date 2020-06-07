# Bug Tracker
This project is a bug tracker for a software company called ‘Stoneware’. It is aimed to help the software development team to keep track of their bugs. 

This is the 6th Project as part of Openclassroom's Backend .NET Path. It is about creating a backend side of a BugTracker application. It involves creating code-first migration using entity framework, creation of stored procedures in SQL server to retrieve data and writing repository class as an interface to the database for front end client. It also involves writing integration tests to ensure that data access logic works as intended.

# Key features
•	Users can create bugs for a given product, version and operating system.

•	Each bug captures created date, description, resolution, product name, operating system, version and a resolved date.

•	Once a bug is resolved, users can fill in the resolution and update the status to ‘resolved’.

•	Each bug has a lifecycle of four different statuses. A) created b) in progress c) resolved d) closed.

•	All data retrieval is implemented as a backend stored procedure and a function that will execute on the SQL server for maximum speed.

•	Users will be able to retrieve issues by different filters namely date range, version, product name, status and also a list of keywords.

•	A .NET Web application will make calls to these stored procedure for its data fetching needs.

# Technology stack used

This project uses

•	SQL Server as a backend database

•	.Net Core, C#, MVC for Web application

•	Razor, C# and JavaScript for rendering Views for supporting Frontend side



# Entity Relationshipt diagram

![](https://github.com/dilipagheda/oc-p6-bugtracker/blob/master/screenshots/database-diagram.PNG)


# Stored Procedures

## GET_ALL_ISSUES_BY_STATUS
### Description
This stored procedure allows user to retrieve all issues by status.

Status can have one of the 4 possible values.

•	Created

•	In progress

•	Resolved

•	Closed

In order to find out outstanding issues, pass the status as ‘created’.

In order to find out resolved issues, pass the status as ‘resolved.

### Input Parameters
 •	Status
### Example Usage
```
EXEC [dbo].[GET_ALL_ISSUES_BY_STATUS] 'created'
EXEC [dbo].[GET_ALL_ISSUES_BY_STATUS] 'in progress'
EXEC [dbo].[GET_ALL_ISSUES_BY_STATUS] 'resolved'
EXEC [dbo].[GET_ALL_ISSUES_BY_STATUS] 'closed'
```

## GET_ALL_ISSUES_BY_PRODUCTNAME_VERSION_STATUS
### Description
This stored procedure allows user to retrieve all issues by product name, version and status

### Input Parameters
•	Version

•	ProductName

•	Status

### Example Usage
```
EXEC [dbo].[GET_ALL_ISSUES_BY_PRODUCTNAME_VERSION_STATUS] '5.6.2.3', 'Intelligent Concrete Soap', 'created'
```

## GET_ALL_ISSUES_BY_PRODUCTNAME_VERSION_KEYWORDS_STATUS
### Description
This stored procedure allows user to retrieve all issues by
Product name, version, keywords and status.

Keywords will be matched against the issue description.

Keywords should be delimited by ; 

e.g., ‘abc;def;geh’ contains three separate keywords.

Note: Only those issues will be returned that contains all given keywords.

### Input Parameters
•	VersionName
•	ProductName
•	Keywords
•	Status

### Example Usage
`EXEC [dbo].[GET_ALL_ISSUES_BY_PRODUCTNAME_VERSION_KEYWORDS_STATUS] '5.6.2.3', 'Intelligent Concrete Soap', 'minus;soluta', 'created'`

## GET_ALL_ISSUES_BY_PRODUCTNAME_STATUS
### Description

This stored procedure allows user to retrieve all issues by
Product name and status.

### Input Parameters

•	ProductName

•	Status

### Example Usage
`EXEC [dbo].[GET_ALL_ISSUES_BY_PRODUCTNAME_STATUS] 'Intelligent Concrete Soap', 'created'`

## GET_ALL_ISSUES_BY_PRODUCTNAME_KEYWORDS_STATUS
### Description
This stored procedure allows user to retrieve all issues by product name and keywords.

Keywords is a string contains keywords seperated by ;

### Input Parameters

•	ProductName

•	Keywords

•	Status

### Example Usage
`EXEC [dbo].[GET_ALL_ISSUES_BY_PRODUCTNAME_KEYWORDS_STATUS] 'Intelligent Concrete Soap', 'minus;quas','created'`

## GET_ALL_ISSUES_BY_KEYWORDS_STATUS
### Description
This stored procedure allows user to retrieve all issues by keywords and a status
### Input Parameters

•	Keywords

•	Status

### Example Usage
`EXEC [dbo].[GET_ALL_ISSUES_BY_KEYWORDS_STATUS] 'minus;quas','created'`

## GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_VERSION_STATUS
### Description
This stored procedure allows user to retrieve all issues by product name, version and a status.
### Input Parameters

•	MinDate

•	MaxDate

•	ProductName

•	Version

•	Status

### Example Usage
```EXEC [dbo].[GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_VERSION_ STATUS] '04/06/2020','05/05/2020', 'Intelligent Concrete Soap','5.6.2.3', ,'created'```

## GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_VERSION_KEYWORDS_STATUS
### Description
This stored procedure allows user to retrieve all issues by date range, product name, version, keywords and status.

Date range is specified by passing minimum date and maximum date as parameters. Date is of the format of dd/mm/yyyy.

### Input Parameters

•	MinDate

•	MaxDate

•	ProductName

•	Version

•	Keywords

•	Status

### Example Usage
```

EXEC [dbo].[GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_VERSION_KEYWORDS_STATUS] '04/06/2020','05/05/2020', 'Intelligent Concrete Soap','5.6.2.3', 'minus','created'

```

## GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_STATUS
### Description

This stored procedure allows user to retrieve all issues by date range, product name and status.

Date range is specified by passing minimum date and maximum date as parameters. Date is of the format of dd/mm/yyyy.

### Input Parameters

•	MinDate

•	MaxDate

•	ProductName

•	Status

### Example Usage
`EXEC [dbo].[GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME _STATUS] '04/06/2020','05/05/2020', 'Intelligent Concrete Soap', 'created'`

## GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_KEYWORDS_STATUS
### Description
This stored procedure allows user to retrieve all issues by date range, product name, keywords and status

Date range is specified by passing minimum date and maximum date as parameters. Date is of the format of dd/mm/yyyy.

### Input Parameters

•	MinDate

•	MaxDate

•	ProductName

•	Keywords

•	Status

### Example Usage

```EXEC [dbo].[GET_ALL_ISSUES_BY_DATERANGE_PRODUCTNAME_VERSION_KEYWORDS_STATUS] '04/06/2020','05/05/2020', 'Intelligent Concrete Soap', 'minus','created'```



