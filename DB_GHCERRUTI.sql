drop database if exists dbExercicioMVC;
create database dbExercicioMVC;
use dbExercicioMVC;



create table tbFuncionario(
ID_Func int primary key,
Nome_Func text not null,
Cargo_Func text not null
);


create table tbUsuario(
ID_User int primary key,
Nome_User text not null,
Observacao_User varchar (50) not null,
DataNascimento_User date not null,
Email_User varchar (200) not null,
Login_User text not null,
Senha_User text not null
);

select * from tbFuncionario;

select * from tbUsuario;














