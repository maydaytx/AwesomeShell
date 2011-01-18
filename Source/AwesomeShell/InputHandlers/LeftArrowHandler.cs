using System;

namespace AwesomeShell.InputHandlers
{
	internal class LeftArrowHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.LeftArrow && input.Modifiers == 0)
			{
				commandEditor.MoveCurrentPositionLeft();

				return true;
			}

			return false;
		}
	}
}