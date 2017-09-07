using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern {
    class Program {
        static void Main(string[] args) {
            MallardDuck md = new MallardDuck();
            RedheadDuck rd = new RedheadDuck();
            RubberDuck rud = new RubberDuck();

            md.Display();
            rd.Display();
            rud.Quack();
            rud.Fly();
        }
    }


    public abstract class Duck {

        /// <summary>
        /// 鸭子叫
        /// </summary>
        public virtual void Quack() {
            Console.WriteLine("呱呱");
        }

        /// <summary>
        /// 鸭子游泳
        /// </summary>
        public void Swim() {
            Console.WriteLine("游泳");
        }

        /// <summary>
        /// 鸭子外观
        /// </summary>
        public abstract void Display();

        /// <summary>
        /// 鸭子飞行
        /// </summary>
        public virtual void Fly() {
            Console.WriteLine("飞行");
        }

    }


    class RubberDuck : Duck {
        public override void Display() {
            throw new NotImplementedException();
        }

        public override void Quack() {
            //base.Quack();
            Console.WriteLine("吱吱");
        }

        //方案1，将Duck中的Fly方法为虚，橡皮鸭覆盖掉此方法并不做任何事情
        public override void Fly() {
            //base.Fly();
        }
    }


    class MallardDuck : Duck {
        public override void Display() {
            //throw new NotImplementedException();
            Console.WriteLine("绿头");
        }
    }


    class RedheadDuck : Duck {
        public override void Display() {
            //throw new NotImplementedException();
            Console.WriteLine("红头");
        }
    }
}
