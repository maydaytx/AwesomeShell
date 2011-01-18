using System;

namespace AwesomeShell
{
	internal class CommandEditor
	{
		private static readonly char[] spaceBuffer = new char[1024];

		static CommandEditor()
		{
		    for (int i = 0; i < spaceBuffer.Length; ++i)
		        spaceBuffer[i] = ' ';
		}

		private static void WriteSpaces(int numberOfSpaces)
		{
			Console.ResetColor();

			while (numberOfSpaces > spaceBuffer.Length)
			{
				Console.Write(spaceBuffer, 0, spaceBuffer.Length);
				numberOfSpaces -= spaceBuffer.Length;
			}

			Console.Write(spaceBuffer, 0, numberOfSpaces);
		}

		//private static readonly DirectoryInfo[] pathDirectories =
		//    Environment.CurrentDirectory.ToEnumerable()
		//    .Concat(Environment.GetEnvironmentVariable("PATH").Split(';'))
		//    .Select(path => new DirectoryInfo(path.Trim()))
		//    .Where(directory => directory.Exists)
		//    .ToArray();

		//private IEnumerable<string> executables = GetExecutablesInPath("*.exe").Concat(GetExecutablesInPath("*.bat")).Concat(GetExecutablesInPath("*.com")).Concat(GetExecutablesInPath("*.cmd"));

		//private static IEnumerable<string> GetExecutablesInPath(string searchPattern)
		//{
		//    return from directory in pathDirectories
		//           from file in directory.EnumerateFiles(searchPattern)
		//           select Path.GetFileNameWithoutExtension(file.Name);
		//}

		private CharNode firstNode;
		private CharNode lastNode;
		private CharNode currentNode;
		private int commandLength;
		private int currentPosition;
		private int commandTop;
		private readonly int commandLeft;
		private readonly ConsoleColor selectoinBackgroundColor = Console.ForegroundColor;
		private readonly ConsoleColor selectionForegroundColor = Console.BackgroundColor;
		private readonly bool useCamelHumps = Config.UseCamelHumps;
		//private readonly bool autoComplete = Config.AutoComplete;

		internal CommandEditor()
		{
			Console.ResetColor();

			if (Console.CursorTop > 0 || Console.CursorLeft > 0)
				Console.WriteLine();

			Console.Write(Environment.CurrentDirectory + ">");

			commandTop = Console.CursorTop;
			commandLeft = Console.CursorLeft;
		}

		internal void WriteChar(char keyChar)
		{
			var lengthBeforeWrite = commandLength;

			EraseSelection();

			var newNode = new CharNode(keyChar);

			if (currentNode != null)
			{
				newNode.PreviousNode = currentNode.PreviousNode;
				newNode.NextNode = currentNode;
				currentNode.PreviousNode = newNode;

				if (newNode.PreviousNode == null)
					firstNode = newNode;
				else
					newNode.PreviousNode.NextNode = newNode;

				currentNode = newNode.NextNode;
			}
			else
			{
				if (lastNode == null)
				{
					firstNode = lastNode = newNode;
				}
				else
				{
					lastNode.NextNode = newNode;
					newNode.PreviousNode = lastNode;
					lastNode = newNode;
				}
			}

			SetCursorPosition();

			var nodeToWrite = newNode;

			while (nodeToWrite != null)
			{
				WriteNode(nodeToWrite);
				nodeToWrite = nodeToWrite.NextNode;
			}

			++commandLength;
			++currentPosition;

			if (lengthBeforeWrite > commandLength)
				WriteSpaces(lengthBeforeWrite - commandLength);

			SetCursorPosition();
		}

		internal void MoveCurrentPositionLeft()
		{
			ClearSelection();

			if (currentPosition > 0)
			{
				if (currentNode == null)
					currentNode = lastNode;
				else
					currentNode = currentNode.PreviousNode;

				--currentPosition;

				SetCursorPosition();
			}
		}

		internal void MoveCurrentPositionRight()
		{
			ClearSelection();

			if (currentNode != null)
			{
				currentNode = currentNode.NextNode;

				++currentPosition;

				SetCursorPosition();
			}
		}

		internal void MoveCursorToBeginning()
		{
			ClearSelection();

			currentNode = firstNode;
			currentPosition = 0;

			SetCursorPosition();
		}

		internal void MoveCursorToEnd()
		{
			ClearSelection();

			currentNode = null;
			currentPosition = commandLength;

			SetCursorPosition();
		}

