using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern {
    /*
     * 咖啡店订单系统。
     */

    /// <summary>
    /// Beverage（饮料）为抽象类，店内所有的饮料必须继承此类
    /// </summary>
    public abstract class Beverage {
        public string descroption = "Unknown Beverage";

        //抽象的行吗？
        public string GetDescription() {
            return descroption;
        }

        public abstract double Cost();
    }

    /// <summary>
    /// 调料装饰抽象类（也可以是一个接口，根据具体情况）
    /// </summary>
    public abstract class CondimentDecorator : Beverage { //需要让这个类能够取代Beverage，所以要继承扩展字Beverage类
        public abstract new string GetDescription(); //所有的调料都必须重新实现GetDescription方法。
    }

    /// <summary>
    /// 浓缩咖啡类。
    /// </summary>
    public class Espresso : Beverage {
        public Espresso() {
            descroption = "Espresso"; //设置饮料的描述，写一个构造器。该变量继承自Beverage
        }

        
        public override double Cost() {
            return 1; //需要计算Espresso的价钱，现在不需要管调料的价钱，直接把Espresso的价格返回即可。
        }
    }

    public class HouseBlend : Beverage {
        public HouseBlend() {
            descroption = "houseblend coffee";
        }


        public override double Cost() {
            return 2; //另一种饮料，和Espresso一样，但描述和价格不同。
        }
    }

    public class DarkRoast : Beverage {
        public DarkRoast() {
            descroption = "DarkRoast coffee";
        }

        
        public override double Cost() {
            return 3; //另一种饮料，和Espresso一样，但描述和价格不同。
        }
    }

    //到现在，抽象组件Beverage，具体组件HouseBlend以及抽象装饰者CondimentDecorator都已经完成。实现具体装饰者。先从摩卡下手

    public class Mocha : CondimentDecorator {
        Beverage beverage; //Mocha引用一个Beverage：1，用一个实例变量记录饮料，也就是被装饰者。

        public Mocha(Beverage beverage) {
            this.beverage = beverage; //2，想办法让被装饰者（饮料）被记录到实例变量中。把饮料当做构造器的参数，再由构造器将此饮料记录在实例变量中。
        }

        public override string GetDescription() {
            return beverage.GetDescription() + "， Mocha";//我们想着描述不仅仅能描述饮料，而是连调料都可以描述。所以利用委托的做法，得到一个叙述，然后在后面加上其他的叙述。
        }

        public override double Cost() {
            return 0.2 + beverage.Cost();//要计算带有Mocha的饮料的价钱，要先把调用委托给被装饰的对象，以计算价钱，然后再加上摩卡的钱，得到结果。
        }
    }

    public class Soy : CondimentDecorator {
        Beverage beverage; //Mocha引用一个Beverage：1，用一个实例变量记录饮料，也就是被装饰者。

        public Soy(Beverage beverage) {
            this.beverage = beverage; //2，想办法让被装饰者（饮料）被记录到实例变量中。把饮料当做构造器的参数，再由构造器将此饮料记录在实例变量中。
            Console.WriteLine("aaaa" + beverage.GetDescription());
        }

        public override string GetDescription() {
            Console.WriteLine("bbbbb" + beverage.GetDescription());
            
            return beverage.GetDescription() + "， Soy";//我们想着描述不仅仅能描述饮料，而是连调料都可以描述。所以利用委托的做法，得到一个叙述，然后在后面加上其他的叙述。
        }

        public override double Cost() {
            return 0.3 + beverage.Cost();//要计算带有Mocha的饮料的价钱，要先把调用委托给被装饰的对象，以计算价钱，然后再加上摩卡的钱，得到结果。
        }
    }

    public class Whip : CondimentDecorator {
        Beverage beverage; 

        public Whip(Beverage beverage) {
            this.beverage = beverage; 
        }

        public override string GetDescription() {
            return beverage.GetDescription() + "， Whip";
        }

        public override double Cost() {
            return 0.4 + beverage.Cost();
        }
    }

    class Program {
        static void Main(string[] args) {
            //订一份Espresso，不需要调料
            //Beverage beverage = new Espresso();
            //Console.WriteLine(beverage.GetDescription() + "$" + beverage.Cost());

           //来一杯有豆浆，摩卡，奶泡的HouseBlend
            Beverage beverage2 = new HouseBlend();
            Console.WriteLine(beverage2.GetDescription() + "$" + beverage2.Cost());
            
            beverage2 = new Soy(beverage2);
            Console.WriteLine(beverage2.GetDescription() + "$" + beverage2.Cost());

            Beverage beverage3 = new Soy(new DarkRoast());
            Console.WriteLine("ccccc" + beverage3.GetDescription());


            //beverage2 = new Mocha(beverage2);
            //beverage2 = new Whip(beverage2);
            
            
/* 
            Beverage beverage3 = new DarkRoast();
            beverage3 = new Mocha(beverage3);
            beverage3 = new Mocha(beverage3);
            beverage3 = new Soy(beverage3);
            Console.WriteLine(beverage3.GetDescription() + "$" + beverage3.Cost());*/
        }
    }
}
