namespace Session_9_OOP_Demo.Built_in_Interfaces
{
    internal class CustomComparer : IComparer<Employee>
    {
        //// 3aml el Employee el gay be nullable l2n momken yegy be null f3ln
        public int Compare(Employee? x, Employee? y)
        {
            //// tab3n 3ady b2a te3ml el behvior el 3amlnah 2bl kdah
            //// we law 2kbr hanrg3 1 we law 2s8er hanrg3 -1 we hakza

            //// lakn el string 2w el name bta3 el employee el hwa men datatype sting
            //// el string 3andha el Comapre bet3tha hast5dmha we hab3tlk el x we el y karn benhom 
            //// we lazem el x we el y ykono nullable l2n momken employee me4 be null lakn el name be null
            //// we kdah kdah el Compare net3rf tet3aml ma3 el null 3ady 
            //// we hatl2 b2a bara anady 3al el class dah we ely el array el sort hy sort 3al 2sass dah 
            //// we dah tab3n tarteb Asscending

            return String.Compare(x?.Name, y?.Name);

            //// law 3ayezoh Desscending han3ks bs el 4art

            //return String.Compare(y?.Name, x?.Name);


            //// momken 2nady 3al el CompareTo gwa el Comapre hena kdah 3ady 
            //// we 3l4an nehadl el null 2st5dmn el nullable coalsing we el tany 
            //// be7es law el x me4 benull 5las hat el name lakn law be null 7otely empty string
            //// lakn el CompareTo hate3rf tet3aml men gwaha law galha null me4 me7tag 27ot 6aga mkanha
            //// we dah 4a8la Asccending 
            
            //return (x?.Name??"").CompareTo(y?.Name);

            //// law 3ayzoh 4a8al Desccending
            //// han3ks el 4art bs

            //return (y?.Name ?? "").CompareTo(x?.Name);
        }
    }
}
