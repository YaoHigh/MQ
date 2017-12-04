using Libs.DataBasePool;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace MQDemo
{
    public class MQDAL
    {
        public static string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        #region 单例模式
        private static MQDAL instance;

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        public static MQDAL GetInstance()
        {
            if (instance == null)
            {
                lock (typeof(MQDAL))
                {
                    if (instance == null)
                    {
                        instance = new MQDAL();
                    }
                }
            }
            return instance;
        }

        private MQDAL()
        {
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(B_STUDENT model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into b_student2(");
            strSql.Append("STUDENT_ID,BUILDING_ID,DORM_NBR,BED_NBR,NAME,SEX,STUDENT_NBR,TEL,ID_CARD,IMAGE_PATH,PSD,CLASS,EMAIL,LAST_ONLINE_TIME,LOGIN_TIMES,ENABLE_FLAG,CREATE_USER_ID,CREATE_TIME,UPDATE_USER_ID,UPDATE_TIME,TENANT_ID,YEARS,BANKNUM,SCHOOL_SYSTEM,OPEN_ID,ORG_ID,STUDENT_TYPE,NATION,AREASOURCE)");
            strSql.Append(" values (");
            strSql.Append("@STUDENT_ID,@BUILDING_ID,@DORM_NBR,@BED_NBR,@NAME,@SEX,@STUDENT_NBR,@TEL,@ID_CARD,@IMAGE_PATH,@PSD,@CLASS,@EMAIL,@LAST_ONLINE_TIME,@LOGIN_TIMES,@ENABLE_FLAG,@CREATE_USER_ID,@CREATE_TIME,@UPDATE_USER_ID,@UPDATE_TIME,@TENANT_ID,@YEARS,@BANKNUM,@SCHOOL_SYSTEM,@OPEN_ID,@ORG_ID,@STUDENT_TYPE,@NATION,@AREASOURCE)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@STUDENT_ID", MySqlDbType.Int32,11),
					new MySqlParameter("@BUILDING_ID", MySqlDbType.Int32,11),
					new MySqlParameter("@DORM_NBR", MySqlDbType.VarChar,8),
					new MySqlParameter("@BED_NBR", MySqlDbType.VarChar,8),
					new MySqlParameter("@NAME", MySqlDbType.VarChar,8),
					new MySqlParameter("@SEX", MySqlDbType.VarChar,2),
					new MySqlParameter("@STUDENT_NBR", MySqlDbType.VarChar,32),
					new MySqlParameter("@TEL", MySqlDbType.VarChar,16),
					new MySqlParameter("@ID_CARD", MySqlDbType.VarChar,18),
					new MySqlParameter("@IMAGE_PATH", MySqlDbType.VarChar,512),
					new MySqlParameter("@PSD", MySqlDbType.VarChar,32),
					new MySqlParameter("@CLASS", MySqlDbType.VarChar,8),
					new MySqlParameter("@EMAIL", MySqlDbType.VarChar,32),
					new MySqlParameter("@LAST_ONLINE_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@LOGIN_TIMES", MySqlDbType.Int32,11),
					new MySqlParameter("@ENABLE_FLAG", MySqlDbType.VarChar,1),
					new MySqlParameter("@CREATE_USER_ID", MySqlDbType.VarChar,32),
					new MySqlParameter("@CREATE_TIME", MySqlDbType.Timestamp),
					new MySqlParameter("@UPDATE_USER_ID", MySqlDbType.VarChar,32),
					new MySqlParameter("@UPDATE_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@TENANT_ID", MySqlDbType.Int32,11),
					new MySqlParameter("@YEARS", MySqlDbType.Int32,4),
					new MySqlParameter("@BANKNUM", MySqlDbType.VarChar,50),
					new MySqlParameter("@SCHOOL_SYSTEM", MySqlDbType.VarChar,10),
					new MySqlParameter("@OPEN_ID", MySqlDbType.VarChar,128),
					new MySqlParameter("@ORG_ID", MySqlDbType.Int32,11),
                    new MySqlParameter("@STUDENT_TYPE", MySqlDbType.VarChar,16),
                    new MySqlParameter("@NATION", MySqlDbType.VarChar,16),
                    new MySqlParameter("@AREASOURCE", MySqlDbType.VarChar,16)};

            parameters[0].Value = model.STUDENT_ID;
            parameters[1].Value = model.BUILDING_ID;
            parameters[2].Value = model.DORM_NBR;
            parameters[3].Value = model.BED_NBR;
            parameters[4].Value = model.NAME;
            parameters[5].Value = model.SEX;
            parameters[6].Value = model.STUDENT_NBR;
            parameters[7].Value = model.TEL;
            parameters[8].Value = model.ID_CARD;
            parameters[9].Value = model.IMAGE_PATH;
            parameters[10].Value = model.PSD;
            parameters[11].Value = model.CLASS;
            parameters[12].Value = model.EMAIL;
            parameters[13].Value = model.LAST_ONLINE_TIME;
            parameters[14].Value = model.LOGIN_TIMES;
            parameters[15].Value = model.ENABLE_FLAG;
            parameters[16].Value = model.CREATE_USER_ID;
            parameters[17].Value = model.CREATE_TIME;
            parameters[18].Value = model.UPDATE_USER_ID;
            parameters[19].Value = model.UPDATE_TIME;
            parameters[20].Value = model.TENANT_ID;
            parameters[21].Value = model.YEARS;
            parameters[22].Value = model.BANKNUM;
            parameters[23].Value = model.SCHOOL_SYSTEM;
            parameters[24].Value = model.OPEN_ID;
            parameters[25].Value = model.ORG_ID;
            parameters[26].Value = model.STUDENT_TYPE;
            parameters[27].Value = model.NATION;
            parameters[28].Value = model.AREASOURCE;

            try
            {
                int rows = ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                throw;
            }
        }
        #endregion

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}