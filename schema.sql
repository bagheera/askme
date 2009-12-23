BEGIN TRANSACTION;
drop table if exists User;
drop table if exists Question;
drop table if exists Answer;
CREATE TABLE User(UserId primary key, UserName varchar(50), EmailId  varchar(50), Password  varchar(50));
CREATE TABLE Question(Id primary key, Text varchar(100), askedOn datetime);
CREATE TABLE Answer(AnswerId primary key, Text varchar(100), createdOn datetime, QuestionId int, UserId int);
COMMIT;