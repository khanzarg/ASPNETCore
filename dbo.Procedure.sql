CREATE PROCEDURE [dbo].[Procedure]
	@Name varchar(200),
	@Email varchar(200),
	@Password varchar(200),
	@BirthDate Date,
	@Gender varchar(50),
	@Phone varchar(10),
	@Role int
AS
BEGIN
	DECLARE
		@EmpId as int

	INSERT INTO TB_M_Employee ([Name], BirthDate, Email, Gender)
	VALUES (@Name, @BirthDate, @Email, @Gender)

	SELECT @EmpId = Id
	FROM TB_M_Employee 
	WHERE Email = @Email
	
	INSERT INTO TB_M_Contact (Id, Phone)
	VALUES (@EmpId, @Phone)
	INSERT INTO TB_M_EmployeeRole(RoleId, EmployeeId)
	VALUES (@Role, @EmpId)

	INSERT INTO TB_M_Account
	VALUES (@EmpId, @Password);
END;

RETURN 0
