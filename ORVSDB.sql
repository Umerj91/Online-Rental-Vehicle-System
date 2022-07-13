create database carrentalsystem
use carrentalsystem
create table users(userid varchar(30)primary key not null,fname varchar(30),lname varchar(30) ,email varchar(30),age int,city varchar(50),cnic varchar(30),passwrord varchar(30),imagetype nvarchar(50),image nvarchar(MAX))
select * from users
create table Car(carrid varchar(30)primary key not null,Cname varchar(30),ctype varchar(30) ,Engine varchar(30),rcity varchar(30),myear int,imagetype nvarchar(50),image nvarchar(MAX))
select * from car

alter table car add rent int
create table buyer(name varchar(30),)
create table allocation(name varchar(30),hiredate date,returndate date,address varchar(30),cnic varchar(30),time varchar(30),userid  varchar(30)foreign key(userid) references Users(userid),carrid  varchar(30)foreign key(carrid) references Car(carrid),payment varchar(20),amount int)
select * from allocation
delete from Car where carrid='ASD-865'
select b.name,b.hiredate,b.returndate,b.address,b.cnic,b.userid,b.carrid,b.payment,b.amount from allocation b inner join users  u on b.userid=u.userid
select * from Car c inner join allocation a on c.carrid=a.carrid
drop table allocation
create table admins(aid varchar(30)primary key not null,fname varchar(30),lname varchar(30) ,email varchar(30),age int,city varchar(50),cnic varchar(30),passwrord varchar(30),imagetype nvarchar(50),image nvarchar(MAX))
select * from admins