-- 1. Vai trò người dùng
CREATE TABLE Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);

-- 2. Người dùng
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    RoleID INT NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    Address NVARCHAR(MAX) NOT NULL,
    CONSTRAINT FK_Users_RoleID FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- 3. Phương tiện
CREATE TABLE Vehicles (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    OwnerID INT NOT NULL,
    PlateNumber NVARCHAR(15) NOT NULL UNIQUE,
    Brand NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    ManufactureYear INT NOT NULL CHECK (ManufactureYear BETWEEN 1950 AND YEAR(GETDATE())),
    EngineNumber NVARCHAR(100) NOT NULL,
    CONSTRAINT FK_Vehicles_OwnerID FOREIGN KEY (OwnerID) REFERENCES Users(UserID)
);

-- 4. Cơ sở kiểm định
CREATE TABLE InspectionStations (
    StationID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(MAX) NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE
);

-- 5. Kết quả kiểm định
CREATE TABLE InspectionRecords (
    RecordID INT IDENTITY(1,1) PRIMARY KEY,
    VehicleID INT NOT NULL,
    StationID INT NOT NULL,
    InspectorID INT NOT NULL,
    InspectionDate DATETIME DEFAULT GETDATE(),
    Result NVARCHAR(10) NOT NULL CHECK (Result IN ('Pass', 'Fail')),
    CO2Emission DECIMAL(5,2) NOT NULL,
    HCEmission DECIMAL(5,2) NOT NULL,
    Comments NVARCHAR(MAX),
    CONSTRAINT FK_Records_Vehicle FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID),
    CONSTRAINT FK_Records_Station FOREIGN KEY (StationID) REFERENCES InspectionStations(StationID),
    CONSTRAINT FK_Records_Inspector FOREIGN KEY (InspectorID) REFERENCES Users(UserID)
);

-- 6. Thông báo
CREATE TABLE Notifications (
    NotificationID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    Message NVARCHAR(MAX) NOT NULL,
    SentDate DATETIME DEFAULT GETDATE(),
    IsRead BIT DEFAULT 0,
    CONSTRAINT FK_Notifications_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- 7. Lịch sử thao tác
CREATE TABLE Logs (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    Action NVARCHAR(100) NOT NULL,
    Timestamp DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Logs_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);


-- Vai trò
INSERT INTO Roles (RoleName) VALUES 
(N'Owner'), 
(N'Inspector'), 
(N'Station'), 
(N'Admin'), 
(N'Police');

-- Người dùng
INSERT INTO Users (FullName, Email, Password, RoleID, Phone, Address)
VALUES 
(N'Nguyen Van avc', 'ac@gmail.com', '123', 5, '0911111111', N'Hà Nội'),
(N'Tran Thi axx', 'axx@gmail.com', '123', 4, '0922222222', N'Đà Nẵng');

-- Cơ sở kiểm định
INSERT INTO InspectionStations (Name, Address, Phone, Email)
VALUES 
(N'Trạm Kiểm Định 01', N'1 Nguyễn Trãi, Hà Nội', '0909123456', 'station01@email.com');

-- Phương tiện
INSERT INTO Vehicles (OwnerID, PlateNumber, Brand, Model, ManufactureYear, EngineNumber)
VALUES 
(1, '29A1-12345', 'Honda', 'Air Blade', 2021, 'ENG123456789');

-- Bản ghi kiểm định
INSERT INTO InspectionRecords (VehicleID, StationID, InspectorID, Result, CO2Emission, HCEmission, Comments)
VALUES 
(1, 1, 2, 'Pass', 1.23, 0.45, N'Xe đạt tiêu chuẩn');

-- Thông báo
INSERT INTO Notifications (UserID, Message)
VALUES 
(1, N'Xe của bạn đã kiểm định thành công.');

-- Lịch sử thao tác
INSERT INTO Logs (UserID, Action)
VALUES 
(1, N'Đăng ký phương tiện'),
(2, N'Kiểm định phương tiện');
