CREATE DATABASE BTL_HSK COLLATE Vietnamese_CI_AS;
GO

USE BTL_HSK
GO

CREATE TABLE tblSanPham (
	sMaSP VARCHAR(30) not null ,
	sTenSP NVARCHAR(50) not null,
	sMaNCC VARCHAR(30)not null,
	sTenDVT NVARCHAR(50)not null,
	sTenLoaiHang NVARCHAR(50),

	iSoLuong INT,
	fGiaTien FLOAT,

	constraint PK_sMaSP primary key (sMaSP) ,
	constraint CK_SoLuong check (iSoLuong >=0),
	constraint CK_GiaTien check (fGiaTien >0),
)
GO




CREATE TABLE tblKhachHang (
	 sSoDTKH VARCHAR(30) NOT NULL,
	sHoTen NVARCHAR(70),
	sGioiTinh nvarchar(5),
	sDiaChi NVARCHAR(55),
	fTongTienKH FLOAT DEFAULT 0.0,
	CONSTRAINT PK_KH PRIMARY KEY(sSoDTKH),
	constraint CK_GioiTinh_KH check ( sGioiTinh = N'Nam' or sGioiTinh = N'Nữ')
)
GO

CREATE TABLE tblNhanVien (
	sMaNV VARCHAR(30),
	sHoTen NVARCHAR(70),
	sGioiTinh nvarchar(5),
	sDiaChi nvarchar(50),
	sSDT varchar(12),
	dNgaySinh date,
	dNgayVaoLam date,
	fLuongCoBan float,
	fPhuCap float,
	constraint PK_sMaNV primary key (sMaNV),
	constraint CK_Tuoi check (DATEDIFF(day, dNgaySinh,dNgayVaoLam) /365 >= 18),
	constraint CK_Luong check (fLuongCoBan>0),
	constraint CK_PhuCap check (fPhuCap > 0),
	constraint CK_GioiTinh check ( sGioiTinh = N'nam' or sGioiTinh = N'nữ')
)
GO

CREATE TABLE tblDonDatHang (
    sMaDDH VARCHAR(30) NOT NULL ,
    sMaNV VARCHAR(30) NOT NULL,
    sSoDTKH VARCHAR(30) NOT NULL,
    dNgayDatHang DATE ,
    fTongTienHang FLOAT DEFAULT 0.0,
	CONSTRAINT PK_DDH PRIMARY KEY (sMaDDH),
    CONSTRAINT CK_NgayDathang CHECK (DATEDIFF(day, dNgayDatHang, GETDATE()) <= 0),
	CONSTRAINT FK_DDH_KhachHang FOREIGN KEY (sSoDTKH) REFERENCES tblKhachHang(sSoDTKH),
    CONSTRAINT FK_DDH_NhanVien FOREIGN KEY (sMaNV) REFERENCES tblNhanVien(sMaNV)
);
GO

CREATE TABLE tblChiTietDDH (
    sMaDDH VARCHAR(30) NOT NULL,
    sMaSP VARCHAR(30) NOT NULL,
    sTenDVT NVARCHAR(50),
    iSoLuong INT CHECK (iSoLuong > 0),
    fGiaTien FLOAT DEFAULT 0.0 CHECK (fGiaTien > 0),
    fThanhTien AS (iSoLuong * fGiaTien) PERSISTED,
    CONSTRAINT FK_ChiTietDDH_DonDatHang FOREIGN KEY (sMaDDH) REFERENCES tblDonDatHang(sMaDDH),
    CONSTRAINT FK_ChiTietDDH_SanPham FOREIGN KEY (sMaSP) REFERENCES tblSanPham(sMaSP)
);
GO





CREATE TABLE tblNhaCungCap (
	sMaNCC VARCHAR(30) not null,
	sTenNCC NVARCHAR(50),
	sSDT varchar(12),
	sDiaChi nvarchar(50),
	sEmail nvarchar(50),
	constraint PK_sMaNCC primary key (sMaNCC)
)
GO

