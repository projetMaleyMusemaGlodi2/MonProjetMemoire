class CritereSelect{
   static int refCatEngin;
   static String depart="Depart",arrive="Destination",datedep,dateRet;
   static int course;
   static int nbrePassager=1,est_Depart_Ou_Arrive;
   static String _tempo;
   static void swap(){
    _tempo=depart;      
     depart=arrive;
     arrive=_tempo;
     
   }
}