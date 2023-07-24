Create Database AssetManagementSystemConcentrix

go

use AssetManagementSystemConcentrix

go

Create Table Vendors
(
	Id nVarChar(36) Not Null Primary Key,
	Name nVarChar(512) Not Null,
	IsActive Bit
)

go

Insert Into Vendors Values('b7b4a571-9907-447d-8e83-1b6b75be1e7c', 'Apple' , 1),
('b7b4a571-9907-447d-8e83-1b6b75be1e8c', 'Dell' , 1),
('b7b4a571-9907-447d-8e83-1b6b75be1e9c', 'Microsoft' , 1),
('b7b4a571-9907-447d-8e83-1b6b75be1e1e', 'Lenovo' , 1),
('b7b4a571-9907-447d-8e83-1b6b75be1e2e', 'Assus' , 1),
('b7b4a571-9907-447d-8e83-1b6b75be1e3e', 'Acer' , 1)

go

Create Table Hardware
(
	Id nVarChar(36) Not Null Primary Key,
	Name nVarChar(512) Not Null,
	IsActive Bit
)

go

Insert Into Hardware Values('b7b4a571-9907-447d-8e83-1b6b75be1e7c', 'Laptop' , 1),
('b7b4a571-9907-447d-8e83-1b6b75be1e8c', 'Desktop' , 1),
('b7b4a571-9907-447d-8e83-1b6b75be1e9c', 'Tablet' , 1),
('b7b4a571-9907-447d-8e83-1b6b75be1e1e', 'Mouse' , 1),
('b7b4a571-9907-447d-8e83-1b6b75be1e2e', 'Keyboard' , 1),
('b7b4a571-9907-447d-8e83-1b6b75be1e3e', 'Adapter' , 1)

go


Create Table Assets
(
	Id nVarChar(36) Not Null Primary Key,
	CustomerName nVarChar(512) Not Null,
	CompanyName nVarChar(512) Not Null,
	Address1 nVarChar(512) Not Null,
	Address2 nVarChar(512) Null,
	VendorId nVarChar(36) Not Null References Vendors(Id),
	HardwareId nVarChar(36) Not Null References Hardware(Id),
	DeliveryDate DateTime Not Null,
	Quantity Integer Not Null,
	Price Decimal(18,2) Not Null,
	TotalAmount Decimal(18,2) Not Null
)

go

