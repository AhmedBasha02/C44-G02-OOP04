namespace Session_9_OOP_Demo.Interfaces
{
    /********************************************* Important Note *************************************************
     * when make implemetaion for an interface and make inheritance from another Class
     * 1st should inherit from the class then implement the interface like that ==>
     * internal class MyType : TypeA , IType
     * if try to implement the interface first then inherit from the class like that ==>
     * internal class MyType : IType , TypeA
     * this will make error 
     * should make inheritance from the class first then implement the interface 
     * not make inheritance in last 
     *************************************************************************************************************/
    internal class MyType : IType 
    {
        /********************************************* Important Note *********************************************
     * 
     * When you implement an interface in a class, you must provide implementations for all members of the interface.
     * If you do not use any member of the interface in your class, you will get a warning or error depending on your IDE settings.
     * 
     * This is to ensure that the class adheres to the contract defined by the interface.
     * 
     *************************************************************************************************************/
        // when make class MyType implements IType then need to use all members of IType inside class
        // to Prevent error that happend when don't use any member of use half of members of IType
        // So should use all members of IType inside Class MyType


        // if change any data type or return type or parameters of any method or property
        // this will make error becuase should write every thing in interace correct not change on it
        // but inside method you can write anything becuase behavior or logic inside method
        // you write it and have freedom to write any thing you want
        public int MyProperty { get; set; }

        public void MyFun()
        {
            // Implementation of MyFun method
            Console.WriteLine("Helloe from Class MyType that implement Interface IType inside it");
        }

        //public void MyDefaultMethod()
        //{
        //    // this is the default implementation of the method
        //    Console.WriteLine($"Hello from Default Implemented Method in Class ==> MType");
        //}


        // Explicit Implementation For Interface :-
        // use name of interface first then set [ . ] then choose method or property
        // like that ==> public void IType.MyDefaultMethod(){};
        // and then make logic inside method as you like 


        /*********************** Note for Explicit Implementation For Interface *************************

        Explicit Implementation For Interface help you to access or reach direct to Default implemented Method

         ************************************************************************************************/

        // then to access or reach direct to Default implemented Method
        // make Explicit Implementation
        //void IType.MyDefaultMethod()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
