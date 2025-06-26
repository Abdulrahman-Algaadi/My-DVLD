using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Collections;
using System.Data.Common;
using System.Net;
using System.Security.Policy;
using System.Runtime.Remoting;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;
using System.ComponentModel;
namespace clsDataAccess
{
    public class clsDataAccess_Sql
    {

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON 
                            LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool Result = false;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseID;
        }
        public static bool UpdateStatus(int ApplicationID, short NewStatus)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @"Update  Applications  
                            set 
                                ApplicationStatus = @NewStatus, 
                                LastStatusDate = @LastStatusDate
                            where ApplicationID=@ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);
            command.Parameters.AddWithValue("LastStatusDate", DateTime.Now);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static DataTable FilterDetainedBy(string ColumnName, string FilterBy)
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = $"Select * From DetainedLicenses_View Where {ColumnName} Like @FilterBy";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@FilterBy", $"%{FilterBy}%");
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Dt.Load(Reader);
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return Dt;
        }

        public static DataTable GetAllDetainedLicense()
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"Select * From DetainedLicenses_View";
            SqlCommand Command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Dt.Load(Reader);
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return Dt;
        }
        public static bool SaveReleaseDetails(int DetainedID, DateTime ReleaseDate
            , int ReleasedByUserID, int ReleasedByApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"Update DetainedLicenses  
                            Set IsReleased =@IsReleased ,ReleaseApplicationID=@ReleaseApplicationID,ReleasedByUserID=@ReleasedByUserID,ReleaseDate=@ReleaseDate 
                        Where DetainID=@DetainID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@DetainID", DetainedID);
            Command.Parameters.AddWithValue("@IsReleased", 1);
            Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleasedByApplicationID);
            Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            try
            {
                connection.Open();
                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return RowsAffected != 0;
        }
        public static bool FindDetainedLicenseByLicenseID(int LicenseID, ref int DetainedID, ref decimal FineFees, ref int CreatedByUserID, ref DateTime DetainDate)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From DetainedLicenses Where LicenseID=@LicenseID And IsReleased=@IsReleased ";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@IsReleased", 0);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    DetainedID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];


                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static bool IsLicenseDetained(int LicenseID) {

            bool IsDetained = false;

            string Query = $"Select * From DetainedLicenses Where LicenseID=@LicenseID And IsReleased=@IsReleased";
            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))


            using (SqlCommand Command = new SqlCommand(Query, connection))
            {
                Command.Parameters.AddWithValue("@IsReleased", 0);
                Command.Parameters.AddWithValue("@LicenseID", LicenseID);


                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        IsDetained = true;
                    }

                }
                catch (Exception ex)
                {

                }
                finally { connection.Close(); }
            }

            return IsDetained;

        }
        public static int DetainLicense(int LicenseID, decimal FineFees, int CreatedByUserID, DateTime DetainDate)
        {
            int DetainID = 0;
            string Connection = ClsConnection.ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);

            string Query = @"Insert into DetainedLicenses(LicenseID,DetainDate,FineFees,CreatedByUserID)
                           Values (@LicenseID,@DetainDate,@FineFees,@CreatedByUserID);
                            Select SCOPE_IDENTITY();";
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@FineFees", FineFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@DetainDate", DetainDate);

                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        DetainID = Inserted;
                    }
                    else
                    {
                        DetainID = 0;
                    }

                }
                catch (Exception ex)
                {
                }
                finally { connection.Close(); }
            }
            return DetainID;
        }
        public static bool IsActiveLicense(int LicenseID)
        {

            bool IsFound = false;

            string Query = $"Select * From Licenses Where LicenseID=@LicenseID And IsActive=@IsActive  ";
            using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))


            using (SqlCommand Command = new SqlCommand(Query, connection))
            {
                Command.Parameters.AddWithValue("@IsActive", 1);
                Command.Parameters.AddWithValue("@LicenseID", LicenseID);


                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        IsFound = true;
                    }

                }
                catch (Exception ex)
                {

                }
                finally { connection.Close(); }
            }
            return IsFound;
        }
        public static bool DeActivateOldLicense(int LicenseID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"Update Licenses 
                            Set IsActive =@IsActive  Where LicenseID=@LicenseID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@IsActive", 0);
            try
            {
                connection.Open();
                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return RowsAffected != 0;
        }
        public static bool ActivateOldLicense(int LicenseID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"Update Licenses 
                            Set IsActive =@IsActive  Where LicenseID=@LicenseID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@IsActive", 1);
            try
            {
                connection.Open();
                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return RowsAffected != 0;
        }

        public static DataTable FilterDataBy(string ColumnName, string Filter)
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = $@"Select InternationalLicenses.InternationalLicenseID As Int_LicenseID,InternationalLicenses.ApplicationID,
InternationalLicenses.DriverID,InternationalLicenses.IssuedUsingLocalLicenseID As L_LicenseID,
InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate,InternationalLicenses.IsActive
From InternationalLicenses 
    Where {ColumnName} Like @Filter";
            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@Filter", $"%{Filter}%");
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Dt.Load(Reader);
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return Dt;
        }
        public static DataTable GetAllInternationalLicenseByPersonID()
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"
Select InternationalLicenses.InternationalLicenseID As Int_LicenseID,InternationalLicenses.ApplicationID,
InternationalLicenses.DriverID,InternationalLicenses.IssuedUsingLocalLicenseID As L_LicenseID,
InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate,InternationalLicenses.IsActive
From InternationalLicenses";
            SqlCommand Command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Dt.Load(Reader);
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return Dt;
        }
        public static bool FindInterNationalLicenseByID(int InternationalLicenseID, ref int AppID, ref int DriverID, ref int IssuedUsingLocalID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From InternationalLicenses Where InternationalLicenseID =@InternationalLicenseID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    AppID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];

                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IssuedUsingLocalID = (int)reader["IssuedUsingLocalLicenseID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    IsActive = Convert.ToBoolean(reader["IsActive"]);


                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static bool IsInternationalLicenseExists(int LicenseID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"
Select * From InternationalLicenses Where IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID; 
						";
            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    IsFound = true;

                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static int AddNewInternationalLicense(int ApplicationID,
                 int DriverID, DateTime ExpirationDate, DateTime IssueDate, bool IsActive, int CreatedByUserID, int IssuedIsingLocalLicenseID)
        {
            int LicenseID = 0;
            string Connection = ClsConnection.ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);

            int IsActiveint = (IsActive == true) ? 1 : 0;
            string Query = @"Insert into InternationalLicenses(CreatedByUserID,ApplicationID,DriverID,IssueDate,ExpirationDate,IsActive,IssuedUsingLocalLicenseID) 
                            Values(@CreatedByUserID,@ApplicationID,@DriverID,@IssueDate,@ExpirationDate,@IsActive,@IssuedUsingLocalLicenseID);
                            Select SCOPE_IDENTITY();
                                                        
";
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedIsingLocalLicenseID);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@IsActive", IsActiveint);

                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        LicenseID = Inserted;
                    }
                    else
                    {
                        LicenseID = 0;
                    }

                }
                catch (Exception ex)
                {
                }
                finally { connection.Close(); }
            }
            return LicenseID;
        }
        public static bool FindLicenseByLicenseID(ref int ApplicationID, int LicenseID, ref int DriverID
              , ref int CreatedByUserID, ref int LicenseClassID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref bool IsActive,
        ref byte IssueReason, ref decimal PaidFees)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From Licenses Where LicenseID=@LicenseID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    if (reader["Notes"]==DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IssueReason = (byte)reader["IssueReason"];
                    IsActive = Convert.ToBoolean(reader["IsActive"]);


                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static bool FindLicenseByLicenseID(int LicenseClass, ref int ApplicationID, int LicenseID, ref int DriverID
            , ref int CreatedByUserID, ref int LicenseClassID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref bool IsActive,
      ref byte IssueReason, ref decimal PaidFees)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From Licenses Where LicenseID=@LicenseID And LicenseClass=@LicenseClass ";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    Notes = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IssueReason = (byte)reader["IssueReason"];
                    IsActive = Convert.ToBoolean(reader["IsActive"]);


                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static bool IsLicenseExists(int LicenseID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"
Select * From Licenses Where LicenseID=@LicenseID; 
						";
            SqlCommand Command = new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    IsFound = true;

                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static DataTable GetAllInternationalLicenseByPersonID(int PersonID)
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"
SELECT InternationalLicenses.InternationalLicenseID, Applications.ApplicationID, LicenseClasses.ClassName, InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive
FROM   Applications INNER JOIN
             InternationalLicenses ON Applications.ApplicationID = InternationalLicenses.ApplicationID INNER JOIN
             People ON Applications.ApplicantPersonID = People.PersonID CROSS JOIN
             LicenseClasses
			 wHERE ApplicantPersonID=@ApplicationPersonID And LicenseClassID=3";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ApplicationPersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Dt.Load(Reader);
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return Dt;
        }
        public static DataTable GetAllLocalLicenseByPersonID(int PersonID)
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"SELECT Licenses.LicenseID, Applications.ApplicationID, LicenseClasses.ClassName,
            Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
               FROM   Applications INNER JOIN
             Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN
             LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID INNER JOIN
             LocalDrivingLicenseApplications ON 
            Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID AND LicenseClasses.LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID INNER JOIN
             People ON Applications.ApplicantPersonID = People.PersonID
	
			 Where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Dt.Load(Reader);
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return Dt;
        }

     
        public static DataTable GetAllDrivers()
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From Drivers_View";
            SqlCommand Command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Dt.Load(Reader);
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return Dt;
        }

        public static bool DeleteApplication(int LocalID)
        {
            int RowsAffectd = 0;
            bool IsDeleted = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"Delete  From LocalDrivingLicenseApplications 
                              Where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalID);

            try
            {
                connection.Open();

                RowsAffectd = Command.ExecuteNonQuery();
                if (RowsAffectd > 0)
                {
                    IsDeleted = true;
                }

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsDeleted;
        }
        public static bool IsLicenseWithClassExists(int PersonID, int ClassTypeID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"SELECT LocalDrivingLicenseApplications.LicenseClassID, LocalDrivingLicenseApplications.ApplicationID
From LocalDrivingLicenseApplications Inner join Applications On LocalDrivingLicenseApplications.ApplicationID =
Applications.ApplicationID Where ApplicantPersonID =@ApplicationPersonID And LicenseClassID=@LicenseClassID
						";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ApplicationPersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", ClassTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    IsFound = true;

                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static bool FindLicenseByApplicationID(int ApplicationID, ref int LicenseID, ref int DriverID
                , ref int CreatedByUserID, ref int LicenseClassID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref bool IsActive,
          ref byte IssueReason, ref decimal PaidFees)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From Licenses Where ApplicationID=@ApplicationID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    Notes = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IssueReason = (byte)reader["IssueReason"];

                    IsActive = Convert.ToBoolean(reader["IsActive"]);


                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static int AddNewLicense(
                int CreatedByUserID, int DriverID, int ApplicationID, int LicenseClassID,
                DateTime IssueDate, DateTime ExpirationDate, string Notes, int IssueReason, decimal PaidFees, bool IsActive)
        {
            int LicenseID = 0;
            string Connection = ClsConnection.ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);

            int IsActiveint = (IsActive == true) ? 1 : 0;
            string Query = @"Insert into Licenses(CreatedByUserID,ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason) 
                            Values(@CreatedByUserID,@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason);
                            Select SCOPE_IDENTITY();
                                                        
";
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@Notes", Notes);
                command.Parameters.AddWithValue("@IsActive", IsActiveint);
                command.Parameters.AddWithValue("@IssueReason", IssueReason);
                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        LicenseID = Inserted;
                    }
                    else
                    {
                        LicenseID = 0;
                    }

                }
                catch (Exception ex)
                {
                }
                finally { connection.Close(); }
            }
            return LicenseID;
        }
        public static DataTable GetDriverLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }
            catch (Exception e )
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
            
       }

        public static bool GetDriverInfoByDriverID(int DriverID,
           ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID,
            ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);

            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            //we dont update the createddate for the driver.
            string query = @"Update  Drivers  
                            set PersonID = @PersonID,
                                CreatedByUserID = @CreatedByUserID
                                where DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            int DriverID = 0;
            string Connection = ClsConnection.ConnectionString;
           
            string Query = @"
        INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
        VALUES (@PersonID, @CreatedByUserID, @CreatedDate);

        Select SCOPE_IDENTITY();
   ";
            using (SqlConnection connection = new SqlConnection(Connection))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@CreatedDate",DateTime.Now);
                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        DriverID = Inserted;
                    }
                    else
                    {
                        DriverID = 0;
                    }

                }
                catch (Exception ex)
                {
                }
                finally { connection.Close(); }
            }
            return DriverID;
        }
        public static int TestsThatAlreadyPassed(int LocalID)
        {
            int Num = 0;
            string Connection = ClsConnection.ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);
            string Query = @"Select PassedTestCount from LocalDrivingLicenseApplications_View Where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            using (SqlCommand command = new SqlCommand(Query, connection))
            {

                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalID);
                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        Num = Inserted;
                    }
                    else
                    {
                        Num = 0;
                    }

                }
                catch (Exception ex)
                {
                }
                finally { connection.Close(); }
            }
            return Num;

        }
        public static int PassedTest(int LocalID, int NumberOfPassedTests)
        {
            int Num = 0;
            string Connection = ClsConnection.ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);
            string Query = @"Select Top 1 Found=1 From LocalDrivingLicenseApplications_View Where  LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID 
                            And PassedTestCount=@PassedTestCount;";
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@PassedTestCount", NumberOfPassedTests);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalID);
                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        Num = Inserted;
                    }
                    else
                    {
                        Num = 0;
                    }

                }
                catch (Exception ex)
                {
                }
                finally { connection.Close(); }
            }
            return Num;

        }
        public static int IsLockedReturnNumber(int LocalID)
        {
            int Num = 0;
            string Connection = ClsConnection.ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);
            string Query = @"Select Top 1 Found =1 From TestAppointments Where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID And IsLocked=0;";
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalID);
                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        Num = Inserted;
                    }
                    else
                    {
                        Num = 0;
                    }

                }
                catch (Exception ex)
                {
                }
                finally { connection.Close(); }
            }



            return Num;
        }
        public static bool FindTestByAppID(int TestID, int TestAppID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From Tests Where TestAppointmentID=@TestAppointmentID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];


                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {

            int ID = -1;
            string Connection = ClsConnection.ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);
            string Query = @"Insert into Tests (TestAppointmentID,TestResult,Notes,CreatedByUserID)
                             Values(@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@Notes", Notes);
                command.Parameters.AddWithValue("@TestResult", TestResult);
                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        ID = Inserted;
                    }

                }
                catch (Exception ex)
                {
                }
                finally { connection.Close(); }
            }



            return ID;
        }

        public static bool FindAppointmentByID(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseID
            , ref DateTime AppointmentDate, ref decimal PaidFees, ref bool IsLocked, ref int CreatedByUserID,ref int ReTakeTestID)
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From TestAppointments Where TestAppointmentID=@TestAppointmentID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    IsLocked = (bool)reader["IsLocked"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    if (reader["RetakeTestApplicationID"]==DBNull.Value)
                    {
                        ReTakeTestID = -1;
                    }
                    else
                    {
                        ReTakeTestID  =(int) reader["RetakeTestApplicationID"];
                        
                    }


                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static bool FindAppointmentByLocalLicenseID(ref int TestAppointmentID, ref int TestTypeID, int LocalDrivingLicenseID
       , ref DateTime AppointmentDate, ref decimal PaidFees, ref bool IsLocked, ref int CreatedByUserID ,ref int ReTakeTestID )
        {

            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From TestAppointments Where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID And IsLocked=0";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestTypeID = (int)reader["TestTypeID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                    {
                        ReTakeTestID = -1;
                    }
                    else
                    {
                        ReTakeTestID = (int)reader["RetakeTestApplicationID"];

                    }


                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }

        public static bool _UpdateAppointment(int TestAppointmentID, DateTime AppointmentDate,
                    int CreatedByUserID, decimal PaidFees, int TestTypeID, int LocalDrivingLicenseID, bool IsLocked)


        {

            int IsLockedNum = (IsLocked == true) ? 1 : 0;
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = $@"Update TestAppointments
                            Set AppointmentDate=@AppointmentDate,CreatedByUserID=@CreatedByUserID,PaidFees=@PaidFees
                            ,TestTypeID=@TestTypeID,LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID,IsLocked= @IsLocked
                            Where TestAppointmentID =@TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);
            Command.Parameters.AddWithValue("@IsLocked", IsLockedNum);



            try
            {
                connection.Open();
                RowsAffected = Command.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return RowsAffected > 0;



        }
        public static DataTable GetAppointmentsForALocalID(int LocalID, int TestTypeID)
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"Select TestAppointmentID,TestTypes.TestTypeTitle,TestTypes.TestTypeFees,
                                IsLocked From TestAppointments inner join TestTypes On TestAppointments.TestTypeID
                            =TestTypes.TestTypeID Where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID And TestTypes.TestTypeID=@TestTypeID; ";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Dt.Load(Reader);
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return Dt;
        }
        public static int CountTrial(int LocalDrivintLicenseID, int TestTypeID) {
            int Counter = 0;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"Select Count(*) From TestAppointments Where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID 
                                    And TestTypeID =@TestTypeID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivintLicenseID);

            try
            {
                connection.Open();
                object obj = Command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                {

                    Counter = Inserted;

                }
                else
                    Counter = 0;
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return Counter;

        }
        public static int AddNewAppointment(int TestTypeID, int LocalDrivingLicenseID
            , DateTime AppointmentDate, decimal PaidFees, bool IsLocked, int CreatedByUserID)
        {

            int ID = -1;
            string Connection = ClsConnection.ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);
            string Query = @"Insert into TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,IsLocked,CreatedByUserID)
                             Values(@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@IsLocked,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);
                command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        ID = Inserted;
                    }

                }
                catch (Exception ex)
                {
                }
                finally { connection.Close(); }
                return ID;
            }
        }
        public static bool FindTestTypeByID(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref decimal TestTypeFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From TestTypes Where TestTypeID=@TestTypeID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestTypeFees = (decimal)reader["TestTypeFees"];
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];


                }
                reader.Close();

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static bool FindUserByID(int UserID, ref string UserName, ref string PassWord, ref bool IsAvtive, ref int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From Users Where UserID =@UserID";
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                cmd.Parameters.AddWithValue("@UserID", UserID);


                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        IsFound = true;

                        UserName = (string)reader["UserName"];
                        PassWord = (string)reader["Password"];
                        PersonID = (int)reader["PersonID"];
                        IsAvtive = ((bool)reader["IsActive"] == true) ? true : false;
                    }


                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }

            }
            return IsFound;
        }
        public static bool FindApplicationTypeByID(int ApplicationTypeID, ref string ApplicationTitle, ref decimal AppFees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From ApplicationTypes Where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationTitle = (string)reader["ApplicationTypeTitle"];
                    AppFees = (decimal)reader["ApplicationFees"];
                }

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;


        }
        public static bool FindLocalDrivingLicenseByApplicationID(ref int LocalDrivingLicenseAppID, ref int ClassTypeID, int ApplicationID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From LocalDrivingLicenseApplications Where ApplicationID=@ApplicationID";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    ClassTypeID = (int)Reader["LicenseClassID"];
                    LocalDrivingLicenseAppID = (int)Reader["LocalDrivingLicenseApplicationID"];

                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return IsFound;


        }

        public static bool FindLicenseClassByID(int LicenseID, ref string LicenseTitle, ref decimal LFees, ref byte ValidtyLengthPfLicense, ref byte MinimumAllowedAge)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From LicenseClasses Where LicenseClassID=@LicenseClassID";
            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    LicenseTitle = (string)reader["ClassName"];
                    LFees = (decimal)reader["ClassFees"];
                    ValidtyLengthPfLicense = (byte)reader["DefaultValidityLength"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                }

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static bool FindLicenseClassByName(ref int LicenseID,  string LicenseTitle, ref decimal LFees, ref byte ValidtyLengthPfLicense, ref byte MinimumAllowedAge)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = $"Select * From LicenseClasses Where ClassName like '{LicenseTitle}%'";
            SqlCommand Command = new SqlCommand(Query, connection);
        
            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    LicenseID = (int)reader["LicenseClassID"];
                    LFees = (decimal)reader["ClassFees"];
                    ValidtyLengthPfLicense = (byte)reader["DefaultValidityLength"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                }

            }
            catch (Exception Ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return IsFound;

        }
        public static DataTable GetAllApplicationTypes()
        {
            DataTable Dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From ApplicationTypes";
            SqlCommand Command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Dt.Load(Reader);
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return Dt;
        }
        public static bool UpdateApplication(int ApplicationID,
                  int ApplicationTypeID, DateTime ApplicationDate, decimal ApplicationFees, int ApplicantPersonID, DateTime LastStatusDate,
                 int CreatedByUserID, int ApplicationTypeStatus)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = @"Update Applications
                            Set ApplicantPersonID=@ApplicantPersonID,ApplicationDate=@ApplicationDate,ApplicationTypeID=@ApplicationTypeID
                            ,ApplicationStatus=@ApplicationStatus,LastStatusDate =@LastStatusDate,PaidFees= @PaidFees,CreatedByUserID=@CreatedByUserID
                            Where ApplicationID =@ApplicationID";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationTypeStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", ApplicationFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                RowsAffected = Command.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return RowsAffected > 0;
        }
        public static bool FindLocalDrivingLicenseAppID(int LocalDrivingLicenseAppID, ref int ClassTypeID, ref int ApplicationID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
            string Query = "Select * From LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseAppID);
            try
            {
                connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    ClassTypeID = (int)Reader["LicenseClassID"];
                    ApplicationID = (int)Reader["ApplicationID"];

                }

            }
            catch (Exception ex)
            {
                //
            }
            finally { connection.Close(); }
            return IsFound;


        }


        public static int AddNewLocalLiceneApplication(int ApplicationID, int LicenseClassID)
        {
            int ID = -1;
            string Connection = ClsConnection.ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);
            string Query = @"Insert into LocalDrivingLicenseApplications (ApplicationID,LicenseClassID)
                             Values(@ApplicationID,@LicenseClassID);
                             SELECT SCOPE_IDENTITY();";
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);



                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        ID = Inserted;
                    }

                }
                catch (Exception ex)
                {
                }
                finally { connection.Close(); }
                return ID;
            }

        }
        public static bool UpdateLocalDrivingLicenseApplication(int LocalID, int ClassTypeID )
        {
            int RowsAffected = 0;
            string Connection = ClsConnection.ConnectionString;
            SqlConnection connection = new SqlConnection(Connection);
            string Query = @"Update LocalDrivingLicenseApplications 
                              set LicenseClassID =@LicenseClassID";
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@LicenseClassID", ClassTypeID);
                try
                {
                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    //
                }
                finally
                {
                    connection.Close();
                }


            }
            return RowsAffected>0;
        }
            public static DataTable GetAllLocalApplications()
            {
                DataTable Dt = new DataTable();
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select * From LocalDrivingLicenseApplications_View";
                SqlCommand Command = new SqlCommand(Query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Dt.Load(Reader);
                    }

                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return Dt;
            }


            public static bool FindApplicationByApplicationID(int AppID, ref int PersonID, ref DateTime AppDate,
                ref int AppTypeID, ref byte AppStatusID, ref DateTime LastStatusDate, ref decimal Fees, ref int CreatedByUserID)
            {
                bool IsFound = false;

                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select * From Applications Where ApplicationID =@ApplicationID";
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", AppID);


                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            PersonID = (int)reader["ApplicantPersonID"];
                            AppDate = (DateTime)reader["ApplicationDate"];
                            AppTypeID = (int)reader["ApplicationTypeID"];
                            AppStatusID = (byte)reader["ApplicationStatus"];
                            LastStatusDate = (DateTime)reader["LastStatusDate"];
                            Fees = (decimal)reader["PaidFees"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];

                        }


                        reader.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }

                }
                return IsFound;

            }
            public static int AddNewApplication(int AppTypeID, int AppTypeStatusID,
                             DateTime LastDateStatus, DateTime AppDate, int CreatedByUserID, decimal AppFees, int PersonID)
            {

                int ID = -1;
                string Connection = ClsConnection.ConnectionString;
                SqlConnection connection = new SqlConnection(Connection);
                string Query = @"Insert into Applications (ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                             Values(@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", AppDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", AppTypeID);
                    command.Parameters.AddWithValue("@ApplicationStatus", AppTypeStatusID);
                    command.Parameters.AddWithValue("@LastStatusDate", LastDateStatus);
                    command.Parameters.AddWithValue("@PaidFees", AppFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                    try
                    {
                        connection.Open();
                        object obj = command.ExecuteScalar();
                        if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                        {
                            ID = Inserted;
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                    finally { connection.Close(); }
                    return ID;
                }
            }
            public static DataTable GetAllTestsType()
            {
                DataTable Dt = new DataTable();
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select * From ShortTestType_View";
                SqlCommand Command = new SqlCommand(Query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Dt.Load(Reader);
                    }

                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return Dt;
            }
            public static bool FindApplicationTestByID(int ID, ref string Title, ref string Desciption, ref decimal Fees)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select * From TestTypes Where TestTypeID=@TestTypeID";

                SqlCommand Command = new SqlCommand(Query, connection);
                Command.Parameters.AddWithValue("@TestTypeID", ID);
                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.Read())
                    {
                        IsFound = true;
                        Title = (string)Reader["TestTypeTitle"];
                        Desciption = (string)Reader["TestTypeDescription"];
                        Fees = (decimal)Reader["TestTypeFees"];


                    }

                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return IsFound;


            }
            public static bool UpdateApplicationTest(int ID, string Description, string Title, decimal Fees)
            {
                int RowsAffected = 0;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = @"Update TestTypes
                            Set TestTypeTitle=@TestTypeTitle,TestTypeDescription=@TestTypeDescription,TestTypeFees=@TestTypeFees
                             Where TestTypeID =@TestTypeID";

                SqlCommand Command = new SqlCommand(Query, connection);
                Command.Parameters.AddWithValue("@TestTypeID", ID);
                Command.Parameters.AddWithValue("@TestTypeTitle", Title);
                Command.Parameters.AddWithValue("@TestTypeDescription", Description);
                Command.Parameters.AddWithValue("@TestTypeFees", Fees);
                try
                {
                    connection.Open();
                    RowsAffected = Command.ExecuteNonQuery();



                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return RowsAffected > 0;

            }
            public static bool UpdateApplicationType(int ID, string Title, decimal Fees)
            {
                int RowsAffected = 0;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = @"Update ApplicationTypes
                            Set ApplicationTypeTitle=@ApplicationTypeTitle,ApplicationFees=@ApplicationFees
                             Where ApplicationTypeID =@ApplicationTypeID";

                SqlCommand Command = new SqlCommand(Query, connection);
                Command.Parameters.AddWithValue("@ApplicationTypeID", ID);
                Command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
                Command.Parameters.AddWithValue("@ApplicationFees", Fees);
                try
                {
                    connection.Open();
                    RowsAffected = Command.ExecuteNonQuery();



                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return RowsAffected > 0;

            }

            public static DataTable GetAllLicensesTypes()
            {
                DataTable Dt = new DataTable();
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = " Select * From LicenseClasses";
                SqlCommand Command = new SqlCommand(Query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Dt.Load(Reader);
                    }

                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return Dt;
            }



            public static bool UpdateUser(int UserID, string UserName, int PersonID, string Password, bool IsActive)
            {

                int RowAffected = 0;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = @"Update Users
                               Set UserName=@UserName,PersonID=@PersonID,Password=@Password,IsActive=@IsActive
                               Where UserID=@UserID";
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    Command.Parameters.AddWithValue("@UserName", UserName);
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    Command.Parameters.AddWithValue("@Password", Password);
                    Command.Parameters.AddWithValue("@IsActive", IsActive);
                    Command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        connection.Open();
                        RowAffected = Command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                return RowAffected > 0;

            }

            public static bool DeleteUser(string Col, int TheWay)
            {
                int RowsAffected = 0;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = $"Delete From Users Where {Col}=@UserID";
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@UserID", TheWay);
                try
                {
                    connection.Open();
                    RowsAffected = cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
                return RowsAffected > 0;
            }

            public static int AddNewUser(string UserName, int PersonID, string Password, bool IsActive)
            {
                int ID = -1;
                string Connection = ClsConnection.ConnectionString;
                SqlConnection connection = new SqlConnection(Connection);
                string Query = @"Insert into Users (UserName,PersonID,Password,IsActive)
                             Values(@UserName,@PersonID,@Password,@IsActive);
                             SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    try
                    {
                        connection.Open();
                        object obj = command.ExecuteScalar();
                        if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                        {
                            ID = Inserted;
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                    finally { connection.Close(); }
                }



                return ID;
            }
            public static bool FindUserByUserNameAndPassWord(ref int UserID, string UserName, ref int PersonID, string PassWord, ref bool IsAvtive)
            {
                bool IsFound = false;

                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select * From Users Where UserName=@UserName And Password =@Password";
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", PassWord);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            UserID = (int)reader["UserID"];
                            PersonID = (int)reader["PersonID"];
                            IsAvtive = (bool)reader["IsActive"] == true ? true : false;
                        }


                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }

                }
                return IsFound;
            }
            public static bool FindUserByPersonID(ref int UserID, ref string UserName, int PersonID, ref string PassWord, ref bool IsAvtive)
            {
                bool IsFound = false;

                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select * From Users Where PersonID =@PersonID";
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    cmd.Parameters.AddWithValue("@PersonID", PersonID);


                    try
                    {
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            UserID = (int)reader["UserID"];
                            UserName = (string)reader["UserName"];
                            PassWord = (string)reader["Password"];

                            IsAvtive = (bool)reader["IsActive"] == true ? true : false;
                        }


                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }

                }
                return IsFound;
            }


            public static DataTable GetAllUsers()
            {
                DataTable Dt = new DataTable();
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select * From Users_View";
                using (SqlCommand cmd = new SqlCommand(Query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader Reader = cmd.ExecuteReader();
                        if (Reader.HasRows)
                        {
                            Dt.Load(Reader);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        connection.Close();
                    }

                }
                return Dt;


            }







            public static bool DeletePerson(string Col, int TheWay)
            {
                int RowsAffected = 0;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = $"Delete From People Where {Col}=@PersonID";
                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@PersonID", TheWay);
                try
                {
                    connection.Open();
                    RowsAffected = cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
                return RowsAffected > 0;
            }
            public static bool FindPersonByID(int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phone,
             ref DateTime DateOfBirth, ref int NationalityCountryID, ref string NationalNo, ref string ImagePath, ref string Address, ref byte Gendor)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select * From People Where PersonID=@PersonID";

                SqlCommand Command = new SqlCommand(Query, connection);
                Command.Parameters.AddWithValue("@PersonID", ID);
                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.Read())
                    {
                        IsFound = true;
                        FirstName = (string)Reader["FirstName"];
                        SecondName = (string)Reader["SecondName"];
                        if (Reader["ThirdName"] != DBNull.Value)
                        {
                            ThirdName = (string)Reader["ThirdName"];
                        }
                        else
                        {
                            ThirdName = "";
                        }

                        LastName = (string)Reader["LastName"];
                        if (Reader["Email"] != DBNull.Value)
                        {
                            Email = (string)Reader["Email"];
                        }
                        else
                        {
                            Email = "";
                        }

                        Phone = (string)Reader["Phone"];
                        DateOfBirth = (DateTime)Reader["DateOfBirth"];
                        NationalityCountryID = (int)Reader["NationalityCountryID"];
                        NationalNo = (string)Reader["NationalNo"];
                        if (Reader["ImagePath"] != DBNull.Value)
                        {
                            ImagePath = (string)Reader["ImagePath"];

                        }
                        else
                            ImagePath = "";
                        Address = (string)Reader["Address"];
                        Gendor = (byte)Reader["Gendor"];



                    }

                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return IsFound;

            }
            public static bool FindPersonByNationalNo(ref int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phone,
          ref DateTime DateOfBirth, ref int NationalityCountryID, string NationalNo, ref string ImagePath, ref string Address, ref byte Gendor)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select * From People Where NationalNo=@NationalNo";

                SqlCommand Command = new SqlCommand(Query, connection);
                Command.Parameters.AddWithValue("@NationalNo", NationalNo);
                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.Read())
                    {
                        IsFound = true;
                        ID = (int)Reader["PersonID"];
                        FirstName = (string)Reader["FirstName"];
                        SecondName = (string)Reader["SecondName"];
                        if (Reader["ThirdName"] != DBNull.Value)
                        {
                            ThirdName = (string)Reader["ThirdName"];
                        }
                        else
                        {
                            ThirdName = "";
                        }

                        LastName = (string)Reader["LastName"];
                        if (Reader["Email"] != DBNull.Value)
                        {
                            Email = (string)Reader["Email"];
                        }
                        else
                        {
                            Email = "";
                        }

                        Phone = (string)Reader["Phone"];
                        DateOfBirth = (DateTime)Reader["DateOfBirth"];
                        NationalityCountryID = (int)Reader["NationalityCountryID"];

                        if (Reader["ImagePath"] != DBNull.Value)
                        {
                            ImagePath = (string)Reader["ImagePath"];

                        }
                        else
                            ImagePath = "";
                        Address = (string)Reader["Address"];
                        Gendor = (byte)Reader["Gendor"];



                    }

                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return IsFound;

            }
            public static DataTable GetAllPeople()
            {
                DataTable Dt = new DataTable();
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select * From GetPeople_View Order By FirstName Asc";
                SqlCommand Command = new SqlCommand(Query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Dt.Load(Reader);
                    }

                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return Dt;
            }

            public static DataTable GetAllCountries()
            {
                DataTable Dt = new DataTable();
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = "Select CountryName From Countries";
                SqlCommand Command = new SqlCommand(Query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Dt.Load(Reader);
                    }

                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return Dt;
            }

            public static bool IsColumnExists(string NewNationalNo, string Column)
            {

                bool IsFound = false;

                string Query = $"Select *From GetPeople_View Where {Column} =@NationalNo ";
                using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))

                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    Command.Parameters.AddWithValue("@NationalNo", NewNationalNo);


                    try
                    {
                        connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();
                        if (Reader.HasRows)
                        {
                            IsFound = true;
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                    finally { connection.Close(); }
                }
                return IsFound;
            }
            public static bool IsColumnExistsUser(string Content, string Column)
            {

                bool IsFound = false;

                string Query = $"Select *From Users where {Column} =@Data ";
                using (SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString))

                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    Command.Parameters.AddWithValue("@Data", Content);


                    try
                    {
                        connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();
                        if (Reader.HasRows)
                        {
                            IsFound = true;
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                    finally { connection.Close(); }
                }
                return IsFound;
            }
            public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, string Email, string Phone,
              DateTime DateOfBirth, int NationalityCountryID, string NationalNo, string ImagePath, string Address, int Gendor)
            {
                int ID = 0;
                string Connection = ClsConnection.ConnectionString;
                SqlConnection connection = new SqlConnection(Connection);
                string Query = @"Insert into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)
                            Values(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);
                            Select SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@SecondName", SecondName);
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@Gendor", Gendor);
                if (ImagePath != "" && ImagePath != null)
                {
                    command.Parameters.AddWithValue("@ImagePath", ImagePath);
                }
                else
                    command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


                command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

                command.Parameters.AddWithValue("@NationalNo", NationalNo);
                try
                {
                    connection.Open();
                    object obj = command.ExecuteScalar();
                    if (obj != null && int.TryParse(obj.ToString(), out int Inserted))
                    {
                        ID = Inserted;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { connection.Close(); }



                return ID;
            }
            public static bool FindCountryByName(string CountryName, ref int CountryID)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = @"Select * From Countries Where CountryName = @CountryName;";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@CountryName", CountryName);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        CountryID = (int)reader["CountryID"];
                        IsFound = true;
                    }

                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return IsFound;
            }
            public static bool FindCountryByID(ref string CountryName, int CountryID)
            {
                bool IsFound = false;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = @"Select * From Countries Where CountryID = @CountryID;";
                SqlCommand command = new SqlCommand(Query, connection);
                command.Parameters.AddWithValue("@CountryID", CountryID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        CountryName = (string)reader["CountryName"];
                        IsFound = true;
                    }

                }
                catch (Exception ex)
                {
                    //
                }
                finally { connection.Close(); }
                return IsFound;
            }
            public static bool UpdatePerson(int ID, string FirstName, string SecondName, string ThirdName,
                string LastName, string Email, string Phone, DateTime BirthDate, int NatioalityCountryID, string NationalNo,
                string ImagePath, string Address, int Gendor)
            {
                int RowAffected = 0;
                SqlConnection connection = new SqlConnection(ClsConnection.ConnectionString);
                string Query = @"Update People 
                        Set FirstName=@FirstName,SecondName=@SecondName ,ThirdName=@ThirdName,LastName=@LastName,Email=@Email,Phone=@Phone,DateOfBirth=@DateOfBirth,
                        NationalityCountryID=@NationalityCountryID,NationalNo=@NationalNo,ImagePath=@ImagePath,Address=@Address,Gendor=@Gendor
                        Where PersonID=@PersonID
";
                using (SqlCommand Command = new SqlCommand(Query, connection))
                {
                    Command.Parameters.AddWithValue("@FirstName", FirstName);
                    Command.Parameters.AddWithValue("@SecondName", SecondName);
                    Command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    Command.Parameters.AddWithValue("@LastName", LastName);
                    Command.Parameters.AddWithValue("@Email", Email);
                    Command.Parameters.AddWithValue("@Address", Address);
                    Command.Parameters.AddWithValue("@DateOfBirth", BirthDate);
                    Command.Parameters.AddWithValue("@Phone", Phone);
                    Command.Parameters.AddWithValue("@NationalityCountryID", NatioalityCountryID);
                    Command.Parameters.AddWithValue("@NationalNo", NationalNo);
                    Command.Parameters.AddWithValue("@Gendor", Gendor);
                    Command.Parameters.AddWithValue("@PersonID", ID);
                    if (ImagePath == "" || ImagePath == null)
                    {
                        Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
                    }
                    else
                    {
                        Command.Parameters.AddWithValue("@ImagePath", ImagePath);
                    }

                    try
                    {
                        connection.Open();
                        RowAffected = Command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                    }
                    finally {
                        connection.Close();
                    }
                }
                return RowAffected > 0;

            }
        }
    } 
