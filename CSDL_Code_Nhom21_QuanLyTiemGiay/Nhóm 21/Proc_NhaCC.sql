--Nhà cung cấp proc

---lấy danh sách nhà cung cấp

CREATE PROC getNhaCC
AS BEGIN
SELECT MaNCC, TenNCC, DiaChi,SDT FROM tblNhaCC
END
GO

---Insert Nhà cung cấp

CREATE PROC InsertNhaCC
@tenNCC NVARCHAR(50), @diaChi NVARCHAR(50), @sDT NVARCHAR(50)
AS BEGIN
INSERT INTO tblNhaCC VALUES
(@tenNCC, @diaChi, @sDT)
END
GO

---Update Nhà cung cấp

CREATE PROC UpdateNhaCC
@maNCC INT, @tenNCC NVARCHAR(50), @diaChi NVARCHAR(50), @sDT NVARCHAR(50)
AS BEGIN
UPDATE tblNhaCC
SET TenNCC = @tenNCC, DiaChi = @diaChi, SDT = @sDT
WHERE MaNCC = @maNCC
END
GO

---Delete nhà cung cấp

CREATE PROC DeleteNhaCC
@maNCC INT
AS BEGIN
DECLARE @ketQua BIT = 1
IF EXISTS(SELECT * FROM tblNhaCC WHERE MaNCC = @maNCC)
	DELETE tblNhaCC WHERE MaNCC = @maNCC
ELSE
	SET @ketQua = 0
SELECT @ketQua
END
GO

---Search Nhà cung cấp

CREATE PROC SearchNhaCC
@tenNCC NVARCHAR(50)
AS BEGIN
SELECT * FROM tblNhaCC WHERE TenNCC LIKE '%' + @tenNCC + '%'
END
GO

---List mã nhà cung cấp

CREATE PROC List_MaNCC
AS BEGIN
SELECT CONVERT(NVARCHAR(50), MaNCC) + ' | ' + TenNCC FROM tblNhaCC
END
GO

