namespace Session_9_OOP_Demo.Interfaces.Example_1
{
    internal class SeriesByThree : ISeries
    {
        // mean sereis start from 0 and each step increas by 3 like that ==> 0 3 6 9 12 ...
        public int Current { get; set; }

        public void GetNext()
        {
            Current += 3;
        }
    }
}
