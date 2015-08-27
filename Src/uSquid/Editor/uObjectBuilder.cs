using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace uSquid.Editor
{
    public class uObjectBuilder : CSCodeBuilder
    {
        [MenuItem("uSquid/BehindTheCurtain/Regenerate uObject.cs")]
        public static void Generate()
        {
            var messages = GetMessagesFromDocs();

            var uObjectBuilderBuilder = new uObjectBuilder();
            uObjectBuilderBuilder.AppenduObjectClass(messages);

            File.WriteAllText(string.Format("{0}/uSquid/uObject.cs", Application.dataPath), uObjectBuilderBuilder.ToString());

            var uBehaviourBuilder = new uObjectBuilder();
            uBehaviourBuilder.AppenduObjectBehaviour(messages);

            File.WriteAllText(string.Format("{0}/uSquid/uObjectBehaviour.cs", Application.dataPath), uBehaviourBuilder.ToString());
        }

        public void AppenduObjectBehaviour(IEnumerable<UnityMessage> messages)
        {
            AppendLine("using UnityEngine;");
            AppendLine("public class uObjectBehaviour");
            BeginBlock();
            {
                AppendLine("public uObject uObject;");
                foreach (var msg in messages)
                {
                    AppendLine(string.Format("public void {0} ({1})", msg.MessageName, FormatParams(null, msg.Args)));
                    BeginBlock();
                    {
                        AppendLine(string.Format("this.uObject.{0}({1});", msg.FireMethodName, FormatParams(null, msg.Args, pair => pair.Value)));
                    }
                    EndBlock();
                }
            }
            EndBlock();
        }

        public void AppenduObjectClass(IEnumerable<UnityMessage> messages)
        {
            const string RemoveFireWarning = "[SuppressMessage(\"Microsoft.Design\", \"CA1030:UseEventsWhereAppropriate\", Justification = \"Firing events is the appropriate usage of \\\"Fire\\\"\")]";

            AppendLine("using UnityEngine;");
            AppendLine("using System.Diagnostics.CodeAnalysis;");

            AppendLine("public class uObject");
            BeginBlock();
            {
                //Declare events
                foreach(var msg in messages)
                {
                    if (!string.IsNullOrEmpty(msg.CustomDelegateName))
                    {
                        AppendLine(string.Format("public event {0} {1};", msg.CustomDelegateName, msg.EventName));
                    }
                    else
                    {
                        AppendLine(string.Format("public event {0} {1};", UnityMessage.DefaultDelegateName, msg.EventName));
                    }
                }
                AppendLine();

                //Declare delegates
                AppendLine(string.Format("public delegate void {0}({1});", UnityMessage.DefaultDelegateName, FormatParams("uObject uObj", null)));
                foreach (var msg in messages.Where(m => !string.IsNullOrEmpty(m.CustomDelegateName)))
                {
                    AppendLine(string.Format("public delegate void {0}({1});", msg.CustomDelegateName, FormatParams("uObject uObj", msg.Args)));
                }
                AppendLine();

                //Declare Fire{0} and Clear{0} methods
                foreach (var msg in messages)
                {
                    AppendLine(RemoveFireWarning);
                    AppendLine(string.Format("public void {0}({1})", msg.FireMethodName, FormatParams(null, msg.Args)));
                    BeginBlock();
                    {
                        AppendLine(string.Format("var copy = {0};", msg.EventName));
                        AppendLine("if (copy != null)");
                        BeginBlock();
                        {
                            AppendLine(string.Format("copy({0});", FormatParams("this", msg.Args, (pair) => pair.Value)));
                        }
                        EndBlock();
                    }
                    EndBlock();
                    AppendLine(string.Format("public void {0}()", msg.ClearMethodName));
                    BeginBlock();
                    {
                        AppendLine(string.Format("{0} = null;", msg.EventName));
                    }
                    EndBlock();
                }
            }
            EndBlock();
        }

        /// <summary>
        /// Will return comma joined string of prefix and args (if present), args format are "key val" by default
        /// </summary>
        string FormatParams(string prefix, IEnumerable<KeyValuePair<string, string>> args, Func<KeyValuePair<string, string>, string> customExtract = null)
        {
            if (customExtract == null)
                customExtract = (pair) => string.Format("{0} {1}", pair.Key, pair.Value);
            if (args != null && args.Any())
            {
                if(!string.IsNullOrEmpty(prefix))
                {
                    return string.Format("{0}, {1}", prefix, string.Join(", ", args.Select(customExtract).ToArray()));
                }
                else
                {
                    return string.Join(", ", args.Select(customExtract).ToArray());
                }
            }
            else
            {
                return prefix;
            }
        }

        static List<UnityMessage> GetMessagesFromDocs()
        {
            var lines = File.ReadAllLines(string.Format("{0}/uSquid/Editor/Resources/MonoBehaviourMessages.txt", Application.dataPath));
            var messages = new List<UnityMessage>();

            var seperator = new string[] { ", " };
            foreach (var line in lines)
            {
                if (line.Contains("//") 
                    || String.IsNullOrEmpty(line)
                    || uSquidUtility.IsWhiteSpaceOrEmpty(line))
                    continue;
                var msg = new UnityMessage();

                var cells = line.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                msg.MessageName = cells[0];

                string nameWithoutOn;
                if (cells[0].Substring(0, 2) == "On")
                    nameWithoutOn = cells[0].Substring(2, cells[0].Length - 2);
                else
                    nameWithoutOn = cells[0];

                msg.EventName = "u" + nameWithoutOn;
                msg.FireMethodName = "Fire" + nameWithoutOn;
                msg.ClearMethodName = "Clear" + nameWithoutOn;

                var argCells = cells.ToList();
                argCells.RemoveAt(0);

                msg.Args = argCells.Select(a =>
                {
                    var argSplit = a.Split(' ');
                    return new KeyValuePair<string, string>(argSplit[0], argSplit[1]);
                }).ToList();

                if (argCells.Any())
                    msg.CustomDelegateName = nameWithoutOn + "EventArgs";
                else
                    msg.CustomDelegateName = null;

                messages.Add(msg);
            }
            return messages;
        }

        public class UnityMessage
        {
            public const string DefaultDelegateName = "uObjectEventArgs";

            public string EventName;
            public string MessageName;
            public List<KeyValuePair<string, string>> Args;
            public string CustomDelegateName;
            public string FireMethodName;
            public string ClearMethodName;
        }
    }
}
