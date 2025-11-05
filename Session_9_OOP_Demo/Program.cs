using Session_9_OOP_Demo.Binding;
using Session_9_OOP_Demo.Built_in_Interfaces;
using Session_9_OOP_Demo.Interfaces;
using Session_9_OOP_Demo.Interfaces.Example_1;
using Session_9_OOP_Demo.Interfaces.Example_2;
using System.ComponentModel;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Session_9_OOP_Demo
{
    internal class Program
    {
        #region Interface - Ex - 1 [ISeries]
        //// make method to print 1st Five numbers in Series
        //public static void PrintSeries (SeriesByTwo seriesByTwo)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        // use this method to prevent start from 0 i need current to start from 2
        //        seriesByTwo.GetNext();
        //        Console.Write($"{seriesByTwo.Current} ");
        //    }
        //    //after finish loop need to reset current becuase if need to make this sereis again
        //    //so should reset Current
        //    // but we cant reach to default implemented method by using instance from class
        //    // mean can't make this ==> seriesByTwo.ResetCurrent();
        //    // becuase class can't access or see default implemented method in interface
        //    // to can access default implemented method 
        //    // so you should make referenc from interface like that ==> ISeries iSeries ;
        //    // and make this reference refer or point to instance from class that implemeneted this interface
        //    // like that ==> iSeries = new SeriesByTwo();
        //    // then now you can access default implemented method from interface 
        //    ISeries iSeries = new SeriesByTwo();
        //    iSeries.ResetCurrent();
        //}

        /***************************** make another creative Solution ***************************/

        // should treat with interface not treat with class 
        // l2n ayam el inheritance kon2 ben2ol benb3t reference mn el parent ka parameter fe el method
        // y2dr y4awr 3al ay instance mn el child 
        // nafs el klam fe el interface 
        // this Reference iSeries can refer or point to ==>
        // any instance from class or struct that used or implement this interface
        // but cant refer or point to instance from interface that mean we can't create instance from interface
        // then make parameter of method from Type Interface mean make reference from interface ISeries

        // we kdah badl ma kont ha3ml 2 method wa7da bet print SeriesByTwo we el tany bet print SeriesByThree
        // la2 ha3ml method teb2a generic tetb3 ay 7aga 3al 7asb ana ha5ly el reference bta3 el interface
        // y4awr 3al any Class by implement el interface dah 
        // we kdah ba2t method wa7da we 3al 7asb ana 3ayez any Sereis swa2 SeriesByTwo or SeriesByThree
        // mograd bs ha5ly el reference y4awr 3al instance mn el sereis deh zay kdah fe el call ta7t 
        // ==> hab3t el parameter ka instnace 3al el sereies el 3ayzha ana zay kdah ==>
        // PrintSeries(new SeriesByTwo()); ==> kdah ana 3ayez el sereis el SeriesByTwo
        // PrintSeries(new SeriesByThree()); ==> kdah ana 3ayez el sereis el SeriesByThree

        /***************************** Note *************************************
        when deal with any reference should first check is it null or not 
        if not null then make method and work correct
        if null dont make method becuase if method run then will happend exception and error
        *************************************************************************/
        public static void PrintSeries(ISeries iSeries)
        {
            if (iSeries is not null)
            {
                for (int i = 0; i < 5; i++)
                {
                    // use this method to prevent start from 0 i need current to start from 2 or 3 
                    // depend on where reference will refer or point to any instance is that SeriesByTwo or SeriesByThree 
                    // GetNext(); will call depend on reference where ir refer or point to
                    // if point or refere on instance from class SeriesByTwo
                    // then will call this method from class SeriesByTwo
                    // if point or refere on instance from class SeriesByThree
                    // then will call this method from class SeriesByThree
                    iSeries.GetNext();
                    Console.Write($"{iSeries.Current} ");
                }
                // can reach direct to default implemented method becuase this is reference from interface 
                // not from class then can reach and access direct default implemented method
                iSeries.ResetCurrent();
                //make this to out from method 
                return;
            }
        }
        
        #endregion
        static void Main(string[] args)
        {
            #region 1] Ex - 3 Binding [Type A , Type B , Type C] , [Type D , Type E]

            /**************************** Test Class TypeB **********************************/

            //// make reference form TypeA
            //// this is Reference Type that CLR reserve 4 bytes in memory in stack
            //// and this reference will point or refer to any instance from TypeA
            //// or any child class from TypeA or any instance from class that inherits from TypeA
            //// this reference can access or update any thing in his class TypeA only
            //// but it can't update and access any value on any class inherits from TypeA
            //// becuase this is not personal scope
            //// but it can only access the members that TypeA has and update them in Class TypeA only 
            //// becuase this is personal scope for TypeA
            //TypeA typeA;

            //// now this reference will point to an instance from Type B
            //typeA = new TypeB(1,2);

            ////Valid becuase A in the personal Scope of Class TypeA then can access it and update it 
            //typeA.A = 10;

            ////InValid becuase B in the personal Scope of Class TypeB then can not access it and update it
            //// not in scope of TypeA
            //// so we can't access or update B
            //typeA.B = 20;

            //// what happend ? it will happen static binding becuase we don't use keyword virtual
            //// and this work ==> Call method Based on Reference
            //// and Reference refer to TypeA when make this ==> TypeA typeA;
            //// then it will call MyFun01 that in Scope of TypeA not in TypeB
            //typeA.MyFun01();

            //// what happend ? it will happen dyanmic binding becuase we use keyword virtual
            //// and this work ==> Call method Based on instance
            //// and Reference refer to TypeA but instance refer to TypeB when make this ==> typeA = new TypeB(1,2);
            //// then it will call MyFun02 that in Scope of TypeB not in TypeA
            //// becuase this method is virtual in TypeA and override in TypeB and this is Dynamic Binding
            //// and instance refer to TypeB this is the main reason 
            //typeA.MyFun02();


            /**************************** Test Class TypeC **********************************/

            /******************** Indirect Parent use Reference from TypeA *******************/

            ////// make reference form TypeA
            ////// this is Reference Type that CLR reserve 4 bytes in memory in stack
            ////// and this reference will point or refer to any instance from TypeA
            ////// or any child class from TypeA or any instance from class that inherits from TypeA
            ////// this mean can refer to Class Type A or B or C
            ////// this reference can access or update any thing in his class TypeA only
            ////// but it can't update and access any value on any class inherits from TypeA
            ////// becuase this is not personal scope
            ////// but it can only access the members that TypeA has and update them in Class TypeA only 
            ////// becuase this is personal scope for TypeA
            //TypeA typeA;

            ////// now this reference will point to an instance from Type C
            //typeA = new TypeC(1,2,3);

            //////Valid becuase A in the personal Scope of Class TypeA then can access it and update it 
            //typeA.A = 10;

            //////InValid becuase B in the personal Scope of Class TypeB then can not access it and update it
            ////// not in scope of TypeA
            ////// so we can't access or update B
            ////// becuase the reference refer to TypeA not TypeB
            //typeA.B = 20;

            //////InValid becuase C in the personal Scope of Class TypeC then can not access it and update it
            ////// not in scope of TypeA
            ////// so we can't access or update C
            ////// becuase the reference refer to TypeA not TypeC
            //typeA.C = 30;

            ////// what happend ? it will happen static binding becuase we don't use keyword virtual
            ////// and this work ==> Call method Based on Reference not based on instance
            ////// and Reference refer to TypeA when make this ==> TypeA typeA;
            ////// then it will call MyFun01 that in Scope of TypeA not in TypeC
            //typeA.MyFun01();

            ////// what happend ? it will happen dyanmic binding becuase we use keyword virtual
            ////// and this work ==> Call method Based on instance not based on reference
            ////// and Reference refer to TypeA but instance refer to TypeC when make this ==> typeA = new TypeC(1,2,3);
            ////// then it will call MyFun02 that in Scope of TypeC not in TypeA or TypeB
            ////// becuase this method is virtual in TypeA and override in TypeB and override in TypeC and this is Dynamic Binding
            ////// and instance refer to TypeC this is the main reason 
            //typeA.MyFun02();

            /********************* direct Parent use Reference from TypeB ********************/

            ////// make reference form TypeB
            ////// this is Reference Type that CLR reserve 4 bytes in memory in stack
            ////// and this reference will point or refer to any instance from TypeB
            ////// or any child class from TypeB or any instance from class that inherits from TypeB
            ////// this mean can refer to Class Type B or C not refer to Class Type A
            ////// becuase Type A is parent of TypeB and child can't refer to parent 
            ////// but Parent can refer to child 
            ////// this reference can access or update any thing in his class TypeB or in TypeA only
            ////// becuase TypeB is child of TypeA and see Scope of Parent Class TypeA and his personal Scope of TypeB
            ////// but it can't update and access any value on any class inherits from TypeB like TypeC
            ////// becuase this is not personal scope
            ////// but it can only access the members that TypeB or TypeA has and update them in Class TypeB or TypeA only 
            ////// becuase this is personal scope for TypeB
            //TypeB typeB;

            ////// now this reference will point to an instance from Type C
            //typeB = new TypeC(1, 2, 3);

            //////Valid becuase A in the personal Scope of Class TypeB then can access it and update it 
            ////// Class TypeB can see Scope of Parent Class TypeA and his personal Scope of TypeB
            ////// So we can access A and Update value on it 
            //typeB.A = 10;

            //////Valid becuase B in the personal Scope of Class TypeB then can access it and update it
            //typeB.B = 20;

            //////InValid becuase C in the personal Scope of Class TypeC then can not access it and update it
            ////// not in scope of TypeB
            ////// so we can't access or update C
            ////// becuase the reference refer to TypeB not TypeC
            //typeB.C = 30;

            ////// what happend ? it will happen static binding becuase we don't use keyword virtual
            ////// and this work ==> Call method Based on Reference not based on instance
            ////// and Reference refer to TypeB when make this ==> TypeB typeB;
            ////// then it will call MyFun01 that in Scope of TypeB not in TypeC
            //typeB.MyFun01();

            ////// what happend ? it will happen dyanmic binding becuase we use keyword virtual
            ////// and this work ==> Call method Based on instance not based on reference
            ////// and Reference refer to TypeB but instance refer to TypeC when make this ==> typeB = new TypeC(1,2,3);
            ////// then it will call MyFun02 that in Scope of TypeC not in TypeA or TypeB
            ////// becuase this method is virtual in TypeA and override in TypeB and override in TypeC and this is Dynamic Binding
            ////// and instance refer to TypeC this is the main reason 
            //typeB.MyFun02();

            /**************************** Test Class TypeD **********************************/

            /******************** Indirect Parent use Reference from TypeA *******************/

            ////// make reference form TypeA
            ////// this is Reference Type that CLR reserve 4 bytes in memory in stack
            ////// and this reference will point or refer to any instance from TypeA
            ////// or any child class from TypeA or any instance from class that inherits from TypeA
            ////// this mean can refer to Class Type A or B or C
            ////// this reference can access or update any thing in his class TypeA only
            ////// but it can't update and access any value on any class inherits from TypeA
            ////// becuase this is not personal scope
            ////// but it can only access the members that TypeA has and update them in Class TypeA only 
            ////// becuase this is personal scope for TypeA
            //TypeA typeA;


            ////// now this reference will point to an instance from Type D
            //typeA = new TypeD(1,2,3,4);


            //////Valid becuase A in the personal Scope of Class TypeA then can access it and update it 
            //typeA.A = 10;

            //////InValid becuase B in the personal Scope of Class TypeB then can not access it and update it
            ////// not in scope of TypeA
            ////// so we can't access or update B
            ////// becuase the reference refer to TypeA not TypeB
            //typeA.B = 20;

            //////InValid becuase C in the personal Scope of Class TypeC then can not access it and update it
            ////// not in scope of TypeA
            ////// so we can't access or update C
            ////// becuase the reference refer to TypeA not TypeC
            //typeA.C = 30;

            //////InValid becuase D in the personal Scope of Class TypeD then can not access it and update it
            ////// not in scope of TypeA
            ////// so we can't access or update D
            ////// becuase the reference refer to TypeA not TypeD
            //typeA.D = 40;

            ////// what happend ? it will happen static binding becuase we don't use keyword virtual
            ////// and this work ==> Call method Based on Reference not based on instance
            ////// and Reference refer to TypeA when make this ==> TypeA typeA;
            ////// then it will call MyFun01 that in Scope of TypeA not in TypeD
            //typeA.MyFun01();

            ////// what happend ? it will happen dyanmic binding becuase we use keyword virtual
            ////// and this work ==> Call method Based on instance not based on reference
            ////// and Reference refer to TypeA but instance refer to TypeD when make this ==> typeA = new TypeD(1,2,3,4);
            ////// then it will call MyFun02 that in Scope of TypeC not in TypeA or TypeB or TypeD
            ////// becuase this method is virtual in TypeA and override in TypeB and override in TypeC and this is Dynamic Binding
            ////// and when use keyword New in TypeD then we break chain of this method 
            ////// and make new Chain for this method from TypeD
            ////// then we have 2 types of chain 
            ////// 1st chain for this method from TypeA to TypeC and end in TypeC
            ////// 2nd chain start from TypeD
            ////// when see o/p of call this method we will get the o/p is ==> TypeC ==> A : 10 , B : 1 , C : 3
            ////// this mean call method that in TypeC not in TypeD but instance refer to TypeD not TypeC
            ////// then what happend ?
            ////// we say when use keyword new make a new chain then when use any reference
            ////// from any type not from TypeD then it will call the last override method from 1st Chain 
            ////// this mean it call method in TypeC becuase this is the last override method 
            ////// or mean the last method in 1st chain becuase we break this chain when use new in TypeD
            ////// and instance refer to TypeD that make new chain on it this is the main reason 
            ////// So call last method from last chain before break it
            //typeA.MyFun02();


            /******************** Indirect Parent use Reference from TypeB *******************/

            ////// make reference form TypeB
            ////// this is Reference Type that CLR reserve 4 bytes in memory in stack
            ////// and this reference will point or refer to any instance from TypeB
            ////// or any child class from TypeB or any instance from class that inherits from TypeB
            ////// becuase Type A is parent of TypeB and child can't refer to parent 
            ////// but Parent can refer to child
            ////// this mean can refer to Class Type B or C or D 
            ////// this reference can access or update any thing in his class TypeB or in TypeA only
            ////// but it can't update and access any value on any class inherits from TypeB
            ////// becuase this is not personal scope
            ////// but it can only access the members that TypeB has and update them in Class TypeB or in TypeA only 
            ////// becuase this is personal scope for TypeB
            //TypeB typeB;


            ////// now this reference will point to an instance from Type D
            //typeB = new TypeD(1, 2, 3, 4);

            //////Valid becuase A in the personal Scope of Class TypeB then can access it and update it 
            ////// Class TypeB can see Scope of Parent Class TypeA and his personal Scope of TypeB
            ////// So we can access A and Update value on it
            //typeB.A = 10;

            //////Valid becuase B in the personal Scope of Class TypeB then can access it and update it 
            //typeB.B = 20;

            //////InValid becuase C in the personal Scope of Class TypeC then can not access it and update it
            ////// not in scope of TypeB
            ////// so we can't access or update C
            ////// becuase the reference refer to TypeB not TypeC
            //typeB.C = 30;

            //////InValid becuase D in the personal Scope of Class TypeD then can not access it and update it
            ////// not in scope of TypeB
            ////// so we can't access or update D
            ////// becuase the reference refer to TypeB not TypeD
            //typeB.D = 40;

            ////// what happend ? it will happen static binding becuase we don't use keyword virtual
            ////// and this work ==> Call method Based on Reference not based on instance
            ////// and Reference refer to TypeB when make this ==> TypeB typeB;
            ////// then it will call MyFun01 that in Scope of TypeB not in TypeD
            //typeB.MyFun01();

            ////// what happend ? it will happen dyanmic binding becuase we use keyword virtual
            ////// and this work ==> Call method Based on instance not based on reference
            ////// and Reference refer to TypeB but instance refer to TypeD when make this ==> typeB = new TypeD(1,2,3,4);
            ////// then it will call MyFun02 that in Scope of TypeC not in TypeA or TypeB or TypeD
            ////// becuase this method is virtual in TypeA and override in TypeB and override in TypeC and this is Dynamic Binding
            ////// and when use keyword New in TypeD then we break chain of this method 
            ////// and make new Chain for this method from TypeD
            ////// then we have 2 types of chain 
            ////// 1st chain for this method from TypeA to TypeC and end in TypeC
            ////// 2nd chain start from TypeD
            ////// when see o/p of call this method we will get the o/p is ==> TypeC ==> A : 10 , B : 1 , C : 3
            ////// this mean call method that in TypeC not in TypeD but instance refer to TypeD not TypeC
            ////// then what happend ?
            ////// we say when use keyword new make a new chain then when use any reference
            ////// from any type not from TypeD then it will call the last override method from 1st Chain 
            ////// this mean it call method in TypeC becuase this is the last override method 
            ////// or mean the last method in 1st chain becuase we break this chain when use new in TypeD
            ////// and instance refer to TypeD that make new chain on it this is the main reason 
            ////// So call last method from last chain before break it
            //typeB.MyFun02();


            /******************** Direct Parent use Reference from TypeC *******************/

            ////// make reference form TypeC
            ////// this is Reference Type that CLR reserve 4 bytes in memory in stack
            ////// and this reference will point or refer to any instance from TypeC
            ////// or any child class from TypeC or any instance from class that inherits from TypeC
            ////// becuase Type B or A is parent of TypeC and child can't refer to parent 
            ////// but Parent can refer to child
            ////// this mean can refer to Class Type C or D 
            ////// this reference can access or update any thing in his class TypeC or in TypeB or in TypeA only
            ////// but it can't update and access any value on any class inherits from TypeC
            ////// becuase this is not personal scope
            ////// but it can only access the members that TypeC has and update them in Class TypeC or in TypeB or in TypeA only 
            ////// becuase this is personal scope for TypeC
            //TypeC typeC;


            ////// now this reference will point to an instance from Type D
            //typeC = new TypeD(1, 2, 3, 4);

            //////Valid becuase A in the personal Scope of Class TypeA then can access it and update it 
            ////// Class TypeC can see Scope of Parent Class TypeA and TypeB and his personal Scope of TypeC
            ////// So we can access A and Update value on it
            //typeC.A = 10;

            //////Valid becuase B in the personal Scope of Class TypeB then can access it and update it 
            ////// Class TypeC can see Scope of Parent Class TypeA and TypeB and his personal Scope of TypeC
            ////// So we can access B and Update value on it 
            //typeC.B = 20;

            //////Valid becuase C in the personal Scope of Class TypeC then can access it and update it
            //typeC.C = 30;

            //////InValid becuase D in the personal Scope of Class TypeD then can not access it and update it
            ////// not in scope of TypeC
            ////// and parent can't access any thing in child but child can access anything in parent
            ////// so we can't access or update D
            ////// becuase the reference refer to TypeC not TypeD
            //typeC.D = 40;

            ////// what happend ? it will happen static binding becuase we don't use keyword virtual
            ////// and this work ==> Call method Based on Reference not based on instance
            ////// and Reference refer to TypeB when make this ==> TypeC typeC;
            ////// then it will call MyFun01 that in Scope of TypeC not in TypeD
            //typeC.MyFun01();

            ////// what happend ? it will happen dyanmic binding becuase we use keyword virtual
            ////// and this work ==> Call method Based on instance not based on reference
            ////// and Reference refer to TypeC but instance refer to TypeD when make this ==> typeC = new TypeD(1,2,3,4);
            ////// then it will call MyFun02 that in Scope of TypeC not in TypeA or TypeB or TypeD
            ////// becuase this method is virtual in TypeA and override in TypeB and override in TypeC and this is Dynamic Binding
            ////// and when use keyword New in TypeD then we break chain of this method 
            ////// and make new Chain for this method from TypeD
            ////// then we have 2 types of chain 
            ////// 1st chain for this method from TypeA to TypeC and end in TypeC
            ////// 2nd chain start from TypeD
            ////// when see o/p of call this method we will get the o/p is ==> TypeC ==> A : 10 , B : 1 , C : 3
            ////// this mean call method that in TypeC not in TypeD but instance refer to TypeD not TypeC
            ////// then what happend ?
            ////// we say when use keyword new make a new chain then when use any reference
            ////// from any type not from TypeD then it will call the last override method from 1st Chain 
            ////// this mean it call method in TypeC becuase this is the last override method 
            ////// or mean the last method in 1st chain becuase we break this chain when use new in TypeD
            ////// and instance refer to TypeD that make new chain on it this is the main reason 
            ////// So call last method from last chain before break it
            ////// becuase TypeD break chain of this method when use keyword new
            //typeC.MyFun02();


            /**************************** Test Class TypeE **********************************/

            /******************** Direct Parent use Reference from TypeD *******************/

            ////// make reference form TypeD
            ////// this is Reference Type that CLR reserve 4 bytes in memory in stack
            ////// and this reference will point or refer to any instance from TypeD
            ////// or any child class from TypeD or any instance from class that inherits from TypeD
            ////// becuase Type C or B or A is parent of TypeD and child can't refer to parent 
            ////// but Parent can refer to child
            ////// this mean can refer to Class Type D or E 
            ////// this reference can access or update any thing in his class TypeD or in TypeC or in TypeB or in TypeA only
            ////// but it can't update and access any value on any class inherits from TypeD
            ////// becuase this is not personal scope
            ////// but it can only access the members that TypeD has and update them in Class TypeD or in TypeC or in TypeB or in TypeA only 
            ////// becuase this is personal scope for TypeD
            ////// Child can access any thing in Parents but Parent can't access anything in child
            //TypeD typeD;


            ////// now this reference will point to an instance from Type E
            //typeD = new TypeE(1, 2, 3 ,4 ,5);

            //////Valid becuase A in the personal Scope of Class TypeA then can access it and update it 
            ////// Class TypeD can see Scope of Parent Class TypeA and TypeB and TypeC and his personal Scope of TypeD
            ////// So we can access A and Update value on it
            //typeD.A = 10;

            //////Valid becuase B in the personal Scope of Class TypeB then can access it and update it 
            ////// Class TypeD can see Scope of Parent Class TypeA and TypeB and TypeC and his personal Scope of TypeD
            ////// So we can access B and Update value on it 
            //typeD.B = 20;

            //////Valid becuase C in the personal Scope of Class TypeC then can access it and update it 
            ////// Class TypeD can see Scope of Parent Class TypeA and TypeB and TypeC and his personal Scope of TypeD
            ////// So we can access C and Update value on it 
            //////Valid becuase C in the personal Scope of Class TypeC then can access it and update it
            //typeD.C = 30;


            //////Valid becuase D in the personal Scope of Class TypeD then can access it and update it
            //typeD.D = 40;

            //////InValid becuase E in the personal Scope of Class TypeE then can not access it and update it
            ////// not in scope of TypeD
            ////// and parent can't access any thing in child but child can access anything in parent
            ////// so we can't access or update E
            ////// becuase the reference refer to TypeD not TypeE
            //typeD.E = 50;

            ////// what happend ? it will happen static binding becuase we don't use keyword virtual
            ////// and this work ==> Call method Based on Reference not based on instance
            ////// and Reference refer to TypeB when make this ==> TypeD typeCD;
            ////// then it will call MyFun01 that in Scope of TypeD not in TypeE
            //typeD.MyFun01();

            ////// what happend ? it will happen dyanmic binding becuase we use keyword virtual
            ////// and this work ==> Call method Based on instance not based on reference
            ////// and Reference refer to TypeD but instance refer to TypeE when make this ==> typeD = new TypeE(1,2,3,4,5);
            ////// then it will call MyFun02 that in Scope of TypeD not in TypeA or TypeB or TypeC
            ////// becuase this method is virtual in TypeD and override in TypeE and this is Dynamic Binding
            ////// and when use keyword New in TypeD then we break chain of this method 
            ////// and make new Chain for this method from TypeD
            ////// then we have 2 types of chain 
            ////// 1st chain for this method from TypeA to TypeC and end in TypeC
            ////// 2nd chain start from TypeD
            ////// when see o/p of call this method we will get the o/p is ==> TypeE ==> A : 10 , B : 1 , C : 3 , D : 4 , E : 5
            ////// this mean call method that in TypeE not in TypeC or B or A but instance refer to TypeE not TypeC
            ////// then what happend ?
            ////// we say when use keyword new make a new chain then when use any reference
            ////// from any type not from TypeE then it will call the last override method from 2nd chain not 1st Chain 
            ////// this mean it call method in TypeE becuase this is the last override method 
            ////// or mean the last method in 2nd chain becuase we break 1st chain when use new in TypeD
            ////// and instance refer to TypeE that make new chain on it this is the main reason 
            ////// So call last method from last chain after break it
            ////// becuase TypeD break chain of this method when use keyword new
            //typeD.MyFun02();

            /****************** Indirect Parent use Reference from TypeA and B and C *****************/

            //TypeA typeA;
            //TypeB typeB;
            //TypeC typeC;

            //typeA = new TypeE(1, 2, 3, 4, 5);
            //typeB = new TypeE(1, 2, 3, 4, 5);
            //typeC = new TypeE(1, 2, 3, 4, 5);

            ////// what happend ? it will happen dyanmic binding becuase we use keyword virtual
            ////// and this work ==> Call method Based on instance not based on reference
            ////// and Reference refer to Type C and B and A but instance refer to TypeE
            ////// when make this ==> typeA = new TypeE(1,2,3,4,5);
            ////// when make this ==> typeB = new TypeE(1,2,3,4,5);
            ////// when make this ==> typeC = new TypeE(1,2,3,4,5);
            ////// then it will call MyFun02 that in Scope of TypeC not in TypeA or TypeB or TypeD or TypeE
            ////// becuase this method is virtual in TypeA and override in TypeB and override in TypeC and this is Dynamic Binding
            ////// and when use keyword New in TypeD then we break chain of this method 
            ////// and make new Chain for this method from TypeD
            ////// then we have 2 types of chain 
            ////// 1st chain for this method from TypeA to TypeC and end in TypeC
            ////// 2nd chain start from TypeD
            ////// when see o/p of call this method we will get the o/p is ==> TypeC ==> A : 1 , B : 1 , C : 3
            ////// this mean call method that in TypeC not in TypeE but instance refer to TypeE not TypeC
            ////// then what happend ?
            ////// we say when use keyword new make a new chain then when use any reference
            ////// from any type not from TypeD or TypeE then it will call the last override method from 1st Chain 
            ////// this mean it call method in TypeC becuase this is the last override method 
            ////// or mean the last method in 1st chain becuase we break this chain when use new in TypeD
            ////// and instance refer to TypeE that override from TypeD that make new chain on it this is the main reason 
            ////// So call last method from last chain before break it
            ////// becuase TypeD break chain of this method when use keyword new
            //typeA.MyFun02();
            //typeB.MyFun02();
            //typeC.MyFun02();



            #endregion

            #region 2] Interface
            // A blueprint of what a class should do (a code contract)
            // An agreement that a class promises to implement specific members.

            // Interfaces :-
            // Method signatures ==> all access modifier used instead of Private
            // Property/Event/Indexer declarations ==> all access modifier used instead of Private
            // Default implementations methods (C# 8.0 and later) ==> all access modifier used
            // Static members (C# 8.0 and later)

            // Interface ==> is Reference Type like Class and Reserve in Stack and Heap
            // Interface ==> dah 3a2d ben 2tnen lazem nem4y 3aleh law class hywrs mn interface 
            // yb2a lazem el class dah y implement el interface dah zay ma hwa
            // wla y8er fe no3 el datatype wla no3 el return wla ay 7aga 
            // masmo7 bs t2rebn y8er fe el property el ba3mlha fe el 2wl 3an tare2 
            // any azawd 3al el property deh lakn man2s4 mnha 
            // ya3ny law 3aml kdah gwa el interface  ==> public int x {get;}
            // 3ady gwa el class 2zawd 3al el x deh 7aga tany lakn man2s4 mnha kdah
            // ==> public int x {get; set;}
            // lakn 8er kdah lazem el mawgod fe el class yb2a hwa hwa zay el fe el interface bedon ta8er
            // we lazem ay 7aga hatektbha gwa el interface yb2a 2nta 3arf 2nk hatst5dmha me4 hatsebha fady kdah
            // 2sl malha4 ma3na te3rf 7aga fe el 3a2d we anta me4 hat3ml beha 7aga 2sln wla leh 3elka bel mawdo3
            // lazem kol 7aga tektbha yb2 hatst5dmha fe el class belzabt

            // we have 2 types of Interfaces :-
            // 1] - A top-level interface is declared directly inside a namespace [Can be public or internal (default)]
            // 2] -Nested interface declarations, those declared inside another type, can be declared using any access modifier.

            //- Default access modifier inside interface [public].
            //- Class must implement all members of the interface.
            //- You cannot create an object of an interface, only a reference . mean ==>
            // mat2dr4 te create instance mn el interface
            //- A class can implement multiple interfaces(unlike base classes).


            /*********************************************************************************************/

            ////Create for an instance from Class MyType
            //// Reference ==> MyType myType ==> reserve 4 bytes in stack
            //// Instance ==> myType = new MyType(); ==> reserve data in heap and this data that in Class
            //// then 4 bytes for int property
            //MyType myType = new MyType();

            ///********************* Test Class MyType with Interface IType ********************/

            //myType.MyProperty = 10;
            //Console.WriteLine(myType.MyProperty);

            //Console.WriteLine();

            //myType.MyFun();

            //Console.WriteLine();

            //// if try to call Default implemented method that is inside interface 
            //// you can't reach and access it if make this 
            ////myType.MyDefaultMethod(); // ==> Invalid to make this becuase this method is inside interface
            //// ==> not inside in class
            //// ==> Can't reach and access it when use refrence from class that implement interface

            //// you can reach and access Default implemented method by using only this way 
            //// ==> make Reference from interface
            //// ==> Not make Reference from calss that implement interface 

            //// then let's make reference from interface ==>  IType iType ;
            //// this Reference iType can refer or point to ==>
            //// any instance from class or struct that used or implement this interface
            //// but cant refer or point to instance from interface that mean we can't create instance from interface
            //// like that ==>  IType iType = new IType(); ==> inValid

            //IType iType = new MyType(); // ==> Valid becuase make instance from class MyTpe that implement interface IType
            //iType.MyDefaultMethod();

            /******************************************************************************************/

            //**** another way to access and reach to Default implemented method inside interface ****//


            // Explicit Implementation For Interface :-
            // use name of interface first then set [ . ] then choose method or property
            // like that ==> public void IType.MyDefaultMethod(){};
            // and then make logic inside method as you like 


            /*********************** Note for Explicit Implementation For Interface *************************

            Explicit Implementation For Interface help you to access or reach direct to Default implemented Method

             ************************************************************************************************/

            // then to access or reach direct to Default implemented Method
            // make Explicit Implementation
            //iType.MyDefaultMethod();


            /******************************************************************************************/



            //// when make this ==> iType.MyFun();
            //// then he will call method from class not from reference becuase instance refer to Class
            //// that implement interface So call method from Class
            //// and also method in Interface have only signature not have any body or logic
            //// and logic or body or behavior inside method in Class
            //// then o/p will be ==> Helloe from Class MyType that implement Interface IType inside it
            //iType.MyFun();

            ///*********************************** Note **********************************/

            //// if we have method in Class like ==> MyDefaultMethod();
            //// that inside interface 
            //// and try to make this ==> iType.MyDefaultMethod();
            //// then it will call method inside Class not inside Interface 
            //// ka2nena ben2ol 7asl override lakn hwa me4 override 7a2e2y lakn zayoh ya3ny
            //// l2n el instance by4awr 3al el class fa hwa law el 7aga gwa el class hygbha 
            //// law me4 gwa el class we gwah el interface bs fa hygbha mn el interface zay ma 7asl fo2



            #endregion

            #region 3] Interface - Ex - 1 [ISeries]
            //// need to make Series and this Series should follow interface to insure that it is series not any another thing

            //// To make Sereis should have 4 Conditions :-
            //// 1] have Property Called ==> [ Current ] this mean that element will stand on it and start from it my Series
            //// like when make Series increase by 2 then if Current = 0 then start from 0 and series will be --> 0 2 4 6 8 and so on
            //// 2] have Method Called ==> [ GetNext() ] this mean increase on current value that i need sereis to increas or appear
            //// like when make Series increase by 2 this mean current will increase on each state by 2 this is the value
            //// 3] have Method Called ==> [ResetCurrent() ] this mean make reset to current to return and start from 0
            //// becuase if we don't make reset to current then current will start from last number that reached from brevious series
            //// and this is not behavior that we need but we need to start from 0 any sereis

            ////can make this 
            //// we don't need to reserve reference to refer or point to address in heap on Class SeriesByTwo
            //PrintSeries(new SeriesByTwo());
            //Console.WriteLine();
            //// or this
            //// if need to reserve reference to refer or point to address in heap on Class SeriesByTwo 
            //// and will use this reference after that in another method then make this solution
            //SeriesByTwo seriesByTwo = new SeriesByTwo();
            //PrintSeries(seriesByTwo);
            //Console.WriteLine();

            ////can make this 
            //// we don't need to reserve reference to refer or point to address in heap on Class SeriesByThree
            //PrintSeries(new SeriesByThree());
            //Console.WriteLine();
            //// or this
            //// if need to reserve reference to refer or point to address in heap on Class SeriesByThree 
            //// and will use this reference after that in another method then make this solution
            //SeriesByThree seriesByThree = new SeriesByThree();
            //PrintSeries(seriesByThree);
            //Console.WriteLine();

            #endregion

            #region 4] Interface - Ex - 2 [IMovedGround - IMovedOnAir - Vechile]
            //// 3andy Vehicle we 3ayez 23ml menha no3en no3 Car we el tany AirPlane
            //// el mo4tark benhom hwa el Speed lazem ykon 3andohm Speed 
            //// el Car te2dr tem4y 3al el 2rd 2odam we wara we left we right
            //// el AirPlane tem4y 3al el 2rd we fe el hwa[air] 2odam we wara we left we right
            //// 3ayzen ne3ml el system dah 

            //// 1st Solution that will be in your brain and this is not Correct :-
            //// harwo7 23ml Class ll MoveOnGround
            //// we harwo7 23ml class tany ll MoveOnAir
            //// we ba3d kdah haro7 23ml class ll Car we class ll AirPlane we 2wrs b2a mn el Classes el fo2 dol
            //// el Car hywrs 3ady mn el MoveOnGround
            //// bs el mo4kela el hatwaghny fe el AirPlane l2nha hate7tag kdah twers mn 2 Classes
            //// hate7tag tewrs mn el MoveOnGround and MoveOnAir l2nha 3andh el 2 behaviors
            //// we kdah hy7sl multiple inheritance classes we dah 8alt 2w me4 7elw 2w me4 mawgod 3andy
            //// el multiple inheritance me4 masmo7 3andy 
            //// fa el 7al dah me4 tmam we we74

            //// 2nd Solution that will be in your brain and this is Correct :-
            //// 3andy el Speed deh kont bakrrh fo2 fe kol class we dah 8alt l2n el Speed hya mo4tarka ben 
            //// el Car we el AirPlane fa me4 me7tag 2krrha 
            //// fa 3l4an kdah ha3ml Class 2smoh Vehicle we ha7ot feh el Property bta3t el Speed 
            //// tb leh ma7tetha4 fe el interface ?? 
            //// 2sl law 7atetha fe el interface bta3 el MoveOnGround hate7tag to7tha fe el interface bta3 el MoveOnAir
            //// fa hat3ml tekrr bardo fa bla4 
            //// madam fe 7aga mo4tarka benhom 5las han7otha fe Class lwa7doh we nwers mn el Class dah 
            //// haro7 ba3d kdah 23ml 2 Interface :-
            //// 1] for IMovedOnGround
            //// 2] for IMovedOnAir
            //// me4 ha3ml interface wa7d ll 2tnen l2n el car me4 btyer fe el air wla el motsekl byter fa kdah ba2et 
            //// mogbr 2st5dm bta3 el tyran l2noh fe interface wa7d fa dah 8alt 
            //// fa 3l4an kdah fasltohm fe 2 interfaces 
            //// el byter hy implement interface  ==> IMovedOnAir
            //// el bym4y 3al el 2rd hy implement interface ==> IMovedOnGround
            //// we ba3d kdah ha3ml 2 Classes for Car and AirPlane
            //// el Car hat inherit from ==> Class Vehilce and hat implement interface ==> IMovedOnGround
            //// el AirPlane hat inherit from ==> Class Vehilce and hat implement interface ==> IMovedOnAir , IMovedOnGround
            //// el 2tnen bywrso mn Class el Vehcile l2n lazem yb2a 3andohm Speed 
            //// el Car mafo4 mo4kel fe el interface 
            //// swa 3aml Implicit Implementation ll Interface MovedOnGround 2w Explicit Implementation ll Interface MovedOnGround
            //// l2n el Car by implement 1 interface only that is Interface MovedOnGround
            //// but in AirPlane by implement 2 Interfaces thay is Interface MovedOnGround and Interface MovedOnAir
            //// then we should and must use Explicit Implementation ll Interface
            //// becuase 2 interfaces have same method with same name but different behaviors
            //// that Class implement both interfaces
            //// so we should different which is belong to MovedOnGround and belong to MovedOnAir
            //// and we will make this when use Explicit Implementation ll Interface
            //// if have same method with same name and same behvior in 2 Interfaces
            //// then we can use Implicit Implementation ll Interface or Explicit Implementation ll Interface
            //// as you like 
            //// but if have same method with same name but different behaviors in 2 interfces
            //// that Class implement both interfaces
            //// then we should use only Explicit Implementation ll Interface

            //// Explicit Implementation For Interface :-
            //// use name of interface first then set [ . ] then choose method or property
            //// like that ==> public void IMovedOnAir.MoveBackward(){}; public void IMovedOnGround.MoveBackward(){};
            //// and then make logic inside method as you like becuase 2 method have 2 different logic or behaviour
            //// mean not same logic or behaviour

            ///*********************** Note for Explicit Implementation For Interface *************************

            //Explicit Implementation For Interface help you to access or reach direct to Default implemented Method

            // ************************************************************************************************/

            //// Implicit Implementation For Interface :-
            //// use method or property Direct
            //// like that ==> public void MoveBackward(){};
            //// this mean class that inherit from 2 interfaces taht have same method with same name and same behavior
            //// can make this direct don't need to make Explicit implementation to prevent repeated code
            //// but if you need to make Explicit implementation make it as you like but you will repeat code 


            /********************************************************************************************
        
            /************************** Lets Test All Clases and Interfaces *****************************/

            //// when make Implicit Implementation for Interface
            //// can reach or access it by make refernce for interface or class
            //// in this use refernce for Class
            //// make refernce from Class Car 
            //// this reference refer or point to Class car
            //// and inside Class Car make all method Implicit Implementation for interface
            //// then we can access methods or reach for these method 
            //// by using refernce from Car taht refer to Class Car
            //// becuase make Implicit Implementation for interface
            //Car car = new Car();
            //car.MoveBackward();
            //car.MoveForward();
            //car.MoveLeft();
            //car.MoveRight();

            //Console.WriteLine();

            //// or can make this 

            //// when make Implicit Implementation for Interface
            //// can reach or access it by make refernce for interface or class
            //// in this use refernce for interface
            //// make refernce from Interface IMovedOnGround 
            //// this reference refer or point to Class Car like that
            //// ==> IMovedOnGround imovedOnGround = new Car();
            //// and make this reference to refer or point to instance for Class Car
            //// to can access or reach to another methods
            //// that implemented by Explicit Implementation for interface or Implicit Implementation for interface
            //IMovedOnGround imovedOnGround = new Car();
            //imovedOnGround.MoveBackward();
            //imovedOnGround.MoveForward();
            //imovedOnGround.MoveLeft();
            //imovedOnGround.MoveRight();


            //// make refernce from Class AirPlane 
            //// this reference refer or point to Class AirPlane
            //// and inside Class AirPlane make 1 method Implicit Implementation for interface
            //// then we can access this method or reach for this method 
            //// by using refernce from AirPlane taht refer to Class AirPlane
            //// becuase make Implicit Implementation for interface for this method
            //// we can't access or reach to another methods
            //// becuase these method implemented inside Class by Explicit Implementation for interface
            //// then to access them should use refernce from interface like that ==>
            //// ==> IMovedOnGround iMovedOnGround;
            //// ==> IMovedOnAir iMovedOnAir;
            //// and make this reference to refer or point to instance for Class AirPlane
            //// to can access or reach to another methods that implemented by Explicit Implementation for interface
            //AirPlane airPlane = new AirPlane();
            //airPlane.MoveBackward();

            //Console.WriteLine();


            //// make refernce from Interface IMovedOnAir 
            //// this reference refer or point to Class AirPlane like that
            //// ==> IMovedOnAir iMovedOnAir = new AirPlane();
            //// and make this reference to refer or point to instance for Class AirPlane
            //// to can access or reach to another methods
            //// that implemented by Explicit Implementation for interface or Implicit Implementation for interface
            //IMovedOnAir iMovedOnAir = new AirPlane();

            //iMovedOnAir.MoveForward();
            //iMovedOnAir.MoveLeft();
            //iMovedOnAir.MoveRight();

            ///********************************* Note ***********************************************/
            //// we can also access method that implemented by using Implicit Implementation for interface
            //// we can access it when make this : -
            //// make refernce from Interface IMovedOnAir 
            //// this reference refer or point to Class AirPlane like that
            //// ==> IMovedOnAir iMovedOnAir = new AirPlane();
            //// and make this reference to refer or point to instance for Class AirPlane
            //// to can access or reach to another methods
            //// that implemented by Explicit Implementation for interface or Implicit Implementation for interface
            //iMovedOnAir.MoveBackward();

            //Console.WriteLine();

            //// make refernce from Interface IMovedOnGround 
            //// this reference refer or point to Class AirPlane like that
            //// ==> IMovedOnGround imovedOnGround = new AirPlane();
            //// and make this reference to refer or point to instance for Class AirPlane
            //// to can access or reach to another methods
            //// that implemented by Explicit Implementation for interface or Implicit Implementation for interface
            //IMovedOnGround imovedOnGround = new AirPlane();

            //imovedOnGround.MoveForward();
            //imovedOnGround.MoveLeft();
            //imovedOnGround.MoveRight();

            ///********************************* Note ***********************************************/
            //// we can also access method that implemented by using Implicit Implementation for interface
            //// we can access it when make this : -
            //// make refernce from Interface IMovedOnGround 
            //// this reference refer or point to Class AirPlane like that
            //// ==> IMovedOnGround imovedOnGround = new AirPlane();
            //// and make this reference to refer or point to instance for Class AirPlane
            //// to can access or reach to another methods 
            //// that implemented by Explicit Implementation for interface or Implicit Implementation for interface
            //imovedOnGround.MoveBackward();

            //Console.WriteLine();
            /********************************************************************************************/


            #endregion

            #region 5] Shallow Copy Vs Deep Copy
            /*
             * -> Refer to how objects are copied, particularly when those objects 
             * contain references to other objects.
             * -> For pure value types (like int, double, struct), both shallow and deep copy 
             * are the same: when you copy them, you copy their values.
             * -> For structs with reference type fields [Reference Properties] 
             * like Struct have inside String Name this is not pure value type
             * , you might need to manually deep copy 
             * the reference type fields, but the struct itself is still copied by value.
             * -> For reference types (such as classes, arrays, and delegates), 
             * a shallow copy and a deep copy have distinct meanings.
             */

            /*
             Any Value Type Reserve only in Stack .
             Any Reference Type Reserve in Stack and Heap like Array ==>
             place in Stack Called ==> Address or Identity and Identity we can say that is [Reference]
             Place in Heap Called ==> Instance or Object State or Data 
             */

            #region Array of Value Type [Shallow Copy]

            /************** Let's Talk about 1st Example Array of Value Types ***************/

            //// -> Array that is Reference Type and save inside it data with Value Types

            //int[] numbers01 = { 1, 2, 3 };

            //// 2nd Array have 3 places with default value of int that is 0 ==> { 0, 0, 0}
            //int[] numbers02 = new int[3];

            //// 3ayzen ne3rf kol wa7d by4wr fen fe el meomory ya3ny 3ayzen el Address bta3 kol array
            //// we dah hytm mn 5elal el method GetHashCode()
            //// 3l4an 2t2kd 2n fe el 2wl 2bl ma 23ml ay no3 men 2nwa3 el copy 2n kol wa7d fe el 2 Arrays
            //// by4awr 3al mkan 8er el tany fe el memory ya3ny kol wa7d leh address 8er el tany 
            //// 2bl ma 23ml ay Copy
            //Console.WriteLine($"Befor Making Shallow Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"Array numbers01 have HashCode or Address in Stack ==> {numbers01.GetHashCode()}");
            //Console.WriteLine($"Array numbers02 have HashCode or Address in Stack ==> {numbers02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of Array numbers01[0] ==> {numbers01[0]}"); // -> o/p = 1
            //Console.WriteLine($"1st Element of Array numbers02[0] ==> {numbers02[0]}"); // -> o/p = 0
            //Console.WriteLine();

            //// -> Now let's making Shallow Copy 
            //// 3an tare2 2ny ha7ot kol array of numbers01 fe el array of numbers02 by using assignment operator [=]
            //// like That ==> numbers02 = numbers01; // ==> this is Shallow Copy
            //// then Data that inside array of numbers01 it will be inside array of numbers02 after make Shallow Copy
            //// Shallow Copy is Faster than Deep Copy
            //// we el motwak3 2n el 2 Array 3andohm nafs el Address ya3ny by4awro 3al nafs el mkan fe el memory
            //// el hwa 3andohm nafs el idenetity fe el stack we 3andohm nafs el data fe el heap
            //// we kdah law array of numbers02 kan 3ando data 5las hatde3 l2noh b2a 3andoh el data el gdeda
            //// el 5adha mn array of numbers01 lma 3amlt Shallow Copy
            //// we kdah ay ta8er fe array of numbers01 fe el data telka2y hysam3 fe el array of numbers02 bardo
            //// l2n el 2tnen 3andohm nafs el address fel stack we by4awrod 3al nafs el data el fe el heap
            //// 3l4an kdah el Shallow Copy ben2ol 3aleh ==> Copy of Identity or Address
            //// l2n by5aly el 2 Arrays 3andohm nafs el Address 2w nafs el Identity fe el Stack
            //// lakn ma25dt4 Copy mn el Data l2 ana 25dt copy mn el Address we el Address dah 
            //// by4awr 3al data fe el heap fa kdah hwa kman hy4awr 3al nafs el data lakn ana ma 25dt4 
            //// copy mn el data ana 25dt copy mn el address we kdah el 2 Array by4awro 3al nafs el data
            //numbers02 = numbers01; // ==> this is Shallow Copy
            //numbers01[0] = 100;
            //Console.WriteLine($"After Making Shallow Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"Array numbers01 have HashCode or Address in Stack ==> {numbers01.GetHashCode()}");
            //Console.WriteLine($"Array numbers02 have HashCode or Address in Stack ==> {numbers02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of Array numbers01[0] ==> {numbers01[0]}"); // -> o/p = 100
            //Console.WriteLine($"1st Element of Array numbers02[0] ==> {numbers02[0]}"); // -> o/p = 100
            //Console.WriteLine();

            #endregion

            #region Array of Value Type [Deep Copy]

            ///************** Let's Talk about 1st Example Array of Value Types ***************/

            //// -> Array that is Reference Type and save inside it data with Value Types

            //int[] numbers01 = { 1, 2, 3 };

            //// 2nd Array have 3 places with default value of int that is 0 ==> { 0, 0, 0}
            //int[] numbers02 = new int[3];

            //// 3ayzen ne3rf kol wa7d by4wr fen fe el meomory ya3ny 3ayzen el Address bta3 kol array
            //// we dah hytm mn 5elal el method GetHashCode()
            //// 3l4an 2t2kd 2n fe el 2wl 2bl ma 23ml ay no3 men 2nwa3 el copy 2n kol wa7d fe el 2 Arrays
            //// by4awr 3al mkan 8er el tany fe el memory ya3ny kol wa7d leh address 8er el tany 
            //// 2bl ma 23ml ay Copy
            //Console.WriteLine($"Befor Making Deep Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"Array numbers01 have HashCode or Address in Stack ==> {numbers01.GetHashCode()}");
            //Console.WriteLine($"Array numbers02 have HashCode or Address in Stack ==> {numbers02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of Array numbers01[0] ==> {numbers01[0]}"); // -> o/p = 1
            //Console.WriteLine($"1st Element of Array numbers02[0] ==> {numbers02[0]}"); // -> o/p = 0
            //Console.WriteLine();

            //// -> Now let's making Deep Copy 
            //// 3an tare2 2ny ha7ot kol array of numbers01 fe el array of numbers02 by using assignment operator [=]
            //// we bast5dm ma3hom method Called ==> [Clone] 
            //// el Method deh mawgoda fe Interface 2smoh ==> ICloneable
            //// ba7ot el Clone ma3 el Array el ha5od menoh el data we ha7otha fe elArray el Tany
            //// ya3ny ha3ml Clone ma3 Array of numbers01
            //// tb el array gab el method bta3t Clone mnen ??
            //// el Array nafsoh gwah method 2smha Clone
            //// ya3ny Class el Array by implememnt el Interface el 2smoh ICloneable
            //// 3l4an yb2a 3andoh el signature method bta3t el Clone();
            //// like that ==> numbers02 = numbers01.Clone();
            //// bs dah hydrb error l2n el Clone btrag3 Object 
            //// fa lazem 23ml casting 2fahmoh 2n el rag3 dah lazem ykon array of int fa hyb2a kdah 
            //// ==> numbers02 = (int[])numbers01.Clone();
            //// we el Clone bet3ml Copy el hwa bykon 2smoh Shallow Copy 
            //// ya3ny kelmt Copy bs hya hya ma3nha Shallow Copy
            //// tb by3ml Shallow Copy ll Data wla Address ??
            //// l2 Clone bet3ml Shallow Copy ll Data ya3ny 3aml Shallow Copy ll data mn Array numbers01 to numbers02
            //// 2w bem3na 2s7 ben2ol kdah  ==> Make a new Array which is a shallow copy of the original aaray
            //// bs me4 hay5od nafs el address l2 wla hy3ml copy ll address l2 bardo
            //// ma 27na 2olna hwa by3ml new array fa 3l4an kdah hwa hydeloh new address or identity 
            //// ya3ny hy7gzloh mkan gded fe el stack be address gded 8er el 2dem 5als

            //numbers02 = (int[])numbers01.Clone();

            //Console.WriteLine($"After Making Deep Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"Array numbers01 have HashCode or Address in Stack ==> {numbers01.GetHashCode()}");
            //Console.WriteLine($"Array numbers02 have HashCode or Address in Stack ==> {numbers02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of Array numbers01[0] ==> {numbers01[0]}"); // -> o/p = 1
            //Console.WriteLine($"1st Element of Array numbers02[0] ==> {numbers02[0]}"); // -> o/p = 1
            //Console.WriteLine();

            //// we kdah ba3d ma 3malt el Deep Copy 
            //// kdah el array el tany ba2 leh address gded we 3ando nafs el data el fe 2wl array
            //// lakn me4 by4awr 3al nafs el data bta3t array number01 l2 hwa ba2 3anoh nafs el data fe el heap
            //// we by4awr 3aleha be address gded lwa7doh 5lash 
            //// ya3ny el 2 array me4 by4awroh 3al nafs el data fe el heap we dah tabe3y l2n kol wa7d leh address mo5talf
            //// fa 3l4an kdah b2a law get 8ert ay element fe array of number01 me4 hysam3 fe array of numbers02
            //// l2n kol wa7d b2a leh el data el 5asa beh 3al 3aks el Shallow copy el 2tnen lehom nafs el address
            //// fa kano by4awro 3al nafs el mkan fa ay t8er fe wa7d fehom kan bysam3 fe el tany
            //// lakn hena 5als kol wa7d leh address lwa7do we leh el data el 5asa beh 
            //// fa law 8ert fe ay wa7d fehom me4 hysam3 fe el tany
            //// kol wa7d leh access 3al el data bta3oth bs malo4 3elak bel tany 5als 
            //numbers01[0] = 200;
            //Console.WriteLine($"After Making Deep Copy and change 1st elemnt in 1st array :- ");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of Array numbers01[0] ==> {numbers01[0]}"); // -> o/p = 200
            //Console.WriteLine($"1st Element of Array numbers02[0] ==> {numbers02[0]}"); // -> o/p = 1
            //Console.WriteLine();

            #endregion

            #endregion

            #region 6] Shallow Copy Vs Deep Copy - 2

            #region Array of Reference Type [Shallow Copy] --> Immutable type [strings , custom Immutable Types]

            //// => Immutable type mean 8er kabl ll ta3del
            //// => custom Immutable Types mean Class 2enta 3amloh Immutable
            ////    el hwa ha5ly kol el properties bta3toh {get;} we kdah b2a immutable
            ////    2w zabt 2nk te access el data gwa el class 3andk bs we kdah b2a immutable class  

            ///************** Let's Talk about 1st Example Array of Reference Types ***************/

            //// -> Array that is Reference Type and save inside it data with Reference Types

            //// Array of Sting that is Data is Reference Types
            //// we bema 2n el data hya Reference Types ma3na kdah ana me4 4ayel values 
            //// ya3n fe el heap ana me4 4ayl array feh kdah ==> { "Amr", "Mona", "Omar" };
            //// l2 ana 4ayel address kol 2sm fehom 
            //// ma "Amr" dah hwa Reference type ya3ny leh address me4 hyt5azen fe el stack 
            //// l2 dah hyt5azen fe el stack we fe el heap 
            //// fa fe el stack hwa leh identity 2w address hy4awr 3al amr fe el heap 
            //// fa kdah Amr leh reference 2w address 2w idenetity fe el stack hy4awr 3aleh fe el heap
            //// we nafs el 2mr 3al "Mona" we "Omar"
            //// we kdah el names dah hwa bardo Refernce Type ya3ny leh address fe el stack we el data fe el heap
            //// we el address 2w el referenc 2w identity bt3at el Array of Sting name01 fe el stack 
            //// hy4awr 3al data fe el heap we el data deh hatbe2 3al 4akl array 
            //// we kol index feh el address el mokabel ll value bta3toh 
            //// ya3ny 2wl index el hwa 0 feh address bta3 Reference value bta3t amr el hwa wal ykon 123 
            //// we tany index el hwa 1 feh address bta3 Reference value bta3t Mona el hwa wal ykon 456
            //// we talt index el hwa 2 feh address bta3 Reference value bta3t Omar el hwa wal ykon 789
            //// we kdah el address bta3 el names hy4awr fel heap 3al el array dah ==> {123 , 456 , 789}
            //// l2n Amr dah 3obar 3an array of char we Mona dah 3obar 3an array of char we kazalk Omar
            //// fa kol array of char hwa refernce type leh address fe el stack we data fe el heap
            //// fa 3l4an kdah el by5azen ka data ll names01 fe el heap hwa el address bta3 kol aaray of char bta3 kol 2sm
            //// el hwa 4ael reference bta3 amr we reference bta3 mona we hakza ly omar
            //string[] names01 = { "Amr", "Mona", "Omar" };

            ////// 2nd Array have 3 places with default value of string that is null ==> { null, null, null}
            ////// null m3an ==> Empty o/p in Console
            //string[] names02 = new string[3];

            //// 3ayzen ne3rf kol wa7d by4wr fen fe el meomory ya3ny 3ayzen el Address bta3 kol array
            //// we dah hytm mn 5elal el method GetHashCode()
            //// 3l4an 2t2kd 2n fe el 2wl 2bl ma 23ml ay no3 men 2nwa3 el copy 2n kol wa7d fe el 2 Arrays
            //// by4awr 3al mkan 8er el tany fe el memory ya3ny kol wa7d leh address 8er el tany 
            //// 2bl ma 23ml ay Copy
            //Console.WriteLine($"Befor Making Shallow Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"Array names01 have HashCode or Address in Stack ==> {names01.GetHashCode()}");
            //Console.WriteLine($"Array names02 have HashCode or Address in Stack ==> {names02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of Array names01[0] ==> {names01[0]} && HashCode is : {names01[0].GetHashCode()}"); 
            //// -> o/p = Amr
            //Console.WriteLine($"1st Element of Array names02[0] ==> {names02[0]}");
            //// -> o/p = null that is empty in console
            //// we can't make this ==> && HashCode is : {names02[0].GetHashCode()} 
            //// in above cw becuase null don't have any hashcode and will make error and esception
            //Console.WriteLine();

            ////// -> Now let's making Shallow Copy 
            ////// 3an tare2 2ny ha7ot kol array of numbers01 fe el array of numbers02 by using assignment operator [=]
            ////// like That ==> names02 = names01; // ==> this is Shallow Copy
            ////// then Data that inside array of names01 it will be inside array of names02 after make Shallow Copy
            ////// Shallow Copy is Faster than Deep Copy
            ////// we el motwak3 2n el 2 Array 3andohm nafs el Address ya3ny by4awro 3al nafs el mkan fe el memory
            ////// el hwa 3andohm nafs el idenetity fe el stack we 3andohm nafs el data fe el heap
            ////// we kdah law array of names02 kan 3ando data 5las hatde3 l2noh b2a 3andoh el data el gdeda
            ////// el 5adha mn array of names01 lma 3amlt Shallow Copy
            ////// we kdah ay ta8er fe array of names01 fe el data telka2y hysam3 fe el array of names02 bardo
            ////// l2n el 2tnen 3andohm nafs el address fel stack we by4awrod 3al nafs el data el fe el heap
            ////// 3l4an kdah el Shallow Copy ben2ol 3aleh ==> Copy of Identity or Address
            ////// l2n by5aly el 2 Arrays 3andohm nafs el Address 2w nafs el Identity fe el Stack
            ////// lakn ma25dt4 Copy mn el Data l2 ana 25dt copy mn el Address we el Address dah 
            ////// by4awr 3al data fe el heap fa kdah hwa kman hy4awr 3al nafs el data lakn ana ma 25dt4 
            ////// copy mn el data ana 25dt copy mn el address we kdah el 2 Array by4awro 3al nafs el data
            //names02 = names01; // ==> this is Shallow Copy
            //names01[0] = "Basha";
            //// ba3d ma 3amlt el ta8er hwa kdah 3aml array of char ly basha we 2daha adress we mkan fe el heap
            //// we hyro7 y4el el address bta3 amr el kan fe el array bta3 el names fe el heap we hy7ot mkanoh 
            //// el address bta3 array od char bta3 basha we kdah amr dah b2a unreachable data we hytms7 kman 4waya mn el heap
            //Console.WriteLine($"After Making Shallow Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"Array names01 have HashCode or Address in Stack ==> {names01.GetHashCode()}");
            //Console.WriteLine($"Array names02 have HashCode or Address in Stack ==> {names02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of Array names01[0] ==> {names01[0]} && HashCode is : {names01[0].GetHashCode()}");
            //// -> o/p = Basha
            //Console.WriteLine($"1st Element of Array names02[0] ==> {names02[0]} && HashCode is : {names02[0].GetHashCode()}");
            //// -> o/p = Basha
            //Console.WriteLine();

            #endregion

            #region Array of Reference Type [Deep Copy] --> Immutable type [strings , custom Immutable Types]

            //// => Immutable type mean 8er kabl ll ta3del
            //// => custom Immutable Types mean Class 2enta 3amloh Immutable
            ////    el hwa ha5ly kol el properties bta3toh {get;} we kdah b2a immutable
            ////    2w zabt 2nk te access el data gwa el class 3andk bs we kdah b2a immutable class  

            ///************** Let's Talk about 1st Example Array of Reference Types ***************/

            //// -> Array that is Reference Type and save inside it data with Reference Types

            //// Array of Sting that is Data is Reference Types
            //// we bema 2n el data hya Reference Types ma3na kdah ana me4 4ayel values 
            //// ya3n fe el heap ana me4 4ayl array feh kdah ==> { "Amr", "Mona", "Omar" };
            //// l2 ana 4ayel address kol 2sm fehom 
            //// ma "Amr" dah hwa Reference type ya3ny leh address me4 hyt5azen fe el stack 
            //// l2 dah hyt5azen fe el stack we fe el heap 
            //// fa fe el stack hwa leh identity 2w address hy4awr 3al amr fe el heap 
            //// fa kdah Amr leh reference 2w address 2w idenetity fe el stack hy4awr 3aleh fe el heap
            //// we nafs el 2mr 3al "Mona" we "Omar"
            //// we kdah el names dah hwa bardo Refernce Type ya3ny leh address fe el stack we el data fe el heap
            //// we el address 2w el referenc 2w identity bt3at el Array of Sting name01 fe el stack 
            //// hy4awr 3al data fe el heap we el data deh hatbe2 3al 4akl array 
            //// we kol index feh el address el mokabel ll value bta3toh 
            //// ya3ny 2wl index el hwa 0 feh address bta3 Reference value bta3t amr el hwa wal ykon 123 
            //// we tany index el hwa 1 feh address bta3 Reference value bta3t Mona el hwa wal ykon 456
            //// we talt index el hwa 2 feh address bta3 Reference value bta3t Omar el hwa wal ykon 789
            //// we kdah el address bta3 el names hy4awr fel heap 3al el array dah ==> {123 , 456 , 789}
            //// l2n Amr dah 3obar 3an array of char we Mona dah 3obar 3an array of char we kazalk Omar
            //// fa kol array of char hwa refernce type leh address fe el stack we data fe el heap
            //// fa 3l4an kdah el by5azen ka data ll names01 fe el heap hwa el address bta3 kol aaray of char bta3 kol 2sm
            //// el hwa 4ael reference bta3 amr we reference bta3 mona we hakza ly omar
            //string[] names01 = { "Amr", "Mona", "Omar" };

            ////// 2nd Array have 3 places with default value of string that is null ==> { null, null, null}
            ////// null m3an ==> Empty o/p in Console
            //string[] names02 = new string[3];

            //// 3ayzen ne3rf kol wa7d by4wr fen fe el meomory ya3ny 3ayzen el Address bta3 kol array
            //// we dah hytm mn 5elal el method GetHashCode()
            //// 3l4an 2t2kd 2n fe el 2wl 2bl ma 23ml ay no3 men 2nwa3 el copy 2n kol wa7d fe el 2 Arrays
            //// by4awr 3al mkan 8er el tany fe el memory ya3ny kol wa7d leh address 8er el tany 
            //// 2bl ma 23ml ay Copy
            //Console.WriteLine($"Befor Making Deep Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"Array names01 have HashCode or Address in Stack ==> {names01.GetHashCode()}");
            //Console.WriteLine($"Array names02 have HashCode or Address in Stack ==> {names02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of Array names01[0] ==> {names01[0]} && HashCode is : {names01[0].GetHashCode()}");
            //// -> o/p = Amr
            //Console.WriteLine($"1st Element of Array names02[0] ==> {names02[0]}");
            //// -> o/p = null that is empty in console
            //// we can't make this ==> && HashCode is : {names02[0].GetHashCode()} 
            //// in above cw becuase null don't have any hashcode and will make error and esception
            //Console.WriteLine();

            ////// -> Now let's making Deep Copy
            ////// 3an tare2 2ny ha7ot kol array of names01 fe el array of names02 by using assignment operator [=]
            ////// we bast5dm ma3hom method Called ==> [Clone] 
            ////// el Method deh mawgoda fe Interface 2smoh ==> ICloneable
            ////// ba7ot el Clone ma3 el Array el ha5od menoh el data we ha7otha fe elArray el Tany
            ////// ya3ny ha3ml Clone ma3 Array of names01
            ////// tb el array gab el method bta3t Clone mnen ??
            ////// el Array nafsoh gwah method 2smha Clone
            ////// ya3ny Class el Array by implememnt el Interface el 2smoh ICloneable
            ////// 3l4an yb2a 3andoh el signature method bta3t el Clone();
            ////// like that ==> names02 = names01.Clone();
            ////// bs dah hydrb error l2n el Clone btrag3 Object 
            ////// fa lazem 23ml casting 2fahmoh 2n el rag3 dah lazem ykon array of string fa hyb2a kdah 
            ////// ==> names02 = (string[])names01.Clone();
            ////// we el Clone bet3ml Copy el hwa bykon 2smoh Shallow Copy 
            ////// ya3ny kelmt Copy bs hya hya ma3nha Shallow Copy
            ////// tb by3ml Shallow Copy ll Data wla Address ??
            ////// l2 Clone bet3ml Shallow Copy ll Data ya3ny 3aml Shallow Copy ll data mn Array names01 to names02
            ////// 2w bem3na 2s7 ben2ol kdah  ==> Make a new Array which is a shallow copy of the original aaray
            ////// bs me4 hay5od nafs el address l2 wla hy3ml copy ll address l2 bardo
            ////// ma 27na 2olna hwa by3ml new array fa 3l4an kdah hwa hydeloh new address or identity 
            ////// ya3ny hy7gzloh mkan gded fe el stack be address gded 8er el 2dem 5als
            //names02 = (string[])names01.Clone();

            //Console.WriteLine($"After Making Deep Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"Array names01 have HashCode or Address in Stack ==> {names01.GetHashCode()}");
            //Console.WriteLine($"Array names02 have HashCode or Address in Stack ==> {names02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of Array names01[0] ==> {names01[0]} && HashCode is : {names01[0].GetHashCode()}");
            //// -> o/p = Amr
            //Console.WriteLine($"1st Element of Array names02[0] ==> {names02[0]} && HashCode is : {names02[0].GetHashCode()}");
            //// -> o/p = Amr
            //Console.WriteLine();

            ////// we kdah ba3d ma 3malt el Deep Copy 
            ////// kdah el array el tany ba2 leh address gded we 3ando nafs el data el fe 2wl array
            ////// lakn me4 by4awr 3al nafs el data bta3t array names01 l2 hwa ba2 3anoh nafs el data fe el heap
            ////// we by4awr 3aleha be address gded lwa7doh 5lash 
            ////// ya3ny el 2 array me4 by4awroh 3al nafs el data fe el heap we dah tabe3y l2n kol wa7d leh address mo5talf
            ////// fa 3l4an kdah b2a law get 8ert ay element fe array of names01 me4 hysam3 fe array of names02
            ////// l2n kol wa7d b2a leh el data el 5asa beh 3al 3aks el Shallow copy el 2tnen lehom nafs el address
            ////// fa kano by4awro 3al nafs el mkan fa ay t8er fe wa7d fehom kan bysam3 fe el tany
            ////// lakn hena 5als kol wa7d leh address lwa7do we leh el data el 5asa beh 
            ////// fa law 8ert fe ay wa7d fehom me4 hysam3 fe el tany
            ////// kol wa7d leh access 3al el data bta3oth bs malo4 3elak bel tany 5als 
            //names01[0] = "Basha";

            //Console.WriteLine($"After Making Deep Copy and change 1st elemnt in 1st array :- ");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of Array names01[0] ==> {names01[0]} && HashCode is : {names01[0].GetHashCode()}");
            //// -> o / p = Basha
            //Console.WriteLine($"1st Element of Array names02[0] ==> {names02[0]} && HashCode is : {names02[0].GetHashCode()}");
            //// -> o / p = Basha
            //Console.WriteLine();

            #endregion

            #endregion

            #region 7] Shallow Copy Vs Deep Copy - 3

            #region Array of Reference Type [Shallow Copy] --> Mutable type [stringbuilder , list , Custom mutable type]

            // => stringbuilder -> lma kont ba3oz 2zwad 3al el 2sm bta3y kan byro7 yzawdoh fe nafs el address
            // => Custom mutable type -> Class 2enta 3amloh Mutable
            //    ha3ml class we gwah el properties 3andh {get; set;} we kdah b2a Mutable
            //    ya3ny bey2dr te access el data we te assign data we kdah b2a Mutable Class

            /************** Let's Talk about 1st Example Array of Reference Types ***************/

            // -> Array that is Reference Type and save inside it data with Reference Types

            // -> Array of StringBuilder that is Data is Reference Types

            //StringBuilder[] arr01 = new StringBuilder[3];

            //// lets set data in Array of StringBuilder

            ////arr01[0] = "Maraiam"; // ==> this in Invalid becuase this is StringBuilder not normal string
            //arr01[0].Append("Marima");
            //Console.WriteLine(arr01[0]);
            //// law 3amlt Run hydrab Exception tb leh ?
            //// 2alk 2enta bet7awl te3ml eh anta bet7awl t7ot el data fe mkan feh null
            //// tb azay ma ana 3aml new fo2 2hoh ==>StringBuilder[] arr01 = new StringBuilder[3];
            //// l2 anta ma3mtl4 el new 
            //// el anta 3amltoh dah ma 2smo4 2nk 7atet el data bta3tk
            //// anta kdah bt2oly 2nk 3andk 2makn be null we 3ayez t7ot gwaha el data 
            //// ana ma3mlt4 initialize 
            //// tb azay ma ana kont ba3ml nafs el klam 3al el string el 3ady we 4a8al 
            //// ah kona ben3ml nafs el klam 3al el string bs me4 bel tare2a deh 
            //// kona ben3ml kdah ==>
            //string[]arr02 = new string[3];
            //arr02[0] = "Mariam"; //==> dah syntax sugar dah 7al 2sra3 badl ma 23ml el gay dah ==>
            //arr02[1] = new string("Ahmed"); // dah el kan by7sl we y7gzlk mkan we y7otlk feh el data bt3atk 
            //// dah el internaly by7sl lakn fo2 fe el stringbuilder anta maro7t4 3arft el mkan 2sln
            //// ana kdah ba7awl 27ot fe null we dah 8alt
            //// fa el stringbuilder ma3ndo4 el syntax sugar dah 

            //// 3andena kaza tare2 hya el hatm4y ma3 el stringbuilder ==>

            //// ==> 1st way to initialize StringBuilder
            //// kdah 3arft el 2makn bta3t el stringbuilder we delw2ty 2ro7 23ml append ll data 3ady hy4ta8l
            //for (int i = 0;i < arr01.Length;i++)
            //{
            //    arr01[i] = new StringBuilder(); // ==> 1st way to initialize StringBuilder
            //}
            // fa law ro7t 3amlt kdah hy4ta8l 3ady l2n 3arft el 2makn 5las we me4 be null we wla ba7ot fe null
            // l2 ana ba7ot fe 2makn m3rafha be nafsy fe el for loop fo2 ==>
            //arr01[0].Append("Marima");
            //Console.WriteLine(arr01[0]);

            //// ==> 2nd way to initialize StringBuilder
            //// hwa 2ny ha3rf kol index el 2wl we ba3den 23ml append ll data kdah ==>
            //arr01[0] = new StringBuilder();
            //arr01[0].Append("Ahmed");
            //Console.WriteLine(arr01[0]);
            //arr01[1] = new StringBuilder();
            //arr01[1].Append("Basha");
            //Console.WriteLine(arr01[1]);

            //// ==> 3rd way to initialize StringBuilder
            //// hast5dm el Constructor el by5od mny el data 3altol kdah ==>
            //arr01[0] = new StringBuilder("Amr");
            //Console.WriteLine(arr01[0]);

            //// ==> 4th way to initialize StringBuilder
            //// deh 2smha Collection Expression we deh ba3mlha we ana ba3ml create ll Array of SrtingBuilder
            //StringBuilder[] arr02 = [new StringBuilder("Mona") , new StringBuilder("Omar") , new StringBuilder("Masr")];

            /************************ let's make Shallow Copy of StringBuilder **************************/

            //// Array of Sting that is Data is Reference Types
            //// we bema 2n el data hya Reference Types ma3na kdah ana me4 4ayel values 
            //// ya3n fe el heap ana me4 4ayl array feh kdah ==> { "Amr", "Mona", "Omar" };
            //// l2 ana 4ayel address kol 2sm fehom 
            //// ma "Amr" dah hwa Reference type ya3ny leh address me4 hyt5azen fe el stack 
            //// l2 dah hyt5azen fe el stack we fe el heap 
            //// fa fe el stack hwa leh identity 2w address hy4awr 3al amr fe el heap 
            //// fa kdah Amr leh reference 2w address 2w idenetity fe el stack hy4awr 3aleh fe el heap
            //// we nafs el 2mr 3al "Mona" we "Omar"
            //// we kdah el names dah hwa bardo Refernce Type ya3ny leh address fe el stack we el data fe el heap
            //// we el address 2w el referenc 2w identity bt3at el Array of Sting arr01 fe el stack 
            //// hy4awr 3al data fe el heap we el data deh hatbe2 3al 4akl array 
            //// we kol index feh el address el mokabel ll value bta3toh 
            //// ya3ny 2wl index el hwa 0 feh address bta3 Reference value bta3t amr el hwa wal ykon 123 
            //// we tany index el hwa 1 feh address bta3 Reference value bta3t Mona el hwa wal ykon 456
            //// we talt index el hwa 2 feh address bta3 Reference value bta3t Omar el hwa wal ykon 789
            //// we kdah el address bta3 el names hy4awr fel heap 3al el array dah ==> {123 , 456 , 789}
            //// l2n Amr dah 3obar 3an array of char we Mona dah 3obar 3an array of char we kazalk Omar
            //// fa kol array of char hwa refernce type leh address fe el stack we data fe el heap
            //// fa 3l4an kdah el by5azen ka data ll names01 fe el heap hwa el address bta3 kol aaray of char bta3 kol 2sm
            //// el hwa 4ael reference bta3 amr we reference bta3 mona we hakza ly omar

            //StringBuilder[] arr01 = [new StringBuilder("Mona"), new StringBuilder("Omar"), new StringBuilder("Masr")];
            //StringBuilder[] arr02 = new StringBuilder[3];

            //// 3ayzen ne3rf kol wa7d by4wr fen fe el meomory ya3ny 3ayzen el Address bta3 kol array
            //// we dah hytm mn 5elal el method GetHashCode()
            //// 3l4an 2t2kd 2n fe el 2wl 2bl ma 23ml ay no3 men 2nwa3 el copy 2n kol wa7d fe el 2 Arrays
            //// by4awr 3al mkan 8er el tany fe el memory ya3ny kol wa7d leh address 8er el tany 
            //// 2bl ma 23ml ay Copy
            //Console.WriteLine($"Befor Making Shallow Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"StringBuilder Array arr01 have HashCode or Address in Stack ==> {arr01.GetHashCode()}");
            //Console.WriteLine($"StringBuilder Array arr02 have HashCode or Address in Stack ==> {arr02.GetHashCode()}");
            //Console.WriteLine();

            ////// -> Now let's making Shallow Copy 
            ////// 3an tare2 2ny ha7ot kol array of numbers01 fe el array of numbers02 by using assignment operator [=]
            ////// like That ==> arr02 = arr01; // ==> this is Shallow Copy
            ////// then Data that inside array of arr01 it will be inside array of arr02 after make Shallow Copy
            ////// Shallow Copy is Faster than Deep Copy
            ////// we el motwak3 2n el 2 Array 3andohm nafs el Address ya3ny by4awro 3al nafs el mkan fe el memory
            ////// el hwa 3andohm nafs el idenetity fe el stack we 3andohm nafs el data fe el heap
            ////// we kdah law array of arr02 kan 3ando data 5las hatde3 l2noh b2a 3andoh el data el gdeda
            ////// el 5adha mn array of arr01 lma 3amlt Shallow Copy
            ////// we kdah ay ta8er fe array of arr01 fe el data telka2y hysam3 fe el array of arr02 bardo
            ////// l2n el 2tnen 3andohm nafs el address fel stack we by4awrod 3al nafs el data el fe el heap
            ////// 3l4an kdah el Shallow Copy ben2ol 3aleh ==> Copy of Identity or Address
            ////// l2n by5aly el 2 Arrays 3andohm nafs el Address 2w nafs el Identity fe el Stack
            ////// lakn ma25dt4 Copy mn el Data l2 ana 25dt copy mn el Address we el Address dah 
            ////// by4awr 3al data fe el heap fa kdah hwa kman hy4awr 3al nafs el data lakn ana ma 25dt4 
            ////// copy mn el data ana 25dt copy mn el address we kdah el 2 Array by4awro 3al nafs el data
            //arr02 = arr01; // ==> this is Shallow Copy

            //Console.WriteLine($"After Making Shallow Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"StringBuilder Array arr01 have HashCode or Address in Stack ==> {arr01.GetHashCode()}");
            //Console.WriteLine($"StringBuilder Array arr02 have HashCode or Address in Stack ==> {arr02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of SrtingBuilder Array arr01[0] ==> {arr01[0]} && HashCode is : {arr01[0].GetHashCode()}");
            //// -> o/p = Mona
            //Console.WriteLine($"1st Element of SrtingBuilder Array arr02[0] ==> {arr02[0]} && HashCode is : {arr02[0].GetHashCode()}");
            //// -> o/p = Mona
            //Console.WriteLine();

            //arr01[0].Append(" Ahmed");
            //// ba3d ma 3amlt el ta8er hwa kdah 3aml array of char ly Ahmed we 2daha nafs el address 
            //// we nafs el mkan fe el heap we hydef Ahmed 3al Mona fe Nafs el address fe nafs el mkan fe el heap 
            //// we kdah 2wl mkan hyb2a feh ==> Mona Ahmed ==> benafs el address bta3 Mona el 2dem
            //// l2n el StringBuilder me4 by5aly fe 2makn unreachable l2a hwa by3ml nafs el 3amlya
            //// 3al nafs el address b7yes ma y3ml4 2makn kter 3al el fady we teb2a unreachable 
            //// fa deh mezt el stringbuilder 3an el string el 3ady 
            //// fa law la7zt el hashcode bta3 2wl index el hwa mona 2bl el ta8er we ba3d el ta8er 
            //// hatla2eho hwa hwa nafs el makn we nafs el address hwa mogard hydef bs ahmed 3al nafs el mkan
            //// l2n el StringBuilder hwa Mutable hy3adl fe nafs el mkan 


            //Console.WriteLine($"After Making Shallow Copy and Change 1st Element :- ");
            //Console.WriteLine();
            //Console.WriteLine($"StringBuilder Array arr01 have HashCode or Address in Stack ==> {arr01.GetHashCode()}");
            //Console.WriteLine($"StringBuilder Array arr02 have HashCode or Address in Stack ==> {arr02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of SrtingBuilder Array arr01[0] ==> {arr01[0]} && HashCode is : {arr01[0].GetHashCode()}");
            //// -> o/p = Mona Ahmed
            //Console.WriteLine($"1st Element of SrtingBuilder Array arr02[0] ==> {arr02[0]} && HashCode is : {arr02[0].GetHashCode()}");
            //// -> o/p = Mona Ahmed
            //Console.WriteLine();
            #endregion

            #region Array of Reference Type [Deep Copy] --> Mutable type [stringbuilder , list , Custom mutable type]

            // => stringbuilder -> lma kont ba3oz 2zwad 3al el 2sm bta3y kan byro7 yzawdoh fe nafs el address
            // => Custom mutable type -> Class 2enta 3amloh Mutable
            //    ha3ml class we gwah el properties 3andh {get; set;} we kdah b2a Mutable
            //    ya3ny bey2dr te access el data we te assign data we kdah b2a Mutable Class

            //// Array of Sting that is Data is Reference Types
            //// we bema 2n el data hya Reference Types ma3na kdah ana me4 4ayel values 
            //// ya3n fe el heap ana me4 4ayl array feh kdah ==> { "Amr", "Mona", "Omar" };
            //// l2 ana 4ayel address kol 2sm fehom 
            //// ma "Amr" dah hwa Reference type ya3ny leh address me4 hyt5azen fe el stack 
            //// l2 dah hyt5azen fe el stack we fe el heap 
            //// fa fe el stack hwa leh identity 2w address hy4awr 3al amr fe el heap 
            //// fa kdah Amr leh reference 2w address 2w idenetity fe el stack hy4awr 3aleh fe el heap
            //// we nafs el 2mr 3al "Mona" we "Omar"
            //// we kdah el names dah hwa bardo Refernce Type ya3ny leh address fe el stack we el data fe el heap
            //// we el address 2w el referenc 2w identity bt3at el Array of Sting arr01 fe el stack 
            //// hy4awr 3al data fe el heap we el data deh hatbe2 3al 4akl array 
            //// we kol index feh el address el mokabel ll value bta3toh 
            //// ya3ny 2wl index el hwa 0 feh address bta3 Reference value bta3t amr el hwa wal ykon 123 
            //// we tany index el hwa 1 feh address bta3 Reference value bta3t Mona el hwa wal ykon 456
            //// we talt index el hwa 2 feh address bta3 Reference value bta3t Omar el hwa wal ykon 789
            //// we kdah el address bta3 el names hy4awr fel heap 3al el array dah ==> {123 , 456 , 789}
            //// l2n Amr dah 3obar 3an array of char we Mona dah 3obar 3an array of char we kazalk Omar
            //// fa kol array of char hwa refernce type leh address fe el stack we data fe el heap
            //// fa 3l4an kdah el by5azen ka data ll names01 fe el heap hwa el address bta3 kol aaray of char bta3 kol 2sm
            //// el hwa 4ael reference bta3 amr we reference bta3 mona we hakza ly omar

            //StringBuilder[] arr01 = [new StringBuilder("Mona"), new StringBuilder("Omar"), new StringBuilder("Masr")];
            //StringBuilder[] arr02 = new StringBuilder[3];

            //// 3ayzen ne3rf kol wa7d by4wr fen fe el meomory ya3ny 3ayzen el Address bta3 kol array
            //// we dah hytm mn 5elal el method GetHashCode()
            //// 3l4an 2t2kd 2n fe el 2wl 2bl ma 23ml ay no3 men 2nwa3 el copy 2n kol wa7d fe el 2 Arrays
            //// by4awr 3al mkan 8er el tany fe el memory ya3ny kol wa7d leh address 8er el tany 
            //// 2bl ma 23ml ay Copy
            //Console.WriteLine($"Befor Making Deep Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"StringBuilder Array arr01 have HashCode or Address in Stack ==> {arr01.GetHashCode()}");
            //Console.WriteLine($"StringBuilder Array arr02 have HashCode or Address in Stack ==> {arr02.GetHashCode()}");
            //Console.WriteLine();

            ////// -> Now let's making Deep Copy
            ////// 3an tare2 2ny ha7ot kol StringBuilder array of arr01 fe el StringBuilder array of arr02
            ////// by using assignment operator [=]
            ////// we bast5dm ma3hom method Called ==> [Clone] 
            ////// el Method deh mawgoda fe Interface 2smoh ==> ICloneable
            ////// ba7ot el Clone ma3 el Array el ha5od menoh el data we ha7otha fe elArray el Tany
            ////// ya3ny ha3ml Clone ma3 Array of arr01
            ////// tb el array gab el method bta3t Clone mnen ??
            ////// el Array nafsoh gwah method 2smha Clone
            ////// ya3ny Class el Array by implememnt el Interface el 2smoh ICloneable
            ////// 3l4an yb2a 3andoh el signature method bta3t el Clone();
            ////// like that ==> arr02 = arr01.Clone();
            ////// bs dah hydrb error l2n el Clone btrag3 Object 
            ////// fa lazem 23ml casting 2fahmoh 2n el rag3 dah lazem ykon array of string fa hyb2a kdah 
            ////// ==> arr02 = (StringBuilder[])arr02.Clone();
            ////// we el Clone bet3ml Copy el hwa bykon 2smoh Shallow Copy 
            ////// ya3ny kelmt Copy bs hya hya ma3nha Shallow Copy
            ////// tb by3ml Shallow Copy ll Data wla Address ??
            ////// l2 Clone bet3ml Shallow Copy ll Data ya3ny 3aml Shallow Copy ll data mn Array arr01 to arr02
            ////// 2w bem3na 2s7 ben2ol kdah  ==> Make a new Array which is a shallow copy of the original array
            ////// bs me4 hay5od nafs el address l2 wla hy3ml copy ll address l2 bardo
            ////// ma 27na 2olna hwa by3ml new array fa 3l4an kdah hwa hydeloh new address or identity 
            ////// ya3ny hy7gzloh mkan gded fe el stack be address gded 8er el 2dem 5als
            //arr02 = (StringBuilder[])arr01.Clone();

            //Console.WriteLine($"After Making Deep Copy :- ");
            //Console.WriteLine();
            //Console.WriteLine($"StringBuilder Array arr01 have HashCode or Address in Stack ==> {arr01.GetHashCode()}");
            //Console.WriteLine($"StringBuilder Array arr02 have HashCode or Address in Stack ==> {arr02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of SrtingBuilder Array arr01[0] ==> {arr01[0]} && HashCode is : {arr01[0].GetHashCode()}");
            //// -> o/p = Mona
            //Console.WriteLine($"1st Element of SrtingBuilder Array arr02[0] ==> {arr02[0]} && HashCode is : {arr02[0].GetHashCode()}");
            //// -> o/p = Mona
            //Console.WriteLine();


            //arr01[0].Append(" Ahmed");
            //// we kdah ba3d ma 3malt el Deep Copy 
            //// kdah el StringBuilder array el tany ba2 leh address gded we 3ando nafs el data el fe 2wl StringBuilder array
            //// lakn me4 by4awr 3al nafs el data bta3t array arr01 l2 hwa ba2 3anoh nafs el data fe el heap
            //// we by4awr 3aleha be address gded lwa7doh 5lash 
            //// ya3ny el 2 array me4 by4awroh 3al nafs el data fe el heap we dah tabe3y l2n kol wa7d leh address mo5talf
            //// fa 3l4an kdah b2a law get 8ert ay element fe array of arr01  hysam3 fe array of arr02
            //// hysam3 !!! azay ??
            //// l2n fe el stringBuilder hwa me4 by8er el address lma badef 2w 24el fe nafs el index
            //// hwa nafs el address zay ma hwa me4 hy8eroh 
            //// fa 3l4an kdah lma hadef Ahmed hal2eh sam3 fe el 2 StringBuilder we b2a 3andy
            //// el o/p hykon Mona Ahmed l2n el 2 StringBuilder fe 2wl index 0 by4wro 3al el mkan el feh
            //// Mona we dah el mkan el hadef feh Ahmed ya3ny nafs el address fa tabe3y hysam3 fe el 2 StringBuilder
            //// l2n el Stringbuilder hwa mutable type ya3ny by8er we ya3dl fe nafs el mkan fe nafs el address

            //// we Kdah uo3tabr fe el StingBuilder el Deep Copy hwa hwa el Shallow Copy
            //// bs el far2 2n tany Stringbuilder byb2a leh address gded fe el Deep Copy bs
            //// lakn homa nafs el behaviour belzabt

            //// law 3ayez b2a te3ml mafhom el DeEp Copy fe el StringBuilder 2w ay Mutable Type
            //// lazem te3ml el Deep Copy Manually we dah sa3b 

            //// ba3d ma 3amlt el ta8er hwa kdah 3aml array of char ly Ahmed we 2daha nafs el address 
            //// we nafs el mkan fe el heap we hydef Ahmed 3al Mona fe Nafs el address fe nafs el mkan fe el heap 
            //// we kdah 2wl mkan hyb2a feh ==> Mona Ahmed ==> benafs el address bta3 Mona el 2dem
            //// l2n el StringBuilder me4 by5aly fe 2makn unreachable l2a hwa by3ml nafs el 3amlya
            //// 3al nafs el address b7yes ma y3ml4 2makn kter 3al el fady we teb2a unreachable 
            //// fa deh mezt el stringbuilder 3an el string el 3ady 
            //// fa law la7zt el hashcode bta3 2wl index el hwa mona 2bl el ta8er we ba3d el ta8er 
            //// hatla2eho hwa hwa nafs el makn we nafs el address hwa mogard hydef bs ahmed 3al nafs el mkan
            //// l2n el StringBuilder hwa Mutable hy3adl fe nafs el mkan 


            //Console.WriteLine($"After Making Shallow Copy and Change 1st Element :- ");
            //Console.WriteLine();
            //Console.WriteLine($"StringBuilder Array arr01 have HashCode or Address in Stack ==> {arr01.GetHashCode()}");
            //Console.WriteLine($"StringBuilder Array arr02 have HashCode or Address in Stack ==> {arr02.GetHashCode()}");
            //Console.WriteLine();
            //Console.WriteLine($"1st Element of SrtingBuilder Array arr01[0] ==> {arr01[0]} && HashCode is : {arr01[0].GetHashCode()}");
            //// -> o/p = Mona Ahmed
            //Console.WriteLine($"1st Element of SrtingBuilder Array arr02[0] ==> {arr02[0]} && HashCode is : {arr02[0].GetHashCode()}");
            //// -> o/p = Mona
            //Console.WriteLine();

            #endregion

            #endregion

            #region 8] Built - in - Interfaces
            #endregion

            #region 9] IClonable [Employee]

            // 3l4an nebd2 negarb el built-in-interface ==> [IClonable]
            // lazem yb2a 3andy user defined datatype a22dr a2tb2a 3aleh el interface we 2st5dm el 
            // method el gwah el hya ==>[Clone()]
            // we 3l4an 2t3aml m3ah ha3ml meno reference we instance 



            /********************************** Shollow Copy **************************************/


            //// el 3aml el Parameterless Constructor hwa el Compiler me4 ana 
            //Employee employee1 = new Employee();

            //// tb law 3ayez 23rfoh ha3ml best5dam el object initializer 
            //Employee employee1 = new Employee() { Id = 10 , Name = "Mariam" , Salary = 1000};

            //// haro7 23ml emplyee2 we dah hykon reference bs kdah
            //// we kdah el stack 7agz 4 bytes ll reference dah or identity bta3y  
            //Employee employee2;

            //// ba3d kdah 3ayez 2sawy el 2 Employess be ba3d kdah ==>
            //// we kdah 3amlna Shallow Copy ya3ny ay ta3del fe wa7d fehom hysam3 fe el tany
            //employee2 = employee1;  //==> Shallow Copy

            //Console.WriteLine($"{employee1.Name}");
            //Console.WriteLine($"{employee2.Name}");
            //Console.WriteLine();

            //// law 3amlna b2a change fe employee1 fe ay data fehom hysam3 fe el employee2 bardo 3altol
            //// la2n ana ka employee2 wa5d nos5a menk 2w bema3na 2sa7 me4awr 3al nafs el data el anta y
            //// employee1 bet4awr 3aleha fa ay ta8er fya 2w fek hansm3 fe ba3d l2nena ben4awr 3al nafs
            //// el mkan el met5azen feh el data l2nena 3amlen ==> Shallow Copy
            //employee1.Name = "Ahmed";
            //Console.WriteLine("After change Name");
            //Console.WriteLine();
            //Console.WriteLine($"{employee1.Name}");
            //Console.WriteLine($"{employee2.Name}");
            //Console.WriteLine();

            //// we bema 2enena 3amlen Shallow Copy yb2a 27ena el 2 employess 3andena nafs el HashCode
            //// nafs el identity
            //Console.WriteLine($"{employee1.GetHashCode()}");
            //Console.WriteLine($"{employee2.GetHashCode()}");
            //Console.WriteLine();



            /********************************** Deep Copy **************************************/

            //// 27na fo2 3amln el Shallow Copy 3ayzen b2a ne3ml hena el Deep Copy

            //Employee employee1 = new Employee() { Id = 10, Name = "Mariam", Salary = 1000 };

            //// haro7 23ml emplyee2 we dah hykon reference bs kdah
            //// we kdah el stack 7agz 4 bytes ll reference dah or identity bta3y 
            //Employee employee2;

            //// we 3l4an ne3ml el Deep Copy baro7 2st5dm el method el hya ==> [Clone()]
            //// bs hal2y 2n me4 la2y 2sln el method el [Clone()] deh wla lya 3aleha access
            //// l2n 2sln hal 2enta el Class bat3 el Employee 2sln by implement el interface el hwa
            //// [IClonable] el gwah el Signature bta3 el method el [Clone()] l2a dah me4 7asl
            //// el Class el Employee me4 by implement el interface dah 
            //// fa kdah male4 access 3al el Method deh we hyfdl darb error
            //// 2bl kdah fo2 Kan Class el Array we el String we el StringBuilder
            //// men gwahom 3amlen Implement ll interface ==> [IClonable]
            //// el gwah el signature bta3 method ==> [Clone()] 
            //// fa kont a2dr a23ml access 3aleha we st5dhma lakn 
            //// el Employee dah user defined datatype gded me4 3aml implememnt ll interface ==> [IClonable]
            //// fa 3l4an el method el [Clone()] te4ta8l we 23ml el ==> Deep Copy
            //// haro7 gwa Class el Employee 23ml Implement ll interface el ==> [ICLonable]

            //employee2 = (Employee)employee1.Clone();

            //Console.WriteLine($"{employee1.Name}");
            //Console.WriteLine($"{employee2.Name}");
            //Console.WriteLine();


            //// law 3amlna b2a change fe employee1 fe ay data fehom me4 hysam3 fe el employee2
            //// la2n ana ka employee2 wa5d nos5a men el data ah bs fe mkan gded fe el heap 
            //// be reference or identity or address gded fa ana ka employee2 ba2 3andy data 5asa bya
            //// we anta ka employee1 3andk el data el 5asa bek 
            //// fa ay 7ad 8er fe 7aga hatsm3 3andoh bs me4 hatsm3 3and el tany 5las 
            //// l2n 3amlna Deep Copy fa ba2 kol wa7d leh address 8er el tany by4awr beh 3al el data bta3toh
            //// ya3ny el 2 employee's me4 3andohm nafs el address me4 nafs el HashCode

            //employee1.Name = "Ahmed";
            //Console.WriteLine("After change Name");
            //Console.WriteLine();
            //Console.WriteLine($"{employee1.Name}");
            //Console.WriteLine($"{employee2.Name}");
            //Console.WriteLine();

            //// we bema 2enena 3amlen Deep Copy yb2a 27ena el 2 employess me4 3andena nafs el HashCode
            //// me4 nafs el identity
            //Console.WriteLine($"{employee1.GetHashCode()}");
            //Console.WriteLine($"{employee2.GetHashCode()}");
            //Console.WriteLine();


            /********************************** Copy Constructor ***********************************/

            //// fe b2a tare2 2shl mn el Clone deh bet3ml nafs el Deep Copy el hya ==>[Copy Constructor]
            //// hwa leh 2st5dam wa7d me4 ben5org 3anoh 2enta law 3ayez to5rg 3anoh bera7tk 
            //// bs 2st5damoh el wa7ed we el 4a23 hwa 2ny ==> [ ba Copy el Data fe el Reference Types ]
            //// law ana 3ayez 23ml el Deep Copy
            //// Tb by3ml eh el Copy Constructor dah ??
            //// dah by5od menk el Employee el 2wl el Employee el 3ayez te copy menoh el data
            //// we ybd2a y3melk el instance el anta 3ayezha 
            //// tb azay ??
            //// me4 2sln el Constructor mas2ol 2enoh y3arflk el fileds bat3tk tb ma ana ha3mlk el kdlam dah 
            //// hanro7 gwa el Class el Employee ne3ml el Constructor 


            //Employee employee1 = new Employee() { Id = 10, Name = "Mariam", Salary = 1000 };

            //// haro7 23ml employee2 we dah hykon reference bs ana 3ayez 24ta8l bel ==> [Copy Constructor]
            //// fa lazem 25ly el reference dah y4awr 3al instance mn el Employee
            //// we ysta5dm el Copy Constructor el ana 3amltoh 
            //// we hab3tlk el Employee el ana 3ayez 25od menoh Copy el hwa ==> employee1
            //// we kdah 5las ana yo3tabr 25dt nos5a mn employee1 ba2et fe employee2
            //// we bema 2eny wa5d copy best5dm el Constructor 
            //// we kol wa7d mest5d ma3h new be7es y3ml Reference gded ya4r 3al el data bat3toh
            //// ya3ny employee1 dah referece by4awr 3al el data bta3toh 
            //// we employee2 dah hwa reference gded malo4 3elka be el reference bta3 employee1
            //// bs el 2tnene 3andohm nafs el data 
            //// bs kol wa7d leh el reference beta3oh el hy4awr 3aleh 
            //// l2n el Copy Constructor dah hwa hwa Deep Copy
            //// fa law 3amlt ta8er fe ay wa7d hysm3 fe na7yetoh bs malo4 3elka bel tany
            //Employee employee2 = new Employee(employee1);


            //Console.WriteLine($"{employee1.Name}");
            //Console.WriteLine($"{employee2.Name}");
            //Console.WriteLine();


            //// law 3amlna b2a change fe employee1 fe ay data fehom me4 hysam3 fe el employee2
            //// la2n ana ka employee2 wa5d nos5a men el data ah bs fe mkan gded fe el heap 
            //// be reference or identity or address gded fa ana ka employee2 ba2 3andy data 5asa bya
            //// we anta ka employee1 3andk el data el 5asa bek 
            //// fa ay 7ad 8er fe 7aga hatsm3 3andoh bs me4 hatsm3 3and el tany 5las 
            //// l2n 3amlna Deep Copy best5dam el [Copy Constructor]
            //// fa ba2 kol wa7d leh address 8er el tany by4awr beh 3al el data bta3toh
            //// ya3ny el 2 employee's me4 3andohm nafs el address me4 nafs el HashCode

            //employee1.Name = "Ahmed";
            //Console.WriteLine("After change Name");
            //Console.WriteLine();
            //Console.WriteLine($"{employee1.Name}");
            //Console.WriteLine($"{employee2.Name}");
            //Console.WriteLine();

            //// we bema 2enena 3amlen Deep Copy best5dam [Copy Constructor]
            //// yb2a 27ena el 2 employess me4 3andena nafs el HashCode
            //// me4 nafs el identity
            //Console.WriteLine($"{employee1.GetHashCode()}");
            //Console.WriteLine($"{employee2.GetHashCode()}");
            //Console.WriteLine();

            //// to test Cases null 

            //Employee employee3 = default;
            //Employee employee4 = new Employee(employee3);

            //Console.WriteLine("******************");
            //Console.WriteLine($"{employee3.Id}");
            //Console.WriteLine($"{employee4.Id}");
            //Console.WriteLine("******************");
            //Console.WriteLine();

            #endregion

            #region 10] , 11] IComparable [Employee[]] and I Comparer [Employee[]]

            #region IComparable
            //// dah metf2en 2noh mas2ol 3an 3amlyet el Sort l7ad delw2ty

            //// han create Array of Employees l2n law 3amlt Create le Array of Integer el behaviour 
            //// bta3 el Comparable 2w el Sort ya3ny hy4ta8l 3ady l2n el Array of Int el struct 2w Class el 
            //// int 3aml mn gwah implememnt ll Interface [IComparable] fa me4 hyb2a fe ay mo4kela law
            //// 3amlt call ll Sort 2w ll Compare
            //// el Array by3ml el Sort based on ComapreTo
            //// ta3l nesbt dah ahoh ==>

            //int[] numbers = { 12, 22, 7, 9, 5 };
            //Array.Sort(numbers);
            //for (int i = 0;i < numbers.Length;i++)
            //{
            //    Console.WriteLine( numbers[i]);
            //}
            //Console.WriteLine();
            ////or
            //foreach (int i in numbers)
            //{
            //    Console.WriteLine( i );
            //}


            //// ana ba2a 3ayez 2ratb based on 4wayet mowazfen 3andy el hwa ha3ml Array of Employee
            //// we be2st5dam el object initializer ha Create el Employees

            //Employee[] employees =
            //{
            //    new Employee(){Id = 1 , Name = "Mariam" , Salary = 20000},
            //    new Employee(){Id = 2 , Name = "Ahmed"  , Salary = 50000},
            //    new Employee(){Id = 3 , Name = "Basha"  , Salary = 45000},
            //    new Employee(){Id = 4 , Name = "Farha"  , Salary = 10000}
            //};

            //// 3ayzen b2a ne3mlohm Sort 5las ro7 nady 3al el Method el 2smha ==>[Sort]
            //// mn Class el Array we 2b3tlha el Array bta3 el employees
            //// bs 2wl ma hat3ml kdah ==> Array.Sort(employees);
            //// we te3ml run hydrb error 2w exeption hy2olk lazem el array el hwa employees dah 
            //// el hwa mn type Employee lazem ykon be implement el interface ==>[IComparable]
            //// ma 3l4an a22dr 2ny 2a Sort me7tag el Method betat3 el CompareTo we ana me4 la2eha 3andk 
            //// y Class el Employee
            //// l2noh me4 3arf 2enta 3ayez te Sort blenesba le2eh 2w based on eh hal el salary wla id wla 
            //// name wla 2eh belzabt 
            //// fa 3l4an dah y4ta8l sa7 lazem gwa class el Employee 2ro7 23ml implement ll interface
            //// [IComparable] we sa3tha hast5dm el signutare bet3at method el ==> [CompareTo]
            //// we 2fhmoh sa3tha ana ha comparer we ha sort based on eh belzabt el salary 2w el id 2w el name
            //// bs 5aly balk el interface [IComparable] fe menoh nos5ten 
            //// 1] 2wl nos5a el hya deh ==> IComparable ==> we deh mo3tmeda 3al el object 
            //// we bet3ml m4akel kter besbb el boxing we el unboxing
            //// 2] tany nos5a el hya deh ==> IComparable<T> ==> we deh el nos5a el geniric el han4ta8l beha
            //// l2n mafeha4 7war el boxing we el unboxing we 2shl 

            //Array.Sort(employees);

            //// ba3d ma 3amln implement ll interface [ICmoparable] we zabnt method el [ComapreTo]
            //// 3l4an el Sort te4ta8l sa7 3al Class el Employee we te3rf teratb el Employees 
            //// bs based on el Salary 
            //// fa han3ml loop 3l4an ne4of hate4ta8l sa7 wla l2a 
            //// bs lazem 23ml el 2wl override 3al el method el ==> [ToString]
            //// 3l4an 24of el data el tal3a 

            //for (int i = 0; i<employees.Length;i++)
            //{
            //    Console.WriteLine( employees[i]);
            //}
            //Console.WriteLine();
            ////or 
            //foreach (Employee employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            //Console.WriteLine();

            //// 4a8al tmam lakn dah byratb Ascendding lakn law 3ayez terteboh Descendding
            //// 3andk 7aleh :-
            //// 1]. te3ml ba3d ma 3aml Sort ll Array ro7 23mloh Reverse we ba3den 2tb3oh 3l4an t4ofoh
            //// 2]. tro7 te3dl el Condition el gwa el methdo el CompareTo t5leh y return el 3aks me4 2ktr


            //// 1]. te3ml ba3d ma 3aml Sort ll Array ro7 23mloh Reverse we ba3den 2tb3oh 3l4an t4ofoh

            //Array.Sort(employees);
            //Array.Reverse(employees);

            //for (int i = 0; i < employees.Length; i++)
            //{
            //    Console.WriteLine(employees[i]);
            //}
            //Console.WriteLine();
            ////or 
            //foreach (Employee employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            //Console.WriteLine();

            //// 2]. tro7 te3dl el Condition el gwa el methdo el CompareTo t5leh y return el 3aks me4 2ktr
            //// ba3d ma 3adln henak fe el Condition el gwa method el ComapreTo

            //Array.Sort(employees);


            //for (int i = 0; i < employees.Length; i++)
            //{
            //    Console.WriteLine(employees[i]);
            //}
            //Console.WriteLine();
            ////or 
            //foreach (Employee employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            //Console.WriteLine();

            #endregion

            #region IComparer

            //// tb law 3ayez 2ratb based on el [Name] me4 el [Salary]
            //// hat2oly tab3n haro7 28er b2a el body bta3 method el ComparTo el 3amlnah we nebneh badl ma 
            //// kan 3al el Salary
            //// ykon 3al el Name 
            //// bs dah kdah mote3b kol ma hate7tag teratb based on 7aga 7aga tany hatro7 kol 4waya t8er
            //// be 2edk fe el implementation we te3mloh 7asb 3ayez tertb based on eh dah me4 sa7 
            //// tb el sa7 eh ????
            //// hal2y 3andy [OberLoad tany ll Sort by5od meny 2 Parameters ]
            //// 1st parameter el hwa el array el ha3ml 3aleh el Sort
            //// 2nd parameter dah el Comparer el ha3ml el Sort based on 3aleh ya3ny hakrn belnesba le 2eh 
            //// bs el 2nd paramtere dah el hwa el Comparer dah Object 2w Class bs lazem ykon by implement
            //// el interface el hwa [IComparer]
            //// fa lama teb3tloh el object 2w el class el hy implememnt el interface [IComparer] sa3tha 
            //// hyratb based on 3aleh 
            //// fa badl ma 2b3tloh el CompareTo el hwa el Default behvior beta3y ana habd2 2b3tlk object
            //// men class tany el class dah by implement el interface [IComparer]
            //// fa haro7 2a Create Class 2smoh ==> CustomComparer
            //// dah class 5as be 3amlet el Compare bta3t el Strings we tab3n lazem y implement [IComparer]
            //// law 3ayez teratb based on decimal value hatro7 te3ml class tany
            //// we dah 5as be 3amlet el Compare bta3t el decimal values tab3n lazem y implement [IComparer]
            //// we hakza 
            //// we tab3n hanest5d el nos5a el geniric el hwa [IComparer<T>]
            //// we tab3n han5leh yt3aml ma3 el Employee el 4a8len 3aleh we 3ayzen ne3mloh tarteb
            //// hanegy hena b2a ne3ml instance mn el Class dah we neb3tho ka paramter 

            //Array.Sort(employees , new CustomComparer());


            //for (int i = 0; i < employees.Length; i++)
            //{
            //    Console.WriteLine(employees[i]);
            //}
            //Console.WriteLine();
            ////or 
            //foreach (Employee employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            //Console.WriteLine();


            //// 4a8al tmam lakn dah byratb Ascendding lakn law 3ayez terteboh Descendding
            //// 3andk 7aleh :-
            //// 1]. te3ml ba3d ma 3aml Sort ll Array ro7 23mloh Reverse we ba3den 2tb3oh 3l4an t4ofoh
            //// 2]. tro7 te3dl el Condition el gwa el methdo el Compare t5leh y return el 3aks me4 2ktr


            //// 1]. te3ml ba3d ma 3aml Sort ll Array ro7 23mloh Reverse we ba3den 2tb3oh 3l4an t4ofoh


            //Array.Sort(employees, new CustomComparer());
            //Array.Reverse(employees);


            //for (int i = 0; i < employees.Length; i++)
            //{
            //    Console.WriteLine(employees[i]);
            //}
            //Console.WriteLine();
            ////or 
            //foreach (Employee employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            //Console.WriteLine();

            //// 2]. tro7 te3dl el Condition el gwa el methdo el Compare t5leh y return el 3aks me4 2ktr
            //// ba3d ma 3adln henak fe el Condition el gwa method el Comapre

            //Array.Sort(employees , new CustomComparer());


            //for (int i = 0; i < employees.Length; i++)
            //{
            //    Console.WriteLine(employees[i]);
            //}
            //Console.WriteLine();
            ////or 
            //foreach (Employee employee in employees)
            //{
            //    Console.WriteLine(employee);
            //}
            //Console.WriteLine();

            #endregion

            #endregion



        }
    }
}
