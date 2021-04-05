
Database Info:-

-------------Table Creation-------------------------------------------------
CREATE TABLE [dbo].[Users] (
    [user_Id]   INT          NOT NULL,
    [user_name] VARCHAR (50) NULL,
    [mobile_No] INT          NULL,
    [email_Id]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([user_Id] ASC),
    CONSTRAINT [FK_AddressId] FOREIGN KEY ([user_Id]) REFERENCES [dbo].[Address] ([address_Id])
);


CREATE TABLE [dbo].[Address] (
    [address_Id] INT          IDENTITY (1, 1) NOT NULL,
    [house_No]   INT          NULL,
    [city]       VARCHAR (50) NULL,
    [state]      VARCHAR (50) NULL,
    [country]    VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([address_Id] ASC)
);



---------------------------------------------------------------------------------------------

Stored Procedures :-

1) Add User Details

CREATE PROCEDURE [dbo].[addUserDetails]
	@Username varchar(50),
	@UserMobileNo int,
	@UserEmailId varchar(50),
	@UserHouseNo varchar(50),
	@UserCity varchar(50),
	@UserState varchar(50),
	@UserCountry varchar(50)
AS
	DECLARE @IDENTITY INT

	INSERT INTO Address(house_No,city,state,country) 
	VALUES (@UserHouseNo,@UserCity,@UserState,@UserCountry);
	
	SELECT @IDENTITY =  @@IDENTITY FROM Address;


	INSERT INTO Users(user_Id,user_name,mobile_No,email_Id) 
	VALUES (@IDENTITY,@Username,@UserMobileNo,@UserEmailId);

	
RETURN 0



2) Get All Contact

CREATE PROCEDURE [dbo].[getAllUserDetails]
	
AS
	SELECT * from Users,Address where Users.user_Id=Address.address_Id;

RETURN 0






3) Get All Contact By Mobile Number

CREATE PROCEDURE [dbo].[getUsers]
	@mobiledetails int = 0
	
AS
	SELECT * from Users,Address WHERE Users.user_Id=Address.address_Id and mobile_No like @mobiledetails;
RETURN 0


-----------------------------------------------------------------------------------------------------------------------------------

1)Get All Details

Input :-

https://localhost:44333/User

Output:-
[
	{
		userId: 1,
		userName: "Vinit",
		mobileNo: 9878,
		emailId: "vinit@mail.com",
		address: {
					addressId: 0,
					houseNo: 192,
					city: "Akola",
					state: "MH",
					country: "IND"
				}
	},
	{
		userId: 2,
		userName: "Rahul",
		mobileNo: 9875,
		emailId: "Rahul@mail.com",
		address: {
					addressId: 0,
					houseNo: 194,
					city: "Bhilai",
					state: "CH",
					country: "IND"
				}
	},
	{
		userId: 10,
		userName: "Daenerys",
		mobileNo: 6732,
		emailId: "Daenerys@mail.com",
		address: {
					addressId: 0,
					houseNo: 100,
					city: "KingLand",
					state: "Westros",
					country: "UK"
				}
	}
]



2)Get Contact By Mobile Number


https://localhost:44333/User/9875

{
		userId: 2,
		userName: "Rahul",
		mobileNo: 9875,
		emailId: "Rahul@mail.com",
		address: {
					addressId: 0,
					houseNo: 194,
					city: "Bhilai",
					state: "CH",
					country: "IND"
				}
}

