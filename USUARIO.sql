
create table tb_departamento(
	id int identity not null primary key,
	departamento nvarchar(100) not null
)

create table tb_ciudad(
	id int identity not null primary key,
	ciudad nvarchar(100) not null,
	departamento int not null,
	foreign key(departamento) references tb_departamento,
)


create table tb_user(
	id int identity not null primary key,
	primer_nombre nvarchar(100) not null,
	otros_nombres nvarchar(100) null,
	primer_apellido nvarchar(100) not null,
	segundo_apellido nvarchar(100) null,
	documento nvarchar(100) not null,
	celular nvarchar(20) not null,
	correo nvarchar(100) not null,
	ciudad int not null,
	departamento int not null,
	foreign key(ciudad) references tb_ciudad,
	foreign key(departamento) references tb_departamento,
	unique(celular, correo)
)