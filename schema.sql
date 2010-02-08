BEGIN TRANSACTION;
drop table if exists User;
drop table if exists Question;
drop table if exists Answer;
drop table if exists Tag;
drop table if exists Vote;
drop table if exists vote;
drop table if exists question_vote;
drop table if exists answer_vote;
CREATE TABLE User(UserId primary key, UserName varchar(50), EmailId  varchar(50), Password  varchar(50), Point int);
CREATE TABLE Answer(AnswerId primary key, Text varchar(100), createdOn datetime, QuestionId int, UserId int);
CREATE TABLE Tag(tagId int, TagName varchar(120), QuestionId int);
Create table Question(Id primary key, Text varchar(100), askedOn datetime, accepted_answer_id int, constraint accepted_answer_fk foreign key (Accepted_Answer_Id) references Answer(AnswerId)); 
CREATE TABLE answer_vote(vote_id int, user_id int, Value int, answer_id int);
CREATE TABLE question_vote(vote_id int, user_id int, value int, question_id int);
COMMIT;

