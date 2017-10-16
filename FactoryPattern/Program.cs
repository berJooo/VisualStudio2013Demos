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

    class CheesePizza : Pizza {    }

    class GreekPizza : Pizza {    }

    class PepperoniPizza : Pizza {    }

    class SimplePizzaFactory : Pizza {    }

    class PizzaStore {

        public Pizza pizza;

        //Pizza订单
        public Pizza OrderPizza(string type) {
            if(type.Equals("cheese")) {
                pizza = new CheesePizza();
            } else if(type.Equals("greek")) {
                pizza = new GreekPizza();
            } else if(type.Equals("pepperoni")) {
                pizza = new PepperoniPizza();
            }

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
