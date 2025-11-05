namespace Session_9_OOP_Demo.Interfaces.Example_2
{
    /********************************************* Important Note *************************************************
     * when make implemetaion for an interface and make inheritance from another Class
     * 1st should inherit from the class then implement the interface like that ==>
     * internal class AirPlane : Vehicle, IMovedOnAir , IMovedOnGround
     * if try to implement the interface first then inherit from the class like that ==>
     * internal class Car : IMovedOnAir , IMovedOnGround , Vehicle
     * this will make error 
     * should make inheritance from the class first then implement the interface 
     * not make inheritance in last 
     *************************************************************************************************************/
    internal class AirPlane : Vehicle, IMovedOnAir , IMovedOnGround
    {
        // Explicit Implementation For Interface :-
        // use name of interface first then set [ . ] then choose method or property
        // like that ==> public void IMovedOnAir.MoveBackward(){}; public void IMovedOnGround.MoveBackward(){};
        // and then make logic inside method as you like becuase 2 method have 2 different logic or behaviour
        // mean not same logic or behaviour
        // like that in Class AirPlane here implement 2 interfaces
        // IMovedOnAir and IMovedOnGround
        // and we have 2 methods with same name and different behavior
        // so we need to make Explicit implementation
        // if we make 2 method that have same name make same behavior 
        // then in this case we can use Implicit implementation
        // and write method 1 time only not need to write 2 times
        // like that ==> we assume or suppose that method MoveBackward have same behvior in Class AirPlane
        // then in this case we can use Implicit implementation for this Method MoveBackward()
        // but we should make access modifier be [public] when make method by implicit implementaion
        // to can access it and reach it outside in Program.Cs
        // if set his method by default access modifier [private] then we can't reach it or access it
        // becuase we make this by Implicit Implementation For Interface
        // but when use Explicit Implementation For Interface
        // all methods have access modifier by default [Private]
        // Private becuase we can't reach to these method or access them even make instance from refrence from me
        // mean from refrence from his interface and refer or point to instance for class that implement this intereface
        // to treat or reach or access method MoveForward()
        // if use interface IMovedOnGround then should make refernce from interface IMovedOnGround
        // like that ==> IMovedOnGround iMovedOnGround;
        // and make this reference refer or point to instance for class that implement his interface
        // like that ==> iMovedOnGround = new AirPlane();
        // if use interface IMovedOnAir then should make refernce from interface IMovedOnAir
        // like that ==> IMovedOnAir iMovedOnAir;
        // and make this reference refer or point to instance for class that implement his interface
        // like that ==> iMovedOnAir = new AirPlane();
        // this happen only when make Explicit Implementation For Interface
        // but if make Implicit Implementation For Interface
        // should make first access modifier to be  [public]
        // then can reach or access it by make refernce for interface or class 
        public void MoveBackward()
        {
            Console.WriteLine($"AirPlane ==> Move Backward on Air and Ground");
        }

        // but if don't have same behaviour 
        // then in this case we can use Explicit implementation for this Method MoveBackward()

        //void IMovedOnAir.MoveBackward()
        //{
        //    Console.WriteLine($"AirPlane ==> Move Backward on Air");
        //}

        //void IMovedOnGround.MoveBackward()
        //{
        //    Console.WriteLine($"AirPlane ==> Move Backward on Ground");
        //}

         void IMovedOnAir.MoveForward()
        {
            Console.WriteLine($"AirPlane ==> Move Forward on Air");    
        }

         void IMovedOnGround.MoveForward()
        {
            Console.WriteLine($"AirPlane ==> Move Forward on Ground");
        }

         void IMovedOnAir.MoveLeft()
        {
            Console.WriteLine($"AirPlane ==> Move Left on Air");
        }

         void IMovedOnGround.MoveLeft()
        {
            Console.WriteLine($"AirPlane ==> Move Left on Ground");
        }

        void IMovedOnAir.MoveRight()
        {
            Console.WriteLine($"AirPlane ==> Move Right on Air");
        }

        void IMovedOnGround.MoveRight()
        {
            Console.WriteLine($"AirPlane ==> Move Right on Ground");
        }
    }
    
}
