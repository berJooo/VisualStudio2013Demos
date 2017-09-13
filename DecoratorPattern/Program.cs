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
    abstract class Beverage {
        //名为description的实例变量由每个子类设置，用来描述饮料。

        //表示各种调料bool
        public bool milk;
        public bool soy;
        public bool mocha;
        public bool whip;

        //改动后，Cost方法不再是抽象，变成所有调料价钱总和
        public virtual int Cost() {
            int cost = 0;

            return cost;
        }

        public void hasMilk() {
            milk = true;
        }

        public bool getMilk() {
            return milk;
        }

        public void hasSoy() {
            soy = true;
        }

        public bool getSoy() {
            return soy;
        }

        public void hasMocha() {
            mocha = true;
        }


        public bool getMocha() {
            return mocha;
        }
    }

    #region 子类需要全部实现Cost表示价钱
   
    class HouseBlend : Beverage {
        public override void Cost() {
            Console.Write(milk);
        }
    }

    class DarkRoast : Beverage {

    }

    class Decaf : Beverage {

    }

    class Espresso : Beverage {

    }

    #endregion

    class Program {
        static void Main(string[] args) {
            HouseBlend hb = new HouseBlend();
            hb.Cost();
        }
    }

}
