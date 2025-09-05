# Appd\_StudentMag

LanoiraM\_6thAppd



RUN IN SSMS:

create database Lanoira\_SchoolDb

go



use Lanoira\_SchoolDb

go



create table Student (

Id int identity(1,1) primary key not null,

FullName varchar(50) not null,

Age int,

Email varchar(50)

);

go



THEN GO SCAFFOLDING

