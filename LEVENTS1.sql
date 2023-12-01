create database LEVENTS
go

use LEVENTS

--bảng người dùng
create TABLE Users (
	UserId INT PRIMARY KEY Identity,
	UserName VARCHAR(50) unique,
	Password VARCHAR(50),
	Role VARCHAR(50),
);

-- teletele
--bảng khách hàng
create TABLE Customers (
    CustomerId INT PRIMARY KEY Identity,
	CustomerName NVARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(15),
    Address NVARCHAR(255),
	UserId INT,
	FOREIGN KEY (UserId) REFERENCES Users(UserId) on delete cascade
);


--bảng bộ sưu tập
create TABLE Collections (
    CollectionId INT PRIMARY KEY Identity,
    CollectionName VARCHAR(255) NOT NULL,
    Description NVARCHAR(1000),
	Image varchar(255)
	
);
alter table Collections 
add ImageAfter varchar(255)

create table ProductTypes (
	ProductTypeId int primary key identity,
	ProductTypeName nvarchar(50),
)

create table Producers (
	ProducerId int primary key identity,
	ProducerName Nvarchar(50)
)

--bảng sản phẩm
create TABLE Products (
    ProductId INT PRIMARY KEY Identity,
    ProductName VARCHAR(255),
    Price int,
    Size VARCHAR(20),
	Description NVARCHAR(1000),
	Image varchar(255),
	CreatedAt date default getdate(),
	ProductTypeId int,
	CollectionId INT,
	ProducerId int, 
	FOREIGN KEY (CollectionId) REFERENCES Collections(CollectionId),
	FOREIGN KEY (ProductTypeId) REFERENCES ProductTypes(ProductTypeId),
	FOREIGN KEY (ProducerId) REFERENCES Producers(ProducerId)
); 


alter table Products 
add ImageAfter varchar(255)

