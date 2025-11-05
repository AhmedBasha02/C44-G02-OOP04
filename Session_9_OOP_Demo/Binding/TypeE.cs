namespace Session_9_OOP_Demo.Binding
{
    // when Class TypeE inherits from TypeD
    // this mean TypeE will have 4 Parents or in correct mean have 5 Parents
    // 1]TypeD ==> Direct Parent
    // 2]TypeC ==> Indirect Parent
    // 3]TypeB ==> Indirect Parent
    // 4]TypeA ==> Indirect Parent
    // 5]Object that TypeA inherit from it ==> Indirect Parent
    // but in reality TypeD will have four Parent that is TypeD and TypeC and TypeB and TypeA
    internal class TypeE : TypeD
    {
        public int E { get; set; }
        

        // make constructor chaning on base constructor TypeD
        // a will define in class TypeA
        // b will define in class TypeB
        // c will define in class TypeC
        // d will define in class TypeD
        // e will define in class TypeE
        // each class will define

        public TypeE(int a, int b, int c, int d , int e) : base(a, b, c, d)
        {
            E = e;
        }

        // if you use new keyword here or not the result will be the same or same behavior
        // because this method is not virtual in parent class [indirect parent or direct parent]
        // so this method will work in Static Binding or Static Polymorphism
        // if you want to override this method in child class then you need to use new keyword
        // and need to use new keyword to make another team understand that is masking or hiding the parent method
        // and this method will call based on reference not based on instance
        public new void MyFun01()
        {
            System.Console.WriteLine($"I am Grand Child of Grand child , Type E");
        }


       
        // this method is virtual in TypeD
        // so this method will work in Dynamic Binding or Dynamic Polymorphism
        // and this method will call based on instance not based on reference
        // and this method coming from TypeD 
        // when make override on method we will search about the method in the parent class
        // that have keyword virtual [direct parent] TypeD
        // becuase this method is ended overide in TypeC and make new chain in TypeD 
        // when use keyword new and need to override in first chain then use virtual on method in TypeD
        // to make override on it when any child inherit from TypeD can override on it 
        
        public override void MyFun02()
        {
            Console.WriteLine($"TypeE ==> A : {A} , B : {B} , C : {C} , D : {D} , E : {E}");
        }
    }
}
