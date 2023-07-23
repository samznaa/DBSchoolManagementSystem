﻿//using DBSchoolManagementSystem.Controllers;
//using DBSchoolManagementSystem.Models;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.WebPages;

//namespace DBSchoolManagementSystem.Services
//{
//    public class StudentServices
//    {
//        public string InsertStudent(Student model)
//        {
//            using (SchoolManagement db = new SchoolManagement())
//            {
//                string ReturnMessage = string.Empty;

//                var TypeNameParam = new SqlParameter { ParameterName = "@FullName", Value = model.FullName };
//                var AddressParam = new SqlParameter { ParameterName = "@Address", Value = model.Address };
//                var EmailParam = new SqlParameter { ParameterName = "@Email", Value = model.Email };
//                var ContactnoParam = new SqlParameter { ParameterName = "@Contactno", Value = model.Contactno };
//                var GenderParam = new SqlParameter { ParameterName = "@Gender", Value = model.Gender };
//                var EnrollmentDateParam = new SqlParameter { ParameterName = "@EnrollmentDate", Value = model.EnrollmentDate };
//                var TypeIdParam = new SqlParameter { ParameterName = "@TypeId", Value = model.TypeId };
//                var MessageParam = new SqlParameter
//                {
//                    ParameterName = "@Message",
//                    DbType = DbType.String,
//                    Size = 50,
//                    Direction = ParameterDirection.Output
//                };

//                var PrimaryIdParam = new SqlParameter
//                {
//                    ParameterName = "@SID",
//                    DbType = DbType.Int32,
//                    Direction = ParameterDirection.Output
//                };

//                var result = db.Database.ExecuteSqlCommand("exec InsertStudent @FullName,@Address,@Email,@Contactno,@Gender,@EnrollmentDate,@Message OUT,@SID OUT", TypeNameParam, AddressParam, EmailParam, ContactnoParam, GenderParam, EnrollmentDateParam, TypeIdParam, MessageParam, PrimaryIdParam);

//                int PKID = (int)PrimaryIdParam.Value;
//                ReturnMessage = MessageParam.SqlValue.ToString();

//                return ReturnMessage;
//            }
//        }

//        public string UpdateStudent(Student model)
//        {
//            using (SchoolManagement db = new SchoolManagement())
//            {
//                string ReturnMessage = string.Empty;

//                var StudentIdParam = new SqlParameter { ParameterName = "@StudentId", Value = model.StudentId };
//                var TypeNameParam = new SqlParameter { ParameterName = "@FullName", Value = model.FullName };
//                var AddressParam = new SqlParameter { ParameterName = "@Address", Value = model.Address };
//                var EmailParam = new SqlParameter { ParameterName = "@Email", Value = model.Email };
//                var ContactnoParam = new SqlParameter { ParameterName = "@Contactno", Value = model.Contactno };
//                var GenderParam = new SqlParameter { ParameterName = "@Gender", Value = model.Gender };
//                var EnrollmentDateParam = new SqlParameter { ParameterName = "@EnrollmentDate", Value = model.EnrollmentDate };
//                var MessageParam = new SqlParameter
//                {
//                    ParameterName = "@Message",
//                    DbType = DbType.String,
//                    Size = 50,
//                    Direction = ParameterDirection.Output
//                };

//                var result = db.Database.ExecuteSqlCommand("exec UpdateStudent @StudentId, @FullName, @Address, @Email, @Contactno, @Gender, @EnrollmentDate, @Message OUT",
//                    StudentIdParam, TypeNameParam, AddressParam, EmailParam, ContactnoParam, GenderParam, EnrollmentDateParam, MessageParam);

//                ReturnMessage = MessageParam.SqlValue.ToString();

//                return ReturnMessage;
//            }
//        }
//        public string DeleteStudent(int StudentId)
//        {
//            using (SchoolManagement db = new SchoolManagement())
//            {
//                string returnMessage = string.Empty;

//                var studentIdParam = new SqlParameter { ParameterName = "@StudentId", Value = StudentId };
//                var messageParam = new SqlParameter
//                {
//                    ParameterName = "@Message",
//                    DbType = DbType.String,
//                    Size = 50,
//                    Direction = ParameterDirection.Output
//                };

