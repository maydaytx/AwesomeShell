using System;

namespace AwesomeShell.InputHandlers
{
	internal class EndHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.End && input.Modifiers == 0)
			{
				commandEditor.MoveCursorToEnd();

				return true;
			}

			return false;
		}
	}
}