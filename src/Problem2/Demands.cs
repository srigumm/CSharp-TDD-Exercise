namespace src.Problem2
{
    using System;
    using System.Collections.Generic;
    /*
        A class, entitled, Demands, which contains a collection of zero to four instances of the Requirements class. 
        The class should have member functions that allow for addition and removal of Requirements. 
        No instance of the Requirements class that is added to the Demands should be able to have the same value of the enumerated type as another instance currently present in the Demands.
     */
    public class Demands{
        
        private IDictionary<eResourceType,Requirements>_requirements;
        const int MAX_REQUIREMENTS=4;
        public Demands(){
            _requirements = new Dictionary<eResourceType,Requirements>();
        }
        public void Add(Requirements requirement){
            //Check count.
            if(this._requirements.Count == MAX_REQUIREMENTS){
                throw new Exception("Allowed zero to four instances only");
            }

            if(this._requirements.Keys.Contains(requirement.Type)){
                //Already exists.
                throw new Exception("Can add only one instance of a particualr requriement type");
            }
            //Check if already exists
            this._requirements.Add(requirement.Type,requirement);
        }
        public void Remove(Requirements requirement){
            //If exists remove
            if(!_requirements.Keys.Contains(requirement.Type)){
                throw new Exception("Requriement doesn't exist");
            }
            _requirements.Remove(requirement.Type);
        }

        public IDictionary<eResourceType,Requirements> Requirements{
            get{
                return this._requirements;
            }
        }
    }

}