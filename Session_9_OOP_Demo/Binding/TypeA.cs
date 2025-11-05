namespace Session_9_OOP_Demo.Binding
{
    internal class TypeA
    {
        public int A { get; set; }
        public TypeA (int a)
        {
            A = a;
        }

        // MyFun01
        //Without Virtual ==> then this mean work in Static Binding or Static Polymorphism
        // if any one need to override this method in child class 
        // then he needs to use new keyword in child class to make override this method
        public void MyFun01()
        {
            System.Console.WriteLine($"I am Parent , Type A");
        }

        //MyFun02
        //Virtual ==> then this mean work in Dyanmic Binding or Dynamic Polymorphism
        public virtual void MyFun02()
        {
            System.Console.WriteLine($"TypeA ==> A : {A}");
        }
    }
}
