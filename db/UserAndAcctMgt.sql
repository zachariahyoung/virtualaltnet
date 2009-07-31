if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1A2E670F582CE0D1]') AND parent_object_id = OBJECT_ID('Roles'))
alter table Roles  drop constraint FK1A2E670F582CE0D1
if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users
if exists (select * from dbo.sysobjects where id = object_id(N'Roles') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Roles
create table Users (Id INT IDENTITY NOT NULL, UserName NVARCHAR(255) null, Password NVARCHAR(255) null, primary key (Id))
create table Roles (Id INT IDENTITY NOT NULL, RoleName NVARCHAR(255) null, UserFk INT null, primary key (Id))
alter table Roles add constraint FK1A2E670F582CE0D1 foreign key (UserFk) references Users

/*Seed Users with User accounts that are Admins value of 1*/
Insert Into Users (UserName,Password) Values ('JLeger','*******')
Insert Into Users (UserName, Password) Values ('Zach', '******')
Insert Into Users (UserName, Password) Values ('Ryan', '******')

/*Seed Accounts (Roles) with our simple Security roles*/
Insert Into Roles (RoleName,UserFk) Values ('Administrator',1)
Insert Into Roles (RoleName,UserFk) Values ('Administrator',2)
Insert Into Roles (RoleName,UserFk) Values ('Administrator',3)
