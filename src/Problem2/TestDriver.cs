namespace src.Problem2
{
    /*
        A method which takes an instance of a Provider, and an instance of a Demands, 
        and returns how many whole multiples of the set of Requirements inside the Demands instance are present in the set of Resources inside the Provider instance.
     */
    public class TestDriver
    {
        public static int GetCount(Provider provider, Demands demands){

            int count =0;
            foreach(var requirement in demands.Requirements.Values){
                
                //find relevant resource first
                var resource = provider.Resources.Keys.Contains(requirement.Type) ? provider.Resources[requirement.Type] : null;
                
                //find how many whole multiples of this requirement exists.
                count += resource != null ? (resource.NumberOfUnits/requirement.NumberOfUnits) : 0;
            }
            return count;
        } 
    }
}