CREATE TABLE tblDonNhapHang (
    sMaDNH VARCHAR(30) NOT NULL ,
    sMaNV VARCHAR(30) NOT NULL,
    sMaNCC VARCHAR(30) NOT NULL,
    dNgayNhapHang DATE,
    fTongTienHang FLOAT DEFAULT 0.0,
	CONSTRAINT PK_DNH PRIMARY KEY (sMaDNH),
    CONSTRAINT CK_NgayNhapHang CHECK (DATEDIFF(day, dNgayNhapHang, GETDATE()) >= 0),
    CONSTRAINT FK_DNH_NhanVien FOREIGN KEY (sMaNV) REFERENCES tblNhanVien(sMaNV),
    CONSTRAINT FK_DNH_NCC FOREIGN KEY (sMaNCC) REFERENCES tblNhaCungCap(sMaNCC)
);
GO
CREATE TABLE tblChiTietDNH (
    sMaDNH VARCHAR(30) NOT NULL,
    sMaSP VARCHAR(30) NOT NULL,
    sTenDVT NVARCHAR(50),
    iSoLuong INT CHECK (iSoLuong > 0),
    fGiaTien FLOAT DEFAULT 0.0 CHECK (fGiaTien > 0),
    fThanhTien AS (iSoLuong * fGiaTien) PERSISTED,
    CONSTRAINT FK_ChiTietDNH_DonNhapHang FOREIGN KEY (sMaDNH) REFERENCES tblDonNhapHang(sMaDNH),
    CONSTRAINT FK_ChiTietDNH_SanPham FOREIGN KEY (sMaSP) REFERENCES tblSanPham(sMaSP)
);
GO





CREATE TABLE Users (
    Username VARCHAR(50) PRIMARY KEY,
    Password VARCHAR(50) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN (N'Admin', N'NhanVien')) NOT NULL
);


--Ràng buộc-------------------------------------------------------------------------------------------------------
ALTER TABLE tblSanPham ADD CONSTRAINT FK_SP_NCC FOREIGN KEY(sMaNCC) REFERENCES tblNhaCungCap(sMaNCC);


------------------------------------------------------------------------------------------------------------------
---alter table tblChiTietDDH
--drop constraint FK_CTDDH_SP

--Thêm dữ liệu----------------------------------------------------------------------------------------------------

INSERT INTO tblKhachHang (sSoDTKH, sHoTen, sGioiTinh, sDiaChi, fTongTienKH)
VALUES 
    ('0961234567', N'Nguyễn Văn A', N'Nam', N'123 Đường A, Quận 1, TP.HCM', 500000),
    ('0987654321', N'Trần Thị B', N'Nữ', N'456 Đường B, Quận 3, TP.HCM', 750000),
    ('0912345678', N'Phạm Văn C', N'Nam', N'789 Đường C, Quận 5, TP.HCM', 420000),
    ('0934567890', N'Hoàng Thị D', N'Nữ', N'321 Đường D, Quận 7, TP.HCM', 640000),
    ('0976543210', N'Võ Văn E', N'Nam', N'654 Đường E, Quận 9, TP.HCM', 320000);
GO

INSERT INTO tblSanPham (sMaSP, sTenSP, sMaNCC, sTenLoaiHang, sTenDVT, iSoLuong, fGiaTien)
VALUES
    ('SP001', N'Bánh Mì Sandwich', 'NCC001', N'Thực phẩm khô', N'Chiếc', 100, 15000),
    ('SP002', N'Nước Ngọt Coca-Cola', 'NCC002', N'Đồ uống', N'Hộp', 200, 10000),
    ('SP003', N'Sữa Tươi Vinamilk', 'NCC001', N'Sữa và chế phẩm', N'Kg', 50, 22000),
    ('SP004', N'Mì Ăn Liền Hảo Hảo', 'NCC002', N'Thực phẩm khô', N'Túi', 500, 3000),
    ('SP005', N'Bánh Quy Oreo', 'NCC001', N'Bánh kẹo', N'Chiếc', 150, 25000);



INSERT INTO tblNhaCungCap (sMaNCC, sTenNCC, sSDT, sDiaChi, sEmail)
VALUES 
('NCC001', N'Công Ty Phân Phối Tạp Hóa VinMart', '0123451234', N'123 Đường A, Quận 1, TP. Hà Nội', 'vinmart.distribution@gmail.com'),
('NCC002', N'Công ty TNHH Việt Nam VIFOTEX', '0123456444', N'1233 Đường D, Quận 1, TP. Hà Nội', 'VIFOTEX.distribution@gmail.com'),
('NCC003', N'Công ty TNHH Red Bull', '0123477779', N'1 Đường F, Thanh Xuân, TP. Hà Nội', 'Red Bull@gmail.com'),
('NCC004', N'Công Ty Cung Ứng Hàng Tiện Lợi Circle K', '0987654321', N'456 Đường B, Quận 2, TP. Hồ Chí Minh', 'circlek.supplies@gmail.com');



