namespace Session_9_OOP_Demo.Binding
{
    internal class TypeB : TypeA
    {
        // when Class TypeB inherits from TypeA
        // this mean TypeC will have 1 Parents or in correct mean have 2 Parents
        // 1]TypeA ==> Direct Parent
        // 2]Object that TypeA inherit from it ==> Indirect Parent
        // but in reality TypeB will have one Parent that is TypeA
        public int B { get; set; }
        // make constructor chaning on base constructor TypeA
        public TypeB(int b , int a):base(a)
        {
            B = b;
        }

        // if you use new keyword here or not the result will be the same or same behavior
        // because this method is not virtual in parent class
        // so this method will work in Static Binding or Static Polymorphism
        // if you want to override this method in child class then you need to use new keyword
        // and need to use new keyword to make another team understand that is masking or hiding the parent method
        public new void MyFun01()
        {
            System.Console.WriteLine($"I am child , Type B");
        }

        public override void MyFun02()
        {
            Console.WriteLine($"TypeB ==> A : {A} , B : {B}");
        }
    }
}
