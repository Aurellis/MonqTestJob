
---------->Скрипт для создания БД<--------------


CREATE DATABASE [MonqTestJobDB] ON  PRIMARY 
( NAME = N'MonqTestJobDB', FILENAME = N'Путь к файлу mdf создаваемой базы данных' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MonqTestJobDB_log', FILENAME = N'Путь к файлу ldf создаваемой базы данных' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)

GO

USE [MonqTestJobDB]

GO

-------> Создание таблицы <-------

CREATE TABLE [dbo].[mails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject] [varchar](256) NOT NULL,
	[body] [varchar](8000) NOT NULL,
	[recipients] [varchar](8000) NOT NULL,
	[createdate] [datetime] NOT NULL,
	[result] [varchar](7) NULL,
	[failedmessage] [varchar](8000) NULL
) 
GO
