using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace uSquid.Editor
{
    public class AssetCodeGenerator
    {
        const string AssetsClassName = "MyAssets";
        const string AssetsClassLocalPath = "MyAssets.cs";
        static Dictionary<string, Type> SupportedFileTypes = new Dictionary<string, Type>()
        {
            {".png", typeof(Texture2D)},
            {".gif", typeof(Texture2D)},
            {".bmp", typeof(Texture2D)},
            {".wav", typeof(AudioSource)},
            {".mp3", typeof(AudioSource)},
        };

        [MenuItem("uSquid/Regenerate " + AssetsClassLocalPath)]
        public static void Generate()
        {
            var assetsDirectory = Application.dataPath;

            Debug.Log(assetsDirectory);

            var myStreamingAssets = new AssetCodeGenerator(AssetsClassName, AssetsClassLocalPath);
            myStreamingAssets.Write();
        }

        AssetCodeGenerator(string className, string classLocalPath)
        {
            _className = className;
            _classLocalPath = classLocalPath;
        }

        private DirectoryInfo GetOrCreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return new DirectoryInfo(path);
        }

        public void Write()
        {
            var assetsDir = GetOrCreateDirectory(Application.dataPath);
            var resourcesDir = GetOrCreateDirectory(string.Format("{0}/Resources", Application.dataPath));
            var streamingDir = GetOrCreateDirectory(string.Format("{0}/StreamingAssets", Application.dataPath));
            var childDirectories = new Dictionary<DirectoryInfo, string>()
            {
                {resourcesDir, uSquidUtility.MakeCodeSafe(resourcesDir.Name)},
                {streamingDir, uSquidUtility.MakeCodeSafe(streamingDir.Name).Replace("Assets", "")},
            };

            string codeOutPath = Application.dataPath + "/" + _classLocalPath;
            _fileOut = new StringBuilder();

            //Style
            var styleHeader = File.ReadAllLines(string.Format("{0}/uSquid/Editor/Style/Header.cs.style", Application.dataPath));
            foreach (var line in styleHeader)
            {
                WriteLine(line.Replace("$CREATED_AT", DateTime.Now.ToString()));
            }

            WriteLine("using uSquid.Assets;");
            WriteLine("using UnityEngine;");

            WriteLine(string.Format("public static class {0}", _className));
            BeginBlock();
            {
                WriteLine(string.Format("public static {0}Node Root = new {0}Node();", _className));
                foreach(var child in childDirectories)
                {
                    WriteLine(string.Format("public static {0}Node.{1}Node {1} {2} get {2} return Root.{1}; {3} {3}", _className, child.Value, "{", "}"));
                }

                var childDirectoriesArray = string.Join(",", childDirectories.Values.ToArray());
                WriteLine(string.Format("public static IDirectoryNode[] GetDirectories() {1} return new IDirectoryNode[] {1} {0} {2}; {2}", childDirectoriesArray, '{', '}'));

                WriteDirectoryClassRecursive(assetsDir, _className, childDirectories);
            }
            EndBlock();

            File.WriteAllText(codeOutPath, _fileOut.ToString());
        }

        private void WriteDirectoryClassRecursive(DirectoryInfo directory, string safeName, Dictionary<DirectoryInfo, string> overrideChildren = null)
        {
            var files = directory.GetFiles().Where(f => !ShouldIgnore(f)).GroupBy(f => uSquidUtility.MakeCodeSafe(f.Name.Split('.').First()));
            var childDirectories = directory.GetDirectories().ToDictionary(d => d, d => uSquidUtility.MakeCodeSafe(d.Name));

            if (overrideChildren != null)
                childDirectories = overrideChildren;

            //Debug.LogWarning(string.Format("Writing for {0}, {1} files, {2} children", directory.Name, files.Keys.Count, childDirectories.Keys.Count));

            WriteLine(string.Format("public class {0}Node : IDirectoryNode", safeName));
            BeginBlock();
            {
                // File instances
                foreach (var group in files)
                    WriteLine(string.Format("public {0}Node {0} = new {0}Node();", group.Key));

                // Dir instances
                foreach (var pair in childDirectories)
                    WriteLine(string.Format("public {0}Node {0} = new {0}Node();", pair.Value));

                // File classes
                foreach (var group in files)
                    WriteFileClass(group);

                // Dir classes
                foreach (var pair in childDirectories)
                    WriteDirectoryClassRecursive(pair.Key, pair.Value);

                //Helper functions
                var childDirectoriesArray = string.Join(",", childDirectories.Values.ToArray());
                WriteLine(string.Format("public IDirectoryNode[] GetDirectories() {1} return new IDirectoryNode[] {1} {0} {2}; {2}", childDirectoriesArray, '{', '}'));
            }
            EndBlock();
        }


        void WriteFileClass(IGrouping<string, FileInfo> group)
        {
            WriteLine(string.Format("public class {0}Node : IAssetNode", group.Key));
            BeginBlock();
            {
                foreach (var fileInfo in group)
                {
                    var fileType = fileInfo.Name.Split('.').Last();
                    WriteLine(string.Format("public Asset {0} = new Asset(typeof(Texture2D), \"{1}\", \"{2}\");", fileType, fileInfo.Name, uSquidUtility.CleanPath(fileInfo.FullName)));
                }
            }
            EndBlock();
        }

        bool ShouldIgnore(FileInfo file)
        {
            return file.Name.Contains(".meta") || file.Name.Contains(".cs");
            //return file.Name.Length >= 4 && file.Name.Substring(file.Name.Length - 4, 4) == ".meta";
        }

        private void WriteLine(string line)
        {
            for (int i = 0; i < _tabIndent; i++)
            {
                _fileOut.Append('\t');
            }

            _fileOut.Append(line);

            _fileOut.Append(Environment.NewLine);
        }

        private void BeginBlock()
        {
            WriteLine("{");
            _tabIndent++;
        }

        private void EndBlock()
        {
            _tabIndent--;
            WriteLine("}");
        }

        private int _tabIndent = 0;
        private string _className;
        private StringBuilder _fileOut;
        private string _classLocalPath;
    }

}
