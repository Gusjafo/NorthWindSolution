alter PROCEDURE [dbo].[SupplierPagedList]  
@page int,  
@rows int,
@searchTerm varchar(250) 
AS 
BEGIN  
 
 SELECT [Id]  ,CompanyName,ContactName,ContactTitle,
 City,Country,Phone,fax,
 COUNT(*) OVER() TotalRecords
 FROM [Supplier]
 WHERE CompanyName like '%' + @searchTerm + '%'
 order by [Id]
 OFFSET @rows*(@page - 1) ROWS                  
 FETCH NEXT @rows ROWS ONLY
 
END
GO
