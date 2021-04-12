USE DULICHVIETNAM
GO

-- Thu tuc kiem tra tai khoan admin
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
--------------------------quynh---------------------------

CREATE PROCEDURE KhachSan_GetAll
AS
BEGIN
  SELECT *
  FROM KHACHSAN
END
GO

