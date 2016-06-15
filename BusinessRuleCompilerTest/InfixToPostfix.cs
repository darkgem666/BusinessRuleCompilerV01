using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace BusinessRuleCompilerTest
{
	public class InfixToPostfix
	{
		private String constant = "";
		public String infix {get; set;}
		public String postfix { get; set;}
		//private ParameterExpression X = Expression.Parameter(typeof(double), "X"); /*Expression.Parameter(typeof(double), "X"); tipo y nombre*/
		private List<char> operatorList = new List<char>(new char[] { '=', '|', '&','(',')' });
		//public Func<int, bool> ConstructFunction(String function) { 

		//}




		public InfixToPostfix(String infix)
		{
			this.infix = infix;
		}

		public void convert()
		{

			Stack<char> operatorStack = new Stack<char>();
			char newSymbol, topsymbol;
			postfix = "";
			for (int infixIndez = 0; infixIndez < infix.Length; infixIndez++)
			{
				newSymbol = infix[infixIndez];
				if (newSymbol == ' ' || newSymbol == '\t' || newSymbol == '\n')
					continue;
				if (!operatorList.Contains(newSymbol))
					postfix += newSymbol;
				if (operatorList.Contains(newSymbol))
				{
					if (operatorStack.Count > 0)
					{
						topsymbol = operatorStack.Peek();
						if (Precedence(topsymbol, newSymbol))
						{
							if (topsymbol != '(')
								postfix += topsymbol;
							operatorStack.Pop();

						}
					}
					if (newSymbol != ')')
					{
						operatorStack.Push(newSymbol);
					}
					else
					{
						char ch;
						do
						{
							ch = operatorStack.Pop();
							if (ch != '(')
							{
								postfix += ch;
							}
						} while (ch!='(');
					}

					while (operatorStack.Count > 0)
					{
						if (operatorStack.Peek() != '(' )
						{
							postfix += operatorStack.Pop();
						}
					}


				}
			}

		}

		private bool Precedence(char symbol1, char symbol2)
		{
			if (symbol1 == '=')
				return false;
			else if (symbol1 == '|' && symbol2 == '&')
				return false;
			else if (symbol1 == ')')
				return false;
			return true;
				
		}
	}
			
}

