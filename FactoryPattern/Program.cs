using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 工厂设计模式
 */

namespace FactoryPattern {

    abstract class Pizza {

		public string name; //名称
		public string dough; //面团类型
		public string sauce; //酱料

		public ArrayList toppings = new ArrayList();

        public virtual void Prepare() {
			Console.WriteLine("preparing " + name);
			Console.WriteLine("tossing dough...");
			Console.WriteLine("adding sauce...");
			Console.WriteLine("adding toppings:");

			for(int i = 0; i < toppings.Count; i++) {
				Console.WriteLine("   " + toppings[i]);
			}
		}

		public virtual void Bake() {
			Console.WriteLine("bake for 25 mins at 350");
		}

		public virtual void Cut() {
			Console.WriteLine("cutting the pizza into diagonal slices");
		}

		public virtual void Box() {
			Console.WriteLine("place pizza in official PizzaStore box");
		}

		public virtual string GetName() {
			return name;
		}
    }

	class DBStyleCheesePizza : Pizza {
		public DBStyleCheesePizza() { //东北披萨有自己的打算番茄酱（Marinara）和薄饼
			name = "DB Style Sauce and Cheese Pizza";
			dough = "Thin Crust Dough";
			sauce = "Marinara Sauce";

			toppings.Add("Grated Reggiano Cheese");//上面有高级干酪
		}
	}

	class BJStyleCheesePizza : Pizza {
		public BJStyleCheesePizza() { //北京披萨使用小西红柿做为酱料，使用厚饼
			name = "beijing Style Deep Dish Cheese Pizza";
			dough = "Extra Thick Crust Dough";
			sauce = "Plum Tomato Sauce";

			toppings.Add("Shredded Mozzarella Cheese"); //北京的深盘披萨使用白干酪
		}

		public override void Cut() { //此方法覆盖了父类的，将披萨切正方形。
			Console.WriteLine("Cutting the pizza into square slices");
		}
	}
	/*
	//起司披萨
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
    }

	//希腊披萨
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
    } 

	//腊肠披萨
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
    } */

	/*
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

    class SouthPizzaFactory : SimplePizzaFactory { }*/


    abstract class PizzaStore {

        //public SimplePizzaFactory factory;

		//public PizzaStore() { }
       
		/*
        public PizzaStore(SimplePizzaFactory factory) {
            this.factory = factory;
        }*/

        //Pizza订单
        public virtual Pizza OrderPizza(string type) {
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

    class DBPizzaStore : PizzaStore{

        public override Pizza CreatePizza(string type) {
            if(type == "cheese") {
                
            } else if(type == "pepperoni") {
                //东北风味腊肠披萨
            }

            return null;
        }
    }

    class BJPizzaStore : PizzaStore {

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
			PizzaStore dbstore = new DBPizzaStore();
			PizzaStore bjstore = new BJPizzaStore();

			Pizza pizza = dbstore.OrderPizza("cheese");
			Console.WriteLine(pizza.GetName());

			pizza = bjstore.OrderPizza("cheese");
			Console.WriteLine(pizza.GetName());
        }
    }
}