//                var result = db.Database.ExecuteSqlCommand("exec DeleteStudent @StudentId, @Message OUT",
//                     studentIdParam, messageParam);

//                returnMessage = messageParam.SqlValue.ToString();

//                return returnMessage;
//            }
//        }
//        public List<StudentVm> GetStudentList()
//        {
//            using (SchoolManagement db = new SchoolManagement())
//            {
//                List<StudentVm> StudentList = new List<StudentVm>();

//                StudentList = db.Database.SqlQuery<StudentVm>("exec ListStudent").ToList();

//                return StudentList;
//            }
//        }

//        public List<AspNetRoles> GetAspNetRolesList()
//        {
//            using (SchoolManagement db = new SchoolManagement())
//            {
//                List<AspNetRoles> AspNetUserRolesList = new List<AspNetRoles>();

//                AspNetUserRolesList = db.Database.SqlQuery<AspNetRoles>("exec [dbo].[ListUserRoles]").ToList();

//                return AspNetUserRolesList;
//            }
//        }

//        public List<LeaveNoteVm> GetLeaveNoteList()
//        {
//            using (SchoolManagement db = new SchoolManagement())
//            {
//                List<LeaveNoteVm> leaveNotes = new List<LeaveNoteVm>();
//                leaveNotes = db.Database.SqlQuery<LeaveNoteVm>("exec ListLeaveNote").ToList();
//                return leaveNotes;
//            }

//        }


//        public List<AssignStudentVm> GetAssignStudentList()
//        {
//            using (SchoolManagement db = new SchoolManagement())
//            {
//                List<AssignStudentVm> assignStudent = new List<AssignStudentVm>();
//                assignStudent = db.Database.SqlQuery<AssignStudentVm>("exec AssignStudentList").ToList();
//                return assignStudent;
//            }

//        }

//        public List<Message> GetAssignMessageList()
//        {
//            using (SchoolManagement db = new SchoolManagement())
//            {
//                List<Message> message = new List<Message>();
//                message = db.Database.SqlQuery<Message>("exec AssignmentMessageList").ToList();
//                return message;
//            }
//        }

//        public List<SubmitAssignmentVm> GetSubmitList()
//        {
//            using (SchoolManagement db = new SchoolManagement())
//            {
//                List<SubmitAssignmentVm> message = new List<SubmitAssignmentVm>();
//                message = db.Database.SqlQuery<SubmitAssignmentVm>("exec SubmitList").ToList();
//                return message;
//            }
//        }

//        public List<AssignInstructorVm> GetAssignInstructorList()
//        {
//            using (SchoolManagement db = new SchoolManagement())
//            {
//                List<AssignInstructorVm> assignInstructors = new List<AssignInstructorVm>();
//                assignInstructors = db.Database.SqlQuery<AssignInstructorVm>("exec AssignInstructorList").ToList();
//                return assignInstructors;
//            }

//        }

