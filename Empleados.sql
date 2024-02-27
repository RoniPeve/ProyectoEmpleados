create database Empleados
go
use Empleados
go
create table empleados(
codigo int primary key identity,
nombre varchar(30) not null,
edad int not null,
sexo char(1) not null,
sueldo money not null)
go
insert into empleados values('Jose',33,'M',3000)
go
insert into empleados values('Maria',21,'F',4000)
go
insert into empleados values('Ana',31,'F',8000)
go
insert into empleados values('Carlos',44,'M',7000)
go
--select*from empleados

create procedure sp_listar
as
select*from empleados
go
--exec sp_listar

create procedure sp_insertar(
@nom varchar(30),
@edad int,
@sexo char(1),
@sue numeric(7,2))
as
insert into empleados values(@nom,@edad,@sexo,@sue)
go
exec sp_insertar 'Andres',31,'M',33333.34
go
create procedure sp_eliminar(
@cod int)
as 
delete from empleados where codigo=@cod
go
--exec sp_eliminar 5

create procedure sp_editar(
@cod int,
@nom varchar(30),
@edad int,
@sexo char(1),
@sue numeric(7,2))
as
update empleados set nombre=@nom,edad=@edad,sexo=@sexo,
	sueldo=@sue where codigo=@cod
go
	--exec sp_editar 3,'cecilia',21,'M',3333.33