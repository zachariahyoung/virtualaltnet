if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users
if exists (select * from dbo.sysobjects where id = object_id(N'Accounts') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Accounts
create table Users (Id INT IDENTITY NOT NULL, UserName NVARCHAR(255) null, Password NVARCHAR(255) null, UserAccountFk INT null, primary key (Id))
create table Accounts (Id INT IDENTITY NOT NULL, Name NVARCHAR(255) null, primary key (Id))
alter table Users add constraint FK2C1C7FE52E76D3B foreign key (UserAccountFk) references Accounts

/*Seed Accounts (Roles) with our simple Security roles */
Insert Into Accounts (Name) Values ('Administrator')

/*Seed Users with User accounts that are Admins value of 1*/
Insert Into Users (UserName,Password,UserAccountFk) Values ('JLeger','betts4463',1)
Insert Into Users (UserName, Password, UserAccountFk) Values ('Zach', 'zachary',1)