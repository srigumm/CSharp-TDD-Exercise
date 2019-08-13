using System;

namespace src
{
    public class Program
    {
        public static void VerifyRule(int number1,int number2,Predicate<Tuple<int,int>> operation,string errorMessage){
            var pair = new Tuple<int,int>(number1,number2);
            if(operation(pair)){
                throw new Exception(errorMessage);
            }
        }        
        public static void Main(string[] args)
        {

            if( args==null || args.Length<2){
                throw new Exception("Should provide 2 arguments");
            }

            Int32 number1 = Int32.MaxValue;
            Int32 number2 = Int32.MaxValue;
            bool isIntegerInput = Int32.TryParse(args[0],out number1)&&Int32.TryParse(args[1],out number2);
            if(!isIntegerInput){
                throw new Exception("Should provide only numbers");
            }
            else{
                //Able to parse as integers
                VerifyRule(number1,number2,(p)=>(p.Item2==0),"Second number cannot be zero");
                VerifyRule(number1,number2,(p)=>(p.Item1<0||p.Item2<0),"Either number is negative");
                VerifyRule(number1,number2,(p)=>(p.Item1<2),"First number cannot be less than 2");
                VerifyRule(number1,number2,(p)=>(p.Item2>p.Item1),"Second number cannot be greater than first number");
                VerifyRule(number1,number2,(p)=>(p.Item1%p.Item2!=0),"First number not evenly divisible by second number");
                VerifyRule(number1,number2,(p)=>(p.Item1>=1000),"First number must be < 1000");

                int i = number1;
                while(i>=number2){
                    Console.Write($"{i} ");
                    i=i-number2;
                }
            }
        }
    }
}
