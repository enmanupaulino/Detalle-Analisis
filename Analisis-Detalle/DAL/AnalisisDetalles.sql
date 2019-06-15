create database AnalisisDb

use AnalisisDb
create table Analisis(

AnalisisId int primary key identity ,
fecha datetime,
UsuarioId varchar (max),

)
create table TiposAnalisis(
TiposId int primary key identity,
Descripcion varchar (max)
)

