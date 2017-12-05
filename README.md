# MQ
c#,.net实现的 简单的MQ生成和消费Demo
消息队列（MQ）是一种应用程序对应用程序的通信方法。
是使用Erlang编写的一个开源的消息队列，本身支持很多的协议：AMQP，XMPP, SMTP, STOMP，也正是如此，使的它变的非常重量级，更适合于企业级的开发。同时实现了一个经纪人(Broker)构架，
这意味着消息在发送给客户端时先在中心队列排队。对路由(Routing)，负载均衡(Load balance)或者数据持久化都有很好的支持。


1、首页需要在MQ 服务器中添加ExchangeList、QueueList、BindingList并且在web.config 中配置


2、生产 
在Global.asax.cs中初始化MQ生产 RabbitMQGateWay.GetPublisher().InitializeForPublisher("DataMakerPublisher");
           // 发送MQ
            bool flag = RabbitMQGateWay.GetPublisher().PublishMessage(JsonHelper.ObjectToJson<B_STUDENT>(b_student), "demoinfo_subscription");


3、消费：RabbitMQGateWay.GetSubscriber().InitializeForReceiver("DispatcherReceiver", HandleMessage);
                switch (routingKey)
                {
                    case "demoinfo_subscription":
                        //result = false;
                        result = PatrolGpsHandleEnQueue(jsonMsg);
                        break;
                }
