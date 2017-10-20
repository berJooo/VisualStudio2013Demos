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

    class CheesePizza : Pizza { }//起司披萨

    class GreekPizza : Pizza {    } //希腊披萨

    class PepperoniPizza : Pizza {    } //腊肠披萨

    class SimplePizzaFactory  {

        public Pizza CreatePizza(string type) {
            Pizza pizza = null;

            if(type.Equals("cheese")) {
                pizza = new CheesePizza();
            } else if(type.Equals("greek")) {

            } else if(type.Equals("pepperoni")) {

            }


            return pizza;
        }
    }

    class PizzaStore {

        public SimplePizzaFactory factory;
       

        public PizzaStore(SimplePizzaFactory factory) {
            this.factory = factory;
        }

        //Pizza订单
        public Pizza OrderPizza(string type) {
            Pizza pizza;

            pizza = factory.CreatePizza(type); //用于创建披萨。在这请注意，我们把new 操作符替换成工厂对象的创建方法，这里不再使用具体实例化

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }
    }

    class Program {
        static void Main(string[] args) {
        }
    }
}
