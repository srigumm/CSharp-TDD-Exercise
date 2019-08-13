## C# Exercise:

### Problem-I


          Write a command-line program that accepts two integers as arguments on the command line. The program counts backwards by ones from the first number until it reaches zero. While counting down, if the current count is evenly divisible by the second number, then the current count is written to the console window. 

#### Test Cases


          Example of positive use case:
          Invoke program:	dotnet run --project src/src.csproj -- "100" "10"

          Expected output:	25  20  15  10  5


          Include robust error handling for the following negative use cases:
									Sample inputs
          First number < 2						1         	1	
          Second number = 0						25	0
          Second number > first number				5 	25
          First number not evenly divisible by second number		25	7
          Either number is not an integer				25	xyz
          Either number is negative					-25	5
          First number must be < 1000				1010	10

### How to Run:

          git clone <<url>>
          cd AIRWORLDEXERCISE
          dotnet restore
          dotnet build
          dotnet test
          dotnet run --project src/src.csproj -- "100" "10"
