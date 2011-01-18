using System;

namespace AwesomeShell.InputHandlers
{
	internal class CtrlDeleteHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.Delete && input.Modifiers == ConsoleModifiers.Control)
			{
				commandEditor.EraseOneWordToRight();

				return true;
			}

			return false;
		}
	}
}