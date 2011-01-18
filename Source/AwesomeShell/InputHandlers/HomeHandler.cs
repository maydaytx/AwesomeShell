using System;

namespace AwesomeShell.InputHandlers
{
	internal class HomeHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.Home && input.Modifiers == 0)
			{
				commandEditor.MoveCursorToBeginning();

				return true;
			}

			return false;
		}
	}
}