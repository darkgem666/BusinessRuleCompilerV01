using System;

namespace BusinessRuleCompilerTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			String infix = "( x = 01 & ( y = 02 | y = 03 | y = 04 ) )";
			String[] infixArray = infix.Split(' ');

			InfixToPostfix postfix = new InfixToPostfix(infix);
			String[] postfixArray = postfix.InfixToPostfix2(infixArray);
			//postfix.convert();
			Console.Write(String.Join(",",postfixArray));
			Console.Write(postfix.ConvertToPostFix(infix.Replace(" ", string.Empty)));

		}
	}
}
