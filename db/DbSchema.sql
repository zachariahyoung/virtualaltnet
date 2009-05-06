if exists (select * from dbo.sysobjects where id = object_id(N'Recordings') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Recordings
if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users
create table Recordings (
  Id INT IDENTITY NOT NULL,
   RecordingDuration NVARCHAR(255) null,
   RecordingTitle NVARCHAR(255) null,
   RecordingUrl NVARCHAR(255) null,
   RecordingDate DATETIME null,
   primary key (Id)
)
create table Users (
  Id INT IDENTITY NOT NULL,
   LastName NVARCHAR(255) null,
   UserName NVARCHAR(255) null,
   FirstName NVARCHAR(255) null,
   Email NVARCHAR(255) null,
   Password NVARCHAR(255) null,
   primary key (Id)
)
