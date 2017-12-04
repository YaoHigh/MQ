using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQDemo
{
    /// <summary>
    /// 学生Model
    /// </summary>
    [Serializable]
    public partial class B_STUDENT
    {
        public B_STUDENT()
        { }
        #region Model
        private int _student_id;
        private int? _building_id;
        private string _dorm_nbr;
        private string _bed_nbr;
        private string _name;
        private string _sex;
        private string _student_nbr;
        private string _tel;
        private string _id_card;
        private string _image_path;
        private string _psd;
        private string _class;
        private string _email;
        private DateTime? _last_online_time;
        private int _login_times;
        private string _enable_flag = "1";
        private string _create_user_id;
        private DateTime _create_time = DateTime.Now;
        private string _update_user_id;
        private DateTime? _update_time;
        private int? _tenant_id;
        private int? _years;
        private string _banknum;
        private string _school_system;
        private string _open_id;
        private int? _org_id;
        private string _nation;
        private string _student_type;// STUDENT_TYPE;
        private string _areasource;//AREASOURCE
        private string _confirmflag;
        /// <summary>
        /// 
        /// </summary>
        public int STUDENT_ID
        {
            set { _student_id = value; }
            get { return _student_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BUILDING_ID
        {
            set { _building_id = value; }
            get { return _building_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DORM_NBR
        {
            set { _dorm_nbr = value; }
            get { return _dorm_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BED_NBR
        {
            set { _bed_nbr = value; }
            get { return _bed_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SEX
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string STUDENT_NBR
        {
            set { _student_nbr = value; }
            get { return _student_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TEL
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ID_CARD
        {
            set { _id_card = value; }
            get { return _id_card; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IMAGE_PATH
        {
            set { _image_path = value; }
            get { return _image_path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PSD
        {
            set { _psd = value; }
            get { return _psd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CLASS
        {
            set { _class = value; }
            get { return _class; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_ONLINE_TIME
        {
            set { _last_online_time = value; }
            get { return _last_online_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LOGIN_TIMES
        {
            set { _login_times = value; }
            get { return _login_times; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ENABLE_FLAG
        {
            set { _enable_flag = value; }
            get { return _enable_flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CREATE_USER_ID
        {
            set { _create_user_id = value; }
            get { return _create_user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CREATE_TIME
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UPDATE_USER_ID
        {
            set { _update_user_id = value; }
            get { return _update_user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UPDATE_TIME
        {
            set { _update_time = value; }
            get { return _update_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TENANT_ID
        {
            set { _tenant_id = value; }
            get { return _tenant_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? YEARS
        {
            set { _years = value; }
            get { return _years; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BANKNUM
        {
            set { _banknum = value; }
            get { return _banknum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCHOOL_SYSTEM
        {
            set { _school_system = value; }
            get { return _school_system; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OPEN_ID
        {
            set { _open_id = value; }
            get { return _open_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ORG_ID
        {
            set { _org_id = value; }
            get { return _org_id; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string NATION
        {
            set { _nation = value; }
            get { return _nation; }
        }
        public string STUDENT_TYPE
        {
            set { _student_type = value; }
            get { return _student_type; }
        }
        /// <summary>
        /// 生源地
        /// </summary>
        public string AREASOURCE
        {
            set { _areasource = value; }
            get { return _areasource; }
        }
        public string CONFIRM_FLAG
        {
            set { _confirmflag = value; }
            get { return _confirmflag; }
        }
        #endregion Model
    }
}
