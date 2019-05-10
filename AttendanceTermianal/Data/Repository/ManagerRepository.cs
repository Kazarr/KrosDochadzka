using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ManagerRepository:ConnectionManager
    {
        public bool GenerateDB()
        {
            bool ret = false;
            Execute((command) =>
            {
                command.CommandText = @"IF  NOT EXISTS (SELECT [name] FROM [sys].[databases] WHERE [name] = N'KROSDOCHADZKA')
                                        BEGIN
                                            CREATE DATABASE[KROSDOCHADZKA]

                                        END";
                if (command.ExecuteNonQuery() != 0)
                {
                    ret = true;
                };
            });
            return ret;
        }
        /// <summary>
        /// TODO Refactor needed. 
        /// </summary>
        /// <returns></returns>
        // Každú tabuľku môžeme dať do samostatného scriptu a skupinu alterov tiež do samostatného
        // Inserty môžeme dať tiež do samostatného. 
        public bool GenerateTables()
        {
            bool ret = false;
            Execute((command) => 
            {
                command.CommandText = @"IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'DailyResult')
	                                    BEGIN
		                                    CREATE TABLE [DailyResult](
			                                    [Id] [int] IDENTITY(1,1) NOT NULL,
			                                    [IdEmployee] [int] NOT NULL,
			                                    [Start] [datetime2](7) NOT NULL,
			                                    [Finish] [datetime2](7) NULL,
			                                    [IdWorktype] [int] NOT NULL,
		                                     CONSTRAINT [PK_Daily_Result] PRIMARY KEY CLUSTERED 
		                                    (
			                                    [Id] ASC
		                                    )WITH (PAD_INDEX = OFF, 
                                                    STATISTICS_NORECOMPUTE = OFF,
                                                    IGNORE_DUP_KEY = OFF,
                                                    ALLOW_ROW_LOCKS = ON, 
                                                    ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		                                    ) ON [PRIMARY]
	                                    END
                                    IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Employee')
	                                    BEGIN
		                                    CREATE TABLE [Employee](
			                                    [Id] [int] IDENTITY(1,1) NOT NULL,
			                                    [Password] [varchar](40) NOT NULL,
			                                    [IdPerson] [int] NOT NULL,
			                                    [IdSupervisor] [int] NULL,
			                                    [IdPermission] [int] NOT NULL,
			                                    [Salary] [decimal](15, 5) NOT NULL,
			                                    [HiredDate] [date] NOT NULL,
		                                     CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
		                                    (
			                                    [Id] ASC
		                                    )WITH (PAD_INDEX = OFF, 
                                                    STATISTICS_NORECOMPUTE = OFF, 
                                                    IGNORE_DUP_KEY = OFF, 
                                                    ALLOW_ROW_LOCKS = ON, 
                                                    ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		                                    ) ON [PRIMARY]
	                                    END
                                    IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Permission')
	                                    BEGIN
		                                    CREATE TABLE [Permission](
			                                    [Id] [int] IDENTITY(1,1) NOT NULL,
			                                    [Name] [nvarchar](20) NOT NULL,
		                                     CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
		                                    (
			                                    [Id] ASC
		                                    )WITH (PAD_INDEX = OFF,
                                                    STATISTICS_NORECOMPUTE = OFF, 
                                                    IGNORE_DUP_KEY = OFF,
                                                    ALLOW_ROW_LOCKS = ON, 
                                                    ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		                                    ) ON [PRIMARY]
	                                    END
                                    IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Person')
	                                    BEGIN
		                                    CREATE TABLE [Person](
			                                    [ID] [int] IDENTITY(1,1) NOT NULL,
			                                    [FirstName] [nvarchar](25) NOT NULL,
			                                    [LastName] [nvarchar](25) NOT NULL,
			                                    [PhoneNumber] [nvarchar](15) NOT NULL,
			                                    [Adress] [nvarchar](100) NULL,
		                                     CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
		                                    (
			                                    [ID] ASC
		                                    )WITH (PAD_INDEX = OFF, 
                                                    STATISTICS_NORECOMPUTE = OFF, 
                                                    IGNORE_DUP_KEY = OFF, 
                                                    ALLOW_ROW_LOCKS = ON,
                                                    ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		                                    ) ON [PRIMARY]
	                                    END
                                    IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'WorkType')
	                                    BEGIN
		                                    CREATE TABLE [WorkType](
			                                    [Id] [int] IDENTITY(1,1) NOT NULL,
			                                    [Name] [nvarchar](50) NOT NULL,
		                                     CONSTRAINT [PK_Work_type] PRIMARY KEY CLUSTERED 
		                                    (
			                                    [Id] ASC
		                                    )WITH (PAD_INDEX = OFF, 
                                                    STATISTICS_NORECOMPUTE = OFF, 
                                                    IGNORE_DUP_KEY = OFF, 
                                                    ALLOW_ROW_LOCKS = ON, 
                                                    ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		                                    ) ON [PRIMARY]
	                                    END
                                    ALTER TABLE [DailyResult] ADD  CONSTRAINT [DF_Daily_Result_Start]  DEFAULT (getdate()) FOR [Start]
                                    ALTER TABLE [Employee] ADD  CONSTRAINT [DF_Employee_Salary]  DEFAULT ((0)) FOR [Salary]
                                    ALTER TABLE [Employee] ADD  CONSTRAINT [DF_Employee_HiredDate]  DEFAULT (getdate()) FOR [HiredDate]
                                    ALTER TABLE [DailyResult]  WITH CHECK ADD FOREIGN KEY([IdWorktype])
                                    REFERENCES [WorkType] ([Id])
                                    ALTER TABLE [DailyResult]  WITH CHECK ADD  CONSTRAINT [FK_Daily_Result_Login] FOREIGN KEY([IdEmployee])
                                    REFERENCES [Employee] ([Id])
                                    ALTER TABLE [DailyResult] CHECK CONSTRAINT [FK_Daily_Result_Login]
                                    ALTER TABLE [Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([IdSupervisor])
                                    REFERENCES [Employee] ([Id])
                                    ALTER TABLE [Employee] CHECK CONSTRAINT [FK_Employee_Employee]
                                    ALTER TABLE [Employee]  WITH CHECK ADD  CONSTRAINT [FK_Login_Permission] FOREIGN KEY([IdPermission])
                                    REFERENCES [Permission] ([Id])
                                    ALTER TABLE [Employee] CHECK CONSTRAINT [FK_Login_Permission]
                                    ALTER TABLE [Employee]  WITH CHECK ADD  CONSTRAINT [FK_Login_Person] FOREIGN KEY([IdPerson])
                                    REFERENCES [Person] ([ID])
                                    ALTER TABLE [Employee] CHECK CONSTRAINT [FK_Login_Person]


                                    INSERT INTO Person (FirstName, LastName, PhoneNumber)
                                    VALUES ('admin', 'admin', 'GolfBallHit')

                                    INSERT INTO Permission ([Name])
                                    VALUES ('Admin')

                                    INSERT INTO Permission ([Name])
                                    VALUES ('Supervisor')

                                    INSERT INTO Permission ([Name])
                                    VALUES ('Worker')

                                    INSERT INTO Employee ([Password], IdPerson, IdPermission)
                                    VALUES (LOWER(CONVERT(nvarchar(40), HASHBYTES('MD5', 'GolfBallHit'),2)), 1, 1)

                                    UPDATE Employee
                                    SET IdSupervisor = Id

                                    INSERT INTO WorkType ([Name])
                                    VALUES ('Work')

                                    INSERT INTO WorkType ([Name])
                                    VALUES ('Lunch')

                                    INSERT INTO WorkType ([Name])
                                    VALUES ('Holiday')

                                    INSERT INTO WorkType ([Name])
                                    VALUES ('Home office')

                                    INSERT INTO WorkType ([Name])
                                    VALUES ('Business trip')

                                    INSERT INTO WorkType ([Name])
                                    VALUES ('Doctor')

                                    INSERT INTO WorkType ([Name])
                                    VALUES ('Private')

                                    INSERT INTO WorkType ([Name])
                                    VALUES ('Other')";
                if(command.ExecuteNonQuery() != 0)
                {
                    ret = true;
                }
            });
            return ret;
        }
        public string GetDataBaseName()
        {
            string ret = "";
            Execute((command) => 
            {
                command.CommandText = @"SELECT [name] FROM [sys].[databases] WHERE[name] = N'KROSDOCHADZKA'";
                ret = (string)command.ExecuteScalar();
            });
            return ret;
        }
               
        public static DailyResultRepository DailyResultRepository = new DailyResultRepository();
        public static EmployeeRepository EmployeeRepository = new EmployeeRepository();
        public static PersonRepository PersonRepository = new PersonRepository();
        public static WorkTypeRepository WorkTypeRepository = new WorkTypeRepository();
        public static DaySummaryRepository DaySummaryRepository = new DaySummaryRepository();
        public static PermissionRepository PermissionRepository = new PermissionRepository();
    }
}