		internal void EraseOneCharToLeft()
		{
			var lengthBeforeErase = commandLength;

			if (!EraseSelection())
			{
				if (currentNode != null && currentNode.PreviousNode != null)
				{
					currentNode.PreviousNode = currentNode.PreviousNode.PreviousNode;

					if (currentNode.PreviousNode == null)
						firstNode = currentNode;
					else
						currentNode.PreviousNode.NextNode = currentNode;
				}
				else if (currentNode == null && lastNode != null)
				{
					lastNode = lastNode.PreviousNode;

					if (lastNode == null)
						firstNode = null;
					else
						lastNode.NextNode = null;
				}
				else
				{
					return;
				}

				--commandLength;
				--currentPosition;
			}

			WriteFromCurrentPositionToTheEnd(lengthBeforeErase - commandLength);
		}

		internal void EraseCurrentChar()
		{
			var lengthBeforeErase = commandLength;

			if (!EraseSelection())
			{
				if (currentNode != null)
				{
					if (currentNode.PreviousNode != null)
						currentNode.PreviousNode.NextNode = currentNode.NextNode;
					else
						firstNode = currentNode.NextNode;

					if (currentNode.NextNode != null)
						currentNode.NextNode.PreviousNode = currentNode.PreviousNode;
					else
						lastNode = currentNode.PreviousNode;

					currentNode = currentNode.NextNode;

					--commandLength;
				}
				else
				{
					return;
				}
			}

			WriteFromCurrentPositionToTheEnd(lengthBeforeErase - commandLength);
		}

		internal void SelectPreviousChar()
		{
			if (currentPosition > 0)
			{
				if (currentNode == null)
					currentNode = lastNode;
				else
					currentNode = currentNode.PreviousNode;

				--currentPosition;

				SetCursorPosition();

				if (currentNode != null)
					currentNode.IsSelected = !currentNode.IsSelected;

				WriteNode(currentNode);

				SetCursorPosition();
			}
		}

		internal void SelectCurrentChar()
		{
			if (currentNode != null)
			{
				currentNode.IsSelected = !currentNode.IsSelected;

				WriteNode(currentNode);

				currentNode = currentNode.NextNode;

				++currentPosition;

				SetCursorPosition();
			}
		}

		internal void SelectAllToLeft()
		{
			if (currentPosition > 0)
			{
				var nodeAfterSelection = currentNode;

				currentNode = firstNode;
				currentPosition = 0;

				SetCursorPosition();

				var node = currentNode;

				while (node != null && node != nodeAfterSelection)
				{
					node.IsSelected = !node.IsSelected;
					WriteNode(node);
					node = node.NextNode;
				}

				SetCursorPosition();
			}
		}

		internal void SelectCurrentAndAllToRight()
		{
			if (currentNode != null)
			{
				currentPosition = commandLength;

				while (currentNode != null)
				{
					currentNode.IsSelected = !currentNode.IsSelected;
					WriteNode(currentNode);
					currentNode = currentNode.NextNode;
				}

				SetCursorPosition();
			}
		}

		internal void MoveCurrentPositionOneWordLeft()
		{
			ClearSelection();

			if (currentPosition > 0)
			{
				if (currentNode == null)
					currentNode = lastNode;
				else
					currentNode = currentNode.PreviousNode;

				--currentPosition;

				var charTester = GetMoveLeftCharTester();

				while (currentNode.PreviousNode != null && charTester(currentNode.PreviousNode.Value))
				{
					currentNode = currentNode.PreviousNode;
					--currentPosition;
				}

				SetCursorPosition();
			}
		}

		internal void MoveCurrentPositionOneWordRight()
		{
			ClearSelection();

			if (currentNode != null)
			{
				currentNode = currentNode.NextNode;

				++currentPosition;

				if (currentNode != null)
				{
					var charTester = GetMoveRightCharTester();

					while (currentNode.NextNode != null && charTester(currentNode.NextNode.Value))
					{
						currentNode = currentNode.NextNode;
						++currentPosition;
					}

					if (currentNode.NextNode == null)
					{
						currentNode = null;
						currentPosition = commandLength;
					}
				}

				SetCursorPosition();
			}
		}

		internal void SelectOneWordLeft()
		{
			if (currentPosition > 0)
			{
				var nodeAfterSelection = currentNode;

				if (currentNode == null)
					currentNode = lastNode;
				else
					currentNode = currentNode.PreviousNode;

				--currentPosition;

				var charTester = GetMoveLeftCharTester();

				while (currentNode.PreviousNode != null && charTester(currentNode.PreviousNode.Value))
				{
					currentNode = currentNode.PreviousNode;
					--currentPosition;
				}

				SetCursorPosition();

				var node = currentNode;
				
				while (node != null && node != nodeAfterSelection)
				{
					node.IsSelected = !node.IsSelected;
					WriteNode(node);
					node = node.NextNode;
				}
				
				SetCursorPosition();
			}
		}

