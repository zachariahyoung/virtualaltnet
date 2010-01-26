
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1A2E670F582CE0D1]') AND parent_object_id = OBJECT_ID('Roles'))
alter table Roles  drop constraint FK1A2E670F582CE0D1


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK73A69973186756F6]') AND parent_object_id = OBJECT_ID('Speakers'))
alter table Speakers  drop constraint FK73A69973186756F6


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF7153E89F3556EA9]') AND parent_object_id = OBJECT_ID('VirtualGroups'))
alter table VirtualGroups  drop constraint FKF7153E89F3556EA9


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK757E8B2652015D4E]') AND parent_object_id = OBJECT_ID('UpcomingEvents'))
alter table UpcomingEvents  drop constraint FK757E8B2652015D4E


    if exists (select * from dbo.sysobjects where id = object_id(N'Recordings') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Recordings

    if exists (select * from dbo.sysobjects where id = object_id(N'Blogs') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Blogs

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    if exists (select * from dbo.sysobjects where id = object_id(N'Roles') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Roles

    if exists (select * from dbo.sysobjects where id = object_id(N'Speakers') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Speakers

    if exists (select * from dbo.sysobjects where id = object_id(N'VirtualGroups') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table VirtualGroups

    if exists (select * from dbo.sysobjects where id = object_id(N'Categories') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Categories

    if exists (select * from dbo.sysobjects where id = object_id(N'UpcomingEvents') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table UpcomingEvents

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

    create table Speakers (
        Id INT IDENTITY NOT NULL,
       FirstName NVARCHAR(255) null,
       LastName NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       Website NVARCHAR(255) null,
       PresentationFk INT null,
       primary key (Id)
    )

    create table VirtualGroups (
        Id INT IDENTITY NOT NULL,
       GroupName NVARCHAR(255) null,
       Website NVARCHAR(255) null,
       ManagerFk INT null,
       primary key (Id)
    )

    create table Categories (
        Id INT IDENTITY NOT NULL,
       Description NVARCHAR(255) null,
       primary key (Id)
    )

    create table UpcomingEvents (
        Id INT IDENTITY NOT NULL,
       Title NVARCHAR(255) null,
       EventDate DATETIME null,
       FullDescription NVARCHAR(255) null,
       ShortDescription NVARCHAR(255) null,
       Approved BIT null,
       PresenterFk INT null,
       primary key (Id)
    )

    alter table Roles 
        add constraint FK1A2E670F582CE0D1 
        foreign key (UserFk) 
        references Users

    alter table Speakers 
        add constraint FK73A69973186756F6 
        foreign key (PresentationFk) 
        references Recordings

    alter table VirtualGroups 
        add constraint FKF7153E89F3556EA9 
        foreign key (ManagerFk) 
        references Users

    alter table UpcomingEvents 
        add constraint FK757E8B2652015D4E 
        foreign key (PresenterFk) 
        references Speakers