-- bảng hóa đơn
create table Bills (
	BillId INT PRIMARY KEY Identity,
	TotalPrice INT,
	Status bit,
	CreatedAt date default getdate(),
	UpdatedAt date default getdate(),
	CustomerId INT,
	FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

-- bảng chi tiết hóa đơn
create table DetailBills (
	DetailBillID INT PRIMARY KEY Identity,
	Price INT,
	Amount INT,
	CreateAt date default getdate(),
	UpdatedAt date default getdate(),
	BillId INT,
	ProductId INT,
    FOREIGN KEY (BillId) REFERENCES Bills(BillId) on delete cascade,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
);


-- Chưa làm
--bảng bộ phối 
create TABLE Mixers (
    MixerId INT PRIMARY KEY Identity,
    MixerName VARCHAR(255) NOT NULL,
    Description NVARCHAR(1000),
    ProductId INT,
	FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);


--bảng bài viết 
create TABLE Posts (
    PostId INT PRIMARY KEY Identity,
    Title VARCHAR(255),
    Content TEXT,
	CreatedAt date,
	UpdatedAt date
);

--bảng sản phẩm yêu thích 
create TABLE Favorite (
    FavoriteId INT PRIMARY KEY Identity ,
    ProductId INT,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

--bảng giỏ hàng 
create TABLE Orders (
    OrderId INT PRIMARY KEY Identity,
    ProductId INT,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);



---------------------Store Procedure---------------------------

-- User
create proc sp_hien_thi_Users 
as
begin
	select * from Users
end

create PROC sp_login (@UserName varchar(50), @Password varchar(50))
AS
BEGIN
	SELECT * FROM Users  
	WHERE UserName = @username and Password = @password
END

create proc sp_tim_theo_id_Users (@UserID int)
as
begin
	select * from Users
	where UserID= @UserID
end


create proc sp_them_Users
	(
	@UserName VARCHAR(50),
	@Password VARCHAR(50),
	@Role VARCHAR(50)
)
as
begin
	insert into Users( UserName, Password, Role)
	values( @UserName, @Password, @Role)
end


create proc sp_sua_Users
(	
	@UserID int,
	@UserName VARCHAR(50),
	@Password VARCHAR(50),
	@Role VARCHAR(50)
)
as
begin
	update Users
	set	UserName = @UserName,
		Password = @Password,
		Role = @Role
	where UserId = @UserID
			
end


create proc sp_xoa_Users (@UserID int)
as
begin
	delete from Users
	where UserID = @UserID
end



-- Customers
create proc sp_get_by_id_Customers 
(
	@CustomerId int
)
as
begin
	select * from Customers
	where CustomerId = @CustomerId
end


create proc sp_them_Customers
(
	@CustomerName NVARCHAR(50),
    @Email VARCHAR(100),
    @Phone VARCHAR(15),
    @Address NVARCHAR(255),
	@UserId INT
)
as
begin
	insert into Customers( CustomerName, Email, Phone, Address, UserId)
	values(@CustomerName, @Email, @Phone, @Address, @UserId)
end



create proc sp_sua_Customers
(	
	@CustomerId int,
	@CustomerName NVARCHAR(50),
    @Email VARCHAR(100),
    @Phone VARCHAR(15),
    @Address NVARCHAR(255),
	@UserId INT
)
as
begin
	update Customers
	set	CustomerName = @CustomerName,
		Email = @Email,
		Phone = @Phone,
		Address = @Address,
		UserId = @UserId
	where CustomerId = @CustomerId
			
end



create proc sp_xoa_Customers (@CustomerId int)
as
begin
	delete from Customers
	where CustomerId = @CustomerId
end



create PROCEDURE sp_tim_kiem_Customers (
	@page_index  INT, 
    @page_size   INT,
	@name Nvarchar(50)
)
AS
    BEGIN
        DECLARE @RecordCount BIGINT;

		SELECT(ROW_NUMBER() OVER(ORDER BY c.CustomerName ASC)) AS RowNumber, 
				c.CustomerId,
				c.CustomerName,
				c.Email,
				c.Phone,
				c.Address,
				c.UserId
		INTO #Results1
		FROM Customers AS c
		WHERE  (@name = '' Or c.CustomerName like N'%'+@name+'%')
						
		SELECT @RecordCount = COUNT(*)
		FROM #Results1;

		SELECT *, @RecordCount AS RecordCount
		FROM #Results1
		WHERE ROWNUMBER BETWEEN (@page_index - 1) * @page_size + 1 AND   -- 0 * 4 and (0 * 4 + 3) - 1 = 2 or -1
		(((@page_index - 1) * @page_size + 1) + @page_size) - 1 OR @page_index = -1;

		DROP TABLE #Results1; 

    END;
go


-- Collections
create proc sp_get_by_id_Collections
(
	@CollectionId int
)
as
begin
	select * from Collections
	where CollectionId = @CollectionId
end


create proc sp_them_Collections
(
	@CollectionName VARCHAR(255),
    @Description NVARCHAR(1000),
	@Image varchar(255)
)
as
begin
	insert into Collections(CollectionName, Description, Image)
	values(@CollectionName, @Description, @Image)
end



create proc sp_sua_Collections
(	
	@CollectionId INT ,
    @CollectionName VARCHAR(255) ,
    @Description NVARCHAR(1000),
	@Image varchar(255)
)
as
begin
	update Collections
	set	CollectionName = @CollectionName,
		Description = @Description,
		Image = @Image
	where CollectionId = @CollectionId
			
end


create proc sp_xoa_Collections (@CollectionId int)
as
begin
	delete from Collections
	where CollectionId = @CollectionId
end



alter PROCEDURE sp_tim_kiem_Collections (
	@page_index  INT, 
    @page_size   INT,
	@CollectionName Nvarchar(50)
)
AS
    BEGIN
        DECLARE @RecordCount BIGINT;

		SELECT(ROW_NUMBER() OVER(ORDER BY cl.CollectionName ASC)) AS RowNumber, 
				cl.CollectionId,
				cl.CollectionName,
				cl.Description,
				cl.Image,
				cl.ImageAfter
		INTO #Results1
		FROM Collections AS cl
		WHERE  (@CollectionName = '' Or cl.CollectionName like N'%'+ @CollectionName+'%')
						
		SELECT @RecordCount = COUNT(*)
		FROM #Results1;

		SELECT *, @RecordCount AS RecordCount
		FROM #Results1
		WHERE ROWNUMBER BETWEEN (@page_index - 1) * @page_size + 1 AND   -- 0 * 4 and (0 * 4 + 3) - 1 = 2 or -1
		(((@page_index - 1) * @page_size + 1) + @page_size) - 1 OR @page_index = -1;

		DROP TABLE #Results1; 

    END;
go


----------------------------------------------------------------------

-- Products

alter proc sp_get_new_product
as
begin 
	select top 8 * from Products p
	order by p.CreatedAt
end 

sp_get_new_product

alter proc sp_get_by_id_Products
(
	@ProductId int
)
as
begin
	select * from Products
	where ProductId = @ProductId
end


create proc sp_them_Products
(
	@ProductName VARCHAR(255),
    @Price int,
    @Size VARCHAR(20),
	@Description NVARCHAR(1000),
	@Image varchar(255),
	@ProductTypeId int,
	@CollectionId INT,
	@ProducerId int
)
as
begin
	insert into Products(ProductName, Price, Size, Description, Image, ProductTypeId, CollectionId, ProducerId)
	values(@ProductName, @Price, @Size, @Description, @Image, @ProductTypeId, @CollectionId, @ProducerId)
end



create proc sp_sua_Products
(	
	@ProductId int,
	@ProductName VARCHAR(255),
    @Price int,
    @Size VARCHAR(20),
	@Description NVARCHAR(1000),
	@Image varchar(255),
	@ProductTypeId int,
	@CollectionId INT,
	@ProducerId int
)
as
begin
	update Products
	set	ProductName = @ProductName,
		Price = @Price,
		Size = @Size,
		Description = @Description,
		Image = @Image,
		ProductTypeId = @ProductTypeId,
		CollectionId = @CollectionId,
		ProducerId = @ProducerId
	where ProductId = @ProductId
			
end


create proc sp_xoa_Products (@ProductId int)
as
begin
	delete from Products
	where ProductId = @ProductId
end


create PROCEDURE sp_tim_kiem_Products (
	@page_index  INT, 
    @page_size   INT,
	@ProductName VARCHAR(255)
)
AS
    BEGIN
        DECLARE @RecordCount BIGINT;

		SELECT(ROW_NUMBER() OVER(ORDER BY p.ProductName ASC)) AS RowNumber, 
				*
		INTO #Results1
		FROM Products AS p
		WHERE  (@ProductName = '' Or p.ProductName like N'%'+ @ProductName+'%')

		SELECT @RecordCount = COUNT(*)
		FROM #Results1;

		SELECT *, @RecordCount AS RecordCount
		FROM #Results1
		WHERE ROWNUMBER BETWEEN (@page_index - 1) * @page_size + 1 AND   -- 0 * 4 and (0 * 4 + 3) - 1 = 2 or -1
		(((@page_index - 1) * @page_size + 1) + @page_size) - 1 OR @page_index = -1;

		DROP TABLE #Results1; 

    END;
go

---------------------------------------------------------------------------------

-- Bills
-- getbyid_bills

alter PROCEDURE sp_them_Bills
(
	@TotalPrice INT,
	@Status bit,
	@CustomerId INT,
	@list_json_DetailBills NVARCHAR(MAX)
)
AS
BEGIN
	DECLARE @BillId INT;
    INSERT INTO Bills (TotalPrice, Status, CustomerId)
	VALUES (@TotalPrice, @Status, @CustomerId)

    SET @BillId = (SELECT SCOPE_IDENTITY());

    IF(@list_json_DetailBills IS NOT NULL)
		BEGIN
            INSERT INTO DetailBills (Price, Amount, BillId, ProductId)
            SELECT	JSON_VALUE(p.value, '$.price'), 
					JSON_VALUE(p.value, '$.amount'),
                    @BillId,
                    JSON_VALUE(p.value, '$.productId')
            FROM OPENJSON(@list_json_DetailBills) AS p;
        END;
    SELECT '';
END;


-------------------------------------------------------------------------

create PROC sp_sua_Bills
(
	@BillId	INT,
	@TotalPrice INT,
	@Status bit,
	@CustomerId INT, 
	@list_json_DetailBills NVARCHAR(MAX)
)
AS
BEGIN
	UPDATE Bills
	SET TotalPrice = @TotalPrice,
		Status = @Status,
		UpdatedAt = GETDATE(),
		CustomerId = @CustomerId
	WHERE BillId = @BillId;
		
	IF(@list_json_DetailBills IS NOT NULL) 
	BEGIN

			-- Insert data to temp table 
		SELECT
			JSON_VALUE(p.value, '$.detailBillID') as DetailBillId,
			JSON_VALUE(p.value, '$.price') as Price,
			JSON_VALUE(p.value, '$.amount') as Amount,
			JSON_VALUE(p.value, '$.billId') as BillId,
			JSON_VALUE(p.value, '$.productId') as ProductId,
			JSON_VALUE(p.value, '$.status') as status
		INTO #Results 
		FROM OPENJSON(@list_json_DetailBills) AS p;
		 
		-- Insert data to table with STATUS = 1;
		INSERT INTO DetailBills(Price, Amount, BillId, ProductId) 
		SELECT
			#Results.Price,
			#Results.Amount,
			@BillId,
			#Results.ProductId
		FROM  #Results 
		WHERE #Results.status = '1'
			
		-- Update data to table with STATUS = 2
			UPDATE DetailBills 
			SET
				Price = #Results.Price,
				Amount = #Results.Amount,
				UpdatedAt = getdate(),
				ProductId = #Results.ProductId
			FROM #Results 
			WHERE  DetailBills.DetailBillId = #Results.DetailBillID 
				AND #Results.status = '2';
			
		-- Delete data to table with STATUS = 3
		DELETE db from DetailBills db
		INNER JOIN #Results R ON db.DetailBillID = R.DetailBillID
		WHERE R.status = '3';

		DROP TABLE #Results;
	END;
    SELECT '';
END;



Create PROC sp_xoa_Bills
	(@BillId int)
as
begin
	delete from Bills
	where BillId = @BillId
end

--------------------------------------------------------------------------
-- Thống kê
alter PROC sp_tim_kiem_Bills (
	@page_index  INT, 
    @page_size   INT,
	@ten_khach Nvarchar(50),
	@fr_NgayTao date, 
	@to_NgayTao date
)
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
		DECLARE @TotalPrice int;

        SELECT(ROW_NUMBER() OVER(
                ORDER BY b.CreatedAt ASC)) AS RowNumber, 
				b.*, c.CustomerName,
				(
					SELECT db.*
					FROM DetailBills db
					WHERE b.BillId = db.BillId FOR JSON PATH
				) AS list_json_DetailBills
        INTO #Results1
        FROM Bills b inner join Customers c on b.CustomerId = c.CustomerId
		WHERE  (@ten_khach = '' Or c.CustomerName like N'%'+ @ten_khach +'%') and					
		((@fr_NgayTao IS NULL AND @to_NgayTao IS NULL)
        OR (@fr_NgayTao IS NOT NULL AND @to_NgayTao IS NULL AND b.CreatedAt >= @fr_NgayTao) 
        OR (@fr_NgayTao IS NULL AND @to_NgayTao IS NOT NULL AND b.CreatedAt <= @to_NgayTao) 
        OR (b.CreatedAt BETWEEN @fr_NgayTao AND @to_NgayTao)) 
		
        SELECT @RecordCount = COUNT(*), @TotalPrice = Sum(TotalPrice)
        FROM #Results1;

        SELECT *, 
                @RecordCount AS RecordCount, @TotalPrice as Revenue
        FROM #Results1
        WHERE ROWNUMBER BETWEEN(@page_index - 1) * @page_size + 1 AND(((@page_index - 1) * @page_size + 1) + @page_size) - 1
                OR @page_index = -1;
        DROP TABLE #Results1; 
	end

go

DECLARE @page_index INT = 1; -- Đặt trang số 1
DECLARE @page_size INT = 30; -- Đặt kích thước trang 10
DECLARE @ten_khach NVARCHAR(50) = N'chien'; -- Đặt tên khách hàng
DECLARE @fr_NgayTao DATE = '2023-11-17'; -- Ngày bắt đầu
DECLARE @to_NgayTao DATE = '2023-10-31'; -- Ngày kết thúc
exec sp_tim_kiem_Bills '1', '10', 'chien', @fr_NgayTao, null


----------------------------------------------------------------------------------------------------------
-- Mixers
create proc sp_hien_thi_Mixer
as
	begin
		select * from Mixer
	end

create proc sp_them_Mixer
	(@MixerID INT,
	@MixerName VARCHAR(255),
	@Description NVARCHAR(50),
	@ProductID INT)
as
	begin
		insert into Mixer(MixerID, MixerName, Description, ProductID )
		values(@MixerID, @MixerName, @Description, @ProductID )
	end

create proc sp_tim_kiem_Mixer (@MixerID int)
as
begin
	select * from Mixer
	where MixerID= @MixerID
end

create proc sp_sua_Mixer
	(@MixerID INT,
	@MixerName VARCHAR(255),
	@Description NVARCHAR(50),
	@ProductID INT)
as
	begin
		update Mixer
		set  MixerName = @MixerName , Description = @Description , ProductID = @ProductID 
		where MixerID = @MixerID
	end

	

create proc sp_xoa_Mixer
	(@MixerID int)
as
	begin
		delete from Mixer
		where MixerID = @MixerID
	end
--------------------------------------------------------------------------------------------------
-- Posts
create proc sp_hien_thi_Post
as
	begin
		select * from Post
	end

create proc sp_them_Post
	(@PostID INT,
	@Title VARCHAR(255),
	@Content TEXT)
	
as
	begin
		insert into Post(PostID, Title, Content )
		values(@PostID, @Title, @Content )
	end

create proc sp_tim_kiem_Post (@PostID int)
as
	begin
		select * from Post
		where PostID= @PostID
	end

create proc sp_sua_Post
	(@PostID INT,
	@Title VARCHAR(255),
	@Content TEXT)
as
	begin
		update Post
		set  Title = @Title , Content = @Content 
		where PostID = @PostID
	end

	

create proc sp_xoa_Post
	(@PostID int)
as
	begin
		delete from Post
		where PostID = @PostID
	end
--------------------------------------------------------------------
create proc sp_hien_thi_Favorite
as
	begin
		select * from Favorite
	end

create proc sp_them_Favorite
	(@FavoriteID INT,
	@ProductID INT)
	
as
	begin
		insert into Favorite(FavoriteID, ProductID )
		values(@FavoriteID, @ProductID )
	end

create proc sp_tim_kiem_Favorite (@FavoriteID int)
as
	begin
		select * from Favorite
		where FavoriteID= @FavoriteID
	end

create proc sp_sua_Favorite
	(@FavoriteID INT,
	@ProductID INT)
as
	begin
		update Favorite
		set  ProductID = @ProductID  
		where FavoriteID = @FavoriteID
	end

	

create proc sp_xoa_Favorite
	(@FavoriteID int)
as
	begin
		delete from Favorite
		where FavoriteID = @FavoriteID
	end
	
-----------------------------------------------------
create proc sp_hien_thi_Oder
as
	begin
		select * from Oder
	end

create proc sp_them_Oder
	(@ProductID INT)
as
	begin
		insert into Oder( ProductID )
		values( @ProductID )
	end

create proc sp_tim_kiem_Oder (@OderID int)
as
	begin
		select * from Oder
		where OderID= @OderID
	end

create proc sp_sua_Oder
	(@OderID INT,
	@ProductID INT)
as
	begin
		update Oder
		set  ProductID = @ProductID  
		where OderID = @OderID
	end

	

create proc sp_xoa_Oder
	(@OderID int)
as
	begin
		delete from Oder
		where OderID = @OderID
	end
----------------------------------------------------
