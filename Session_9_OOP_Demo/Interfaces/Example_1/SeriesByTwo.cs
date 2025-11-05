namespace Session_9_OOP_Demo.Interfaces.Example_1
{
    internal class SeriesByTwo : ISeries
    {
        // mean sereis start from 0 and each step increas by 2 like that ==> 0 2 4 6 8 10 ...
        public int Current { get; set; } // ==> inside Class then Compilier will Generate backing field for this property

        public void GetNext() 
        {
            Current += 2;
        }
    }
}
