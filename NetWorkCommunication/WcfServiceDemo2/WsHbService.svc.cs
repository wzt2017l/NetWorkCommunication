using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceDemo2
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“WsHbService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 WsHbService.svc 或 WsHbService.svc.cs，然后开始调试。
    public class WsHbService : IWsHbService
    {
        protected Students data = new Students();
        public Students GetStudents()
        {
            return data;
        }

        public string Hello(string name)
        {
            return "Hello:" + name;
        }

        public bool UpdateScore(int id, int newScore)
        {
          return  data.UpDateScore(id,newScore);
        }
        public string GetStudentValue()
        {
            return data.ToString();
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string OtherInfo { get; set; }

        public Student()
        {
            ID = 0;
            Name = "张三";
            OtherInfo = "自动生成";
            Score = 50;
        }

        public override string ToString()
        {
            return $"学号：{ID}，姓名：{Name}，成绩：{Score}，{OtherInfo}";
        }
    }

    public class Students
    {
        public List<Student> list { get; set; }
        public Students()
        {
            list = new List<Student>
            {
                new Student{ID=13001,Name="小张",Score=85},
                new Student{ID=13002,Name="小里",Score=88},
                new Student{ID=13003,Name="小名",Score=95},
                new Student{ID=13004,Name="小秋",Score=76},
                new Student{ID=13005,Name="小亲",Score=66}
            };
        }
        public bool UpDateScore(int id,int newScore)
        {
            var s = list.FirstOrDefault(_=>_.ID==id);
            if (s!=null)
            {
                s.Score = newScore;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in list)
            {
                sb.AppendLine(s.ToString());
            }
            return sb.ToString();
        }
    }
}
