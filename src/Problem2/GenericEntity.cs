namespace src.Problem2
{
    public class GenericEntity : IEntity
    {
        protected eResourceType _type;
		protected int _numberOfUnits;

		public GenericEntity(eResourceType type, int numberOfUnits){
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