INSERT INTO tblNhanvien (sMaNV, sHoTen, sGioiTinh, sDiaChi, sSDT, dNgaySinh, dNgayVaoLam, fLuongCoBan, fPhuCap)
VALUES 
('NV001', N'Nguyễn Văn An', N'Nam', N'123 Trần Phú, Hà Nội', '0912345678', '1990-01-15', '2020-05-10', 10000000, 2000000),
('NV002', N'Trần Thị Bích Ngọc', N'Nữ', N'45 Lê Lợi, Đà Nẵng', '0987654321', '1992-07-20', '2019-09-01', 9500000, 1500000),
('NV003', N'Lê Văn Cường', N'Nam', N'78 Nguyễn Huệ, TP HCM', '0911223344', '1988-03-10', '2018-03-15', 12000000, 2500000),
('NV004', N'Phạm Thị Duyên', N'Nữ', N'32 Phan Đình Phùng, Hải Phòng', '0900112233', '1995-12-25', '2021-11-20', 8500000, 1000000),
('NV005', N'Hoàng Văn Em', N'Nam', N'90 Hùng Vương, Cần Thơ', '0933445566', '1993-06-30', '2022-01-05', 11000000, 1800000),
('NV006', N'Võ Thị Phương Lan', N'Nữ', N'56 Bạch Đằng, Huế', '0922334455', '1994-09-15', '2023-07-01', 9500000, 1200000);


INSERT INTO tblDonDatHang (sMaDDH, sMaNV, sSoDTKH, dNgayDatHang, fTongTienHang)
VALUES 
    ('DDH001', 'NV001', '0961234567', '2025-03-18', 500000),
    ('DDH002', 'NV002', '0987654321', '2025-03-17', 750000),
    ('DDH003', 'NV003', '0912345678', '2025-03-16', 420000),
    ('DDH004', 'NV001', '0934567890', '2025-03-15', 640000),
    ('DDH005', 'NV002', '0976543210', '2025-03-14', 320000);
GO

INSERT INTO tblChiTietDDH (sMaDDH, sMaSP, sTenDVT, iSoLuong, fGiaTien)
VALUES 
    ('DDH001', 'SP001', N'Chiếc', 20, 15000),
    ('DDH001', 'SP002', N'Hộp', 30, 10000),
    ('DDH002', 'SP003', N'Kg', 10, 22000),
    ('DDH002', 'SP004', N'Túi', 50, 3000),
    ('DDH003', 'SP005', N'Chiếc', 15, 25000),
    ('DDH003', 'SP001', N'Chiếc', 10, 15000),
    ('DDH004', 'SP003', N'Kg', 20, 22000),
    ('DDH004', 'SP002', N'Hộp', 40, 10000),
    ('DDH005', 'SP005', N'Chiếc', 12, 25000),
    ('DDH005', 'SP004', N'Túi', 30, 3000);
GO


INSERT INTO tblDonNhapHang (sMaDNH, sMaNV, sMaNCC, dNgayNhapHang, fTongTienHang)
VALUES 
    ('DNH001', 'NV001', 'NCC001', '2025-03-18', 1500000),
    ('DNH002', 'NV002', 'NCC002', '2025-03-17', 800000),
    ('DNH003', 'NV001', 'NCC003', '2025-03-16', 1200000),
    ('DNH004', 'NV003', 'NCC004', '2025-03-15', 950000),
    ('DNH005', 'NV002', 'NCC001', '2025-03-14', 670000);
GO

INSERT INTO tblChiTietDNH (sMaDNH, sMaSP, sTenDVT, iSoLuong, fGiaTien)
VALUES 
    ('DNH001', 'SP001', N'Chiếc', 100, 15000),
    ('DNH001', 'SP002', N'Hộp', 50, 10000),
    ('DNH002', 'SP003', N'Kg', 30, 22000),
    ('DNH002', 'SP004', N'Túi', 100, 3000),
    ('DNH003', 'SP005', N'Chiếc', 60, 25000),
    ('DNH003', 'SP001', N'Chiếc', 20, 15000),
    ('DNH004', 'SP003', N'Kg', 40, 22000),
    ('DNH004', 'SP002', N'Hộp', 20, 10000),
    ('DNH005', 'SP005', N'Chiếc', 30, 25000),
    ('DNH005', 'SP004', N'Túi', 50, 3000);
GO


