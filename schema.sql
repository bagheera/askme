BEGIN TRANSACTION;
drop table if exists User;
drop table if exists Question;
drop table if exists Answer;
drop table if exists Tag;
drop table if exists Vote;
CREATE TABLE User(UserId primary key, UserName varchar(50), EmailId  varchar(50), Password  varchar(50), Point int);
CREATE TABLE Question(Id primary key, Text varchar(100), askedOn datetime);
CREATE TABLE Answer(AnswerId primary key, Text varchar(100), createdOn datetime, QuestionId int, UserId int);
CREATE TABLE Tag(tagId int, TagName varchar(120), QuestionId int);

CREATE TABLE Vote(VoteId int, UserId int, Value int, answerId int);
drop table question;
Create table Question(Id primary key, Text varchar(100), askedOn datetime, accepted_answer_id int, constraint accepted_answer_fk foreign key (Accepted_Answer_Id) references Answer(AnswerId)); 
COMMIT;

