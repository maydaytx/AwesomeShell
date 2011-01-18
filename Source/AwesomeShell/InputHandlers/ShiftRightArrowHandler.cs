using System;

namespace AwesomeShell.InputHandlers
{
	internal class ShiftRightArrowHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.RightArrow && input.Modifiers == ConsoleModifiers.Shift)
			{
				commandEditor.SelectCurrentChar();

				return true;
			}

			return false;
		}
	}
}