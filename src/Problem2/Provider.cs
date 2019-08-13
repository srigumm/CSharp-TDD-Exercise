namespace src.Problem2
{
    using System;
    using System.Collections.Generic;
    /*
        A class, entitled Provider, which contains a collection of zero to four instances of the Resource class. 
        The class should have member functions that allows for addition and removal of Resources.
        No instance of the Resource class that is added to the Provider should be able to have the same value of the enumerated type as another instance currently present in the Provider.
     */
    public class Provider : GenericRepository<Resource>
    {
        public Provider():base()
        {
            
        }

        public IDictionary<eResourceType,Resource> Resources{
            get{
                return this.Items;
            }
        }
    }
}