using System;

namespace AwesomeShell.InputHandlers
{
	internal class BackspaceHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.Backspace && input.Modifiers == 0)
			{
				commandEditor.EraseOneCharToLeft();

				return true;
			}

			return false;
		}
	}
}