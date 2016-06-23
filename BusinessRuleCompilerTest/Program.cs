using System;
using System.Linq.Expressions;

namespace BusinessRuleCompilerTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			/*String infix = "( x = 003049 | x = 003050 | x = 003051 | x = 003052 | x = Ext001 | x = 003020 | x = 003023 " +
				"| x = 003024 | ( x = 003231 ) | x = 005973 | x = 003133 | x = 003134 | ( x = 003057 & y = 2144 ) " +
				"| x = 003128 | x = 003176 | x = 003177 | x = 003180 | x = 003181 | x = 003182 | x = 006100 | x = 006830 " +
				"| x = 007223 | x = 007287 | ( x = 003259 & y = 7340 ) | x = 007288 | ( x = 006797 & y = 7336 ) | x = 007928 " +
				"| ( x = 006797 & y = 7340 ) | ( x = 003202 > y = 7370 ) | x = 007310 | x = 007558 | ( x = 007380 & y = 7616 ) " +
				"| ( x = 003251 & y = 7616 ) | ( x = 003253 & y = 7616 ) | ( x = 003254 & y = 7616 ) | x = Bm0001 | x = Bm0002 " +
				"| x = Bm0003 | x = Bm0004 | x = 007304 | ( x = 006262 & y = 7655 ) | ( x = 007698 & ( y = 7656 | y = 7655 | y = 7616 ) ) " +
				"| ( x = 007699 & y = 7656 ) | ( x = 007700 & y = 7656 ) | ( x = 007703 & ( y = 7655 | y = 7656 ) ) )";

			String[] infixArray = infix.Split(' ');

			InfixToPostfix postfix = new InfixToPostfix(infix);
			String[] postfixArray = postfix.InfixToPostfix2(infixArray);
			//postfix.convert();
			Console.Write(String.Join(",",postfixArray));*/


			//Expression<Func<int, bool>> esPar = a => a % 2 == 0;
			 Expression<Func<string,string,bool>> perfil = (x,y) => (x == "003049" || x == "003050" || x == "003051" || x == "003052" || x == "Ext001" || x == "003020" || x == "003023"
	|| x == "003024" || (x == "003231") || x == "005973" || x == "003133" || x == "003134" || (x == "003057" && y == "2144")
	|| x == "003128" || x == "003176" || x == "003177" || x == "003180" || x == "003181" || x == "003182" || x == "006100" || x == "006830"
	|| x == "007223" || x == "007287" || (x == "003259" && y == "7340") || x == "007288" || (x == "006797" && y == "7336") || x == "007928"
	|| (x == "006797" && y == "7340") || (x ==  "003202" &&  y != "7370" ) || x == "007310" || x == "007558" || (x == "007380" && y == "7616")
	|| (x == "003251" && y == "7616") || (x == "003253" && y == "7616") || (x == "003254" && y == "7616") || x == "Bm0001" || x == "Bm0002"
	|| x == "Bm0003" || x == "Bm0004" || x == "007304" || (x == "006262" && y == "7655") || (x == "007698" && (y == "7656" || y == "7655" || y == "7616")) || (x == "007699" && y == "7656") || (x == "007700" && y == "7656") || (x == "007703" && (y == "7655" || y == "7656")));

			Func<string, string, bool> perfilCompilado = perfil.Compile();
			bool perfile = perfilCompilado("003202", "1");
			Console.Write(perfile);

		}
	}
}
