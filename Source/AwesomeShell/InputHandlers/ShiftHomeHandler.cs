using System;

namespace AwesomeShell.InputHandlers
{
	internal class ShiftHomeHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.Home && input.Modifiers == ConsoleModifiers.Shift)
			{
				commandEditor.SelectAllToLeft();

				return true;
			}

			return false;
		}
	}
}