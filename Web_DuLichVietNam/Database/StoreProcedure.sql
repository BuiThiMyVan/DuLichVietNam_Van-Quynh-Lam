USE DULICHVIETNAM
GO

CREATE PROC KIEMTRAADMIN
	@tendangnhap VARCHAR(50),
	@matkhau VARCHAR(50)
AS
BEGIN
	DECLARE @count INT
	DECLARE @res BIT

	SELECT @count = count(*)
	FROM ADMIN
	WHERE TenDNAdmin = @tendangnhap AND MK = @matkhau

	IF @count > 0
		set @res = 1
	ELSE
		set @res = 0
	select @res
END

create proc Khachhang_ListAll
as
	select * from KHACHHANG

exec Khachhang_ListAll

create proc Khachhang_Insert
	@Name nvarchar(50),
	@NS date,
	@GT int,
	@SDT varchar(10),
	@Email varchar(50),
	@TenDN varchar(50),
	@MK varchar(50),
	@MaQuyen int
as
begin
	insert into KHACHHANG(TenKH,NgaySinh,GioiTinh,SDT,Email,TenDN,MK,MaQuyen)
	values(@Name,@NS,@GT,@SDT,@Email,@TenDN,@MK,@MaQuyen)
end
go

