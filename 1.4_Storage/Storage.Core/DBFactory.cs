using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Zero.Storage.Core
{
    public class DBFactory
    {
        private const string ConnectionStringSchool = "ConnectionString.hzjy_school";
        private const string ConnectionStringBasis = "ConnectionString.hzyj_basis";
        private const string ConnectionStringFamily = "ConnectionString.hzyj_family";

        private static Database _school;
        private static Database _basis;
        private static Database _family;

        static DBFactory()
        {
            Init();
        }

        protected DBFactory()
        {

        }

        public static Database School
        {
            get { return _school; }
        }

        public static Database Basis
        {
            get { return _basis; }
        }

        public static Database Family
        {
            get { return _family; }
        }

        public static void Reset()
        {
            Init();
        }

        private static void Init()
        {
            try
            {
                _school = DatabaseFactory.CreateDatabase(ConnectionStringSchool);
                _basis = DatabaseFactory.CreateDatabase(ConnectionStringBasis);
                _family = DatabaseFactory.CreateDatabase(ConnectionStringFamily);
            }
            catch (Exception e)
            {
                //xQuant.Log4.LogHelper.Write(xQuant.Log4.LogLevel.Error, String.Format("DBFactory 静态构造函数异常：{0}", e.ToString()));
                //写入日志
            }
        }

        #region Oracle数据处理的特殊处理
        /// <summary>
        /// 设置Oracle在读取数据时，对Clob字段方式为完全读取, 如果不是Oracle则不启作用
        /// </summary>
        /// <param name="dbCommand"></param>
        public static void SetOracleCommandClobFetchSize(DbCommand dbCommand)
        {
            Oracle.DataAccess.Client.OracleCommand command = dbCommand as Oracle.DataAccess.Client.OracleCommand;
            if (command == null)
                //throw new Exception("DbCommand不是OracleCommand或为空");
                return;
            command.InitialLOBFetchSize = -1;
        }

        /// <summary>
        /// 设置OracleDataReader RowSize, 记录数1000, 如果不是Oracle则不启作用
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="reader"></param>
        public static void SetOracleDataReaderRowSize(DbCommand dbCommand, IDataReader reader)
        {
            SetOracleDataReaderRowSize(dbCommand, reader, 200);
        }

        /// <summary>
        /// 设置OracleDataReader RowSize, 如果不是Oracle则不启作用
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="reader"></param>
        /// <param name="rows"></param>
        public static void SetOracleDataReaderRowSize(DbCommand dbCommand, IDataReader reader, int rows)
        {
            Oracle.DataAccess.Client.OracleDataReader oreader;
            if (reader is Oracle.DataAccess.Client.OracleDataReader)
                oreader = reader as Oracle.DataAccess.Client.OracleDataReader;
            else
            {
                PropertyInfo pi = reader.GetType().GetProperty("InnerReader");
                if (pi == null)
                    return;

                oreader = pi.GetValue(reader, null) as Oracle.DataAccess.Client.OracleDataReader;
            }

            if (oreader == null)
            {
                return;
            }

            if (((Oracle.DataAccess.Client.OracleCommand)dbCommand).RowSize <= 0) //RowSize可能为0, 则不设置，使用默认值
                return;

            oreader.FetchSize = ((Oracle.DataAccess.Client.OracleCommand)dbCommand).RowSize * rows;
        }
        #endregion

        #region 获取表的查询sql语句中的字段列表
        /// <summary>
        /// 获取指定表名的架构信息
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetSchema(Database db, string tableName)
        {
            DbDataAdapter ap = db.GetDataAdapter();
            DbCommand cmd = db.GetSqlStringCommand(string.Format("SELECT * FROM {0}", tableName));
            cmd.Connection = db.CreateConnection();
            ap.SelectCommand = cmd;
            DataTable t = new DataTable();
            ap.FillSchema(t, SchemaType.Mapped);
            return t;
        }

        /// <summary>
        /// 将传入的数据表的列名组织成"prefix.ColumnN as prefix_ColumnN,..."格式
        /// </summary>
        /// <param name="table"></param>
        /// <param name="prefixTableName"></param>
        /// <returns></returns>
        public static string GetSelectFieldNameList(DataTable table, string prefixTableName)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn col in table.Columns)
            {
                if (sb.Length > 0)
                    sb.Append(", ");
                sb.AppendFormat("{0}.{1} AS {0}_{1}", prefixTableName, col.ColumnName);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将传入的数据表的列名组织成"prefix.ColumnN as prefix_ColumnN,..."格式
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tableName"></param>
        /// <param name="prefixTableName"></param>
        /// <returns></returns>
        public static string GetSelectFieldNameList(Database db, string tableName, string prefixTableName)
        {
            return GetSelectFieldNameList(GetSchema(db, tableName), prefixTableName);
        }

        /// <summary>
        /// 取数据库用户名
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static string GetUserId(Database db)
        {
            return GetConnectionElement(db.ConnectionString, "User ID");
        }

        private static string GetConnectionElement(string rawString, string name)
        {
            if (!rawString.Contains(name))
            {
                return string.Empty;
            }

            string value = "";
            int startIndex = rawString.IndexOf(name) + name.Length;
            int endIndex1 = rawString.IndexOf(")", startIndex);
            int endIndex2 = rawString.IndexOf(";", startIndex);

            if (endIndex1 > 0)
            {
                value = rawString.Substring(startIndex, endIndex1 - startIndex);
            }
            else if (endIndex2 > 0)
            {
                value = rawString.Substring(startIndex, endIndex2 - startIndex);
            }

            value = value.Replace("=", "").Trim();

            return value;
        }

        #endregion

        /// <summary>
        /// 系统默认超长的超时时间
        /// </summary>
        /// <returns></returns>
        public static TimeSpan DefaultLongTimeout
        {
            get
            {
                //2011-03-29 清算超时，默认从10分钟 改为30分钟。
                if (60 * 30 <= System.Transactions.TransactionManager.DefaultTimeout.TotalSeconds)
                    return System.Transactions.TransactionManager.DefaultTimeout;
                else
                    return new TimeSpan(0, 30, 0);
            }
        }

        /// <summary>
        /// 获取数据库服务端当前日期
        /// </summary>
        /// <returns></returns>
        public static string GetDateFromDataBase()
        {
            string sql = "SELECT TO_CHAR(SYSDATE,'YYYY-MM-DD') FROM DUAL";
            //return SimpleDal.ExecuteScalar(DBFactory.TRD, sql).ToString();
            return string.Empty;
        }

        /// <summary>
        /// 获取数据库服务端当前日期时间
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeFromDataBase()
        {
            //string sql = "SELECT TO_CHAR(SYSDATE,'YYYY-MM-DD HH24:MI:SS') FROM DUAL";
            //return SimpleDal.ExecuteScalar(DBFactory.TRD, sql).ToString();
            return string.Empty;
        }
    }
}
