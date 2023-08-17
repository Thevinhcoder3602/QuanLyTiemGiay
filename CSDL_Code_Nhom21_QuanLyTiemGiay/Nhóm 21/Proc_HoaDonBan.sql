---Hóa đơn bán

---ListOfBills

CREATE PROC List_HDBan
AS BEGIN
SELECT b.MaHDBan, c.TenKH, NgayBan, TongTienBan FROM tblHDBan b, tblKhachHang c
WHERE b.MaKH = c.MaKH
END
GO

---InsertBill

CREATE PROC Insert_HDBan
@maNV INT, @maKH INT, @tongTienBan FLOAT
AS BEGIN
ALTER TABLE tblHDBan NOCHECK CONSTRAINT ALL
DELETE FROM tblCTHDBan
ALTER TABLE tblHDBan CHECK CONSTRAINT ALL

INSERT INTO tblHDBan VALUES
(@maNV, @maKH, DEFAULT, @tongTienBan)
END
GO

---SearchCustomerInBill

CREATE PROC Search_TenKH_HDBan
@tenKH NVARCHAR(50)
AS BEGIN
SELECT b.MaHDBan, c.TenKH, NgayBan, TongTienBan FROM tblHDBan b, tblKhachHang c
WHERE b.MaKH = c.MaKH AND c.TenKH LIKE '%' + @tenKH + '%'
END
GO

---GetRevenueInApril

CREATE PROC Thang4
AS BEGIN
SELECT SUM(TongTienBan) AS Revenue, Date = DATEADD(MONTH, DATEDIFF(MONTH, 0, NgayBan), 0)
FROM    tblHDBan
WHERE   NgayBan >= '2023-04-01' 
AND     NgayBan <= '2023-04-30'
GROUP BY DATEADD(MONTH, DATEDIFF(MONTH, 0, NgayBan), 0)
END
GO

---GetRevenueInMay
CREATE PROC Thang5
AS BEGIN
SELECT SUM(TongTienBan) AS Revenue, Date = DATEADD(MONTH, DATEDIFF(MONTH, 0, NgayBan), 0)
FROM    tblHDBan
WHERE   NgayBan >= '2023-05-01' 
AND     NgayBan <= '2023-05-31'
GROUP BY DATEADD(MONTH, DATEDIFF(MONTH, 0, NgayBan), 0)
END
GO

---GetRevenueInJune
CREATE PROC Thang6
AS BEGIN
SELECT SUM(TongTienBan) AS Revenue, Date = DATEADD(MONTH, DATEDIFF(MONTH, 0, NgayBan), 0)
FROM    tblHDBan
WHERE   NgayBan >= '2023-06-01' 
AND     NgayBan <= '2023-06-30'
GROUP BY DATEADD(MONTH, DATEDIFF(MONTH, 0, NgayBan), 0)
END
GO

---GetRevenueInApril
CREATE PROC Thang7
AS BEGIN
SELECT SUM(TongTienBan) AS Revenue, Date = DATEADD(MONTH, DATEDIFF(MONTH, 0, NgayBan), 0)
FROM    tblHDBan
WHERE   NgayBan >= '2023-07-01' 
AND     NgayBan <= '2023-06-31'
GROUP BY DATEADD(MONTH, DATEDIFF(MONTH, 0, NgayBan), 0)
END
GO


---- Chỉnh thời gian thành default
ALTER TABLE [dbo].[tblHDBan] ADD  DEFAULT (sysdatetime()) FOR [NgayBan]
GO