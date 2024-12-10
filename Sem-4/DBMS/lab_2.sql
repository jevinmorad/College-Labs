-- Create Department Table
CREATE TABLE Department (
 DepartmentID INT PRIMARY KEY,
 DepartmentName VARCHAR(100) NOT NULL UNIQUE
);

--Insert
CREATE OR ALTER PROC PR_DEPARTMENT_INSERT
	@DepartmentID INT,
	@DepartmentName VARCHAR(50)
AS
BEGIN
	insert into Department values (@DepartmentID, @DepartmentName)
END

--Update
CREATE OR ALTER PROC PR_DEPARTMENT_UPDATE
	@DepartmentID INT,
	@DepartmentName VARCHAR(50)
AS
BEGIN
	Update Department 
	SET DepartmentId = @DepartmentID, DepartmentName = @DepartmentName
	where DepartmentID = @DepartmentID
END

--Delete
CREATE OR ALTER PROC PR_DEPARTMENT_DELETE
	@DepartmentID INT
AS
BEGIN
	Delete from Department 
	where DepartmentID = @DepartmentID
END

--Select by primary key
CREATE OR ALTER PROC PR_DEPARTMENT_SELECTBYPKEY
	@DepartmentID INT
AS
BEGIN
	Select * from Department 
	where DepartmentID = @DepartmentID
END

EXECUTE PR_DEPARTMENT_INSERT 1,'Admin'
EXECUTE PR_DEPARTMENT_INSERT 2,'IT'
EXECUTE PR_DEPARTMENT_INSERT 3,'HR'
EXECUTE PR_DEPARTMENT_INSERT 4,'Account'

--------------------------------------------------------------------------

-- Create Designation Table
CREATE TABLE Designation (
 DesignationID INT PRIMARY KEY,
 DesignationName VARCHAR(100) NOT NULL UNIQUE
);

 --Insert
CREATE OR ALTER PROC PR_DESIGNATION_INSERT
	@DesignationID INT,
	@DesignationName VARCHAR(100)
AS
BEGIN
	insert into Designation values (@DesignationID, @DesignationName)
END

--Update
CREATE OR ALTER PROC PR_DESIGNATION_UPDATE
	@DesignationID INT,
	@DesignationName VARCHAR(100)
AS
BEGIN
	Update Designation 
	SET DesignationID = @DesignationID, DesignationName = @DesignationID
	where DesignationID = DesignationID
END

--Delete
CREATE OR ALTER PROC PR_DESIGNATION_DELETE
	@DesignationID Int
AS
BEGIN
	Delete from Designation 
	where DesignationID = @DesignationID
END

--Select by primary key
CREATE OR ALTER PROC PR_DESIGNATION_SELECTBYPKEY
	@DesignationID Int
AS
BEGIN
	Select * from Designation 
	where DesignationID = @DesignationID
END

EXECUTE PR_DESIGNATION_INSERT 11,'Jobber'
EXECUTE PR_DESIGNATION_INSERT 12,'Welder'
EXECUTE PR_DESIGNATION_INSERT 13,'Clerk'
EXECUTE PR_DESIGNATION_INSERT 14,'Manager'
EXECUTE PR_DESIGNATION_INSERT 15,'CEO'

--------------------------------------------------------------------------

-- Create Person Table
CREATE TABLE Person (
 PersonID INT PRIMARY KEY IDENTITY(101,1),
 FirstName VARCHAR(100) NOT NULL,
 LastName VARCHAR(100) NOT NULL,
 Salary DECIMAL(8, 2) NOT NULL,
 JoiningDate DATETIME NOT NULL,
 DepartmentID INT NULL,
 DesignationID INT NULL,
 FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID),
 FOREIGN KEY (DesignationID) REFERENCES Designation(DesignationID)
);

--Insert
CREATE OR ALTER PROC PR_PERSON_INSERT
	@FirstName Varchar (100),
	@LastName Varchar (100),
	@Salary Decimal (8,2),
	@JoiningDate Datetime,
	@DepartmentID Int,
	@DesignationID Int
AS
BEGIN
	insert into Person values (@FirstName, @LastName, @Salary, @JoiningDate, @DepartmentID, @DesignationID)
END

--Update
CREATE OR ALTER PROC PR_PERSON_UPDATE
	@PersonID Int,
	@FirstName Varchar (100),
	@LastName Varchar (100),
	@Salary Decimal (8,2),
	@JoiningDate Datetime,
	@DepartmentID Int,
	@DesignationID Int
AS
BEGIN
	Update Person 
	SET FirstName = @FirstName, LastName = @LastName, Salary = @Salary, JoiningDate = @JoiningDate, DepartmentID = @DepartmentID, DesignationID = @DesignationID
	where PersonID = @PersonID
END

--Delete
CREATE OR ALTER PROC PR_PERSON_DELETE
	@PersonID Int
AS
BEGIN
	Delete from Person 
	where PersonID = @PersonID
END

--Select by primary key
CREATE OR ALTER PROC PR_PERSON_SELECTBYPKEY
	@PersonID Int
AS
BEGIN
	Select * from Person 
	where PersonID = @PersonID
END

EXECUTE PR_PERSON_INSERT 'Rahul', 'Anshu', 56000, '1990-01-01', 1, 12
EXECUTE PR_PERSON_INSERT 'Hardik', 'Hinsu', 18000, '1990-09-25', 2, 11
EXECUTE PR_PERSON_INSERT 'Bhavin', 'Kamani', 25000, '1991-5-14', NULL, 11
EXECUTE PR_PERSON_INSERT 'Bhoomi', 'Patel', 39000, '2024-02-20', 1, 13
EXECUTE PR_PERSON_INSERT 'Rohit', 'Rajgor', 17000, '1990-07-23', 2, 15
EXECUTE PR_PERSON_INSERT 'Priya', 'Mehta', 25000, '1990-10-18', 2, NULL
EXECUTE PR_PERSON_INSERT 'Neha', 'Trivedi', 18000, '2014-02-20', 3, 15

--3. Join if foreign key is available
CREATE OR ALTER PROC PR_JOIN
	@PersonID INT
AS
BEGIN
	Select dept.*, desig.*, per.*
	from Person per
	Join Department dept on dept.DepartmentID = per.DepartmentID
	Join Designation desig on desig.DesignationID = per.DesignationID
	where PersonID = @PersonID
END

--Select Top 3 from Person
CREATE OR ALTER PROC PR_TOP3
AS
BEGIN
	Select Top 3 * from Person
END
