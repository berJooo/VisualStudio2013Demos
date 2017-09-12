using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern {
    class Program {
        static void Main(string[] args) {
            Duck modeDuck = new ModeDuck();
            modeDuck.performFly();
            modeDuck.SetFlyBehavior(new FlyRocket());
            modeDuck.SetQuackBehavior(new Squeak());
            modeDuck.performFly();
            modeDuck.performQuack();
            modeDuck.Swim();
            modeDuck.Display();
        }
    }


    public abstract class Duck {

        /// <summary>
        /// 声明变量类型为行为的接口类型
        /// </summary>
        public QuackBehavior quackBehavior;//每只鸭子都会引用实现QuackBehavior接口的对象
        public FlyBehavior flyBehavior;

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
        /// 此方法取代了Quack
        /// </summary>
        public void performQuack() {
            quackBehavior.Quack1();//鸭子对象不亲自处理呱呱叫行为，而是委托给quackBehavior引用的对象
        }
        
        /// <summary>
        /// 此方法取代了Fly().同理Quack()方法
        /// </summary>
        public void performFly() {
            flyBehavior.Fly();
        }

        public void SetFlyBehavior(FlyBehavior fb) {
            flyBehavior = fb;
        }

        public void SetQuackBehavior(QuackBehavior qb) {
            quackBehavior = qb;
        }
    }


    class RubberDuck : Duck {
        public override void Display() {
            throw new NotImplementedException();
        }
    }


    class MallardDuck : Duck {

        /// <summary>
        /// 写一个构造函数，可以保证创建对象时，将实例复制给父类的quackBehavior
        /// </summary>
        public MallardDuck() {
            quackBehavior = new Quack();//绿头鸭使用Quack类处理呱呱叫，所以当performQuack()被调用时，叫的职责被委托给Quack对象，而我们得到了真正的呱呱叫。
            flyBehavior = new FlyWithWings();//使用FlyWithWings作为其FlyBehavior类型。
        }

        public override void Display() {
            //throw new NotImplementedException();
            Console.WriteLine("绿头");
        }       
    }


    /// <summary>
    /// 这是一个接口，所有飞行类都实现它，所有新的飞行类必须实现Fly方法
    /// </summary>
    public interface FlyBehavior {
        void Fly();
    }

    /// <summary>
    /// 呱呱叫行为同样，一个接口只包含一个需要实现的Quack方法
    /// </summary>
    public interface QuackBehavior {
        void Quack1();
    }

    /// <summary>
    /// 这个类实现了所有有翅膀的鸭子飞行动作
    /// </summary>
    class FlyWithWings : FlyBehavior {

        public void Fly() {
            Console.WriteLine("会飞");
        }
    }

    /// <summary>
    /// 实现了所有不会飞的鸭子的动作
    /// </summary>
    class FlyNoWay : FlyBehavior {

        public void Fly() {
            Console.WriteLine("不会飞");
        }
    }


    class FlyRocket : FlyBehavior {
        public void Fly() {
            Console.Write("火箭动力推进装置");
        }
    }

    /// <summary>
    /// 呱呱叫
    /// </summary>
    class Quack : QuackBehavior {

        public void Quack1() {
            Console.WriteLine("呱呱叫");
        }
    }

    /// <summary>
    /// 名为呱呱叫，实则吱吱叫
    /// </summary>
    class Squeak : QuackBehavior {

        public void Quack1() {
            Console.WriteLine("吱吱叫");
        }
    }

    /// <summary>
    /// 名为呱呱叫，实则不出声
    /// </summary>
    class MuteQuack : QuackBehavior {

        public void Quack1() {
            Console.WriteLine("不会叫");
        }
    }


    class RedheadDuck : Duck {
        public override void Display() {
            //throw new NotImplementedException();
            Console.WriteLine("红头");
        }
    }

    class ModeDuck : Duck {
        public ModeDuck() {
            flyBehavior = new FlyNoWay();
            quackBehavior = new Quack();
        }

        public override void Display() {
            Console.WriteLine("我就是一木头鸭子");
        }
    }
}
