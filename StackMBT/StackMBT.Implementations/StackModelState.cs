using System;
using System.Text;
using Microsoft.Modeling;

namespace StackMBT.Implementations
{
	public struct StackModelState
	{
		public Sequence<int> Stack;

		public override string ToString()
		{
			var text = new StringBuilder();

			text.Append("[");
			for (int i = 0; i < Stack.Count; i++)
			{
				if (i != 0)
					text.Append(",");

				text.Append(Stack[i]);
			}
			text.Append("]");

			return text.ToString();
		}
	}
}
