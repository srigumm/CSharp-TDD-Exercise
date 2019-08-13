namespace src.Problem2
{
    using System;
    using System.Collections.Generic;
    /*
        A class, entitled, Demands, which contains a collection of zero to four instances of the Requirements class. 
        The class should have member functions that allow for addition and removal of Requirements. 
        No instance of the Requirements class that is added to the Demands should be able to have the same value of the enumerated type as another instance currently present in the Demands.
     */
    public class Demands :GenericRepository<Requirements>{
        public Demands():base()
        {
        }
        public IDictionary<eResourceType,Requirements> Requirements{
            get{return Items;}
        }
    }

}