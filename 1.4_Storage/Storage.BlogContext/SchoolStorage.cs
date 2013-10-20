using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Zero.Storage.Core;

namespace Zero.Storage.BlogContext
{
    /// <summary>
    /// obp.net 测试
    /// </summary>
    public static partial class SchoolStorage
    {
        public static bool Insert()
        {
            Database db = DBFactory.School;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO TPRC_PARAM_UNDERLYING");
            strSql.Append("( I_CODE, A_TYPE, M_TYPE, P_FLAG, P_SPOT_TYPE, P_SPOT_PRICE)");
            strSql.AppendFormat(" VALUES({0},{1},{2},{3},{4},{5})",
                                db.BuildParameterName("I_CODE"),
                                db.BuildParameterName("A_TYPE"),
                                db.BuildParameterName("M_TYPE"),
                                db.BuildParameterName("P_FLAG"),
                                db.BuildParameterName("P_SPOT_TYPE"),
                                db.BuildParameterName("P_SPOT_PRICE"));

            //DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());

            DbCommand dbCommand = db.GetSqlStringCommand(SchoolInsert);

            
            db.AddInParameter(dbCommand, "I_CODE", DbType.String, "");
            db.AddInParameter(dbCommand, "A_TYPE", DbType.String, "");
            db.AddInParameter(dbCommand, "M_TYPE", DbType.String, "");
            db.AddInParameter(dbCommand, "P_FLAG", DbType.String, "");
            db.AddInParameter(dbCommand, "P_SPOT_TYPE", DbType.Int32, "");
            db.AddInParameter(dbCommand, "P_SPOT_PRICE", DbType.Decimal, "");

            return db.ExecuteNonQuery(dbCommand) > 0;


            //Database db = DBFactory.APP;
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("INSERT INTO TPRC_PARAM_UNDERLYING");
            //strSql.Append("( I_CODE, A_TYPE, M_TYPE, P_FLAG, P_SPOT_TYPE, P_SPOT_PRICE)");
            //strSql.AppendFormat(" VALUES({0},{1},{2},{3},{4},{5})",
            //    db.BuildParameterName("I_CODE"),
            //    db.BuildParameterName("A_TYPE"),
            //    db.BuildParameterName("M_TYPE"),
            //    db.BuildParameterName("P_FLAG"),
            //    db.BuildParameterName("P_SPOT_TYPE"),
            //    db.BuildParameterName("P_SPOT_PRICE"));

            //DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            //db.AddInParameter(dbCommand, "I_CODE", DbType.String, aDr.I_CODE);
            //db.AddInParameter(dbCommand, "A_TYPE", DbType.String, aDr.A_TYPE);
            //db.AddInParameter(dbCommand, "M_TYPE", DbType.String, aDr.M_TYPE);
            //db.AddInParameter(dbCommand, "P_FLAG", DbType.String, aDr.P_FLAG);
            //db.AddInParameter(dbCommand, "P_SPOT_TYPE", DbType.Int32, aDr.P_SPOT_TYPE);
            //db.AddInParameter(dbCommand, "P_SPOT_PRICE", DbType.Decimal, aDr.P_SPOT_PRICE);
            //return db.ExecuteNonQuery(dbCommand);
            //return true;
        }

        public static bool Update()
        {
            //Database db = DBFactory.APP;
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("UPDATE TPRC_PARAM_UNDERLYING SET ");
            //strSql.AppendFormat("P_SPOT_TYPE ={0}, ", db.BuildParameterName("P_SPOT_TYPE"));
            //strSql.AppendFormat("P_SPOT_PRICE ={0}  ", db.BuildParameterName("P_SPOT_PRICE"));
            //strSql.Append("WHERE 1=1 ");
            //strSql.AppendFormat("AND I_CODE = {0} ", db.BuildParameterName("I_CODE"));
            //strSql.AppendFormat("AND A_TYPE = {0} ", db.BuildParameterName("A_TYPE"));
            //strSql.AppendFormat("AND M_TYPE = {0} ", db.BuildParameterName("M_TYPE"));
            //strSql.AppendFormat("AND P_FLAG = {0} ", db.BuildParameterName("P_FLAG"));

            //DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            //db.AddInParameter(dbCommand, "I_CODE", DbType.String, aDr.I_CODE);
            //db.AddInParameter(dbCommand, "A_TYPE", DbType.String, aDr.A_TYPE);
            //db.AddInParameter(dbCommand, "M_TYPE", DbType.String, aDr.M_TYPE);
            //db.AddInParameter(dbCommand, "P_FLAG", DbType.String, aDr.P_FLAG);
            //db.AddInParameter(dbCommand, "P_SPOT_TYPE", DbType.Int32, aDr.P_SPOT_TYPE);
            //db.AddInParameter(dbCommand, "P_SPOT_PRICE", DbType.Decimal, aDr.P_SPOT_PRICE);
            //return db.ExecuteNonQuery(dbCommand);
            return true;
        }
    }

    public static partial class SchoolStorage
    {
        private const string SchoolInsert = @"";

        private const string SchoolUpdate = @"";
    }
}
