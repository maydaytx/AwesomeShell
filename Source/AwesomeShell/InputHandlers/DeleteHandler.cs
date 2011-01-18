using System;

namespace AwesomeShell.InputHandlers
{
	internal class DeleteHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.Delete && input.Modifiers == 0)
			{
				commandEditor.EraseCurrentChar();

				return true;
			}

			return false;
		}
	}
}