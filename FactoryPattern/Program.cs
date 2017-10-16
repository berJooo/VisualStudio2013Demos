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

        public Pizza pizza;

        //Pizza订单
        public Pizza OrderPizza() {
            
            pizza = 

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
