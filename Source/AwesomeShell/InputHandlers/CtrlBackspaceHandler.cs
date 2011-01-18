using System;

namespace AwesomeShell.InputHandlers
{
	internal class CtrlBackspaceHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.Backspace && input.Modifiers == ConsoleModifiers.Control)
			{
				commandEditor.EraseOneWordToLeft();

				return true;
			}

			return false;
		}
	}
}