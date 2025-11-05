namespace Session_9_OOP_Demo.Interfaces
{
    // this is an interface 1st type of interface ==> Top-Level interface [Write inside Namespace Direct]
    internal interface IType 
    {
        // we can write 4 things inside an interface :-

        // 1] Property/Event/Indexer declarations [Signature for Property]==> all access modifier used instead of Private

        // Compilier will not Generate backing field for this property
        // backing field for this property happend only inside class or struct in Automatic Property
        public int MyProperty { get; set; }

        // 2] Method signatures [Signature for Method]==> all access modifier used instead of Private

        //bafhme el developer el tany el hymdy 3al el 3a2d bta3y gwa el class bta3oh
        //2n hwa hy7tag y implement this method 2smha MyFun we me4 bet return ay 7aga we me4 beta5d parameters
        public void MyFun();

        // 3] Default implementations methods (C# 8.0 and later) ==> all access modifier used

        //deh law 3ayez te3ml method feha default implementations
        public void MyDefaultMethod()
        {
            // this is the default implementation of the method
            // it can be overridden in the implementing class
            Console.WriteLine($"Hello from Default Implemented Method in Interface ==> IType");
        }

        // 4] Static members (C# 8.0 and later)


        // kdah ba3d el ana 3amltoh fo2 dah kolh 5alst kol 4o8ly fe el interface 3ayez b2a 7ad ymdy 3al el 3a2d dah
        // and kdah hena ba act ka 2wl developer el hwa katbt el 3a2d bta3y 5las 
        // mstany b2a el developer el tany ymdy el hwa yst5dm kol el fo2 dah gwa el class bta3oh
        // fa haro7 23ml el class el 2smoh ==> MyType
        // we dah hwa el ha3ml feh el implement ll Interface IType Gwah
    }
}
