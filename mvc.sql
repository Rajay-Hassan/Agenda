
--CREATE DATABASE agenda;
------------------------------------------------------------*/
USE agenda;

/*------------------------------------------------------------
-- Table: brokers
------------------------------------------------------------*/
CREATE TABLE brokers(
	idBroker      INT IDENTITY (1,1) NOT NULL ,
	lastname      NVARCHAR (50) NOT NULL ,
	firstname     NVARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL  ,
	CONSTRAINT brokers_PK PRIMARY KEY (idBroker)
);


/*------------------------------------------------------------
-- Table: customers
------------------------------------------------------------*/
CREATE TABLE customers(
	idCustomer    INT IDENTITY (1,1) NOT NULL ,
	lastname      NVARCHAR (50) NOT NULL ,
	firstname     NVARCHAR (50) NOT NULL ,
	mail          VARCHAR (100) NOT NULL ,
	phoneNumber   VARCHAR (10) NOT NULL ,
	budget        INT  NOT NULL  ,
	CONSTRAINT customers_PK PRIMARY KEY (idCustomer)
);


/*------------------------------------------------------------
-- Table: appointments
------------------------------------------------------------*/
CREATE TABLE appointments(
	idAppointment   INT IDENTITY (1,1) NOT NULL ,
	dateHour        DATETIME  NOT NULL ,
	subject         TEXT  NOT NULL ,
	idBroker        INT  NOT NULL ,
	idCustomer      INT  NOT NULL  ,
	CONSTRAINT appointments_PK PRIMARY KEY (idAppointment)

	,CONSTRAINT appointments_brokers_FK FOREIGN KEY (idBroker) REFERENCES brokers(idBroker)
	,CONSTRAINT appointments_customers0_FK FOREIGN KEY (idCustomer) REFERENCES customers(idCustomer)
);



