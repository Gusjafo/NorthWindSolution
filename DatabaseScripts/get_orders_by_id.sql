
create PROCEDURE [dbo].[get_orders_by_id]
    @orderId int
AS
BEGIN
    declare @tmpOrders table(
        orderId int not null primary key,
        orderDate datetime,
        orderNumber nvarchar(10),
        customerId int,
        customer varchar(255),
        totalAmount decimal(12,2),
        totalRecords int
    )
    insert into @tmpOrders
    select o.Id,o.OrderDate,o.OrderNumber,o.CustomerId,c.FirstName + ' ' + c.LastName customer,o.TotalAmount, 
    COUNT(*) OVER() TotalRecords
    from dbo.[Order] o with(nolock)
    inner join dbo.Customer c with(nolock) on o.CustomerId = c.Id
    where o.Id = @orderId

    select * from @tmpOrders

    select oi.Id, oi.OrderId,oi.ProductId,p.ProductName,oi.UnitPrice, oi.Quantity  
    from OrderItem oi with(nolock)
    inner join @tmpOrders t on oi.OrderId = t.orderId
    inner join Product p with(nolock) on oi.ProductId = p.Id
END
GO
