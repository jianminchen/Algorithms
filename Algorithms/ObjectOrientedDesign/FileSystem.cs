using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ObjectOrientedDesign
{
    class FileSystem
    {
        public abstract class FileDirectoryBase
        {
            public string Name { get; private set; }
            public DateTime CreatedTime { get; private set; }
            public DateTime ModifiedTime { get; private set; }
            public Directory Parent { get; private set; }

            public string GetFullPath()
            {
                if (this.Parent == null)
                {
                    return this.Name;
                }

                return this.Parent.GetFullPath() + "\\" + this.Name;
            }

            protected FileDirectoryBase(string name, Directory parent)
            {
                this.Name = name;
                this.CreatedTime = DateTime.Now;
                this.ModifiedTime = DateTime.Now;
                this.Parent = parent;
            }

            public void Delete()
            {
                if (this.Parent != null)
                {
                    this.Parent.DeleteChild(this);
                }
            }
        }

        public class File : FileDirectoryBase
        {
            public string Contents { get; private set; }
            public File(string name, string contents, Directory parent): 
                base(name, parent)
            {
                this.Contents = contents;
            }           
        }

        public class Directory: FileDirectoryBase
        {
            private Dictionary<string, FileDirectoryBase> children;
            public List<FileDirectoryBase> Children
            {
                get
                {
                    return this.children.Values.ToList();
                }
            }

            public Directory(string name, Directory parent) : 
                base(name, parent)
            {
                this.children = new Dictionary<string, FileDirectoryBase>();
            }

            public void AddChild(FileDirectoryBase child)
            {
                this.children.Add(child.Name, child);
            }

            public void DeleteChild(FileDirectoryBase child)
            {
                this.children.Remove(child.Name);
            }
        }

        public static void Main(string[] args)
        {
            Directory root = new Directory("C:", null);
            Directory childFolder = new Directory("users", root);
            root.AddChild(childFolder);
            File firstFile = new File("test.txt", "hello world", childFolder);
            childFolder.AddChild(firstFile);

            root.DeleteChild(childFolder);
            Console.ReadKey();
        }
    }
}
