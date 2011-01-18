using System;

namespace AwesomeShell.InputHandlers
{
	internal class ShiftLeftArrowHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.LeftArrow && input.Modifiers == ConsoleModifiers.Shift)
			{
				commandEditor.SelectPreviousChar();

				return true;
			}

			return false;
		}
	}
}