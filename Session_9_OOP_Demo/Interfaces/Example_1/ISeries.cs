namespace Session_9_OOP_Demo.Interfaces.Example_1
{
    internal interface ISeries
    {
        // 1] Property/Event/Indexer declarations [Signature for Property]==> all access modifier used instead of Private

        // Compilier will not Generate backing field for this property
        // backing field for this property happend only inside class or struct in Automatic Property
        public int Current { get; set; }

        // 2] Method signatures [Signature for Method]==> all access modifier used instead of Private

        //bafhme el developer el tany el hymdy 3al el 3a2d bta3y gwa el class bta3oh
        //2n hwa hy7tag y implement this method 2smha GetNext we me4 bet return ay 7aga we me4 beta5d parameters
        public void GetNext();

        // 3] Default implementations methods (C# 8.0 and later) ==> all access modifier used

        //deh law 3ayez te3ml method feha default implementations
        //we el method bta3t el [ResetCurrent()] deh hatb2a default
        //l2n el logic bta3 2nk te3ml reset ll current me4 hyt8er sabt fe kol el series
        //we bem 2en hast5dmh 3altol yb2a me4 lazem kol 4waya 2krrha fe kol class hy implememnt el interface
        //l2 ha5leh defualt we 2st5dmha 3altol badl ma 2krr fe el code
        public void ResetCurrent()
        {
            // this is the default implementation of the method
            // it can be overridden in the implementing class

            Current = 0;
            
            // you assign cuurent to be 0 
            // so should propert Current have { set; }
            // if don't have { set; } then error will happen becuase we can't access current and assign to be 0
        }
    }
}
