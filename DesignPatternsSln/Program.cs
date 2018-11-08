using System;
using System.Collections;
namespace IteratorDesign
{
    class IteratorApp
    {
        static void Main()
        {
            ConcreteAggregate objects = new ConcreteAggregate();
            objects[0] = "First Item";
            objects[1] = "Second Item";
            objects[2] = "Third Item";
            objects[3] = "Fourth Item";

            // Create Iterator and provide aggregate
            Iterator iterativeObj = objects.CreateIterator();
            Console.WriteLine("Iterating over collection:");
            object item = iterativeObj.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = iterativeObj.Next();

            }

            // Wait for user
            Console.ReadKey();
        }
    }

    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    class ConcreteAggregate : Aggregate
    {
        private ArrayList _items = new ArrayList();
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }

    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    class ConcreteIterator : Iterator
    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;

        // Constructor
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        // Gets first iteration item
        public override object First()
        {
            return _aggregate[0];
        }

        // Gets next iteration item
        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }
            return ret;
        }

        // Gets current iteration item
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}