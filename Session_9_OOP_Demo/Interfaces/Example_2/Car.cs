namespace Session_9_OOP_Demo.Interfaces.Example_2
{
    /********************************************* Important Note *************************************************
     * when make implemetaion for an interface and make inheritance from another Class
     * 1st should inherit from the class then implement the interface like that ==>
     * internal class Car : Vehicle, IMovedOnGround
     * if try to implement the interface first then inherit from the class like that ==>
     * internal class Car : IMovedOnGround , Vehicle
     * this will make error 
     * should make inheritance from the class first then implement the interface 
     * not make inheritance in last 
     *************************************************************************************************************/
    internal class Car : Vehicle, IMovedOnGround
    {
        // Implicit Implementation For Interface :-
        // use method or property Direct
        // like that ==> public void MoveBackward(){};
        // this mean class that inherit from 2 interfaces taht have same method with same name and same behavior
        // can make this direct don't need to make Explicit implementation to prevent repeated code
        // but if you need to make Explicit implementation make it as you like but you will repeat code 
        // but in Class Car here implement only IMovedOnGround interface 
        // then we don't need to make Explicit implementation
        // make it Implicit implementation
        // like that ==> public void MoveBackward(){};
        // if make Implicit Implementation For Interface
        // should make first access modifier to be  [public]
        // then can reach or access it by make refernce for interface or class 
        // we should make access modifier be [public] when make method by implicit implementaion
        // to can access it and reach it outside in Program.Cs
        // if set his method by default access modifier [private] then we can't reach it or access it
        // becuase we make this by Implicit Implementation For Interface
        public void MoveBackward()
        {
            Console.WriteLine($"Car ==> Move Backward on Ground");
        }

        public void MoveForward()
        {
            Console.WriteLine($"Car ==> Move Forward on Ground");
        }

        public void MoveLeft()
        {
            Console.WriteLine($"Car ==> Move Left on Ground");
        }

        public void MoveRight()
        {
            Console.WriteLine($"Car ==> Move Right on Ground");
        }
    }
}
