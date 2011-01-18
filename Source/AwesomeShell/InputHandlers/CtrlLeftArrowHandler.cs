using System;

namespace AwesomeShell.InputHandlers
{
	internal class CtrlLeftArrowHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.LeftArrow && input.Modifiers == ConsoleModifiers.Control)
			{
				commandEditor.MoveCurrentPositionOneWordLeft();

				return true;
			}

			return false;
		}
	}
}