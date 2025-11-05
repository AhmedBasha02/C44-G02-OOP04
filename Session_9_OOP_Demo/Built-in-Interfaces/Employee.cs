namespace Session_9_OOP_Demo.Built_in_Interfaces
{
    /*********************************** [IClonable] ******************************************/

    // 3l4an nebd2 negarb el built-in-interface ==> [IClonable]
    // lazem yb2a 3andy user defined datatype a22dr a2tb2a 3aleh el interface we 2st5dm el 
    // method el gwah el hya ==>[Clone()]

    // we 3l4an ne3ml el Deep Copy baro7 2st5dm el method el hya ==> [Clone()]
    // bs hal2y 2n me4 la2y 2sln el method el [Clone()] deh wla lya 3aleha access
    // l2n 2sln hal 2enta el Class bat3 el Employee 2sln by implement el interface el hwa
    // [IClonable] el gwah el Signature bta3 el method el [Clone()] l2a dah me4 7asl
    // el Class el Employee me4 by implement el interface dah 
    // fa kdah male4 access 3al el Method deh we hyfdl darb error
    // 2bl kdah fo2 Kan Class el Array we el String we el StringBuilder
    // men gwahom 3amlen Implement ll interface ==> [IClonable]
    // el gwah el signature bta3 method ==> [Clone()] 
    // fa kont a2dr a23ml access 3aleha we st5dhma lakn 
    // el Employee dah user defined datatype gded me4 3aml implememnt ll interface ==> [IClonable]
    // fa 3l4an el method el [Clone()] te4ta8l we 23ml el ==> Deep Copy
    // haro7 gwa Class el Employee 23ml Implement ll interface el ==> [ICLonable]

    // bs hal2y el Method el nezlt lma 3amlt implement ll interface
    // nezlt bet return Object kdah ==>
    // public object Clone()
    //{
    //     throw new NotImplementedException();
    //}
    // bs hya el Mafrod tekon betrag3 nafs el user defined datatye el hwa ==> Employee
    // ya3ny el mafrod be t retur Employee
    // hwa by return [object] l2noh me4 3arf el hyrg3oh dah
    // hwa Employee wla Point wla ay 7aga 2enta 3amlha fe el donya e4 3arfo dah eh 
    // 2e4 3arfo el rag3 hykon eh
    // fa hwa medholk 3al 4akl [object] we anat b2a 2b2a rag3oh 3al el 4akl el anta 3ayezoh el hwa [Employee]

    /*******************************************************************************************************/

    /************************************* [IComparable] *********************************************/


    /*************************************************************************************************/
internal class Employee : ICloneable , IComparable<Employee> //,IComparable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Salary { get; set; }

        public object Clone()
        {
            // 3ayzen neml Deep Copy
            // ya3ny 3ayezn nebd2a ne Create new identity or Address or reference with same object state [data]
            // fa haro7 2a ==> return new Employee ();
            // kdah hwa hy3ml identity or Address or reference gded 
            // we hast2bl el data b2a mn el Employee el hyb3lty el data el hwa henak employee1 
            // el hwa el Caller el bym3l Call ly method el ==> [Clone()]
            // el [this] dah ll data el gaya mn barah el hya gaya mn employee1
            // el hwa el Caller el bym3l Call ly method el ==> [Clone()] fa ha5od el data menoh
            // we 27otha hena fe el Employee el gded el be identity 2w reference 2w address gded el harg3oh
            // we ba3d ma 27otha harg3 el data deh be identity or Address or reference gded 
            // yt7at fe el employee2 el ba3mloh 2sln Deep Copy

            // el[this]==> bet3abr 3an el instance el gay mn employee1 henak el hya el data el fe employee1

            // bs barah hwa za3ln l2n hena 2enta betrag3 object we el object y2dr y4awr 3al ay 7aga fe el donya 
            // we ana hena bareturn object we hwa bara mestany el reference yb2a of type [Employee]
            // fa lazem bara 23ml [Casting] a22olh sek fya 2en el rag3lk dah hwa men type [Employee]
            // we kdah el donya hate4ta8l tmam 
            return new Employee()
            {
                Id = this.Id,
                Name = this.Name,
                Salary = this.Salary,
            };
        }


        /********************** [IComparable el nos5a el gdedea el genrici ] *************************/

        //// el nos5a el gdedea el bet5od menk el Employee 3altol me4 el Object 
        //// we hwa 3erf kdah 3an tare2 we ana ba3ml implement ll Interface fo2 el generic 
        //// 2detoh el Employee ba2loh el gayelk hykon of Type Employee ==> IComparable<Employee>
        //// we 3l4an kdah fe el method ==> [ComareTo] 3aml el Paramter bet3ah of Type [Employee]
        //// me4 object zay el 2dem 
        //// we hanro7 b2a ne3ml nafs el behvior bta3 el CompareTo

        //// tb el CompareTo deh by7slah implememnt azay ll body bta3ha men gwah ya3ny bet4ta8l azay ?
        //// hya leha behaviour mo3yen 
        //// we 5aly balk el [This] hwa dayman el [Caller] el hwa by3ml call ll method
        //// law 3ayez 2a CompareTo Based on el Salary
        //// fa el byhaviour hyb2a kdah 
        //// This.Salary > other.Salary ==> return +ve number like +ve 1 or any +ve number
        //// This.Salary < other.Salary ==> return -ve number like -ve 1 or any -ve number
        //// This.Salary = other.Salary ==> return zero [0]
        //// bs tab3n hat check el 2wl 3al el obj el gayely law hwa be null kdah el Caller el hwa el this 
        //// hyb2a 2kbr menoh 3altol fa kdah el mafrod y return +ve number el hwa +ve 1

        //// bs 5aly balk el implementation el 3amlen ne3mloh dah ben3mloh 3al el fady we el malyan 
        //// el hwa el behvior el 3amlnah dah 
        //// l2n el behavior dah 2sln mawgod fe el [Salary] we el [Salary] dah hwa mn Type [Int]
        //// we el [int] 3andoh 2sln method [CompareTo] gwa el Class bta3 el [int]
        //// fa hanro7 nest5dm el CompareTo bta3 el [int] 3altol 
        //// ana ha3ml kdah l2n bakrn based on el [Salary] we el [Salary] dah hwa Datatype [int]
        //// we Class el [int] men gwah 3aml implement ll interface [IComparable] fa hwa 3andoh 
        //// method el ComareTo bta3toh we bet3ml nafs el behvior el hwa 
        //// law el Caller > mn el gay ==> return +ve number
        //// we law el Caller < mn el gay ==> return -ve number
        //// we law el Caller = mn el gay ==> return zero [0]
        //// fa haro7 23ml kdah ==> return this.Salary.CompareTo(other.Salary);
        //// we deh ma3nah 
        //// law el Caller el hwa [this.Salary] > mn el gay el hwa [other.Salary]==> return +ve number
        //// we law el Caller el hwa [this.Salary] < mn el gay el hwa [other.Salary]==> return -ve number
        //// we law el Caller el hwa [this.Salary] = mn el gay el hwa [other.Salary]==> return Zero [0]
        
        //// madama fe 7ad 3aml el implementation 5las 5odoh menoh ma tkrrho4 anta zay ma 3amlna kdah 
        //// lakn law 7ad me4 3amloh 5las han3mloh be 2dena zay ma kona 3amlen 
        public int CompareTo(Employee? other)
        {
            //if (other is null || this.Salary > other.Salary)
            //{
            //    return 1;
            //}
            //else if (this.Salary < other.Salary)
            //{
            //    return -1;
            //}
            //else
            //{
            //    return 0;
            //}


            //// bs 5aly balk el implementation el 3amlen ne3mloh fo2 dah ben3mloh 3al el fady we el malyan 
            //// el hwa el behvior el 3amlnah dah 
            //// l2n el behavior dah 2sln mawgod fe el [Salary] we el [Salary] dah hwa mn Type [Int]
            //// we el [int] 3andoh 2sln method [CompareTo] gwa el Class bta3 el [int]
            //// fa hanro7 nest5dm el CompareTo bta3 el [int] 3altol 
            //// ana ha3ml kdah l2n bakrn based on el [Salary] we el [Salary] dah hwa Datatype [int]
            //// we Class el [int] men gwah 3aml implement ll interface [IComparable] fa hwa 3andoh 
            //// method el ComareTo bta3toh we bet3ml nafs el behvior el hwa 
            //// law el Caller > mn el gay ==> return +ve number
            //// we law el Caller < mn el gay ==> return -ve number
            //// we law el Caller = mn el gay ==> return zero [0]
            //// fa haro7 23ml kdah ==> return this.Salary.CompareTo(other.Salary);
            //// we deh ma3nah 
            //// law el Caller el hwa [this.Salary] > mn el gay el hwa [other.Salary]==> return +ve number
            //// we law el Caller el hwa [this.Salary] < mn el gay el hwa [other.Salary]==> return -ve number
            //// we law el Caller el hwa [this.Salary] = mn el gay el hwa [other.Salary]==> return Zero [0]
            //// dah byratb men el so8yer ll kber ya3ny ==> Ascendding

            //if (other == null)
            //{
            //    return 1;
            //}
            //return this.Salary.CompareTo(other.Salary);

            //// bs dah tab3n byratb el 7aga 3al 2enha Ascendding me4 Descindiing
            //// fa 3l4an n5leh yratb Descindding
            //// han3ks el Conditions bs me4 2ktr 
            //// fa hykon kdah ==> return other.Salary.CompareTo(this.Salary);
            //// el hwa el this b2a gwah we el other b2a bara 
            //// we kdah dah ma3nah 
            //// law el Caller el hwa [this.Salary] < mn el gay el hwa [other.Salary]==> return +ve number
            //// we law el Caller el hwa [this.Salary] > mn el gay el hwa [other.Salary]==> return -ve number
            //// we law el Caller el hwa [this.Salary] = mn el gay el hwa [other.Salary]==> return Zero [0]
            //// dah byratb men el kber ll so8yer ya3ny ==> Descendding

            if (other == null)
            {
                return 1;
            }
            return other.Salary.CompareTo(this.Salary);
        }

        /*********************************************************************************************/

        /************************ [IComparable el nos5a el 2dema el object] **************************/

        //// el nos5a el 2dema el bet5od menk object 
        //// we el object dah hwa el employee el tany 
        //// 2sl el CompareTo hya betebd2a tekarn kol 2 be ba3d 
        //// tb 2wl employee byegy menen ??
        //// 2wl employee dah hwa el Caller el by3ml Call ly method el CompareTo
        //// fa dymn 2wl employee 3omroh ma hykon be null leh b2a ??
        //// hwa ana ynfa3 a22ol 3andy 2wl employee be null we 2ro7 23ml men 5elaloh call ly method l2a tab3n mynfa34
        //// ma t2dr4 7aga be null te3ml access 2w call ly method l2n el null me4 gwah 7aga 2sl 34lan te2dr
        //// te access beha 7ad we hwa me4 hy4of 2sln ay method 
        //// el momken yb2a be null hwa tany employee 3ady el hwa hab3toh gwa method el CompareTo
        //// el Caller le ay method 3omroh ma hykon be null 

        //// el parameter el bast2bl feh gwa el CompareTo hwa gay 3al 2noh [ object ]
        //// l2noh me4 3arf anta hateb3t aeh belzabt we deh 2sln el nos5a el 2dema mn el interface ==> IComparable
        //// bat3aml ma3 el object 3al 2enoh el parent bta3 el kol 
        //// bs 2bl ma te4ta8l me7tag tet check el 2wl el object el gay dah be null wla l2a 

        //// tb el CompareTo deh by7slah implememnt azay ll body bta3ha men gwah ya3ny bet4ta8l azay ?
        //// hya leha behaviour mo3yen 
        //// we 5aly balk el [This] hwa dayman el [Caller] el hwa by3ml call ll method
        //// law 3ayez 2a CompareTo Based on el Salary
        //// fa el byhaviour hyb2a kdah 
        //// This.Salary > obj.Salary ==> return +ve number like +ve 1 or any +ve number
        //// This.Salary < obj.Salary ==> return -ve number like -ve 1 or any -ve number
        //// This.Salary = obj.Salary ==> return zero [0]
        //// bs tab3n hat check el 2wl 3al el obj el gayely law hwa be null kdah el Caller el hwa el this 
        //// hyb2a 2kbr menoh 3altol fa kdah el mafrod y return +ve number el hwa +ve 1

        //// hal2ay mo4kel b2a el [obj] dah hwa object bs lama 23ml ==> obj.
        //// hal2eh me4 zahr 3andoh wla Salalry wla ID wla Name el hya 7agat el Employee
        //// l2n el [obj] hwa mn type Object fa momken ykon ay 7aga 
        //// fa ana lazem 2fhmoh 2enoh ykon mn Type ==> Employee
        //// 3l4an 23rf access el Salalry 2w ID 2w Name
        //// fa lazem 23ml [ Casting ] 3al el [obj] 2fhmoh 2noh 2nk hatkon [Employee]


        //// bs 5aly balk el implementation el 3amlen ne3mloh dah ben3mloh 3al el fady we el malyan 
        //// el hwa el behvior el 3amlnah dah 
        //// l2n el behavior dah 2sln mawgod fe el [Salary] we el [Salary] dah hwa mn Type [Int]
        //// we el [int] 3andoh 2sln method [CompareTo] gwa el Class bta3 el [int]
        //// fa hanro7 nest5dm el CompareTo bta3 el [int] 3altol 
        //// ana ha3ml kdah l2n bakrn based on el [Salary] we el [Salary] dah hwa Datatype [int]
        //// we Class el [int] men gwah 3aml implement ll interface [IComparable] fa hwa 3andoh 
        //// method el ComareTo bta3toh we bet3ml nafs el behvior el hwa 
        //// law el Caller > mn el gay ==> return +ve number
        //// we law el Caller < mn el gay ==> return -ve number
        //// we law el Caller = mn el gay ==> return zero [0]
        //// fa haro7 23ml kdah ==> return this.Salary.CompareTo(other.Salary);
        //// we deh ma3nah 
        //// law el Caller el hwa [this.Salary] > mn el gay el hwa [other.Salary]==> return +ve number
        //// we law el Caller el hwa [this.Salary] < mn el gay el hwa [other.Salary]==> return -ve number
        //// we law el Caller el hwa [this.Salary] = mn el gay el hwa [other.Salary]==> return Zero [0]

        //// madama fe 7ad 3aml el implementation 5las 5odoh menoh ma tkrrho4 anta zay ma 3amlna kdah 
        //// lakn law 7ad me4 3amloh 5las han3mloh be 2dena zay ma kona 3amlen 

        //public int CompareTo(object? obj)
        //{
        //    // tb el CompareTo deh by7slah implememnt azay ll body bta3ha men gwah ya3ny bet4ta8l azay ?
        //    // hya leha behaviour mo3yen 
        //    // we 5aly balk el [This] hwa dayman el [Caller] el hwa by3ml call ll method
        //    // law 3ayez 2a CompareTo Based on el Salary
        //    // fa el byhaviour hyb2a kdah 
        //    // This.Salary > obj.Salary ==> return +ve number like +ve 1 or any +ve number
        //    // This.Salary < obj.Salary ==> return -ve number like -ve 1 or any -ve number
        //    // This.Salary = obj.Salary ==> return zero [0]
        //    // bs tab3n hat check el 2wl 3al el obj el gayely law hwa be null kdah el Caller el hwa el this 
        //    // hyb2a 2kbr menoh 3altol fa kdah el mafrod y return +ve number el hwa +ve 1

        //    // hal2ay mo4kel b2a el [obj] dah hwa object bs lama 23ml ==> obj.
        //    // hal2eh me4 zahr 3andoh wla Salalry wla ID wla Name el hya 7agat el Employee
        //    // l2n el [obj] hwa mn type Object fa momken ykon ay 7aga 
        //    // fa ana lazem 2fhmoh 2enoh ykon mn Type ==> Employee
        //    // 3l4an 23rf access el Salalry 2w ID 2w Name
        //    // fa lazem 23ml [ Casting ] 3al el [obj] 2fhmoh 2noh 2nk hatkon [Employee]
        //    // we hansmeh be ay 2sm wal ykon ==> other
        //    // we kdah el other b2a e3andoh kol 7aga bta3t el Employee
        //    // we 3amlnah be ==> [Employee ? ] 3l4an ykon nullable Employee ysma7 bel null
        //    // we deh kdah el nos5a el 2dema 

        //    Employee? other = (Employee?)obj;
        //    if (other is null /*or == null */)
        //    { // this mean ==> This.Salary > obj.Salary el hwa = null
        //      // ==> return +ve number like +ve 1 or any +ve number
        //        return 1; 
        //    }

        //    if (this.Salary > other.Salary)
        //    {
        //        return 1;
        //    }
        //    else if(this.Salary < other.Salary)
        //    { 
        //        return -1; 
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //    //// kan momken ne3m 2wl 2 if fe 1 if we nest5d el || kdah ==> 

        //    //if(other is null || this.Salary > other.Salary)
        //    //{
        //    //    return 1;
        //    //}

        //    else if(this.Salary<other.Salary)
        //    { 
        //        return -1; 
        //    }
        //    else
        //    {
        //        return 0;
        //    }


        //// bs 5aly balk el implementation el 3amlen ne3mloh fo2 dah ben3mloh 3al el fady we el malyan 
            //// el hwa el behvior el 3amlnah dah 
            //// l2n el behavior dah 2sln mawgod fe el [Salary] we el [Salary] dah hwa mn Type [Int]
            //// we el [int] 3andoh 2sln method [CompareTo] gwa el Class bta3 el [int]
            //// fa hanro7 nest5dm el CompareTo bta3 el [int] 3altol 
            //// ana ha3ml kdah l2n bakrn based on el [Salary] we el [Salary] dah hwa Datatype [int]
            //// we Class el [int] men gwah 3aml implement ll interface [IComparable] fa hwa 3andoh 
            //// method el ComareTo bta3toh we bet3ml nafs el behvior el hwa 
            //// law el Caller > mn el gay ==> return +ve number
            //// we law el Caller < mn el gay ==> return -ve number
            //// we law el Caller = mn el gay ==> return zero [0]
            //// fa haro7 23ml kdah ==> return this.Salary.CompareTo(other.Salary);
            //// we deh ma3nah 
            //// law el Caller el hwa [this.Salary] > mn el gay el hwa [other.Salary]==> return +ve number
            //// we law el Caller el hwa [this.Salary] < mn el gay el hwa [other.Salary]==> return -ve number
            //// we law el Caller el hwa [this.Salary] = mn el gay el hwa [other.Salary]==> return Zero [0]
            //// dah byratb men el so8yer ll kber ya3ny ==> Ascendding

            //if (other == null)
            //{
            //    return 1;
            //}
            //return this.Salary.CompareTo(other.Salary);

            //// bs dah tab3n byratb el 7aga 3al 2enha Ascendding me4 Descindiing
            //// fa 3l4an n5leh yratb Descindding
            //// han3ks el Conditions bs me4 2ktr 
            //// fa hykon kdah ==> return other.Salary.CompareTo(this.Salary);
            //// el hwa el this b2a gwah we el other b2a bara 
            //// we kdah dah ma3nah 
            //// law el Caller el hwa [this.Salary] < mn el gay el hwa [other.Salary]==> return +ve number
            //// we law el Caller el hwa [this.Salary] > mn el gay el hwa [other.Salary]==> return -ve number
            //// we law el Caller el hwa [this.Salary] = mn el gay el hwa [other.Salary]==> return Zero [0]
            //// dah byratb men el kber ll so8yer ya3ny ==> Descendding

            //if (other == null)
            //{
            //    return 1;
            //}
            //return other.Salary.CompareTo(this.Salary);

        //}

        /***************************************************************************************/


        public override string ToString()
        {
            return $"Id : {Id} , Name : {Name} , Salary : {Salary}";
        }


        /********************************** Copy Constructor ***********************************/

        // fe b2a tare2 2shl mn el Clone deh bet3ml nafs el Deep Copy el hya ==>[Copy Constructor]
        // hwa leh 2st5dam wa7d me4 ben5org 3anoh 2enta law 3ayez to5rg 3anoh bera7tk 
        // bs 2st5damoh el wa7ed we el 4a23 hwa 2ny ==> [ ba Copy el Data fe el Reference Types ]
        // law ana 3ayez 23ml el Deep Copy
        // Tb by3ml eh el Copy Constructor dah ??
        // dah by5od menk el Employee el 2wl el Employee el 3ayez te copy menoh el data
        // we ybd2a y3melk el instance el anta 3ayezha 
        // tb azay ??
        // me4 2sln el Constructor mas2ol 2enoh y3arflk el fileds bat3tk tb ma ana ha3mlk el kdlam dah 
        // hanro7 gwa el Class el Employee ne3ml el Constructor 

        // we el [this] deha 3ayeda 3al el hyklmny men barah el hwa el Caller el hy3ml Call ll Constructor
        // el hwa fe el 7ala deh hwa [employee2] me4 employee1 l2n el employee2 hwa el hystad3y el Constructor

        // dah kdah no3 men el Constructor 2smoh Copy Constructor 

        // bs hatl2y gwa Method el [Clone()] fo2 el ==> return new Employee()
        // ze3lt l2n mab2a4 kdah feh Parameterless Constructor 
        // l2n mogard ma 3amlt ana parameter Constructor 5las mab2a4 feh 7aga 2smha Parameterless Constructor
        // we kman bara hatl2y lama 3amlt el
        // [object initializer ly employee1 el tare2 deh sa7 law fe Parameterless Constructor
        // 2w law mafe4 ay paramtereize Constructor 5als we el compiler hy generate sa3tha
        // el Parameterless Constructor lakn 3l4an 3amlt ana Paramterize Constructor
        // fa el Compiler 5als hy3tmd 3aleh we me4 hy3ml generate men gwah ll Parameterless Constructor
        // fa hydrb error barah fa 3l4an 27l kol dah haro7 23ml be 2edy el Parameterless Constructor]

        // bs el Code dah me4 Protective Code l2n el [emp1] dah momken ygey be null
        // fa haro7 2st5dm el null Colasing we el nullable
        // emp1?.Id??0; ==> dah ma3nah law el emp1 me4 be null hatly el Id 3ady lakn law be null 7ot 0
        // emp1?.Name??""; ==> dah ma3nah law el emp1 me4 be null hatly el Name 3ady lakn law be null 7ot Empty string [""]
        public Employee(Employee emp1)
        {
            this.Id = emp1?.Id??0;
            this.Name = emp1?.Name??"";
            this.Salary = emp1?.Salary??0;
        }
        public Employee() { }
    }
}
