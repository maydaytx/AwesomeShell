using System;

namespace AwesomeShell.InputHandlers
{
	internal class CtrlRightArrowHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.RightArrow && input.Modifiers == ConsoleModifiers.Control)
			{
				commandEditor.MoveCurrentPositionOneWordRight();

				return true;
			}

			return false;
		}
	}
}