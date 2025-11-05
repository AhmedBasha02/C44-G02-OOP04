namespace Session_9_OOP_Demo.Binding
{
    // when Class TypeD inherits from TypeC
    // this mean TypeD will have 3 Parents or in correct mean have 4 Parents
    // 1]TypeC ==> Direct Parent
    // 2]TypeB ==> Indirect Parent
    // 3]TypeA ==> Indirect Parent
    // 4]Object that TypeA inherit from it ==> Indirect Parent
    // but in reality TypeD will have three Parent that is TypeC and TypeB and TypeA
    internal class TypeD : TypeC
    {
        public int D { get; set; }
        // make constructor chaning on base constructor TypeC
        // a will define in class TypeA
        // b will define in class TypeB
        // c will define in class TypeC
        // each class will define each value in his own constructor
        public TypeD(int a, int b, int c , int d) : base(a, b , c)
        {
            D = d;
        }

        // if you use new keyword here or not the result will be the same or same behavior
        // because this method is not virtual in parent class [indirect parent or direct parent]
        // so this method will work in Static Binding or Static Polymorphism
        // if you want to override this method in child class then you need to use new keyword
        // and need to use new keyword to make another team understand that is masking or hiding the parent method
        // and this method will call based on reference not based on instance
        public new void MyFun01()
        {
            System.Console.WriteLine($"I am Child of Grand child , Type D");
        }

        // this method is override in TypeB and TypeC
        // and this method is virtual in TypeA
        // so this method will work in Dynamic Binding or Dynamic Polymorphism
        // and this method will call based on instance not based on reference
        

        // lma 2st5dm new 3al method kont 3amlha fe el bedya virtual we ba3mlha override fe el classes
        // el btwers mny fa lma 2st5dm el new kdah haksr el selsela bta3t el method deh
        // we habd2a selsela gdeda mn 3andy we kdah el method deh 3andha 2wl selsela el hya 
        // mn Class TypeA l7ad class TypeC 
        // we el selsela el gdeda el mn TypeD malha4 3elak bel selsela el 2dema 5als 
        // deh selsela gdeda lwa7dha 8er el tanya
        
        public new virtual void MyFun02()   // start new chain
        {
            Console.WriteLine($"TypeD ==> A : {A} , B : {B} , C : {C} , D : {D}");
        }

        // used keyword Virtual in Method MyFun02 above 
        // becuase this method is start of new chain and i need to inherit it to any child inherit from this class
        // So i use keyword new to make any child that inherit from this class can override on it
    }
}
