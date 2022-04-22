using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmLibDemo;

public delegate void DemoWatchListAddCallback<T>(DemoWatchList<T> self, T data);

public class DemoWatchList<T> : List<T>
{
    public DemoWatchListAddCallback<T>? OnAdd;

    public DemoWatchList():base() { }

    public DemoWatchList(DemoWatchListAddCallback<T> onAdd) : base()
    {
        OnAdd = onAdd;
    }
    public DemoWatchList(IEnumerable<T> collection) : base(collection) { }
    public DemoWatchList(IEnumerable<T> collection, DemoWatchListAddCallback<T> onAdd) : base(collection)
    {
        OnAdd = onAdd;
    }

    public new void Add(T item)
    {
        base.Add(item);
        OnAdd?.Invoke(this, item);
    }
}
