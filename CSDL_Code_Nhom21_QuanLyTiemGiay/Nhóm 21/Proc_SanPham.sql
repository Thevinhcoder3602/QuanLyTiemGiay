USE QLTiemGiay
Go
---Lấy danh sách sản phẩm
CREATE PROC getSanPham
AS BEGIN
SELECT MaSP, TenSP, SoLuong, GiaNhapSP, GiaBanSP, AnhSP, GhiChu FROM tblSanPham
END
GO
----Thêm sản phẩm
CREATE PROC InsertSanPham
@TenSP NVARCHAR(50), @SoLuong INT, @GiaNhapSP FLOAT, @GiaBanSP FLOAT,
@AnhSP IMAGE, @GhiChu NVARCHAR(100)
AS BEGIN
INSERT INTO tblSanPham VALUES
(@TenSP, @SoLuong, @GiaNhapSP, @GiaBanSP, @AnhSP, @GhiChu)
END
GO
----Sửa sản phẩm
CREATE PROC UpDateSanPham
@MaSP INT, @TenSP NVARCHAR(50), @SoLuong INT, @GiaNhapSP FLOAT, 
@GiaBanSP FLOAT, @AnhSP IMAGE, @GhiChu NVARCHAR(100)
AS BEGIN
UPDATE tblSanPham
SET TenSP = @TenSP, SoLuong = @SoLuong, GiaNhapSP = @GiaNhapSP,
GiaBanSP = @GiaBanSP, AnhSP = @AnhSP, GhiChu = @GhiChu
WHERE MaSP = @MaSP
END
GO
---- Xóa sản phẩm
CREATE PROC DeleteSanPham
@MaSP int
AS BEGIN
DECLARE @KetQua BIT = 1
IF EXISTS(SELECT * FROM tblSanPham WHERE MaSP = @MaSP)
	DELETE tblSanPham WHERE MaSP = @MaSP
ELSE
	SET @KetQua = 0
SELECT @KetQua
END
GO
----Tìm kiếm sản phẩm
CREATE PROC SearchSanPham
@TenSP NVARCHAR(50)
AS BEGIN
SELECT * FROM tblSanPham WHERE TenSP LIKE '%' + @TenSP + '%'
END
GO

---DanhSachTen_SL
CREATE PROC DanhSachTen_SL
AS BEGIN
SELECT TenSP + ' | ' + CONVERT(NVARCHAR(50), SoLuong) FROM tblSanPham
END
GO
----GetGiaBanSP
CREATE PROC GetGiaBanSP
@TenSP NVARCHAR(50)
AS BEGIN
SELECT GiaBanSP FROM tblSanPham WHERE TenSP = @TenSP
END
GO
----Lấy giá nhập sản phẩm
CREATE PROC getGiaNhapSP
@TenSP NVARCHAR(50)
AS BEGIN
SELECT GiaNhapSP FROM tblSanPham WHERE TenSP = @TenSP
END
GO
-----GetMaSP
CREATE PROC GetMaSP
@TenSP NVARCHAR(50)
AS BEGIN
SELECT MaSP FROM tblSanPham WHERE TenSP = @TenSP
END
GO