if exists (select * from dbo.sysobjects where id = object_id(N'Recordings') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Recordings
create table Recordings (
  Id INT IDENTITY NOT NULL,
   RecordingDuration NVARCHAR(255) null,
   RecordingTitle NVARCHAR(255) null,
   RecordingUrl NVARCHAR(255) null,
   RecordingDate DATETIME null,
   primary key (Id)
)
