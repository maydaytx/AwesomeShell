using System;

namespace AwesomeShell.InputHandlers
{
	internal class PrintableCharacterHandler : IInputHandler
	{
		//private static readonly char[] punctuation = {'`', '-', '=', '[', ']', '\\', ';', '\'', ',', '.', '/', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '{', '}', '|', ':', '"', '<', '>', '?'};

		bool IInputHandler.Handle(ConsoleKeyInfo input, CommandEditor commandEditor)
		{
			bool shiftOrNothing = input.Modifiers == 0 || input.Modifiers == ConsoleModifiers.Shift;

			bool letterOrNumber = char.IsLetterOrDigit(input.KeyChar);
			bool isPunctuation = char.IsPunctuation(input.KeyChar) || char.IsSymbol(input.KeyChar);
			bool spaceBar = input.Modifiers == 0 && input.Key == ConsoleKey.Spacebar;

			if ((shiftOrNothing && (letterOrNumber || isPunctuation)) || spaceBar)
			{
				commandEditor.WriteChar(input.KeyChar);

				return true;
			}

			return false;
		}
	}
}