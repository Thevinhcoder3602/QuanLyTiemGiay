---Chi tiết hóa đơn bán

---ListBillInfo

CREATE PROC List_CTHDBan
AS BEGIN
SELECT b.MaSP, p.TenSP, b.SoLuong, GiaBan FROM tblCTHDBan b, tblSanPham p
WHERE b.MaSP = p.MaSP
END
GO

---InsertBillInfor

CREATE PROC Insert_CTHDBan
@maSP INT, @soLuong INT, @giaBanSP FLOAT  
AS BEGIN
DECLARE @giaBan FLOAT = @soLuong * @giaBanSP
UPDATE tblSanPham
SET SoLuong = SoLuong - @soLuong
WHERE MaSP = @maSP

INSERT INTO tblCTHDBan VALUES
(@maSP, @soLuong, @giaBan)
END
GO

---GetTotalPrice

CREATE PROC TongGiaBan
AS BEGIN
SELECT SUM(GiaBan) from tblCTHDBan
END
GO

---DeleteProductInBillInfo

CREATE PROC Delete_SP_CTHDBan
@maSP int
AS BEGIN
DECLARE @ketQua BIT = 1
IF EXISTS(SELECT * FROM tblCTHDBan WHERE MaSP = @maSP)
	DELETE tblCTHDBan WHERE MaSP = @maSP
ELSE
	SET @ketQua = 0
SELECT @ketQua
END
GO

---UpdateProductInBillInfo

CREATE PROC Update_SP_CTHDBan
@maSP int, @soLuong int
AS BEGIN
UPDATE b
SET b.SoLuong = @soLuong, GiaBan = @soLuong * p.GiaBanSP
FROM tblSanPham p, tblCTHDBan b
WHERE p.MaSP = @maSP AND b.MaSP = p.MaSP
END
GO

USE [master]
GO
ALTER DATABASE [QLTiemGiay] SET  READ_WRITE 
GO