//    }
//}
using DBSchoolManagementSystem.Controllers;
using DBSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace DBSchoolManagementSystem.Services
{
    public class StudentServices
    {
        public string InsertStudent(Student model)
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                string ReturnMessage = string.Empty;

                var TypeNameParam = new SqlParameter { ParameterName = "@FullName", Value = model.FullName };
                var AddressParam = new SqlParameter { ParameterName = "@Address", Value = model.Address };
                var EmailParam = new SqlParameter { ParameterName = "@Email", Value = model.Email };
                var ContactnoParam = new SqlParameter { ParameterName = "@Contactno", Value = model.Contactno };
                var GenderParam = new SqlParameter { ParameterName = "@Gender", Value = model.Gender };
                var EnrollmentDateParam = new SqlParameter { ParameterName = "@EnrollmentDate", Value = model.EnrollmentDate };
                var TypeIdParam = new SqlParameter { ParameterName = "@TypeId", Value = model.TypeId };
                var MessageParam = new SqlParameter
                {
                    ParameterName = "@Message",
                    DbType = DbType.String,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };

                var PrimaryIdParam = new SqlParameter
                {
                    ParameterName = "@SID",
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output
                };

                var result = db.Database.ExecuteSqlCommand("exec InsertStudent @FullName,@Address,@Email,@Contactno,@Gender,@EnrollmentDate,@Message OUT,@SID OUT", TypeNameParam, AddressParam, EmailParam, ContactnoParam, GenderParam, EnrollmentDateParam, TypeIdParam, MessageParam, PrimaryIdParam);

                int PKID = (int)PrimaryIdParam.Value;
                ReturnMessage = MessageParam.SqlValue.ToString();

                return ReturnMessage;
            }
        }

        public string UpdateStudent(Student model)
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                string ReturnMessage = string.Empty;

                var StudentIdParam = new SqlParameter { ParameterName = "@StudentId", Value = model.StudentId };
                var TypeNameParam = new SqlParameter { ParameterName = "@FullName", Value = model.FullName };
                var AddressParam = new SqlParameter { ParameterName = "@Address", Value = model.Address };
                var EmailParam = new SqlParameter { ParameterName = "@Email", Value = model.Email };
                var ContactnoParam = new SqlParameter { ParameterName = "@Contactno", Value = model.Contactno };
                var GenderParam = new SqlParameter { ParameterName = "@Gender", Value = model.Gender };
                var EnrollmentDateParam = new SqlParameter { ParameterName = "@EnrollmentDate", Value = model.EnrollmentDate };
                var MessageParam = new SqlParameter
                {
                    ParameterName = "@Message",
                    DbType = DbType.String,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };

                var result = db.Database.ExecuteSqlCommand("exec UpdateStudent @StudentId, @FullName, @Address, @Email, @Contactno, @Gender, @EnrollmentDate, @Message OUT",
                    StudentIdParam, TypeNameParam, AddressParam, EmailParam, ContactnoParam, GenderParam, EnrollmentDateParam, MessageParam);

                ReturnMessage = MessageParam.SqlValue.ToString();

                return ReturnMessage;
            }
        }
        public string DeleteStudent(int StudentId)
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                string returnMessage = string.Empty;

                var studentIdParam = new SqlParameter { ParameterName = "@StudentId", Value = StudentId };
                var messageParam = new SqlParameter
                {
                    ParameterName = "@Message",
                    DbType = DbType.String,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };

                var result = db.Database.ExecuteSqlCommand("exec DeleteStudent @StudentId, @Message OUT",
                     studentIdParam, messageParam);

                returnMessage = messageParam.SqlValue.ToString();

                return returnMessage;
            }
        }
        public List<StudentVm> GetStudentList()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<StudentVm> StudentList = new List<StudentVm>();

                StudentList = db.Database.SqlQuery<StudentVm>("exec ListStudent").ToList();

                return StudentList;
            }
        }

        public List<AspNetRoles> GetAspNetRolesList()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<AspNetRoles> AspNetUserRolesList = new List<AspNetRoles>();

                AspNetUserRolesList = db.Database.SqlQuery<AspNetRoles>("exec [dbo].[ListUserRoles]").ToList();

                return AspNetUserRolesList;
            }
        }

        public List<leaveNoteVm> GetLeaveNoteList()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<leaveNoteVm> leaveNotes = new List<leaveNoteVm>();
                leaveNotes = db.Database.SqlQuery<leaveNoteVm>("exec ListLeaveNote").ToList();
                return leaveNotes;
            }

        }

        public List<AssignInstructorVm> GetAssignInstructorList()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<AssignInstructorVm> assignInstructors = new List<AssignInstructorVm>();
                assignInstructors = db.Database.SqlQuery<AssignInstructorVm>("exec AssignInstructorList").ToList();
                return assignInstructors;
            }

        }
        public List<AssignStudentVm> GetAssignStudentList()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<AssignStudentVm> assignStudent = new List<AssignStudentVm>();
                assignStudent = db.Database.SqlQuery<AssignStudentVm>("exec AssignStudentList").ToList();
                return assignStudent;
            }

        }

        public List<Message> GetAssignMessageList()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<Message> message = new List<Message>();
                message = db.Database.SqlQuery<Message>("exec AssignmentMessageList").ToList();
                return message;
            }

        }

        public List<SubmitAssignmentVm> GetSubmitList()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<SubmitAssignmentVm> message = new List<SubmitAssignmentVm>();
                message = db.Database.SqlQuery<SubmitAssignmentVm>("exec SubmitList").ToList();
                return message;
            }

        }




    }



}

 
