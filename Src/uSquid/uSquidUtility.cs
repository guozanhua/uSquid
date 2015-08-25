using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSquid
{
    public static class uSquidUtility
    {
        //Replaces backslashes with forward slashes
        public static string CleanPath(string path)
        {
            return path.Replace('\\', '/');
        }
        
        public static string MakeCodeSafe(string srcName)
        {
            var className = srcName.ToCharArray();
            for (int i = 0; i < className.Length; i++)
            {
                if (i == 0 && Numbers.Contains(className[i]))
                {
                    className[i] = '_';
                }
                else if (!AllowedClassCharacters.Contains(className[i]))
                {
                    className[i] = '_';
                }
            }

            var result = new string(className);

            if (CSharpKeyWords.Contains(result))
                return '@' + result;
            else
                return result;
        }

        static char[] Numbers = "1234567890".ToCharArray();
        static char[] AllowedClassCharacters = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijklmnopqrstuvxyz_".ToCharArray();
        static string[] CSharpKeyWords = new string[]
        {
            "abstract",
            "as",
            "base",
            "bool",
            "break",
            "byte",
            "case",
            "catch",
            "char",
            "checked",
            "class",
            "const",
            "continue",
            "decimal",
            "default",
            "delegate",
            "do",
            "double",
            "else",
            "enum",
            "event",
            "explicit",
            "extern",
            "false",
            "finally",
            "fixed",
            "float",
            "for",
            "foreach",
            "goto",
            "if",
            "implicit",
            "in",
            "int",
            "interface",
            "internal",
            "is",
            "lock",
            "long",
            "namespace",
            "new",
            "null",
            "object",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "readonly",
            "ref",
            "return",
            "sbyte",
            "sealed",
            "short",
            "sizeof",
            "stackalloc",
            "static",
            "string",
            "struct",
            "switch",
            "this",
            "throw",
            "true",
            "try",
            "typeof",
            "uint",
            "ulong",
            "unchecked",
            "unsafe",
            "ushort",
            "using",
            "virtual",
            "void",
            "volatile",
            "while",
        };
    }
}
