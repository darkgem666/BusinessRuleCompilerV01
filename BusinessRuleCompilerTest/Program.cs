using System;

namespace BusinessRuleCompilerTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			String infix = "( x =  007698 & ( y =  7656 | y ==  7655 | y =  7616 ))";
			InfixToPostfix postfix = new InfixToPostfix(infix);
			postfix.convert();
			Console.Write(postfix.postfix);

		}
	}
}
