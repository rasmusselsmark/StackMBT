using System;
using System.Collections.Generic;
using Microsoft.Modeling;
using StackMBT.Implementations;

namespace StackMBT.Models
{
	public static class StackModel
	{
		// Model state
		public static StackModelState ModelState = new StackModelState() {Stack = new Sequence<int>()};

		#region Domains
		public static IEnumerable<int> PushValue()
		{
			return new int[] { ModelState.Stack.Count };	
		}
		#endregion

		[AcceptingStateCondition]
		static bool IsAcceptingState()
		{
			return (ModelState.Stack.Count == 0);
		}

		/// <summary>
		/// Action for validating state of model at run-time.
		/// See http://msdn.microsoft.com/en-us/library/ee620464.aspx for more info
		/// </summary>
		/// <param name="state">The state.</param>
		[Rule]
		static void Checker(StackModelState state)
		{
			Condition.IsTrue(state.Equals(ModelState));
		}

		#region Actions
		[Rule]
        public static void Push([Domain("PushValue")] int x)
        {
            Condition.IsTrue(ModelState.Stack.Count < 5);
			ModelState.Stack = ModelState.Stack.Insert(0, x);
        }

        [Rule]
        public static void Pop()
        {
			Condition.IsTrue(ModelState.Stack.Count > 0);
			ModelState.Stack = ModelState.Stack.RemoveAt(0);
        }

		[Rule]
		public static void Clear()
		{
			Condition.IsTrue(ModelState.Stack.Count > 0);

			while (ModelState.Stack.Count > 0)
			{
				ModelState.Stack = ModelState.Stack.RemoveAt(0);
			}
		}
		#endregion
	}
}
