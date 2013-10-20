using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Storage.BlogContext
{
    public class UserStorage
    {
//        /// <summary>
//        /// 查询年级（获取指定学校的所有年级）
//        /// </summary>
//        /// <param name="schoolID">学校ID</param>
//        /// <param name="termID">学期ID</param>
//        /// <param name="userID">用户ID</param>
//        /// <param name="roleID">角色ID</param>
//        /// <returns></returns>
//        public static IList<SchoolGradeModel> SearchGrade(int schoolID, int termID, int userID, int roleID)
//        {
//            OracleParameter[] parameters =
//                new OracleParameter[]
//                    {
//                        OracleDbHelper.Instance.MakeOutParam("po_errno", OracleDbType.Int32, 30),
//                        OracleDbHelper.Instance.MakeOutParam("po_errmsg", OracleDbType.Varchar2, 512),
//                        OracleDbHelper.Instance.MakeInParam("pi_school_id", OracleDbType.Int32, schoolID),
//                        OracleDbHelper.Instance.MakeInParam("pi_school_term_id", OracleDbType.Int32, termID),
//                        OracleDbHelper.Instance.MakeInParam("pi_user_id", OracleDbType.Int32, userID),
//                        OracleDbHelper.Instance.MakeInParam("pi_role_id", OracleDbType.Int32, roleID),
//                        OracleDbHelper.Instance.MakeOutParam("po_result", OracleDbType.RefCursor)

//                    };
//            IList<SchoolGradeModel> schoolGrades = new List<SchoolGradeModel>();
//            using (DbDataReader reader = OracleDbHelper.Instance.ExecuteReader(CommandType.StoredProcedure, "aapkg_yujin.prc_school_grade_search", parameters))
//            {
//                if (reader.HasRows)
//                {
//                    while (reader.Read())
//                    {
//                        SchoolGradeModel schoolGrade = new SchoolGradeModel();
//                        ReadSchoolGrade(reader, ref schoolGrade);
//                        schoolGrades.Add(schoolGrade);
//                    }
//                }
//            }
//            return schoolGrades;
//        }

//        /// <summary>
//        /// 查询年级（获取指定学校的年级，通过老师ID）
//        /// </summary>
//        /// <param name="schoolID">学校ID</param>
//        /// <param name="termID">学期ID</param>
//        /// <param name="teacherID">老师ID</param>
//        /// <returns></returns>
//        public static IList<SchoolGradeModel> SearchGrade(int schoolID, int termID, int teacherID)
//        {
//            OracleParameter[] parameters =
//                new OracleParameter[]
//                    {
//                        OracleDbHelper.Instance.MakeInParam("SCHOOL_ID", OracleDbType.Int32, schoolID),
//                        OracleDbHelper.Instance.MakeInParam("SCHOOL_TERM_ID", OracleDbType.Int32, termID),
//                        OracleDbHelper.Instance.MakeInParam("USER_ID", OracleDbType.Int32, teacherID)
//                    };

//            string commandText = @"
//SELECT 
//SCHOOL_GRADE_ID,SCHOOL_ID,SCHOOL_TERM_ID,SCHOOL_GRADE_NAME,CLASS_COUNT,
//DISP_ORDER
//FROM SCHOOL_GRADE LEFT JOIN SCHOOL_CLASS ON SCHOOL_GRADE.SCHOOL_ID=:SCHOOL_ID AND SCHOOL_GRADE.SCHOOL_TERM_ID=:SCHOOL_TERM_ID AND SCHOOL_GRADE.SCHOOL_GRADE_ID=SCHOOL_CLASS.SCHOOL_GRADE_ID
//LEFT JOIN SCHOOL_CLASS_TEACHER ON SCHOOL_CLASS.SCHOOL_CLASS_ID=SCHOOL_CLASS_TEACHER.SCHOOL_CLASS_ID
//WHERE 
//SCHOOL_CLASS_TEACHER.SCHOOL_TERM_ID=:SCHOOL_TERM_ID AND SCHOOL_CLASS_TEACHER.USER_ID=:USER_ID";
//            IList<SchoolGradeModel> schoolGrades = new List<SchoolGradeModel>();
//            using (DbDataReader reader = OracleDbHelper.Instance.ExecuteReader(CommandType.Text, commandText, parameters))
//            {
//                if (reader.HasRows)
//                {
//                    while (reader.Read())
//                    {
//                        SchoolGradeModel schoolGrade = new SchoolGradeModel();
//                        ReadSchoolGrade(reader, ref schoolGrade);
//                        schoolGrades.Add(schoolGrade);
//                    }
//                }
//            }
//            return schoolGrades;
//        }

    }
}