		internal void SelectOneWordRight()
		{
			if (currentNode != null)
			{
				currentNode.IsSelected = !currentNode.IsSelected;
				WriteNode(currentNode);

				currentNode = currentNode.NextNode;
				++currentPosition;

				if (currentNode != null)
				{
					var charTester = GetMoveRightCharTester();

					while (currentNode.NextNode != null && charTester(currentNode.NextNode.Value))
					{
						currentNode.IsSelected = !currentNode.IsSelected;
						WriteNode(currentNode);

						currentNode = currentNode.NextNode;
						++currentPosition;
					}

					if (currentNode.NextNode == null)
					{
						currentNode.IsSelected = !currentNode.IsSelected;
						WriteNode(currentNode);

						currentNode = null;
						currentPosition = commandLength;
					}
				}

				SetCursorPosition();
			}
		}

		internal void EraseOneWordToLeft()
		{
			var lengthBeforeErase = commandLength;

			if (!EraseSelection() && currentPosition > 0)
			{
				var nodeAfterErase = currentNode;

				if (currentNode == null)
					currentNode = lastNode;
				else
					currentNode = currentNode.PreviousNode;

				var length = 1;
				--currentPosition;

				var charTester = GetMoveLeftCharTester();

				while (currentNode.PreviousNode != null && charTester(currentNode.PreviousNode.Value))
				{
					currentNode = currentNode.PreviousNode;
					++length;
					--currentPosition;
				}

				var nodeBeforeErase = currentNode.PreviousNode;

				DoErase(nodeBeforeErase, nodeAfterErase, length);
			}

			WriteFromCurrentPositionToTheEnd(lengthBeforeErase - commandLength);
		}

		internal void EraseOneWordToRight()
		{
			var lengthBeforeErase = commandLength;

			if (!EraseSelection() && currentNode != null)
			{
				var nodeBeforeErase = currentNode.PreviousNode;

				currentNode = currentNode.NextNode;
				var length = 1;

				if (currentNode != null)
				{
					var charTester = GetMoveRightCharTester();

					while (currentNode.NextNode != null && charTester(currentNode.NextNode.Value))
					{
						currentNode = currentNode.NextNode;
						++length;
					}

					if (currentNode.NextNode == null)
					{
						currentNode = null;
						++length;
					}
				}

				DoErase(nodeBeforeErase, currentNode, length);
			}

			WriteFromCurrentPositionToTheEnd(lengthBeforeErase - commandLength);
		}

		private void WriteFromCurrentPositionToTheEnd(int numberOfSpacesAtEnd)
		{
			SetCursorPosition();

			var nodeToWrite = currentNode;

			while (nodeToWrite != null)
			{
				WriteNode(nodeToWrite);
				nodeToWrite = nodeToWrite.NextNode;
			}

			if (numberOfSpacesAtEnd > 0)
				WriteSpaces(numberOfSpacesAtEnd);

			SetCursorPosition();
		}

		private Func<char, bool> GetMoveLeftCharTester()
		{
			Func<char, bool> charTester;
			var previousValue = 'a';

			if (char.IsLetterOrDigit(currentNode.Value))
				if (useCamelHumps)
					if (char.IsUpper(currentNode.Value))
						charTester = value => false;
					else
						charTester = value =>
						{
							bool result = !char.IsUpper(previousValue) && char.IsLetterOrDigit(value);
							previousValue = value;
							return result;
						};
				else
					charTester = value => char.IsLetterOrDigit(value);
			else
				charTester = value => !char.IsLetterOrDigit(value);
			return charTester;
		}

		private Func<char, bool> GetMoveRightCharTester()
		{
			Func<char, bool> charTester;
			char previousValue;

			if (char.IsLetterOrDigit(currentNode.Value))
			{
				if (useCamelHumps)
				{
					previousValue = 'a';

					charTester = value =>
					{
						var result = char.IsLetterOrDigit(value) && !char.IsUpper(previousValue) || !char.IsLetterOrDigit(value) && char.IsLetterOrDigit(previousValue);
						previousValue = value;
						return result;
					};
				}
				else
				{
					previousValue = 'a';

					charTester = value =>
					{
						var result = char.IsLetterOrDigit(value) || char.IsLetterOrDigit(previousValue);
						previousValue = value;
						return result;
					};
				}
			}
			else
			{
				previousValue = ' ';

				charTester = value =>
				{
					var result = !char.IsLetterOrDigit(value) || !char.IsLetterOrDigit(previousValue);
					previousValue = value;
					return result;
				};
			}

			return charTester;
		}

		private void WriteNode(CharNode nodeToWrite)
		{
			var coordinates = GetCoordinates(currentPosition);

			if (coordinates.X == Console.BufferWidth - 1 && coordinates.Y == Console.BufferHeight - 1)
				--commandTop;

			if (nodeToWrite.IsSelected)
			{
				Console.BackgroundColor = selectoinBackgroundColor;
				Console.ForegroundColor = selectionForegroundColor;
			}
			else
			{
				Console.ResetColor();
			}

			Console.Write(nodeToWrite.Value);
		}

