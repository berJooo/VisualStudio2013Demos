using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 工厂设计模式
 */

namespace FactoryPattern {

    abstract class Pizza {
        public abstract void Prepare();
        public abstract void Bake();
        public abstract void Cut();
        public abstract void Box();
    }

    class CheesePizza : Pizza {
        public override void Prepare() {
            Console.WriteLine("准备");
        }

        public override void Bake() {
            Console.WriteLine("烘焙");
        }

        public override void Cut() {
            Console.WriteLine("切块");
        }

        public override void Box() {
            Console.WriteLine("装盒");
        }
    }//起司披萨

    class GreekPizza : Pizza {
        public override void Prepare() {
            throw new NotImplementedException();
        }

        public override void Bake() {
            throw new NotImplementedException();
        }

        public override void Cut() {
            throw new NotImplementedException();
        }

        public override void Box() {
            throw new NotImplementedException();
        }
    } //希腊披萨

    class PepperoniPizza : Pizza {
        public override void Prepare() {
            throw new NotImplementedException();
        }

        public override void Bake() {
            throw new NotImplementedException();
        }

        public override void Cut() {
            throw new NotImplementedException();
        }

        public override void Box() {
            throw new NotImplementedException();
        }
    } //腊肠披萨

    class SimplePizzaFactory  {

        public Pizza CreatePizza(string type) {
            Pizza pizza = null;

            if(type.Equals("cheese")) {
                pizza = new CheesePizza();
            } else if(type.Equals("greek")) {
                pizza = new GreekPizza();
            } else if(type.Equals("pepperoni")) {
                pizza = new PepperoniPizza();
            }


            return pizza;
        }
    }

    class DongbeiPizzaFactory : SimplePizzaFactory {

    }

    class BeijingPizzaFactory : SimplePizzaFactory {

    }

    class SouthPizzaFactory : SimplePizzaFactory { }

    abstract class PizzaStore {

        public SimplePizzaFactory factory;

		public PizzaStore() { }
       

        public PizzaStore(SimplePizzaFactory factory) {
            this.factory = factory;
        }

        //Pizza订单
        public Pizza OrderPizza(string type) {
            Pizza pizza;

            pizza = CreatePizza(type); //用于创建披萨。在这请注意，我们把new 操作符替换成工厂对象的创建方法，这里不再使用具体实例化

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        public abstract Pizza CreatePizza(string type);
    }

    class DongbeiPizzaStore : PizzaStore{

        public override Pizza CreatePizza(string type) {
            if(type == "cheese") {
                //东北风味cheese披萨
            } else if(type == "pepperoni") {
                //东北风味腊肠披萨
            }

            return null;
        }
    }

    class BeijingPizzaStore : PizzaStore {

        public override Pizza CreatePizza(string type) {
            throw new NotImplementedException();
        }
    }

    class SouthPizzaStore : PizzaStore {

        public override Pizza CreatePizza(string type) {
            throw new NotImplementedException();
        }
    }

    class Program {
        static void Main(string[] args) {
            DongbeiPizzaStore dbps = new DongbeiPizzaStore();
            dbps.OrderPizza("cheese");
        }
    }
}
