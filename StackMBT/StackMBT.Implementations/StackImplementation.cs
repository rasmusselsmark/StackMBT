using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackMBT.Implementations
{
    public static class StackImplementation
    {
		// Model state variables
		private static Stack<int> stack = new Stack<int>();

		public static void Checker(StackModelState state)
		{
			Assert.AreEqual(state.Stack.Count, stack.Count, "Not same number of elements in stack");

			string expected = ArrayToString(state.Stack.ToArray());
			string actual = ArrayToString(stack.ToArray());

			Assert.AreEqual(expected, actual, "Array elements not equal");
		}

		private static string ArrayToString<T>(T[] array)
		{
			var text = new StringBuilder();
			text.Append("[");

			for (int i = 0; i < array.Length; i++)
			{
				if (i != 0)
					text.Append(",");

				text.Append(array[i].ToString());
			}
			text.Append("]");

			return text.ToString();
		}

		public static void Push(int x)
		{
			stack.Push(x);
		}

		public static void Pop()
		{
			stack.Pop();
		}

		public static void Clear()
		{
			stack.Clear();
		}
	}
}
