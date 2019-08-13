namespace src.Problem2
{ 
    using System;
    using System.Collections.Generic;

    public class GenericRepository<T> : IRepository<T>  where T:GenericEntity
    {
        private IDictionary<eResourceType,T> _items;
        const int MAX_REQUIREMENTS=4;
        public GenericRepository(){
            _items = new Dictionary<eResourceType,T>();
        }
        public void Add(T item){
            //Check count.
            if(this._items.Count == MAX_REQUIREMENTS){
                throw new Exception("Allowed zero to four instances only");
            }

            if(this._items.Keys.Contains(item.Type)){
                //Already exists.
                throw new Exception($"Can add only one instance of a particualr {item.GetType().Name} type");
            }
            //Check if already exists
            this._items.Add(item.Type,item);
        }
        public void Remove(T item){
            //If exists remove
            if(!_items.Keys.Contains(item.Type)){
                throw new Exception($"{item.GetType().Name} doesn't exist");
            }
            _items.Remove(item.Type);
        }

        public IDictionary<eResourceType,T> Items{
            get{
                return this._items;
            }
        }
        
    }
}