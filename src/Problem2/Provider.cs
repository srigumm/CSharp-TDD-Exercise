namespace src.Problem2
{
    using System;
    using System.Collections.Generic;
    /*
        A class, entitled Provider, which contains a collection of zero to four instances of the Resource class. 
        The class should have member functions that allows for addition and removal of Resources.
        No instance of the Resource class that is added to the Provider should be able to have the same value of the enumerated type as another instance currently present in the Provider.
     */
    public class Provider{
        private IDictionary<eResourceType,Resource>_resources;
        const int MAX_RESOURCE_TYPES=4;

        public Provider(){
            _resources = new Dictionary<eResourceType,Resource>();
        }
        public void Add(Resource resource){
            //Check count.
            if(_resources.Count == MAX_RESOURCE_TYPES){
                throw new Exception("Allowed zero to four instances only");
            }
            if(_resources.Keys.Contains(resource.Type)){
                //Already exists.
                throw new Exception("Can add only one instance of a particualr resource type");
            }

            _resources.Add(resource.Type,resource);
        }
        public void Remove(Resource resource){
            //If exists remove
            if(!_resources.Keys.Contains(resource.Type)){
                throw new Exception("Resource doesn't exist");
            }
            _resources.Remove(resource.Type);
        }

        public IDictionary<eResourceType,Resource> Resources{
            get{
                return this._resources;
            }
        }
    }
}