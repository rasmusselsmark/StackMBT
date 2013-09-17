using System;
using Microsoft.Modeling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackMBT.Models;

namespace StackMBT.UnitTests
{
	[TestClass]
	public class StackModelTests
	{
		[TestInitialize]
		public void TestInitialize()
		{
			// As model class is static, we need to reset state before every test
			StackModel.ModelState.Stack = new Sequence<int>();
		}

		[TestMethod]
		public void PushOneElementGivesStackWithExpectedElement()
		{
			StackModel.Push(0);

			Assert.AreEqual(1, StackModel.ModelState.Stack.Count, "Expected 1 element in stack");
			Assert.AreEqual(0, StackModel.ModelState.Stack[0], "Expected 0 as single element in stack");
		}

		[TestMethod]
		public void PushTwoElementsGivesStackWithExpectedElements()
		{
			StackModel.Push(0);
			StackModel.Push(1);

			Assert.AreEqual(2, StackModel.ModelState.Stack.Count, "Expected 1 element in stack");
			Assert.AreEqual(1, StackModel.ModelState.Stack[0], "Expected 1 as first element in stack");
			Assert.AreEqual(0, StackModel.ModelState.Stack[1], "Expected 0 as second element in stack");
		}

		[TestMethod]
		public void PopStackWithOneElementResultsInEmptyStack()
		{
			StackModel.Push(0);
			StackModel.Pop();

			Assert.AreEqual(0, StackModel.ModelState.Stack.Count, "Expected empty stack");
		}

		[TestMethod]
		public void PopPopsFirstElementInStack()
		{
			StackModel.Push(0);
			StackModel.Push(1);
			StackModel.Pop();

			Assert.AreEqual(1, StackModel.ModelState.Stack.Count, "Expected empty stack");
			Assert.AreEqual(0, StackModel.ModelState.Stack[0], "Expected 0 as first element in stack");
		}
	}
}
