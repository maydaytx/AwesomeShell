using System;

namespace AwesomeShell.InputHandlers
{
	internal class CtrlShiftRightArrowHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			const ConsoleModifiers controlShift = ConsoleModifiers.Control | ConsoleModifiers.Shift;

			if (input.Key == ConsoleKey.RightArrow && input.Modifiers == controlShift)
			{
				commandEditor.SelectOneWordRight();

				return true;
			}

			return false;
		}
	}
}