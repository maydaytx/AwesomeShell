using System;

namespace AwesomeShell.InputHandlers
{
	internal class RightArrowHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.RightArrow && input.Modifiers == 0)
			{
				commandEditor.MoveCurrentPositionRight();

				return true;
			}

			return false;
		}
	}
}