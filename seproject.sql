


drop table if exists userr
CREATE TABLE userr (
    user_ids INT PRIMARY KEY identity (500,2) ,
    username varchar(50) NOT NULL UNIQUE,
	name varchar(50),
    password VARCHAR (100) NOT NULL,
	staff_type varchar(50) NOT NULL
);

INSERT INTO userr (username, name, password , staff_type) VALUES
('user1', 'Haris' , 'password1' ,  'student'),
('user2', 'Sara', 'password2' , 'student'),
('user3', 'Muhammad' ,'password3',  'student'),
('user4', 'Asim' ,'password4', 'teacher');

select * from userr
drop table if exists classroom
create table classroom (
		classroom_code varchar(50) UNIQUE ,
		teacher_id varchar(50)
);



drop table if exists classroom_members
create table classroom_members (

		class_code varchar(50),
		teacher_id varchar(50),
		student_id varchar(50),


)

insert into classroom_members (class_code , teacher_id , student_id) values
('abcdef' , 'user5' , 'user2' )


select* from classroom_members
insert into classroom (classroom_code, teacher_id) values 
('abcdef', 'user5');

select * from classroom

drop table if exists course_outline
create table course_outline
(
		
		teacher_id varchar(50),
		class_code varchar(50),
		marks varchar(1000),
		outline varchar(1000)
);


select* from course_outline
drop table if exists Assignments
CREATE TABLE Assignments (
    AssignmentId INT PRIMARY KEY IDENTITY,
    TeacherId VARCHAR(50),
    ClassroomCode VARCHAR(50),
    AssignmentDescription VARCHAR(1000),
    FilePath VARCHAR(1000),
    SubmissionDate DATETIME DEFAULT GETDATE() -- Optional: Include submission date/time
);

select* from Assignments

drop table if exists SubmittedAssignments
CREATE TABLE SubmittedAssignments (
    SubmissionId INT PRIMARY KEY IDENTITY,
    AssignmentId INT,
    StudentId VARCHAR(50),
    ClassroomCode VARCHAR(50),
    SubmissionStatus VARCHAR(50) DEFAULT 'Not Submitted', -- Default status is 'Submitted'
	filepath varchar(1000)
);

select* from SubmittedAssignments


drop table if exists announcements
create table announcements (
	announcementID INT PRIMARY KEY IDENTITY,
	announcement varchar(5000),
	loginID varchar(50),
	classroomcode varchar(50),
	name varchar(50)

);
select* from announcements

drop table if exists query
create table query
(

	id INT PRIMARY KEY identity (100,2),
	query varchar(1000),
	loginID varchar(50),
	classroomcode varchar(50)

);
select * from query

drop table if exists Query_Response
create table Query_Response(

		id int ,
		response varchar(1000),
		loginID varchar(50),
		classroomcode varchar(50)



);
select * from Query_Response