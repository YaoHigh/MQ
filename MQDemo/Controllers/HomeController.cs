using LDTSSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MQDemo.Controllers
{
    public class HomeController : Controller
    {
        #region 默认页面
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion

        #region 生产
        /// <summary>
        /// 生产
        /// </summary>
        /// <returns></returns>
        public ActionResult Produce()
        {
            B_STUDENT b_student = new B_STUDENT();
            b_student.NAME = "张三" + DateTime.Now.ToString("HHmmss");
            b_student.SEX = "男";
            b_student.TEL = "13885150551";
            b_student.PSD = "96E79218965EB72C92A549DD5A330112";
            b_student.LOGIN_TIMES = 0;
            b_student.ENABLE_FLAG = "1";
            b_student.CREATE_TIME = DateTime.Now;

            // 发送MQ
            bool flag = RabbitMQGateWay.GetPublisher().PublishMessage(JsonHelper.ObjectToJson<B_STUDENT>(b_student), "demoinfo_subscription");

            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new Object[] { flag ? 1 : 0 };//返回一个自定义的object数组 
            return result;
        }
        #endregion

        #region 消费
        /// <summary>
        /// 消费
        /// 是个异步的过程
        /// </summary>
        /// <returns></returns>
        public ActionResult Consume()
        {
            RabbitMQGateWay.GetSubscriber().InitializeForReceiver("DispatcherReceiver", HandleMessage);

            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new Object[] { 1 };//返回一个自定义的object数组 
            return result;
        }

        #region 1 接收订阅处理HandleMessage
        /// <summary>
        /// 1.1 接收订阅处理HandleMessage
        /// </summary>
        /// <param name="jsonMsg">jsonMsg</param>
        /// <param name="routingKey">routingKey</param>
        /// <returns></returns>
        private bool HandleMessage(string jsonMsg, string routingKey)
        {
            bool result = true;
            try
            {
                switch (routingKey)
                {
                    case "demoinfo_subscription":
                        //result = false;
                        result = PatrolGpsHandleEnQueue(jsonMsg);
                        break;
                }
            }
            catch (Exception ex)
            {
                //mLogger.Error(ex.ToString());
            }
            return result;
        }
        #endregion

        #region 2 访问数据队列入数据
        /// <summary>
        /// 1.2 访问数据队列入数据
        /// </summary>
        /// <param name="jsonXgGpsinfoModel">json数据</param>
        /// <returns></returns>
        public bool PatrolGpsHandleEnQueue(string studentStr)
        {
            bool result = true;
            B_STUDENT b_student = null;
            if (IsValidOperateLogJson(studentStr, out b_student))
            {
                MQDAL.GetInstance().Add(b_student);
            }
            return result;
        }
        #endregion

        #region 2.1 校验从RabbitMQ队列获取用户访问Json串是否正确
        /// <summary>
        /// 1.2.1 校验从RabbitMQ队列获取用户访问Json串是否正确
        /// </summary>
        /// <param name="jsonXgGpsinfoModel">json数据</param>
        /// <param name="xgGpsinfoEntity">json转成的对象</param>
        /// <returns></returns>
        private bool IsValidOperateLogJson(string studentStr, out B_STUDENT student)
        {
            B_STUDENT newstudent = null;
            try
            {
                newstudent = JsonHelper.JSONToObject<B_STUDENT>(studentStr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            student = newstudent;
            if (student == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #endregion
    }
}