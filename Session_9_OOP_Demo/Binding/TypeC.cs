namespace Session_9_OOP_Demo.Binding
{
    // when Class TypeC inherits from TypeB
    // this mean TypeC will have 2 Parents or in correct mean have 3 Parents
    // 1]TypeB ==> Direct Parent
    // 2]TypeA ==> Indirect Parent
    // 3]Object that TypeA inherit from it ==> Indirect Parent
    // but in reality TypeC will have two Parent that is TypeB and TypeA
    internal class TypeC : TypeB
    {
        public int C { get; set; }
        // make constructor chaning on base constructor TypeB
        // a will define in class TypeA
        // b will define in class TypeB
        // c will define in class TypeC
        // each class will define each value in his own constructor
        public TypeC(int a, int b , int c) : base(a,b)
        {
            C = c;
        }

        // if you use new keyword here or not the result will be the same or same behavior
        // because this method is not virtual in parent class [indirect parent or direct parent]
        // so this method will work in Static Binding or Static Polymorphism
        // if you want to override this method in child class then you need to use new keyword
        // and need to use new keyword to make another team understand that is masking or hiding the parent method
        // and this method will call based on reference not based on instance
        public new void MyFun01()
        {
            System.Console.WriteLine($"I am Grand child , Type C");
        }

        // this method is override in TypeB and TypeC
        // and this method is virtual in TypeA
        // so this method will work in Dynamic Binding or Dynamic Polymorphism
        // and this method will call based on instance not based on reference
        // and this method coming from TypeB that i override it in TypeB and now making override it in TypeC
        // when make override on method we will search about the method in the parent class
        // that have keyword virtual [indirect parent] TypeA
        // or the method that i maked override on it in the parent class [direct parent] TypeB
        public override void MyFun02()
        {
            Console.WriteLine($"TypeC ==> A : {A} , B : {B} , C : {C}");
        }

        // deh kdah selsela ll method deh gay mn TypeA we ba3d kdah mn Type B l7ad hena 3andy fe TypeC
        // fa deh kdah selsela motsela beb3dha 
        // and b2a fe class Type D haksr el selsela deh we habd2 selsela gdeda ly nafs el method bs
        // men 3and TypeD we hawrs el method el gdedea deh ly TypeE el hywrs mn TypeD
        // we kdah ba2 3and selselten mn el method deh 
        // wa7da mn 2wl TypeA l7ad TypeC
        // we el tanya mn TypeD l7ad TypeE
    }
}
