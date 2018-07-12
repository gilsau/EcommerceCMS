use EcommerceCMS
go

-- Remove all foreign keys
print '--------------------------------------'
print 'remove all foreign keys'
while(exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_TYPE='FOREIGN KEY'))
begin
	declare @sql nvarchar(2000)
	SELECT TOP 1 @sql=('ALTER TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME
	+ '] DROP CONSTRAINT [' + CONSTRAINT_NAME + ']')
	FROM information_schema.table_constraints
	WHERE CONSTRAINT_TYPE = 'FOREIGN KEY'
	exec (@sql)
end
go

print '--------------------------------------'
print 'create table: SupplierSource'
if exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'SupplierSource')
begin
	drop table dbo.SupplierSource
end
go
create table dbo.SupplierSource(
	Id int identity(1,1) primary key,
	Logo nvarchar(250) not null,
	Title nvarchar(50) not null,
	[Url] nvarchar(250) not null,
	FileSample nvarchar(250) null,
	CSVColumns nvarchar(1000) null,
	DBColumns nvarchar(1000) null,
	Created datetime not null,
	CreatedBy nvarchar(50) not null
)
go

insert into SupplierSource values('http://www.wholesale2b.com/images/FinalLogoNew-nosub-small.png','Wholesale2b','http://www.wholesale2b.com', null, null, null, getdate(),'system')
insert into SupplierSource values('http://www.inventorysource.com/wp-content/uploads/2016/11/final-logo.png','Inventory Source','http://www.inventorysource.com', null, null, null, getdate(),'system')
go

print '--------------------------------------'
print 'create table: Supplier'
if exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Supplier')
begin
	drop table dbo.Supplier
end
go
create table dbo.Supplier(
	Id int identity(1,1) primary key,
	SupplierSourceId int not null FOREIGN KEY REFERENCES SupplierSource(Id),
	Logo nvarchar(250) not null,
	Title nvarchar(50) not null,
	CSVUrl nvarchar(500) not null,
	ProductsImported int not null,
	ProductsNotImported int not null,
	LastDownload datetime null,
	Created datetime not null,
	CreatedBy nvarchar(50) not null
)
go

insert into Supplier values(1,'https://www.wholesale2b.com/logo/logo-ahi.png','AHI','https://www.wholesale2b.com/members.php/myaccount/download?download=data&id=&supplier_id=B365&feed_type=free&feed=1&zip=1&token=1b6a9869369ae9eb8f83ea843edb3b2c',0,0, null,getdate(),'system')
insert into Supplier values(1,'https://www.wholesale2b.com/logo/logo-air-venturi.png','Air Venturi','https://www.wholesale2b.com/members.php/myaccount/download?download=data&id=&supplier_id=P892&feed_type=free&feed=1&zip=1&token=1b6a9869369ae9eb8f83ea843edb3b2c',0,0,null,getdate(),'system')
go

print '--------------------------------------'
print 'create table: Website'
if exists(select 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Website')
begin
	drop table dbo.[Website]
end
go
create table dbo.[Website](
	Id int identity(1,1) primary key,
	Logo nvarchar(250) not null,
	Title nvarchar(50) not null,
	[Url] nvarchar(250) not null,
	ServerName nvarchar(50) not null,
	DatabaseName nvarchar(50) not null,
	Username nvarchar(50) not null,
	[Password] nvarchar(50) not null,
	Created datetime not null,
	CreatedBy nvarchar(50) not null
)
go

insert into Website values('http://toysandgamesroom.com/content/images/thumbs/0005444.jpeg','Toys & Games Room','http://www.toysandgamesroom.com','gtechappsolutions.com','gtechapp_toysandgamesroom','gtechapp_admin','Xmod350!',getdate(),'system')
insert into Website values('http://homeandgardenstatues.com/content/images/thumbs/0000597.jpeg','Home & Garden Statues','http://www.homeandgardenstatues.com','gtechappsolutions.com','gtechapp_homeandgardenstatues','gtechapp_admin','Xmod350!',getdate(),'system')
insert into Website values('http://outdoorsfungear.com/content/images/thumbs/0004235.jpeg','Outdoors Fun Gear','http://www.outdoorsfungear.com','gtechappsolutions.com','gtechapp_outdoorsfungear','gtechapp_admin','Xmod350!',getdate(),'system')
insert into Website values('http://hisandherscloset.com/content/images/thumbs/0003228.jpeg','His & Hers Closet','http://www.hisandherscloset.com','gtechappsolutions.com','gtechapp_hisandherscloset','gtechapp_admin','Xmod350!',getdate(),'system')
insert into Website values('http://www.funmodernelectronics.com/content/images/thumbs/0000153.jpeg','Fun Modern Electronics','http://www.funmodernelectronics.com','gtechappsolutions.com','gtechapp_funmodernelectronics','gtechapp_admin','Xmod350!',getdate(),'system')
go 

	