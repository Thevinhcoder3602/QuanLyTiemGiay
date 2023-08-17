---Nhân Viên_proc

---Login

CREATE PROC DangNhap
@email NVARCHAR(50), @mk NVARCHAR(50)
AS BEGIN
DECLARE @trangthai BIT
IF EXISTS(SELECT * FROM tblNhanVien WHERE Email = @email AND MK = @mk)
	SET @trangthai = 1
ELSE
	SET @trangthai = 0
SELECT @trangthai
END
GO

---IsExistEmail

CREATE PROC KiemTraEmail
@email NVARCHAR(50)
AS BEGIN
DECLARE @ketQua BIT
IF EXISTS(SELECT * FROM tblNhanVien WHERE Email = @email)
	SET @ketQua = 1
ELSE
	SET @ketQua = 0
SELECT @ketQua
END
GO

--- UpdatePassword


CREATE PROC [dbo].[UpdateMatKhau]
@email NVARCHAR(50), @mk NVARCHAR(50)
AS BEGIN
UPDATE tblNhanVien
SET MK = @mk
WHERE Email = @email
END
GO

---GetEmployeeRole

CREATE PROC getVaiTroNV
@email NVARCHAR(50)
AS BEGIN
SELECT VaiTro FROM tblNhanVien WHERE Email = @email
END
GO

---ChangePassword

CREATE PROC ChangeMatKhau
@email NVARCHAR(50), @mkCu NVARCHAR(50), @mkMoi NVARCHAR(50)
AS BEGIN
DECLARE @mk NVARCHAR(50), @ketQua bit
SELECT @mk = MK FROM tblNhanVien WHERE Email = @email
IF @mk = @mkCu
BEGIN
    UPDATE tblNhanVien SET MK = @mkMoi WHERE Email = @email
	SET @ketQua = 1
END
ELSE SET @ketQua = 0
SELECT @ketQua
END
GO

---ListOfEmployees

CREATE PROC getNhanVien
AS BEGIN
SELECT MaNV, TenNV, DiaChi, SDT, Email, VaiTro, TrangThai FROM tblNhanVien
END
GO


---InsertEmployee

CREATE PROC InsertNhanVien
@tenNV NVARCHAR(50), @diaChi NVARCHAR(50), @sDT NVARCHAR(50), 
@email NVARCHAR(50), @vaiTro BIT, @trangThai BIT, @mK NVARCHAR(50)
AS BEGIN
INSERT INTO tblNhanVien VALUES
(@tenNV, @diaChi, @sDT, @email, @vaiTro, @trangThai, @mK)
END
GO

---UpdateEmployee

CREATE PROC UpdateNhanVien
@tenNV NVARCHAR(50), @diaChi NVARCHAR(50), @sDT NVARCHAR(50), 
@email NVARCHAR(50), @vaiTro BIT, @trangThai BIT
AS BEGIN
UPDATE tblNhanVien
SET TenNV = @tenNV, DiaChi = @diaChi, SDT = @sDT,
VaiTro = @vaiTro, TrangThai = @trangThai
WHERE @email = Email
END
GO

---UpdateEmployeeAddressPhoneNumber

CREATE PROC Update_DiaChi_SDT_NhanVien
@diaChi NVARCHAR(50), @sDT NVARCHAR(50), @email NVARCHAR(50)
AS BEGIN
UPDATE tblNhanVien
SET DiaChi = @diaChi, SDT = @sDT
WHERE @email = Email
END
GO

---DeleteEmployee

CREATE PROC DeleteNhanVien
@maNV INT
AS BEGIN
DECLARE @ketQua BIT = 1
IF EXISTS(SELECT * FROM tblNhanVien WHERE MaNV = @maNV)
	DELETE tblNhanVien WHERE MaNV = @maNV
ELSE
	SET @ketQua = 0
SELECT @ketQua
END
GO

---SearchEmployee

CREATE PROC SearchNhanVien
@tenNV NVARCHAR(50)
AS BEGIN
SELECT MaNV, TenNV, DiaChi, SDT, Email, VaiTro, TrangThai FROM tblNhanVien WHERE TenNV LIKE '%' + @tenNV + '%'
END
GO


---GetEmployeeIdName

CREATE PROC getMaNV
@email NVARCHAR(50)
AS BEGIN
SELECT CONVERT(NVARCHAR(50), MaNV) + ' | ' + TenNV FROM tblNhanVien WHERE Email = @email
END
GO

---GetEmployeeAddressPhoneNumber

CREATE PROC get_DiaChi_SDT_NhanVien
@email NVARCHAR(50)
AS BEGIN
SELECT DiaChi + ' | ' + SDT FROM tblNhanVien WHERE Email = @email
END
GO



