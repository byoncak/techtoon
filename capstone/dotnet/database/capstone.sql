USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)
CREATE TABLE collections (
	collection_id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	collection_name VARCHAR(50) NOT NULL,
	is_public bit,
	CONSTRAINT PK_collections PRIMARY KEY (collection_id),
	CONSTRAINT FK_collection_user FOREIGN KEY (user_id) REFERENCES users (user_id)
	)

CREATE TABLE comics (
	--maybe link this to the API id number
	comic_id int IDENTITY(1,1) NOT NULL,
	marvel_id VARCHAR(100),
	title varchar(max) NOT NULL,
	issue_number int NOT NULL,
	description varchar(max),
	cover_img varchar(max),
	main_character varchar(max),
	CONSTRAINT PK_comics PRIMARY KEY (comic_id),
	)
CREATE TABLE comics_collections(
	comic_id int,
	collection_id int,
	CONSTRAINT PK_comics_collections PRIMARY KEY (comic_id, collection_id),
	CONSTRAINT FK_comics FOREIGN KEY (comic_id) REFERENCES comics (comic_id),
	CONSTRAINT FK_collections FOREIGN KEY (collection_id) REFERENCES collections (collection_id)
	)




--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO
