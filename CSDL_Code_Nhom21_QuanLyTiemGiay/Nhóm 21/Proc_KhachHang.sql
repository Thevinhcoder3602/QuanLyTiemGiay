--Khách hàng_proc

---ListOfCustomers

CREATE PROC getKhachHang
AS BEGIN
SELECT MaKH, TenKH, DiaChi,SDT FROM tblKhachHang
END
GO

---InsertCustomer

CREATE PROC InsertKhachHang
@tenKH NVARCHAR(50), @diaChi NVARCHAR(50), @sDT NVARCHAR(50)
AS BEGIN
INSERT INTO tblKhachHang VALUES
(@tenKH, @diaChi, @sDT)
END
GO

---UpdateCustomer

CREATE PROC UpdateKhachHang
@maKH INT, @tenKH NVARCHAR(50), @diaChi NVARCHAR(50), @sDT NVARCHAR(50)
AS BEGIN
UPDATE tblKhachHang
SET TenKH = @tenKH, DiaChi = @diaChi, SDT = @sDT
WHERE MaKH = @maKH
END
GO

---DeleteCustomer

CREATE PROC DeleteKhachHang
@maKH INT
AS BEGIN
DECLARE @ketQua BIT = 1
IF EXISTS(SELECT * FROM tblKhachHang WHERE MaKH = @maKH)
	DELETE tblKhachHang WHERE MaKH = @maKH
ELSE
	SET @ketQua = 0
SELECT @ketQua
END
GO

---SearchCustomer

CREATE PROC SearchKhachHang
@tenKH NVARCHAR(50)
AS BEGIN
SELECT * FROM tblKhachHang WHERE TenKH LIKE '%' + @tenKH + '%'
END
GO

---ListCustomerIdName

CREATE PROC List_MaKH
AS BEGIN
SELECT CONVERT(NVARCHAR(50), MaKH) + ' | ' + TenKH FROM tblKhachHang
END
GO

