using System;

namespace AwesomeShell.InputHandlers
{
	internal class ShiftEndHandler : IInputHandler
	{
		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			if (input.Key == ConsoleKey.End && input.Modifiers == ConsoleModifiers.Shift)
			{
				commandEditor.SelectCurrentAndAllToRight();

				return true;
			}

			return false;
		}
	}
}