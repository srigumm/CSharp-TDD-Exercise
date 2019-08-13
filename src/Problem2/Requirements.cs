namespace src.Problem2
{
    /*
    A class, entitled Requirements, that contains two pieces of data. 
    The first is an instance of the enumerated type above. 
    The second is an integer that represents the required number of units of the enumerated type specified in the first piece of data. 
    The class should have a constructor or member function that accepts the enumerated type and the value of the units variable.
     */
    public class Requirements
    {
		private eResourceType _type;
		private int _numberOfUnits;

		public Requirements(eResourceType type, int numberOfUnits){
            this._type = type;
            this._numberOfUnits = numberOfUnits;
		}

        public eResourceType Type{
            get{
                return this._type;
            }
        }
        public int NumberOfUnits{
            get{
                return this._numberOfUnits;
            }
        }
	}
}