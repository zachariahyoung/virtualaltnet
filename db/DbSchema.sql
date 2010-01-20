
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1A2E670F582CE0D1]') AND parent_object_id = OBJECT_ID('Roles'))
alter table Roles  drop constraint FK1A2E670F582CE0D1


    if exists (select * from dbo.sysobjects where id = object_id(N'Recordings') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Recordings

    if exists (select * from dbo.sysobjects where id = object_id(N'Blogs') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Blogs

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    if exists (select * from dbo.sysobjects where id = object_id(N'Roles') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Roles

    create table Recordings (
        Id INT IDENTITY NOT NULL,
       Title NVARCHAR(255) null,
       Url NVARCHAR(255) null,
       Date DATETIME null,
       Duration NVARCHAR(255) null,
       Speaker NVARCHAR(255) null,
       UserGroup NVARCHAR(255) null,
       LiveMeetingUrl NVARCHAR(255) null,
       Description NVARCHAR(255) null,
       primary key (Id)
    )

    create table Blogs (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) null,
       Url NVARCHAR(255) null,
       Rss NVARCHAR(255) null,
       primary key (Id)
    )

    create table Users (
        Id INT IDENTITY NOT NULL,
       UserName NVARCHAR(255) null,
       Password NVARCHAR(255) null,
       primary key (Id)
    )

    create table Roles (
        Id INT IDENTITY NOT NULL,
       RoleName NVARCHAR(255) null,
       UserFk INT null,
       primary key (Id)
    )

    alter table Roles 
        add constraint FK1A2E670F582CE0D1 
        foreign key (UserFk) 
        references Users
