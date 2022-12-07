namespace dotnet.Day7
{
    interface ISize
    {
        int GetSize();
    }

    internal class Directory : ISize
    {
        public Directory(string name, Directory? parent)
        {
            Name = name;
            Parent = parent;
        }
        public IEnumerable<ISize> Children => _children.ToArray();
        public IEnumerable<Directory> SubDirectories => _children.OfType<Directory>().ToArray();
        public string Name { get; }
        public Directory? Parent { get; }

        private readonly List<ISize> _children = new List<ISize>();
        public int GetSize()
        {
            return _children.Select(c => c.GetSize()).Sum();
        }

        public void Add(ISize child)
        {
            _children.Add(child);
        }

        public void Add(IEnumerable<ISize> children)
        {
            _children.AddRange(children);
        }

        public Directory GetOrCreateChildDirectory(string name)
        {
            var rv = _children.OfType<Directory>().FirstOrDefault(child => child.Name == name);
            if (rv == null)
            {
                rv = new Directory(name, this);
                _children.Add(rv);
            }
            return rv;
        }

        //public int GetTotalSize()
        //{
        //    return GetSize() + (_children.OfType<Directory>().Select(d => d.GetTotalSize()).Sum());
        //}
    }

    internal class File : ISize
    {
        private readonly int _size;
        public File(string name, int size)
        {
            Name = name;
            _size = size;
        }

        public string Name { get; }

        public int GetSize()
        {
            return _size;
        }
    }
}
