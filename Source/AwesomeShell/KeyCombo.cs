//using System;
//using System.Collections.Generic;
//
//namespace AwesomeShell
//{
//	internal class KeyCombo
//	{
//		private const ConsoleModifiers None = 0;
//
//		private static readonly IList<KeyCombo> all = new List<KeyCombo>();
//
//		internal static readonly KeyCombo a = new KeyCombo('a');
//		internal static readonly KeyCombo b = new KeyCombo('b');
//		internal static readonly KeyCombo c = new KeyCombo('c');
//		internal static readonly KeyCombo d = new KeyCombo('d');
//		internal static readonly KeyCombo e = new KeyCombo('e');
//		internal static readonly KeyCombo f = new KeyCombo('f');
//		internal static readonly KeyCombo g = new KeyCombo('g');
//		internal static readonly KeyCombo h = new KeyCombo('h');
//		internal static readonly KeyCombo i = new KeyCombo('i');
//		internal static readonly KeyCombo j = new KeyCombo('j');
//		internal static readonly KeyCombo k = new KeyCombo('k');
//		internal static readonly KeyCombo l = new KeyCombo('l');
//		internal static readonly KeyCombo m = new KeyCombo('m');
//		internal static readonly KeyCombo n = new KeyCombo('n');
//		internal static readonly KeyCombo o = new KeyCombo('o');
//		internal static readonly KeyCombo p = new KeyCombo('p');
//		internal static readonly KeyCombo q = new KeyCombo('q');
//		internal static readonly KeyCombo r = new KeyCombo('r');
//		internal static readonly KeyCombo s = new KeyCombo('s');
//		internal static readonly KeyCombo t = new KeyCombo('t');
//		internal static readonly KeyCombo u = new KeyCombo('u');
//		internal static readonly KeyCombo v = new KeyCombo('v');
//		internal static readonly KeyCombo w = new KeyCombo('w');
//		internal static readonly KeyCombo x = new KeyCombo('x');
//		internal static readonly KeyCombo y = new KeyCombo('y');
//		internal static readonly KeyCombo z = new KeyCombo('z');
//		internal static readonly KeyCombo A = new KeyCombo('A');
//		internal static readonly KeyCombo B = new KeyCombo('B');
//		internal static readonly KeyCombo C = new KeyCombo('C');
//		internal static readonly KeyCombo D = new KeyCombo('D');
//		internal static readonly KeyCombo E = new KeyCombo('E');
//		internal static readonly KeyCombo F = new KeyCombo('F');
//		internal static readonly KeyCombo G = new KeyCombo('G');
//		internal static readonly KeyCombo H = new KeyCombo('H');
//		internal static readonly KeyCombo I = new KeyCombo('I');
//		internal static readonly KeyCombo J = new KeyCombo('J');
//		internal static readonly KeyCombo K = new KeyCombo('K');
//		internal static readonly KeyCombo L = new KeyCombo('L');
//		internal static readonly KeyCombo M = new KeyCombo('M');
//		internal static readonly KeyCombo N = new KeyCombo('N');
//		internal static readonly KeyCombo O = new KeyCombo('O');
//		internal static readonly KeyCombo P = new KeyCombo('P');
//		internal static readonly KeyCombo Q = new KeyCombo('Q');
//		internal static readonly KeyCombo R = new KeyCombo('R');
//		internal static readonly KeyCombo S = new KeyCombo('S');
//		internal static readonly KeyCombo T = new KeyCombo('T');
//		internal static readonly KeyCombo U = new KeyCombo('U');
//		internal static readonly KeyCombo V = new KeyCombo('V');
//		internal static readonly KeyCombo W = new KeyCombo('W');
//		internal static readonly KeyCombo X = new KeyCombo('X');
//		internal static readonly KeyCombo Y = new KeyCombo('Y');
//		internal static readonly KeyCombo Z = new KeyCombo('Z');
//		internal static readonly KeyCombo Zero = new KeyCombo('0');
//		internal static readonly KeyCombo One = new KeyCombo('1');
//		internal static readonly KeyCombo Two = new KeyCombo('2');
//		internal static readonly KeyCombo Three = new KeyCombo('3');
//		internal static readonly KeyCombo Four = new KeyCombo('4');
//		internal static readonly KeyCombo Five = new KeyCombo('5');
//		internal static readonly KeyCombo Six = new KeyCombo('6');
//		internal static readonly KeyCombo Seven = new KeyCombo('7');
//		internal static readonly KeyCombo Eight = new KeyCombo('8');
//		internal static readonly KeyCombo Nine = new KeyCombo('9');
//		internal static readonly KeyCombo GraveAccent = new KeyCombo('`');
//		internal static readonly KeyCombo Minus = new KeyCombo('-');
//		internal static readonly KeyCombo Equal = new KeyCombo('=');
//		internal static readonly KeyCombo LeftSquareBracket = new KeyCombo('[');
//		internal static readonly KeyCombo RightSquareBracket = new KeyCombo(']');
//		internal static readonly KeyCombo Backslash = new KeyCombo('\\');
//		internal static readonly KeyCombo Semicolon = new KeyCombo(';');
//		internal static readonly KeyCombo SingleQuote = new KeyCombo('\'');
//		internal static readonly KeyCombo Comma = new KeyCombo(',');
//		internal static readonly KeyCombo Period = new KeyCombo('.');
//		internal static readonly KeyCombo ForwardSlash = new KeyCombo('/');
//		internal static readonly KeyCombo Tilde = new KeyCombo('~');
//		internal static readonly KeyCombo ExclamationPoint = new KeyCombo('!');
//		internal static readonly KeyCombo At = new KeyCombo('@');
//		internal static readonly KeyCombo Pound = new KeyCombo('#');
//		internal static readonly KeyCombo DollarSign = new KeyCombo('$');
//		internal static readonly KeyCombo Percent = new KeyCombo('%');
//		internal static readonly KeyCombo Carat = new KeyCombo('^');
//		internal static readonly KeyCombo Ampersand = new KeyCombo('&');
//		internal static readonly KeyCombo Asterisk = new KeyCombo('*');
//		internal static readonly KeyCombo LeftParenthesis = new KeyCombo('(');
//		internal static readonly KeyCombo RightParenthesis = new KeyCombo(')');
//		internal static readonly KeyCombo Underscore = new KeyCombo('_');
//		internal static readonly KeyCombo Plus = new KeyCombo('+');
//		internal static readonly KeyCombo LeftCurlyBracket = new KeyCombo('{');
//		internal static readonly KeyCombo RightCurlyBracket = new KeyCombo('}');
//		internal static readonly KeyCombo Pipe = new KeyCombo('|');
//		internal static readonly KeyCombo Colon = new KeyCombo(':');
//		internal static readonly KeyCombo DoubleQuote = new KeyCombo('"');
//		internal static readonly KeyCombo LessThan = new KeyCombo('<');
//		internal static readonly KeyCombo GreaterThan = new KeyCombo('>');
//		internal static readonly KeyCombo QuestionMark = new KeyCombo('?');
//		internal static readonly KeyCombo Space = new KeyCombo(ConsoleKey.Spacebar, None, ' ');
//		internal static readonly KeyCombo CtrlSpace = new KeyCombo(ConsoleKey.Spacebar, ConsoleModifiers.Control);
//		internal static readonly KeyCombo CtrlC = new KeyCombo(ConsoleKey.C, ConsoleModifiers.Control);
//		internal static readonly KeyCombo Left = new KeyCombo(ConsoleKey.LeftArrow, None);
//		internal static readonly KeyCombo CtrlLeft = new KeyCombo(ConsoleKey.LeftArrow, ConsoleModifiers.Control);
//		internal static readonly KeyCombo ShiftLeft = new KeyCombo(ConsoleKey.LeftArrow, ConsoleModifiers.Shift);
//		internal static readonly KeyCombo CtrlShiftLeft = new KeyCombo(ConsoleKey.LeftArrow, ConsoleModifiers.Control | ConsoleModifiers.Shift);
//		internal static readonly KeyCombo Right = new KeyCombo(ConsoleKey.RightArrow, None);
//		internal static readonly KeyCombo CtrlRight = new KeyCombo(ConsoleKey.RightArrow, ConsoleModifiers.Control);
//		internal static readonly KeyCombo ShiftRight = new KeyCombo(ConsoleKey.RightArrow, ConsoleModifiers.Shift);
//		internal static readonly KeyCombo CtrlShiftRight = new KeyCombo(ConsoleKey.RightArrow, ConsoleModifiers.Control | ConsoleModifiers.Shift);
//		internal static readonly KeyCombo Up = new KeyCombo(ConsoleKey.UpArrow, None);
//		internal static readonly KeyCombo Down = new KeyCombo(ConsoleKey.DownArrow, None);
//		internal static readonly KeyCombo Backspace = new KeyCombo(ConsoleKey.Backspace, None);
//		internal static readonly KeyCombo Delete = new KeyCombo(ConsoleKey.Delete, None);
//		internal static readonly KeyCombo Tab = new KeyCombo(ConsoleKey.Tab, None);
//		internal static readonly KeyCombo ShiftTab = new KeyCombo(ConsoleKey.Tab, ConsoleModifiers.Shift);
//		internal static readonly KeyCombo Home = new KeyCombo(ConsoleKey.Home, None);
//		internal static readonly KeyCombo End = new KeyCombo(ConsoleKey.End, None);
//		internal static readonly KeyCombo Enter = new KeyCombo(ConsoleKey.Enter, None);
//
//		private readonly Func<ConsoleKeyInfo, bool> equals;
//		private readonly bool isPrintable;
//		private readonly char keyChar;
//
//		internal bool IsPrintable
//		{
//			get { return isPrintable; }
//		}
//
//		internal char KeyChar
//		{
//			get { return keyChar; }
//		}
//
//		private KeyCombo(ConsoleKey key, ConsoleModifiers modifiers)
//		{
//			equals = input => input.Key == key && input.Modifiers == modifiers;
//
//			all.Add(this);
//		}
//
//		private KeyCombo(ConsoleKey key, ConsoleModifiers modifiers, char keyChar) : this(key, modifiers)
//		{
//			isPrintable = true;
//			this.keyChar = keyChar;
//		}
//
//		private KeyCombo(char keyChar)
//		{
//			equals = input => input.KeyChar == keyChar && (input.Modifiers == None || input.Modifiers == ConsoleModifiers.Shift);
//
//			isPrintable = true;
//			this.keyChar = keyChar;
//
//			all.Add(this);
//		}
//
//		internal static IEnumerable<KeyCombo> GetAll()
//		{
//			return all;
//		}
//
//		internal bool Equals(ConsoleKeyInfo input)
//		{
//			return equals(input);
//		}
//	}
//}