		private void SetCursorPosition()
		{
			var coordinates = GetCoordinates(currentPosition);

			Console.SetCursorPosition(coordinates.X, coordinates.Y);
		}

		private void ClearSelection()
		{
			if (currentNode != null && currentNode.IsSelected)
			{
				var node = currentNode;

				while (node != null && node.IsSelected)
				{
					node.IsSelected = false;
					WriteNode(node);
					node = node.NextNode;
				}

				SetCursorPosition();
			}
			else
			{
				var nodeAfterSelection = currentNode;
				CharNode node;
				
				if (currentNode != null && currentNode.PreviousNode != null && currentNode.PreviousNode.IsSelected)
					node = currentNode.PreviousNode;
				else if (currentNode == null && lastNode != null && lastNode.IsSelected)
					node = lastNode;
				else
					return;

				var selectionStartPosition = currentPosition - 1;

				while (node != null && node.IsSelected)
				{
					node.IsSelected = false;
					--selectionStartPosition;
					node = node.PreviousNode;
				}

				if (node == null)
				{
					node = firstNode;
					selectionStartPosition = 0;
				}

				var coordinates = GetCoordinates(selectionStartPosition);

				Console.SetCursorPosition(coordinates.X, coordinates.Y);

				while (node != nodeAfterSelection)
				{
					WriteNode(node);
					node = node.NextNode;
				}
			}
		}

		private bool EraseSelection()
		{
			CharNode nodeBeforeSelection;
			CharNode nodeAfterSelection;
			int selectionLength;

			if (currentNode != null && currentNode.IsSelected)
			{
				nodeBeforeSelection = currentNode.PreviousNode;
				nodeAfterSelection = currentNode.NextNode;
				selectionLength = 1;

				while (nodeAfterSelection != null && nodeAfterSelection.IsSelected)
				{
					++selectionLength;
					nodeAfterSelection = nodeAfterSelection.NextNode;
				}
			}
			else if (currentNode != null && currentNode.PreviousNode != null && currentNode.PreviousNode.IsSelected)
			{
				nodeAfterSelection = currentNode;
				nodeBeforeSelection = currentNode.PreviousNode.PreviousNode;
				selectionLength = 1;

				while (nodeBeforeSelection != null && nodeBeforeSelection.IsSelected)
				{
					++selectionLength;
					nodeBeforeSelection = nodeBeforeSelection.PreviousNode;
				}

				currentPosition -= selectionLength;
			}
			else if (currentNode == null && lastNode != null && lastNode.IsSelected)
			{
				nodeAfterSelection = null;
				nodeBeforeSelection = lastNode.PreviousNode;
				selectionLength = 1;

				while (nodeBeforeSelection != null && nodeBeforeSelection.IsSelected)
				{
					++selectionLength;
					nodeBeforeSelection = nodeBeforeSelection.PreviousNode;
				}

				lastNode = nodeBeforeSelection;
				currentPosition -= selectionLength;
			}
			else
			{
				return false;
			}

			DoErase(nodeBeforeSelection, nodeAfterSelection, selectionLength);

			return true;
		}

		private void DoErase(CharNode nodeBeforeErase, CharNode nodeAfterErase, int length)
		{
			if (nodeBeforeErase != null)
				nodeBeforeErase.NextNode = nodeAfterErase;
			else
				firstNode = nodeAfterErase;

			if (nodeAfterErase != null)
				nodeAfterErase.PreviousNode = nodeBeforeErase;
			else
				lastNode = nodeBeforeErase;

			currentNode = nodeAfterErase;

			commandLength -= length;
		}

		internal string Complete()
		{
			ClearSelection();

			currentNode = null;
			currentPosition = commandLength;

			SetCursorPosition();

			Console.WriteLine();

			return ToString();
		}

		public override string ToString()
		{
			char[] buffer = new char[commandLength];

			var i = 0;
			var node = firstNode;

			while (node != null)
			{
				buffer[i++] = node.Value;
				node = node.NextNode;
			}

			return new string(buffer);
		}

		private Point GetCoordinates(int position)
		{
			int x = commandLeft + position;
			int y = commandTop;

			while (x >= Console.WindowWidth)
			{
				x -= Console.WindowWidth;
				++y;
			}

			return new Point(x, y);
		}

		private class Point
		{
			internal readonly int X;
			internal readonly int Y;

			internal Point(int x, int y)
			{
				X = x;
				Y = y;
			}
		}

		private class CharNode
		{
			internal readonly char Value;
			internal CharNode PreviousNode;
			internal CharNode NextNode;
			internal bool IsSelected;

			internal CharNode(char value)
			{
				Value = value;
			}
		}
	}
}