using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
     //定义猫大叫事件的代理
   public delegate void AlertHandler();
   //主人类
    class Human
    {
       //主人被惊醒的方法
        public void Wake()
        {
            Console.WriteLine("主人：喵喵（改动第二次），猫别叫");
        }
    }
    //老鼠类
    class Mouse
    {
       //老鼠被吓包的方法
        public void Run()
        {
            Console.WriteLine("老鼠：有危险,快撤！");
        }
    }
    //猫类
    class Cat
    {
       //猫大叫事件
        public event AlertHandler AlertEvent;
        public Cat()
        {
           //猫大叫时执行Cry方法
            AlertEvent += new AlertHandler(Alert);
        }
        //猫大叫事件执行的处理程序
        public void Alert()
        {
            Console.WriteLine("猫：呜哇...呜哇...");
        }
        //猫大叫的方法
        public void Cry()
        {
           //触发猫大叫的事件
            AlertEvent();
        }
    }
    //房子类
    class House
    {
       //房子里有一只老鼠、一只猫和主人
        public Mouse mouse = new Mouse();
        public Cat cat = new Cat();
        public Human human = new Human();
        //由于在一个房子里，猫大叫的事件会引发老鼠“逃跑”和主人“惊醒”
        //所以在这里把老鼠“逃跑”和主人“惊醒”两个方法挂接到猫大叫的事件上。
        public House()
        {
            cat.AlertEvent +=new AlertHandler(mouse.Run);
            cat.AlertEvent +=new AlertHandler(human.Wake);
        }

    }
    //客户程序
    class Program
    {
        static void Main(string[] args)
        {
           //有一间房子
            House h = new House();
            //猫大叫
            h.cat.Cry();

            Console.ReadKey();
        }
    }


}
