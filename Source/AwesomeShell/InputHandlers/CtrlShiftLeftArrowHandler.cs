using System;

namespace AwesomeShell.InputHandlers
{
	internal class CtrlShiftLeftArrowHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			const ConsoleModifiers controlShift = ConsoleModifiers.Control | ConsoleModifiers.Shift;

			if (input.Key == ConsoleKey.LeftArrow && input.Modifiers == controlShift)
			{
				commandEditor.SelectOneWordLeft();

				return true;
			}

			return false;
		}
	}
}