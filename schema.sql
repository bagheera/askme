BEGIN TRANSACTION;
CREATE TABLE User(UserId varchar(20), UserName varchar(50), EmailId  varchar(50), Password  varchar(50));
CREATE TABLE Question(Id int, Text varchar(100), askedOn datetime);
CREATE TABLE Answer(AnswerId int, Text varchar(100), createdOn datetime, QuestionId int, UserId varchar(20));
CREATE TABLE Tag(tagId int, TagName varchar(120), QuestionId int);
COMMIT;