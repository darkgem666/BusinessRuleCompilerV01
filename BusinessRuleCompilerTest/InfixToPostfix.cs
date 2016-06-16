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
		//private List<string> operators = new List<string>(new string[] {"=", "|", "&", "(", ")", });
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




				}
			}

			while (operatorStack.Count > 0)
			{
				if (operatorStack.Peek() != '(' )
				{
					postfix += operatorStack.Pop();
				}
			}

		}

		//Arreglar espacios
		public  string[] InfixToPostfix2(string[] infixArray)
		{
			var stack = new Stack<string>();
			var postfix2 = new string[infixArray.Length];

			int index = 0;
			string st;
			for (int i = 0; i < infixArray.Length; i++)
			{
				if (!("(&|)=>".Contains(infixArray[i])))
				{
					postfix2[index] = infixArray[i];
					index++;
				}
				else
				{
					if (infixArray[i].Equals("("))
					{
						stack.Push("(");
					}
					else if (infixArray[i].Equals(")"))
					{
						st = stack.Pop();
						while (!(st.Equals("(")))
						{
							postfix2[index] = st;
							index++;
							st = stack.Pop();
						}
					}
					else
					{
						while (stack.Count > 0)
						{
							st = stack.Pop(); //cambiarlo a peek
							//if (RegnePrioritet(st) >= RegnePrioritet(infixArray[i]))
							if (Precedence(infixArray[i],st))
							{
								postfix2[index] = st;
								index++;
							}
							else
							{
								stack.Push(st);
								break;
							}
						}
						stack.Push(infixArray[i]);
					}
				}
			}
			while (stack.Count > 0)
			{
				postfix2[index] = stack.Pop();
				index++;
			}

			return postfix2.TakeWhile(item => item != null).ToArray();
		}


		public  string ConvertToPostFix(string inFix)
		{
			StringBuilder postFix = new StringBuilder();
			char arrival;
			Stack<char> oprerator = new Stack<char>();//Creates a new Stack
			foreach (char c in inFix.ToCharArray())//Iterates characters in inFix
			{
				if (Char.IsNumber(c) || !("(&|)=>".Contains(c)))
					postFix.Append(c);
				else if (c == '(')
					oprerator.Push(c);
				else if (c == ')')//Removes all previous elements from Stack and puts them in 
								  //front of PostFix.  
				{
					arrival = oprerator.Pop();
					while (arrival != '(')
					{
						postFix.Append(arrival);
						arrival = oprerator.Pop();
					}
				}
				else
				{
					if (oprerator.Count != 0 && Predecessor(oprerator.Peek(), c))//If find an operator
					{
						arrival = oprerator.Pop();
						while (Predecessor(arrival, c))
						{
							postFix.Append(arrival);

							if (oprerator.Count == 0)
								break;

							arrival = oprerator.Pop();
						}
						oprerator.Push(c);
					}
					else
						oprerator.Push(c);//If Stack is empty or the operator has precedence 
				}
			}
			while (oprerator.Count > 0)
			{
				arrival = oprerator.Pop();
				postFix.Append(arrival);
			}
			return postFix.ToString();
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


	    private bool Precedence(string symbol1, string symbol2)
		{
			if (symbol1 == "=" )//&& (symbol2 != "|" || symbol2 != "&") )
				return false;
			else if (symbol1 == "|" && symbol2 == "&")
				return true;
			else if (symbol1 == ")" || symbol2 == "(" || symbol1 == "(")
				return false;
			return true;

		}


		private static bool Predecessor(char firstOperator, char secondOperator)
		{
			string opString = "(|&=>";

			int firstPoint, secondPoint;

			int[] precedence = { 0, 12, 13, 14,14 };// "(" has less prececence

			firstPoint = opString.IndexOf(firstOperator);
			secondPoint = opString.IndexOf(secondOperator);

			return (precedence[firstPoint] >= precedence[secondPoint]) ? true : false;
		}
	}
			
}

